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

            var serverActions = from m in _server.GetType().GetMethods() where m.Name.EndsWith("Type") && m.GetParameters().Count() <= 2 && m.GetParameters().Count() > 0 && typeof(LinkedType).IsAssignableFrom(m.GetParameters()[0].ParameterType) select m;
            var updateActions = from m in serverActions where m.GetParameters().Count() == 2 && m.Name.StartsWith("Update") && m.GetParameters()[1].ParameterType == typeof(string) && m.ReturnType == typeof(IEnumerable<string>) select m;
            var deleteActions = from m in serverActions where m.GetParameters().Count() == 1 && m.Name.StartsWith("Delete") && m.ReturnType == typeof(bool) select m;
            var serverProperties = from p in _server.GetType().GetProperties() where p.Name.EndsWith("Types") && typeof(IEnumerable<LinkedType>).IsAssignableFrom(p.PropertyType) && p.CanRead select p;
            foreach (var type in ModelFactory.GetAllLinkedTypes())
            {
                var update = (from m in updateActions where m.GetParameters()[0].ParameterType == type.Type select m).ElementAtOrDefault(0);
                var delete = (from m in deleteActions where m.GetParameters()[0].ParameterType == type.Type select m).ElementAtOrDefault(0);
                var list = (from p in serverProperties where p.PropertyType == typeof(IEnumerable<>).MakeGenericType(type.Type) select p).ElementAtOrDefault(0);

                if (update == null || delete == null || list == null)
                    Console.WriteLine("Found " + type.Description + "(" + type.Type + ") but necessary methods and properties are not available");
                else
                {
                    try
                    {
                        var listType = typeof(IEnumerable<>).MakeGenericType(type.Type);
                        var returnListType = typeof(Func<>).MakeGenericType(listType);
                        var listFunc = Delegate.CreateDelegate(returnListType, _server, list.GetGetMethod(), true);

                        var updateType = typeof(Func<,,>).MakeGenericType(new Type[] { type.Type, typeof(string), typeof(IEnumerable<string>) });
                        var updateFunc = Delegate.CreateDelegate(updateType, _server, update, true);

                        var deleteType = typeof(Func<,>).MakeGenericType(new Type[] { type.Type, typeof(bool) });
                        var deleteFunc = Delegate.CreateDelegate(deleteType, _server, delete, true);

                        _mainWindow.AddNewLinkedType(type.Description, () =>
                        {
                            _typesPresenter?.Close();
                            ILinkedTypeManagerWindow window = ClientSideInterfaceFactory.NewLinkedTypeManagerWindow();
                            window.FormClosed += (object s, FormClosedEventArgs e) => _typesPresenter = null;

                            var presenterType = typeof(LinkedTypeManagerPresenter<>).MakeGenericType(type.Type);
							var presenter = Activator.CreateInstance(presenterType, BindingFlags.NonPublic | BindingFlags.Instance, null, new Object[] { _server, window, listFunc, updateFunc, deleteFunc, type.Creator, type.Description }, null) as IClosablePresenter;
                            _typesPresenter = presenter;

                            window.Show();
                        });

                        Console.WriteLine("Found " + type.Description + "(" + type.Type + "), created menu strip item to edit list");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Found " + type.Description + "(" + type.Type + ") but cannot bind to method");
                    }
                }
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

        public event ClientAction ExitClient;
        private void Exit()
        {
            _typesPresenter?.Close();
            _server.ClientDisconnected();
            ExitClient(this);
        }

    }
}
