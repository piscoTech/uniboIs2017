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
	public interface IUpdateLinkedTypeDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();
		string NameText { get; set; }
		string TypeName { set; }

		Func<bool> Validation { set; }
	}

	partial class UpdateLinkedTypeDialog : Form, IUpdateLinkedTypeDialog
	{
		private Func<bool> _validation;

		internal UpdateLinkedTypeDialog()
		{
			InitializeComponent();
		}

		public string NameText
		{
			get => name.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No name specified");

				name.Text = value;
			}
		}

		public string TypeName
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No type name specified");

				this.Text = "Modifica – Tipo " + value + " – Flotta";
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
