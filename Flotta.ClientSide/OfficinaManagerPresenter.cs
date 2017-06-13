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
	class OfficinaManagerPresenter : IWindowPresenter
	{
		private IServer _server;
		private IOfficineManagerWindow _window;
		private UpdateOfficinaPresenter _activePresenter;

		private List<IOfficina> _officinaList;

		internal OfficinaManagerPresenter(IServer server)
		{
			_server = server;
			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;
		}

		public void Show()
		{
			_window = ClientSideInterfaceFactory.NewOfficineManagerWindow();
			_window.FormClosed += (object sender, FormClosedEventArgs e) => this.Close();

			_window.CreateNewOfficina += OnCreateNewOfficina;
			_window.ViewOfficina += OnViewOfficina;
			_window.DeleteOfficina += OnDeleteOfficina;
			UpdateOfficinaList();

			_window.Show();
		}

		private void OnObjectChanged(IDBObject obj)
		{
			if (obj is IOfficina)
			{
				UpdateOfficinaList();
			}
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is IOfficina)
			{
				UpdateOfficinaList();
			}
		}

		private void UpdateOfficinaList()
		{
			if (_window == null)
				return;

			_officinaList = (from o in _server.Officine orderby o.IsDisabled, o.Nome select o).ToList();
			_window.OfficineList = from t in _officinaList select ClientSideInterfaceFactory.NewLinkedTypeListItem(t.Nome, t.IsDisabled);
		}

		private void OnCreateNewOfficina()
		{
			DoEdit(null);
		}

		private void OnViewOfficina(int index)
		{
			DoEdit(_officinaList[index]);
		}

		private void DoEdit(IOfficina off)
		{
			_activePresenter = new UpdateOfficinaPresenter(_server, off);
			_activePresenter.PresenterClosed += () => _activePresenter = null;
			_activePresenter.ShowDialog();
		}

		private void OnDeleteOfficina(int index)
		{
			if (MessageBox.Show("Sei sicuro di voler eliminare " + _officinaList[index].Nome + "?", "Elimina", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (!_server.DeleteOfficina(_officinaList[index]))
					MessageBox.Show("Errore durante l'eliminazione");
			}
		}

		public event Action PresenterClosed;
		public void Close()
		{
			var win = _window;
			_window = null;

			_activePresenter?.Close();
			win?.Close();
			win?.Dispose();
			PresenterClosed?.Invoke();
		}
	}
}
