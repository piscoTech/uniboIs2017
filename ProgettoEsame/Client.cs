using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoEsame
{
	public class Client
	{

		private Server _server;
		private ClientWindow _window;
		public ClientWindow Window
		{
			set
			{
				_window = value;
			}
		}

		public Client(Server server)
		{
			_server = server;
		}

		public void exit()
		{
			_server.ReleaseClient(this);
		}

	}
}
