using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ServerSide.Interface;

namespace Flotta.ServerSide
{
	public static class ServerSideFactory
	{

		public static IServer NewServer(IServerWindow window, CreateClientHandler clientCreator)
		{
			Server server = new Server(window);
			server.ClientCreator = clientCreator;

			return server;
		}

	}
}
