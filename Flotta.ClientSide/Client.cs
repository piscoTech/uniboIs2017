using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;
using Flotta.ServerSide;

namespace Flotta.ClientSide
{
	public class Client : IClient
	{

		private IServer _server;

		public Client(IServer server)
		{
			_server = server;

			_server.ClientConnected();
			_server.OnObjectChange += ObjectChanged;
		}

		private void ObjectChanged(IDBObject obj)
		{
			throw new NotImplementedException("Qualcosa è cambiato nel database");
		}

		public void Exit()
		{
			_server.ClientDisconnected();
		}

	}
}
