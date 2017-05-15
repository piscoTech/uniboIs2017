using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;

namespace Flotta.ServerSide
{
	public class Server : IServerInterface
	{

		private HashSet<IMezzo> _mezzi = new HashSet<IMezzo>();

		public delegate void CreateClient();
		private CreateClient _createClient;
		public CreateClient ClientCreator
		{
			set
			{
				_createClient = value;
			}
		}

		private readonly object _syncLock = new object();
		private int _activeConnections = 0;

		public bool CanTerminate
		{
			get
			{
				lock (_syncLock)
				{
					return _activeConnections == 0;
				}
			}
		}

		public event ConnectionsChanged OnConnectionsChange;
		public event ObjectChanged OnObjectChange;

		public void ClientConnected()
		{
			lock (_syncLock)
			{
				_activeConnections++;
				OnConnectionsChange(_activeConnections);
			}
		}

		public void ClientDisconnected()
		{
			lock (_syncLock)
			{
				_activeConnections--;
				OnConnectionsChange(_activeConnections);
			}
		}

		public void SpawnClient()
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

			var numMatch = from m in _mezzi where m.Numero == numero select m;
			if (numMatch.Count() > 0)
			{
				if (isNew || numMatch.Count() > 1 || numMatch.First() != mezzo)
					errors.Add("Il numero è già utilizzato");
			}

			// Check that all Tessera/Dispositivo/PermessoType exists and are saved on server

			if (errors.Count > 0)
				return errors;
			else
			{
				errors = mezzo.Update(modello, targa, numero, numeroTelaio, annoImmatricolazione, portata, altezza, lunghezza, profondità, volumeCarico, tessere, dispositivi, permessi).ToList();

				if(errors.Count == 0)
				{
					if (!_mezzi.Contains(mezzo))
						_mezzi.Add(mezzo);
					OnObjectChange(mezzo);
				}

				return errors;
			}

		}
	}
}
