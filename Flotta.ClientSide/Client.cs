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

		private IServer _server;
		private IClientWindow _mainWindow;
		private IUser _user;

		private MezzoTabPresenter _mezzoPresenter;
		private IWindowPresenter _typesPresenter;
		private IWindowPresenter _officinePresenter;
		private ChangePasswordPresenter _passwordPresenter;
		private UsersManagerPresenter _userPresenter;

		private List<IMezzo> _mezziList = new List<IMezzo>();

		internal Client(IServer server)
		{
			_server = server;

			_server.ClientConnected();
			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;
		}

		public void Show()
		{
			using (IAuthenticateUserDialog authDialog = ClientSideInterfaceFactory.NewAuthenticateUserDialog())
			{
				do
				{
					if (authDialog.ShowDialog() == DialogResult.OK)
					{
						_user = _server.ValidateUser(authDialog.Username, authDialog.Password);
						if (_user == null)
							MessageBox.Show("Nome utente o password errati");

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
					var presenterType = typeof(LinkedTypeManagerPresenter<>).MakeGenericType(type.Type);
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

			_mezzoPresenter = new MezzoTabPresenter(_server, this, _mainWindow.MezzoTabControl);

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
			_officinePresenter = new OfficinaManagerPresenter(_server);
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
			_userPresenter = new UsersManagerPresenter(_server, _user);
			_userPresenter.PresenterClosed += () => _userPresenter = null;
			_userPresenter.Show();
		}

		public event Action PresenterClosed;
		public void Close()
		{
			var win = _mainWindow;
			_mainWindow = null;

			win?.Close();
			_typesPresenter?.Close();
			if (!_closed)
				_server.ClientDisconnected(_user);
			PresenterClosed?.Invoke();

			_closed = true;
		}

	}
}
