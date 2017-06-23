using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flotta.ClientSide.View
{
	public interface IChangePasswordDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();

		string NewPassword { get; }
		string RepeatPassword { get; }
		string OldPassword { get; }

		Func<bool> Validation { set; }
	}

	public partial class ChangePasswordDialog : Form, IChangePasswordDialog
	{
		private Func<bool> _validation;

		public ChangePasswordDialog()
		{
			InitializeComponent();
		}

		public string NewPassword => newPassword.Text;
		public string RepeatPassword => repeatPassword.Text;
		public string OldPassword => oldPassword.Text;

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
