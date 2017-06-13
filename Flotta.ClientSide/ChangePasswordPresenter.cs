using System;
using Flotta.Model;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using System.Windows.Forms;
using System.Linq;

namespace Flotta.ClientSide
{
	internal class ChangePasswordPresenter : IDialogPresenter
	{
		private readonly IServer _server;
		private readonly IUser _user;
		private IChangePasswordDialog _view;

		internal ChangePasswordPresenter(IServer server, IUser user)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			if (user == null)
				throw new ArgumentNullException("No user specified");

			_server = server;
			_user = user;
		}

		public void ShowDialog()
		{
			using (_view = ClientSideInterfaceFactory.NewChangePasswordDialog())
			{
				_view.Validation = () =>
				{
					string newPassword = _view.NewPassword;
					string repeatPassword = _view.RepeatPassword;
					if (newPassword != repeatPassword)
					{
						MessageBox.Show("La nuova password non corrisponde", "Errore");
						return false;
					}

					var errors = _server.ChangeUserPassword(_user, newPassword, _view.OldPassword);

					if (errors.Count() > 0)
					{
						MessageBox.Show(String.Join("\r\n", errors), "Errore");
						return false;
					}
					else
						return true;
				};

				_view.ShowDialog();
			}
			Close();
		}

		public event Action PresenterClosed;
		public void Close()
		{
			var win = _view;
			_view = null;

			win?.Close();
			win?.Dispose();
			PresenterClosed?.Invoke();
		}
	}
}
