using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoEsame
{
	public class Server
	{

		private List<Client> _clients = new List<Client>();
		private ServerWindow _window;
		public ServerWindow Window
		{
			set
			{
				_window = value;
			}
		}

		public int ClientCount
		{
			get { return _clients.Count; }
		}

		public void SpawnClient()
		{
			Client client = new Client(this);
			_clients.Add(client);

			(new ClientWindow(client)).Show();
		}

		public void ReleaseClient(Client client)
		{
			_clients.Remove(client);
			_window.UpdateCounter();
		}

		public bool CanTerminate
		{
			get { return ClientCount == 0; }
		}

	}
}
