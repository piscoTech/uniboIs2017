using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flotta.ClientSide.Interface
{
	public interface IRenewScadenzaDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();
		DateTime Date { get; set; }
		string ScadName { set; }

		Func<bool> Validation { set; }
	}

	partial class RenewScadenzaDialog : Form, IRenewScadenzaDialog
	{
		private Func<bool> _validation;

		internal RenewScadenzaDialog()
		{
			InitializeComponent();
		}

		public DateTime Date
		{
			get => date.Value;
			set => date.Value = value;
		}

		public string ScadName
		{
			set => this.Text = "Rinnova Scadenza – " + value + " – Flotta";
		}

		public Func<bool> Validation
		{
			set => _validation = value;
		}

		private void OnSave(object sender, EventArgs e)
		{
			this.DialogResult = (_validation?.Invoke() ?? false) ? DialogResult.OK : DialogResult.None;
		}
	}
}
