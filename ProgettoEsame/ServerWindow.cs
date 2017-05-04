using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoEsame
{
	public partial class ServerWindow : Form
	{

		private Server _server;

		public ServerWindow(Server server)
		{
			InitializeComponent();

			_server = server;
			_server.Window = this;
		}

		private void NewClient(object sender, EventArgs e)
		{
			_server.SpawnClient();
			UpdateCounter();
		}

		public void UpdateCounter()
		{
			clientCountLbl.Text = "" + _server.ClientCount;
		}

		private void CloseServer(object sender, FormClosingEventArgs e)
		{
			if (!_server.CanTerminate)
			{
				e.Cancel = true;
				MessageBox.Show("Impossibile uscire con client aperti!");
			}
		}
	}
}
