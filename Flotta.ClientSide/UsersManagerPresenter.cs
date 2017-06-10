using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using Flotta.Model;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	class UsersManagerPresenter : IWindowPresenter
	{
		private IServer _server;
		private IUsersManagerWindow _window;
		private IUser _user;

		private List<IUser> _usersList;
		private UpdateUserPresenter _updatePresenter;

		internal UsersManagerPresenter(IServer server, IUser user)
		{
			_server = server;
			_server.ObjectChanged += OnObjectChangedRemoved;
			_server.ObjectRemoved += OnObjectChangedRemoved;

			_user = user;
		}

		public void Show()
		{
			if (!_user.IsAdmin)
			{
				Close();
				return;
			}

			_window = ClientSideInterfaceFactory.NewUsersManagerWindow();
			_window.FormClosed += (object s, FormClosedEventArgs e) => Close();

			_window.CreateNewUser += OnCreateNewType;
			_window.EditUser += OnEditType;
			_window.DeleteUser += OnDeleteUser;

			UpdateUserList();

			_window.Show();
		}

		private void OnObjectChangedRemoved(IDBObject obj)
		{
			if (obj is IUser)
			{
				UpdateUserList();
			}
		}

		private void UpdateUserList()
		{
			if (_window == null)
				return;

			_usersList = (from u in _server.Users orderby u.IsAdmin, u.Username select u).ToList();
			_window.UserList = from u in _usersList select ClientSideInterfaceFactory.NewUserListItem(u.Username, u.IsAdmin);
		}

		private void OnCreateNewType()
		{
			DoEdit(null);
		}

		private void OnEditType(int index)
		{
			DoEdit(_usersList[index]);
		}

		private void DoEdit(IUser user)
		{
			if (!_user.IsAdmin)
				return;

			_updatePresenter = new UpdateUserPresenter(_server, user);
			_updatePresenter.PresenterClosed += () => _updatePresenter = null;
			_updatePresenter.ShowDialog();
		}

		private void OnDeleteUser(int index)
		{
			if (MessageBox.Show("Sei sicuro di voler eliminare " + _usersList[index].Username + "?", "Elimina", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				var errors = _server.DeleteUser(_usersList[index]);

				if (errors.Count() > 0)
					MessageBox.Show(String.Join("\r\n", errors), "Errore");
			}
		}

		public event Action PresenterClosed;
		public void Close()
		{
			var win = _window;
			_window = null;

			_updatePresenter?.Close();
			win?.Close();
			win?.Dispose();
			PresenterClosed?.Invoke();
		}
	}
}
