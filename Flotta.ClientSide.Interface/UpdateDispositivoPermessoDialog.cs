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
	public interface IUpdateDispositivoPermessoDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();
		string Type { set; }
		string Path { get; set; }

		Func<bool> Validation { set; }
	}

	public partial class UpdateDispositivoPermessoDialog : Form, IUpdateDispositivoPermessoDialog
	{
		private Func<bool> _validation;

		public UpdateDispositivoPermessoDialog()
		{
			InitializeComponent();
		}

		public string Type
		{
			set => this.Text = "Modifica – " + value + " – Flotta";
		}

		public string Path
		{
			get => filePath.Text;
			set => filePath.Text = value;
		}

		public Func<bool> Validation
		{
			set => _validation = value;
		}

		private void OnSave(object sender, EventArgs e)
		{
			this.DialogResult = (_validation?.Invoke() ?? false) ? DialogResult.OK : DialogResult.None;
		}

		private void OnSelectFile(object sender, EventArgs e)
		{
			openFileDialog.FileName = Path;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				filePath.Text = openFileDialog.FileName;
			}
		}
	}
}
