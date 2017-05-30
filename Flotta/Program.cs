using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flotta.ServerSide;
using Flotta.ClientSide;

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

			_server = ServerSideFactory.NewServer(SpawnClient);
			_server.Run();
		}

		private static void SpawnClient()
		{
			IClient client = ClientSideFactory.NewClientPresenter(_server);
			_clients.Add(client);

			client.PresenterClosed += () => _clients.Remove(client);
			client.Show();
		}
	}
}
