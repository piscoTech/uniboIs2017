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
	public partial class ClientWindow : Form
	{
		private Client _client;

		public ClientWindow(Client client)
		{
			InitializeComponent();

			_client = client;
			_client.Window = this;
		}

		private void CloseClient(object sender, FormClosedEventArgs e)
		{
			_client.exit();
		}
	}
}
