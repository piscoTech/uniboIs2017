using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;
using Flotta.ServerSide.Interface;

namespace Flotta.ServerSide
{
	public class Server : IServer
	{

		private IServerWindow _window;
		private HashSet<IMezzo> _mezzi = new HashSet<IMezzo>();

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

		public IEnumerable<IMezzo> Mezzi
		{
			get => from m in _mezzi orderby m.Numero select m;
		}

		public IEnumerable<string> UpdateMezzo(IMezzo mezzo, bool isNew, string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondità, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi)
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
					if (isNew && !_mezzi.Contains(mezzo))
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

	}
}
