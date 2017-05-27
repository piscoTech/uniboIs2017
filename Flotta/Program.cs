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

		private static IServer _server;
		private static List<IClient> _clients = new List<IClient>();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			IServerWindow serverWindow = ServerSideInterfaceFactory.NewServerWindow();
			_server = ServerSideFactory.NewServer(serverWindow, SpawnClient);

			serverWindow.Run();
		}

		private static void SpawnClient()
		{
			IClient client = ClientSideFactory.NewClientPresenter(_server);
			_clients.Add(client);

			client.ExitClient += (c) => _clients.Remove(c);
		}
	}
}
