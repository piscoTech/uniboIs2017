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
	public interface IUpdateLinkedObjectDialog : IDisposable
	{
		void Close();
		DialogResult ShowDialog();
		string NameText { get; set; }
		string TypeName { set; }
	}

	partial class UpdateLinkedObjectDialog : Form, IUpdateLinkedObjectDialog
	{
		internal UpdateLinkedObjectDialog()
		{
			InitializeComponent();
		}

		public string NameText
		{
			get => name.Text;
			set => name.Text = value;
		}

		public string TypeName
		{
			set => this.Text = "Modifica – Tipo " + value + " – Flotta";
		}
	}
}
