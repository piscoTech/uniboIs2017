using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ServerSide
{
	public class Server : IServerInterface
	{

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
				lock(_syncLock)
				{
					return _activeConnections == 0;
				}
			}
		}

		public event ConnectionsChanged OnConnectionsChange;
		public event ObjectChanged OnObjectChange;

		public void ClientConnected()
		{
			lock(_syncLock)
			{
				_activeConnections++;
				OnConnectionsChange(_activeConnections);
			}
		}

		public void ClientDisconnected()
		{
			lock(_syncLock)
			{
				_activeConnections--;
				OnConnectionsChange(_activeConnections);
			}
		}

		public void SpawnClient()
		{
			_createClient();
		}
	}
}
