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
	public delegate void CreateClientHandler();

	public interface IServerWindow
	{
		bool CanTerminate { set; }
		event CreateClientHandler CreateClient;
		void UpdateCounter(int activeConnections);

		void Run();
	}

	public partial class ServerWindow : Form, IServerWindow
	{

		private bool _canTerminate = false;
		public bool CanTerminate
		{
			set => _canTerminate = value;
		}

		internal ServerWindow()
		{
			InitializeComponent();
		}

		public event CreateClientHandler CreateClient;
		private void NewClient(object sender, EventArgs e)
		{
			CreateClient?.Invoke();
		}

		public void UpdateCounter(int activeConnections)
		{
			clientCountLbl.Text = "" + activeConnections;
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			if (!_canTerminate)
			{
				e.Cancel = true;
				MessageBox.Show("Impossibile uscire con client aperti!");
			}
		}

		public void Run()
		{
			Application.Run(this);
		}

	}
}
