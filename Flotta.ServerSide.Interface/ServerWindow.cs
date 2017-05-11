using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flotta.ServerSide;

namespace Flotta.ServerSide.Interface
{
	public partial class ServerWindow : Form
	{

		private IServerInterface _server;

		public ServerWindow(Server server)
		{
			InitializeComponent();

			_server = server;
			_server.OnConnectionsChange += UpdateCounter;
		}

		private void NewClient(object sender, EventArgs e)
		{
			_server.SpawnClient();
		}

		public void UpdateCounter(int activeConnections)
		{
			clientCountLbl.Text = "" + activeConnections;
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			if (!_server.CanTerminate)
			{
				e.Cancel = true;
				MessageBox.Show("Impossibile uscire con client aperti!");
			}
		}

	}
}
