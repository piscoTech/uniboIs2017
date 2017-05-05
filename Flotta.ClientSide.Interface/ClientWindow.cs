using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flotta.ClientSide;

namespace Flotta.ClientSide.Interface
{
	public partial class ClientWindow : Form
	{
		private IClient _client;

		public ClientWindow(IClient client)
		{
			InitializeComponent();

			_client = client;
		}

		private void CloseClient(object sender, FormClosedEventArgs e)
		{
			_client.Exit();
		}
	}
}
