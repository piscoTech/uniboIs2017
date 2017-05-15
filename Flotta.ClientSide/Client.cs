using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;

namespace Flotta.ClientSide
{
	public delegate void ClientAction(IClient client);
	public delegate void StatusReportAction(bool status);

	class Client : IClient
	{

		private IServer _server;
		private IClientWindow _mainWindow;

		private MezzoTabPresenter _mezzoPresenter;

		private List<IMezzo> _mezziList = new List<IMezzo>();

		internal Client(IServer server)
		{
			_server = server;

			_server.ClientConnected();
			_server.ObjectChange += ObjectChanged;

			_mainWindow = ClientSideInterfaceFactory.NewClientWindow();
			_mainWindow.Show();
			_mainWindow.WindowClose += Exit;
			_mainWindow.MezzoSelected += OnMezzoSelected;
			_mainWindow.CreateNewMezzo += OnCreateNewMezzo;

			_mezzoPresenter = new MezzoTabPresenter(this, _mainWindow.MezzoTabControl);

			UpdateMezziList();
		}

		private void UpdateMezziList()
		{
			_mezziList = _server.Mezzi.ToList();
			_mainWindow.MezziList = from m in _mezziList select ClientSideInterfaceFactory.NewMezzoListItem(m.Numero, m.Modello, m.Targa);
		}

		private void ObjectChanged(IDBObject obj)
		{
			if(obj is IMezzo)
			{
				UpdateMezziList();
				if(_mezzoPresenter.Mezzo == obj)
				{
					_mezzoPresenter.Mezzo = _mezzoPresenter.Mezzo;
				}
			}
		}

		private void OnMezzoSelected(int index)
		{
			if (index < 0 || index >= _mezziList.Count())
				return;

			_mainWindow.HasMezzo = true;
			_mezzoPresenter.Mezzo = _mezziList[index];
		}

		private NewMezzoPresenter _newMezzo;

		private void OnCreateNewMezzo()
		{
			INewMezzoInterface newMezzoWindow = ClientSideInterfaceFactory.NewNewMezzoInterface();
			_newMezzo = new NewMezzoPresenter(_server, newMezzoWindow);
			_newMezzo.CreationCompleted += OnNewMezzoCreated;

			newMezzoWindow.ShowDialog();
		}

		private void OnNewMezzoCreated(bool created)
		{
			_newMezzo = null;
		}

		public event ClientAction ExitClient;
		private void Exit()
		{
			_server.ClientDisconnected();
			ExitClient(this);
		}

	}
}
