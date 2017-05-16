using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	public delegate void ClientAction(IClient client);
	public delegate void StatusReportAction(bool status);

	public interface IClient
	{
		event ClientAction ExitClient;
	}

	class Client : IClient
	{

		private IServer _server;
		private IClientWindow _mainWindow;

		private MezzoTabPresenter _mezzoPresenter;
		private object _typesPresenter;

		private List<IMezzo> _mezziList = new List<IMezzo>();

		internal Client(IServer server)
		{
			_server = server;

			_server.ClientConnected();
			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;

			_mainWindow = ClientSideInterfaceFactory.NewClientWindow();
			_mainWindow.Show();
			_mainWindow.WindowClose += Exit;
			_mainWindow.MezzoSelected += OnMezzoSelected;
			_mainWindow.CreateNewMezzo += OnCreateNewMezzo;

			_mainWindow.OpenTesseraTypes += () => {
				ILinkedObjectManagerWindow window = ClientSideInterfaceFactory.NewLinkedObjectManagerWindow();
				window.FormClosed += (object sender, FormClosedEventArgs e) => _typesPresenter = null;
		
				_typesPresenter = new LinkedObjectManagerPresenter<ITesseraType>(_server, window, () => _server.TesseraTypes, _server.UpdateTesseraType, _server.DeleteTesseraType, ModelFactory.NewTesseraType);

				window.Show();
			};

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
			if(obj is IMezzo)
			{
				UpdateMezziList();
				if(_mezzoPresenter.Mezzo == obj)
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
			INewMezzoView newMezzoWindow = ClientSideInterfaceFactory.NewNewMezzoInterface();
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
