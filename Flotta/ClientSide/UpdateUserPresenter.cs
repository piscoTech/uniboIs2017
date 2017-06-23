using System;
using System.Windows.Forms;
using Flotta.ClientSide.View;
using Flotta.Model;
using Flotta.ServerSide;
using System.Linq;

namespace Flotta.ClientSide
{
	internal class UpdateUserPresenter : IDialogPresenter
	{
		private readonly IServer _server;
		private IUpdateUserDialog _window;
		private readonly IUser _user;
		private readonly bool _isNew;

		internal UpdateUserPresenter(IServer server, IUser user)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			if (user == null)
				throw new ArgumentNullException("No user specified");

			_server = server;
			_isNew = user == null;
			_user = user ?? ModelFactory.NewUtente();
		}

		public void ShowDialog()
		{
			using (_window = ClientSideInterfaceFactory.NewUpdateUserDialog())
			{
				_server.ObjectRemoved += OnObjectRemoved;

				_window.Validation = () =>
				{
					string password = _window.Password;
					string repeatPassword = _window.RepeatPassword;
					if (password != repeatPassword)
					{
						MessageBox.Show("La password non corrisponde", "Errore");
						return false;
					}

					var errors = _server.UpdateUser(_user, _isNew, _window.Username, password, _window.IsAdmin);

					if (errors.Count() > 0)
					{
						MessageBox.Show(String.Join("\r\n", errors), "Errore");
						return false;
					}
					else
						return true;
				};
				_window.Username = _user.Username ?? "";
				_window.IsNewUser = _isNew;
				_window.Password = _window.RepeatPassword = "";
				_window.IsAdmin = _user.IsAdmin;

				_window.ShowDialog();
			}
			Close();
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is IUser u && u == _user)
			{
				Close();
			}
		}

		public event Action PresenterClosed;
		public void Close()
		{
			_server.ObjectRemoved -= OnObjectRemoved;

			var win = _window;
			_window = null;

			win?.Close();
			win?.Dispose();
			PresenterClosed?.Invoke();
		}
	}
}
