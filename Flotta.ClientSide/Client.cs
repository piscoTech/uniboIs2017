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
		private IServer _server;
		private IClientWindow _mainWindow;

		private MezzoTabPresenter _mezzoPresenter;
		private IWindowPresenter _typesPresenter;
		private IWindowPresenter _officinePresenter;

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
			_mainWindow = ClientSideInterfaceFactory.NewClientWindow();
			_mainWindow.Show();
			_mainWindow.WindowClose += Close;
			_mainWindow.MezzoSelected += OnMezzoSelected;
			_mainWindow.CreateNewMezzo += OnCreateNewMezzo;
			_mainWindow.ManageOfficine += OnManageOfficine;

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

		public event Action PresenterClosed;
		public void Close()
		{
			var win = _mainWindow;
			_mainWindow = null;

			win?.Close();
			_typesPresenter?.Close();
			_server.ClientDisconnected();
			PresenterClosed?.Invoke();
		}

	}
}
