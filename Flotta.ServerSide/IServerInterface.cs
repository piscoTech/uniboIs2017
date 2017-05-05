using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ServerSide
{

	public delegate void ConnectionsChanged(int activeConnections);

	public interface IServerInterface : IServer
	{
		void SpawnClient();
		bool CanTerminate
		{
			get;
		}
		event ConnectionsChanged OnConnectionsChange;
	}
}
