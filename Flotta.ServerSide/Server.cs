﻿using System;
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
		IEnumerable<IDispositivoType> DispositivoTypes { get; }
		IEnumerable<IPermessoType> PermessoTypes { get; }
		IEnumerable<IManutenzioneType> ManutenzioneTypes { get; }
		IEnumerable<IAssicurazioneType> AssicurazioneTypes { get; }

		IEnumerable<string> UpdateMezzo(IMezzo mezzo, string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondita, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi);
		bool DeleteMezzo(IMezzo mezzo);

		IEnumerable<string> UpdateTesseraType(ITesseraType tessera, string name);
		IEnumerable<string> UpdateDispositivoType(IDispositivoType dispositivo, string name);
		IEnumerable<string> UpdatePermessoType(IPermessoType permesso, string name);
		IEnumerable<string> UpdateManutenzioneType(IManutenzioneType manutenzione, string name);
		IEnumerable<string> UpdateAssicurazioneType(IAssicurazioneType assicurazione, string name);
		bool DeleteTesseraType(ITesseraType tessera);
		bool DeleteDispositivoType(IDispositivoType dispositivo);
		bool DeletePermessoType(IPermessoType permesso);
		bool DeleteManutenzioneType(IManutenzioneType manutenzione);
		bool DeleteAssicurazioneType(IAssicurazioneType manutenzione);
	}

	public class Server : IServer
	{

		private IServerWindow _window;
		private HashSet<IMezzo> _mezzi = new HashSet<IMezzo>();

		private HashSet<ITesseraType> _tesseraTypes = new HashSet<ITesseraType>();
		private HashSet<IDispositivoType> _dispositivoTypes = new HashSet<IDispositivoType>();
		private HashSet<IPermessoType> _permessoTypes = new HashSet<IPermessoType>();
		private HashSet<IManutenzioneType> _manutenzioneTypes = new HashSet<IManutenzioneType>();
		private HashSet<IAssicurazioneType> _assicurazioneTypes = new HashSet<IAssicurazioneType>();

		internal Server(IServerWindow window)
		{
			_window = window;

			_window.CreateClient += OnCreateClient;
			_window.CanTerminate = true;

			FillDatabase();
		}

		private void FillDatabase()
		{
			ITesseraType tt = ModelFactory.NewTesseraType();
			tt.Update("Tessera 1");
			_tesseraTypes.Add(tt);
			tt = ModelFactory.NewTesseraType();
			tt.Update("Tessera 2");
			tt.Disable();
			_tesseraTypes.Add(tt);

			IDispositivoType dt = ModelFactory.NewDispositivoType();
			dt.Update("Dispositivo 1");
			dt.Disable();
			_dispositivoTypes.Add(dt);
			dt = ModelFactory.NewDispositivoType();
			dt.Update("Dispositivo 2");
			_dispositivoTypes.Add(dt);

			IPermessoType pt = ModelFactory.NewPermessoType();
			pt.Update("Permesso 1");
			_permessoTypes.Add(pt);
			pt = ModelFactory.NewPermessoType();
			pt.Update("Permesso 2");
			pt.Disable();
			_permessoTypes.Add(pt);

			IMezzo m = ModelFactory.NewMezzo();
			ITessera t = ModelFactory.NewTessera(_tesseraTypes.ElementAt(1));
			t.Update("123", "7654");
			IDispositivo d = ModelFactory.NewDispositivo(_dispositivoTypes.ElementAt(0));
			d.Update(null);
			IPermesso p1, p2;
			p1 = ModelFactory.NewPermesso(_permessoTypes.ElementAt(0));
			p1.Update(null);
			p2 = ModelFactory.NewPermesso(_permessoTypes.ElementAt(1));
			p1.Update(null);
			m.Update("Mezzo 1", "aa000aa", 100, "ABC12345", 2017, 1, 5.4F, 9, 10, 5, new ITessera[] { t }, new IDispositivo[] { d }, new IPermesso[] { p1, p2 });
			_mezzi.Add(m);
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
		public IEnumerable<ITesseraType> TesseraTypes => from t in _tesseraTypes orderby t.Name select t;
		public IEnumerable<IDispositivoType> DispositivoTypes => from t in _dispositivoTypes orderby t.Name select t;
		public IEnumerable<IPermessoType> PermessoTypes => from t in _permessoTypes orderby t.Name select t;
		public IEnumerable<IManutenzioneType> ManutenzioneTypes => from t in _manutenzioneTypes orderby t.Name select t;
		public IEnumerable<IAssicurazioneType> AssicurazioneTypes => from t in _assicurazioneTypes orderby t.Name select t;

		public IEnumerable<string> UpdateMezzo(IMezzo mezzo, string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondita, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi)
		{
			if (mezzo == null) throw new ArgumentNullException();
			List<String> errors = new List<string>();

			var numMatch = from m in _mezzi where m.Numero == numero && m != mezzo select m;
			if (numMatch.Count() > 0)
				errors.Add("Il numero è già utilizzato");

			if (!(new HashSet<ITesseraType>(from t in tessere select t.Type)).IsSubsetOf(from t in _tesseraTypes select t))
				errors.Add("Uno o più tipi di tessere non esistono");
			if (!(new HashSet<IDispositivoType>(from d in dispositivi select d.Type)).IsSubsetOf(from d in _dispositivoTypes select d))
				errors.Add("Uno o più tipi di dispositivi non esistono");
			if (!(new HashSet<IPermessoType>(from p in permessi select p.Type)).IsSubsetOf(from p in _permessoTypes select p))
				errors.Add("Uno o più tipi di permessi non esistono");

			if (errors.Count > 0)
				return errors;
			else
			{
				errors = mezzo.Update(modello, targa, numero, numeroTelaio, annoImmatricolazione, portata, altezza, lunghezza, profondita, volumeCarico, tessere, dispositivi, permessi).ToList();

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

		private IEnumerable<string> UpdateLinkedType<T>(HashSet<T> list, T obj, string name) where T : LinkedType
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
			return UpdateLinkedType(_tesseraTypes, tessera, name);
		}

		public IEnumerable<string> UpdateDispositivoType(IDispositivoType dispositivo, string name)
		{
			return UpdateLinkedType(_dispositivoTypes, dispositivo, name);
		}

		public IEnumerable<string> UpdatePermessoType(IPermessoType permesso, string name)
		{
			return UpdateLinkedType(_permessoTypes, permesso, name);
		}

		public IEnumerable<string> UpdateManutenzioneType(IManutenzioneType manutenzione, string name)
		{
			return UpdateLinkedType(_manutenzioneTypes, manutenzione, name);
		}

		public IEnumerable<string> UpdateAssicurazioneType(IAssicurazioneType assicurazione, string name)
		{
			return UpdateLinkedType(_assicurazioneTypes, assicurazione, name);
		}

		private bool DeleteLinkedType<T>(HashSet<T> list, T obj, bool disable) where T : LinkedType
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

			return DeleteLinkedType(_tesseraTypes, tessera, res.Count() > 0);
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

			return DeleteLinkedType(_dispositivoTypes, dispositivo, res.Count() > 0);
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

			return DeleteLinkedType(_permessoTypes, permesso, res.Count() > 0);
		}

		public bool DeleteManutenzioneType(IManutenzioneType manutenzione)
		{
			if (manutenzione == null) throw new ArgumentNullException();

			// Check if no manutenzione uses the type

			return DeleteLinkedType(_manutenzioneTypes, manutenzione, false);
		}

		public bool DeleteAssicurazioneType(IAssicurazioneType assicurazione)
		{
			if (assicurazione == null) throw new ArgumentNullException();

			// Check if no incidents uses the type

			return DeleteLinkedType(_assicurazioneTypes, assicurazione, false);
		}
	}
}
