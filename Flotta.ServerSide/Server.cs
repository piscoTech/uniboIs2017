using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;
using Flotta.ServerSide.Interface;

namespace Flotta.ServerSide
{

	public delegate void ObjectChangedHandler(IDBObject obj);

	public interface IServer
	{
		void ClientDisconnected();
		void ClientConnected();
		event ObjectChangedHandler ObjectChanged;
		event ObjectChangedHandler ObjectRemoved;

		IEnumerable<IMezzo> Mezzi { get; }
		IEnumerable<ITesseraType> TesseraTypes { get; }

		IEnumerable<string> UpdateMezzo(IMezzo mezzo, string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondità, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi);
		bool DeleteMezzo(IMezzo mezzo);

		IEnumerable<string> UpdateTesseraType(ITesseraType tessera, string name);
		IEnumerable<string> UpdateDispositivoType(IDispositivoType dispositivo, string name);
		IEnumerable<string> UpdatePermessoType(IPermessoType permesso, string name);
		IEnumerable<string> UpdateManutenzioneType(IManutenzioneType manutenzione, string name);
		// UpdateAssicurazioneType
		bool DeleteTesseraType(ITesseraType tessera);
		bool DeleteDispositivoType(IDispositivoType dispositivo);
		bool DeletePermessoType(IPermessoType permesso);
		bool DeleteManutenzioneType(IManutenzioneType manutenzione);
		// DeleteAssicurazioneType
	}

	public class Server : IServer
	{

		private IServerWindow _window;
		private HashSet<IMezzo> _mezzi = new HashSet<IMezzo>();

		private HashSet<ITesseraType> _tesseraTypes = new HashSet<ITesseraType>();
		private HashSet<IDispositivoType> _dispositivoTypes = new HashSet<IDispositivoType>();
		private HashSet<IPermessoType> _permessoTypes = new HashSet<IPermessoType>();
		private HashSet<IManutenzioneType> _manutenzioneTypes = new HashSet<IManutenzioneType>();
		// _assicurazioneType

		internal Server(IServerWindow window)
		{
			_window = window;

			_window.CreateClient += OnCreateClient;
			_window.CanTerminate = true;
		}

		private CreateClientHandler _createClient;
		public CreateClientHandler ClientCreator
		{
			set
			{
				_createClient = value;
			}
		}

		private readonly object _syncLock = new object();
		private int _activeConnections = 0;
		private bool CanTerminate
		{
			get => _activeConnections == 0;
		}

		public event ObjectChangedHandler ObjectChanged;
		public event ObjectChangedHandler ObjectRemoved;

		public void ClientConnected()
		{
			lock (_syncLock)
			{
				_window.UpdateCounter(++_activeConnections);
				_window.CanTerminate = CanTerminate;
			}
		}

		public void ClientDisconnected()
		{
			lock (_syncLock)
			{
				_window.UpdateCounter(--_activeConnections);
				_window.CanTerminate = CanTerminate;
			}
		}

		private void OnCreateClient()
		{
			_createClient();
		}

		public IEnumerable<IMezzo> Mezzi => from m in _mezzi orderby m.Numero select m;
		public IEnumerable<ITesseraType> TesseraTypes => from t in _tesseraTypes orderby t.IsDisabled, t.Name select t;

		public IEnumerable<string> UpdateMezzo(IMezzo mezzo, string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondità, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi)
		{
			if (mezzo == null) throw new ArgumentNullException();
			List<String> errors = new List<string>();

			var numMatch = from m in _mezzi where m.Numero == numero && m != mezzo select m;
			if (numMatch.Count() > 0)
				errors.Add("Il numero è già utilizzato");

			// Check that all Tessera/Dispositivo/PermessoType exists and are saved on server

			if (errors.Count > 0)
				return errors;
			else
			{
				errors = mezzo.Update(modello, targa, numero, numeroTelaio, annoImmatricolazione, portata, altezza, lunghezza, profondità, volumeCarico, tessere, dispositivi, permessi).ToList();

				if (errors.Count == 0)
				{
					if (!_mezzi.Contains(mezzo))
						_mezzi.Add(mezzo);
					ObjectChanged(mezzo);
				}

				return errors;
			}
		}

		public bool DeleteMezzo(IMezzo mezzo)
		{
			if (mezzo == null) throw new ArgumentNullException();

			if (_mezzi.Contains(mezzo) && _mezzi.Remove(mezzo))
			{
				ObjectRemoved(mezzo);
				return true;
			}

			return false;
		}

		private IEnumerable<string> UpdateLinkedObject<T>(HashSet<T> list, T obj, string name) where T : class, ILinkedObject
		{
			if (obj == null) throw new ArgumentNullException();

			List<string> errors = new List<string>();
			name = name?.Trim();
			if (String.IsNullOrEmpty(name))
				// Let the object give the error for missing name
				return obj.Update(null);

			var nameMatch = from l in list where l.Name == name && l != obj select l;
			if (nameMatch.Count() > 0)
			{
				errors.Add("Il nome è già utilizzato");
			}

			if (errors.Count > 0)
				return errors;
			else
			{
				errors = obj.Update(name).ToList();

				if (errors.Count == 0)
				{
					if (!list.Contains(obj))
						list.Add(obj);
					ObjectChanged(obj);
				}

				return errors;
			}
		}

		public IEnumerable<string> UpdateTesseraType(ITesseraType tessera, string name)
		{
			return UpdateLinkedObject(_tesseraTypes, tessera, name);
		}

		public IEnumerable<string> UpdateDispositivoType(IDispositivoType dispositivo, string name)
		{
			return UpdateLinkedObject(_dispositivoTypes, dispositivo, name);
		}

		public IEnumerable<string> UpdatePermessoType(IPermessoType permesso, string name)
		{
			return UpdateLinkedObject(_permessoTypes, permesso, name);
		}

		public IEnumerable<string> UpdateManutenzioneType(IManutenzioneType manutenzione, string name)
		{
			return UpdateLinkedObject(_manutenzioneTypes, manutenzione, name);
		}

		private bool DeleteLinkedObject<T>(HashSet<T> list, T obj, bool disable) where T : class, ILinkedObject
		{
			if (disable)
			{
				obj.Disable();
				ObjectChanged(obj);
				return true;
			}
			else
			{
				if (list.Contains(obj) && list.Remove(obj))
				{
					ObjectRemoved(obj);
					return true;
				}

				return false;
			}
		}

		public bool DeleteTesseraType(ITesseraType tessera)
		{
			if (tessera == null) throw new ArgumentNullException();

			var res = from t in (
						from m in _mezzi
						select (
							from t in m.Tessere
							where t.Type == tessera
							select t.Type
						)
					  )
					  where t.Count() > 0
					  select t;

			return DeleteLinkedObject(_tesseraTypes, tessera, res.Count() > 0);
		}

		public bool DeleteDispositivoType(IDispositivoType dispositivo)
		{
			if (dispositivo == null) throw new ArgumentNullException();

			var res = from t in (
						from m in _mezzi
						select (
							from t in m.Dispositivi
							where t.Type == dispositivo
							select t.Type
						)
					  )
					  where t.Count() > 0
					  select t;

			return DeleteLinkedObject(_dispositivoTypes, dispositivo, res.Count() > 0);
		}

		public bool DeletePermessoType(IPermessoType permesso)
		{
			if (permesso == null) throw new ArgumentNullException();

			var res = from t in (
						from m in _mezzi
						select (
							from t in m.Permessi
							where t.Type == permesso
							select t.Type
						)
					  )
					  where t.Count() > 0
					  select t;

			return DeleteLinkedObject(_permessoTypes, permesso, res.Count() > 0);
		}

		public bool DeleteManutenzioneType(IManutenzioneType manutenzione)
		{
			if (manutenzione == null) throw new ArgumentNullException();

			// Check if no manutenzione uses the type

			return DeleteLinkedObject(_manutenzioneTypes, manutenzione, false);
		}
	}
}
