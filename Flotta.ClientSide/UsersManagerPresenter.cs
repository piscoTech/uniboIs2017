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

		//private IUpdateLinkedTypeDialog _updateDialog;

		private void OnCreateNewType()
		{
			DoEdit(null);
		}

		private void OnEditType(int index)
		{
			//DoEdit(_typeList[index]);
		}

		private void DoEdit(IUser user)
		{
			//_activeType = activeType;

			//using (_updateDialog = ClientSideInterfaceFactory.NewUpdateLinkedTypeDialog())
			//{
			//	_updateDialog.NameText = activeType?.Name ?? "";
			//	_updateDialog.TypeName = _typeName;
			//	_updateDialog.Validation = () =>
			//	{
			//		T type = activeType ?? ModelFactory.NewLinkedType<T>();
			//		var errors = _server.UpdateLinkedType(type, _updateDialog.NameText);
			//		if (errors.Count() > 0)
			//		{
			//			MessageBox.Show(String.Join("\r\n", errors), "Errore");
			//			return false;
			//		}
			//		else
			//			return true;
			//	};

			//	_updateDialog.ShowDialog();
			//	_updateDialog = null;
			//}
		}

		private void OnDeleteUser(int index)
		{
			if (MessageBox.Show("Sei sicuro di voler eliminare " + _usersList[index].Username + "?", "Elimina", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				//if (!_server.DeleteLinkedType(_typeList[index]))
				//	MessageBox.Show("Errore durante l'eliminazione");
			}
		}

		public event Action PresenterClosed;
		public void Close()
		{
			var win = _window;
			_window = null;

			// _updateDialog?.Close();
			win?.Close();
			win?.Dispose();
			PresenterClosed?.Invoke();
		}
	}
}
