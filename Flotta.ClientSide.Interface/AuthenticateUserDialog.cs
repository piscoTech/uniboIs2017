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

	public delegate void ValidatedHandler();
	public delegate bool SubmitHandler(string username, string password);

	public interface IAuthenticateUserDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();

		string Username { get; }
		string Password { get; }
		void Clear();
	}

	public partial class AuthenticateUserDialog : Form, IAuthenticateUserDialog
	{
		public AuthenticateUserDialog()
		{
			InitializeComponent();
		}

		public string Username => username.Text;
		public string Password => password.Text;

		public void Clear()
		{
			username.Text = password.Text = "";
			this.DialogResult = DialogResult.None;
		}

		//private void submitButton_Click(object sender, EventArgs e)
		//{

		//	if (OnSubmit(Username, Password))
		//		OnValidated();
		//	else
		//	{
		//		MessageBox.Show("Username o Password errati...");
		//	}
		//}
	}
}
