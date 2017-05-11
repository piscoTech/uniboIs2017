using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flotta.ServerSide;
using Flotta.ServerSide.Interface;
using Flotta.ClientSide;
using Flotta.ClientSide.Interface;

namespace Flotta
{
	static class Program
	{

		private static Server _server;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
 
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			_server = new Server();
			_server.ClientCreator = SpawnClient;

			Application.Run(new ServerWindow(_server));
		}

		private static void SpawnClient()
		{
			Client client = new Client(_server);
			(new ClientWindow(client)).Show();
		}
	}
}
