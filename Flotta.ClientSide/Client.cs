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

	class Client : IClient
	{

		private IServer _server;
		private IClientWindow _mainWindow;

		private MezzoTabPresenter _mezzoPresenter;

		private List<DummyMezzo> _mezziList = new List<DummyMezzo>();

		internal Client(IServer server)
		{
			_server = server;

			_server.ClientConnected();
			_server.OnObjectChange += ObjectChanged;

			_mezziList.Add(new DummyMezzo() { Nome = "Prova", Targa = "AB000CB" });
			_mezziList.Add(new DummyMezzo() { Nome = "Esempio", Targa = "AB123CB" });

			_mainWindow = ClientSideInterfaceFactory.NewClientWindow();
			_mainWindow.Show();
			_mainWindow.WindowClose += Exit;
			_mainWindow.MezzoSelected += OnMezzoSelected;

			_mezzoPresenter = new MezzoTabPresenter(this, _mainWindow.MezzoTabControl);

			UpdateMezziList();
		}

		private void UpdateMezziList()
		{
			List<IMezzoListItem> tmp = new List<IMezzoListItem>();

			foreach(DummyMezzo m in _mezziList)
			{
				tmp.Add(ClientSideInterfaceFactory.NewMezzoListItem(m.Nome, m.Targa));
			}

			_mainWindow.MezziList = tmp;
		}

		private void ObjectChanged(IDBObject obj)
		{
			throw new NotImplementedException("Qualcosa è cambiato nel database");
		}

		private void OnMezzoSelected(int index)
		{
			if (index < 0 || index >= _mezziList.Count)
				return;

			_mainWindow.HasMezzo = true;
			_mezzoPresenter.Mezzo = _mezziList[index];
		}

		public event ClientAction ExitClient;
		private void Exit()
		{
			_server.ClientDisconnected();
			ExitClient(this);
		}

	}
}
