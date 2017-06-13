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
	public interface IUpdateTesseraDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();
		string Codice { get; set; }
		string Pin { get; set; }

		Func<bool> Validation { set; }
	}

	internal partial class UpdateTesseraDialog : Form, IUpdateTesseraDialog
	{
		private Func<bool> _validation;

		internal UpdateTesseraDialog()
		{
			InitializeComponent();
		}

		public string Codice
		{
			get => codice.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No codice specified");

				codice.Text = value;
			}
		}

		public string Pin
		{
			get => pin.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No pin specified");

				pin.Text = value;
			}
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
