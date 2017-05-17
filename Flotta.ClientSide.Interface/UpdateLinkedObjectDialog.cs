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
	public delegate void SaveType(string name);

	public interface IUpdateLinkedObjectDialog
	{
		void Close();
		DialogResult ShowDialog();
		event FormClosedEventHandler FormClosed;
		event SaveType SaveType;
		string NameText { set; }
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
			set => name.Text = value;
		}

		public event SaveType SaveType;
		private void OnSaveType(object sender, EventArgs e)
		{
			SaveType?.Invoke(name.Text);
		}

		public string TypeName
		{
			set => this.Text = "Cambia – " + value + " – Flotta";
		}
	}
}
