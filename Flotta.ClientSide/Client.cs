using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using System.Windows.Forms;
using System.Reflection;

namespace Flotta.ClientSide
{
	public interface IClient : IWindowPresenter
	{
	}

	internal class Client : IClient
	{
		private bool _closed = false;

		private readonly IServer _server;
		private IClientWindow _mainWindow;
		private IUser _user;

		private MezzoTabPresenter _mezzoPresenter;
		private IWindowPresenter _typesPresenter;
		private IWindowPresenter _officinePresenter;
		private IDialogPresenter _passwordPresenter;
		private IWindowPresenter _usersPresenter;

		private List<IMezzo> _mezziList = new List<IMezzo>();

		internal Client(IServer server)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			_server = server;

			_server.ClientConnected();
		}

		public void Show()
		{
			using (IAuthenticateUserDialog authDialog = ClientSideInterfaceFactory.NewAuthenticateUserDialog())
			{
				do
				{
					if (authDialog.ShowDialog() == DialogResult.OK)
					{
						var res = _server.ValidateUser(authDialog.Username, authDialog.Password);
						_user = res.Item1;
						if (_user == null)
							MessageBox.Show(res.Item2);

						authDialog.Clear();
					}
					else
						break;
				} while (_user == null);
			}
			if (_user == null)
			{
				Close();
				return;
			}

			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;

			_mainWindow = ClientSideInterfaceFactory.NewClientWindow();
			_mainWindow.SetUserMode(_user.Username, _user.IsAdmin);
			_mainWindow.Show();
			_mainWindow.WindowClose += Close;
			_mainWindow.MezzoSelected += OnMezzoSelected;
			_mainWindow.CreateNewMezzo += OnCreateNewMezzo;
			_mainWindow.ManageOfficine += OnManageOfficine;
			_mainWindow.ChangePassword += OnChangePassword;
			_mainWindow.ManageUsers += OnManageUsers;

			foreach (var type in ModelFactory.GetAllLinkedTypes())
			{
				_mainWindow.AddNewLinkedType(type.Description, () =>
				{
					_typesPresenter?.Close();
					var presenterType = typeof(LinkedTypesManagerPresenter<>).MakeGenericType(type.Type);
					_typesPresenter = Activator.CreateInstance(presenterType,
															 BindingFlags.NonPublic | BindingFlags.Instance,
															 null,
															 new Object[] { _server, type.Description },
															 null
															) as IWindowPresenter;
					_typesPresenter.PresenterClosed += () => _typesPresenter = null;
					_typesPresenter.Show();
				});
			}

			_mezzoPresenter = new MezzoTabPresenter(_server, _mainWindow.MezzoTabControl);

			UpdateMezziList();
		}

		private void UpdateMezziList()
		{
			_mezziList = _server.Mezzi.ToList();
			_mainWindow.MezziList = from m in _mezziList select ClientSideInterfaceFactory.NewMezzoListItem(m.Numero, m.Modello, m.Targa);
		}

		private void OnObjectChanged(IDBObject obj)
		{
			if (obj is IMezzo)
			{
				UpdateMezziList();
				if (_mezzoPresenter.Mezzo == obj)
				{
					_mezzoPresenter.ReloadTab();
				}
			}
			else if (obj is IUser u && u == _user)
			{
				_mainWindow?.SetUserMode(_user.Username, _user.IsAdmin);
			}
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is IMezzo)
			{
				UpdateMezziList();
				if (_mezzoPresenter.Mezzo == obj)
				{
					_mainWindow.HasMezzo = false;
					_mezzoPresenter.Mezzo = null;
					_mezzoPresenter.ReloadTab();
				}
			}
		}

		private void OnMezzoSelected(int index)
		{
			_mainWindow.HasMezzo = true;
			_mezzoPresenter.Mezzo = _mezziList[index];
		}

		private NewMezzoPresenter _newMezzo;

		private void OnCreateNewMezzo()
		{
			_newMezzo = new NewMezzoPresenter(_server);
			_newMezzo.PresenterClosed += () => _newMezzo = null;
			_newMezzo.ShowDialog();
		}

		private void OnManageOfficine()
		{
			_officinePresenter = new OfficineManagerPresenter(_server);
			_officinePresenter.PresenterClosed += () => _officinePresenter = null;
			_officinePresenter.Show();
		}


		private void OnChangePassword()
		{
			_passwordPresenter = new ChangePasswordPresenter(_server, _user);
			_passwordPresenter.PresenterClosed += () => _passwordPresenter = null;
			_passwordPresenter.ShowDialog();
		}

		private void OnManageUsers()
		{
			_usersPresenter = new UsersManagerPresenter(_server, _user);
			_usersPresenter.PresenterClosed += () => _usersPresenter = null;
			_usersPresenter.Show();
		}

		public event Action PresenterClosed;
		public void Close()
		{
			_server.ObjectChanged -= OnObjectChanged;
			_server.ObjectRemoved -= OnObjectRemoved;

			var win = _mainWindow;
			_mainWindow = null;
			win?.Close();

			_mezzoPresenter?.Close();
			_typesPresenter?.Close();
			if (!_closed)
				_server.ClientDisconnected(_user);
			PresenterClosed?.Invoke();

			_closed = true;
		}
	}
}
