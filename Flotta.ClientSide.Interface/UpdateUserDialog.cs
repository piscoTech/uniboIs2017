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
	public interface IUpdateUserDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();

		string Username { get; set; }
		string Password { get; set; }
		string RepeatPassword { get; set; }
		bool IsAdmin { get; set; }

		bool IsNewUser { set; }
		Func<bool> Validation { set; }
	}

	internal partial class UpdateUserDialog : Form, IUpdateUserDialog
	{
		private Func<bool> _validation;

		internal UpdateUserDialog()
		{
			InitializeComponent();
		}

		public string Username
		{
			get => username.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No username specified");

				username.Text = value;
			}
		}

		public string Password
		{
			get => password.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No password specified");

				password.Text = value;
			}
		}

		public string RepeatPassword
		{
			get => repeatPassword.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No repeat password specified");

				repeatPassword.Text = value;
			}
		}

		public bool IsAdmin
		{
			get => isAdmin.Checked;
			set => isAdmin.Checked = value;
		}

		public bool IsNewUser
		{
			set
			{
				passwordLbl.Visible = repeatPasswordLbl.Visible = value;
				password.Visible = repeatPassword.Visible = value;
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
