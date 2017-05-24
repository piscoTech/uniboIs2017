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
	public interface IClient
	{
		event Action<IClient> ExitClient;
	}

	class Client : IClient
	{

		private IServer _server;
		private IClientWindow _mainWindow;

		private MezzoTabPresenter _mezzoPresenter;
		private IClosablePresenter _typesPresenter;

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

			foreach (var type in ModelFactory.GetAllLinkedTypes())
			{
				_mainWindow.AddNewLinkedType(type.Description, () =>
				{
					_typesPresenter?.Close();
					ILinkedTypeManagerWindow window = ClientSideInterfaceFactory.NewLinkedTypeManagerWindow();
					window.FormClosed += (object s, FormClosedEventArgs e) => _typesPresenter = null;

					var presenterType = typeof(LinkedTypeManagerPresenter<>).MakeGenericType(type.Type);
					var presenter = Activator.CreateInstance(presenterType,
															 BindingFlags.NonPublic | BindingFlags.Instance,
															 null,
															 new Object[] { _server, window, type.Description },
															 null
															) as IClosablePresenter;
					_typesPresenter = presenter;

					window.Show();
				});

				Console.WriteLine("Found " + type.Description + "(" + type.Type + "), created menu strip item to edit list");
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
			using (INewMezzoDialog newMezzoDialog = ClientSideInterfaceFactory.NewNewMezzoDialog())
			{
				_newMezzo = new NewMezzoPresenter(_server, newMezzoDialog);
				_newMezzo.CreationCompleted += OnNewMezzoCreated;

				newMezzoDialog.ShowDialog();
			}
		}


		private void OnNewMezzoCreated(bool created)
		{
			_newMezzo = null;
		}

		public event Action<IClient> ExitClient;
		private void Exit()
		{
			_typesPresenter?.Close();
			_server.ClientDisconnected();
			ExitClient(this);
		}

	}
}
