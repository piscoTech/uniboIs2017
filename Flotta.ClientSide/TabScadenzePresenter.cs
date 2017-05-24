using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ClientSide.Interface;
using Flotta.Model;
using Flotta.ServerSide;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	internal class TabScadenzePresenter : ITabPresenter
	{

		private IServer _server;
		private ITabScadenzeView _view;

		private MezzoTabPresenter _tabs;

		private List<IScadenzaAdapter> _scadenze = new List<IScadenzaAdapter>();
		private List<IScadenzaListItem> _scadenzeItem = new List<IScadenzaListItem>();

		private IScadenzaAdapter _activeScad = null;
		private UpdateScadenzaPresenter _updatePresenter = null;

		internal TabScadenzePresenter(IServer server, MezzoTabPresenter tabs, ITabScadenzeView view)
		{
			_tabs = tabs;

			_server = server;
			_view = view;

			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;

			_view.ScadenzaEdit += OnScadenzaEdit;
			//_view.ScadenzaEdit += ;
		}

		public void Reload()
		{
			if (_tabs.Mezzo == null)
				return;

			_updatePresenter?.Close();
			// Close renew presenter
			_activeScad = null;

			_scadenze.Clear();
			_scadenzeItem.Clear();

			_scadenze.AddRange(from t in _tabs.Mezzo.Tessere orderby t.Type.Name select t);

			UpdateItems(null);
			_view.Scadenze = _scadenzeItem;
		}

		private void UpdateItems(IScadenzaAdapter scadOwner)
		{
			if (scadOwner != null)
			{
				int index = _scadenze.IndexOf(scadOwner);
				if (index < 0)
				{
					Reload();
					return;
				}
				IScadenzaListItem item = _scadenzeItem.ElementAtOrDefault(index);
				if (item != null)
					item.Date = scadOwner.Scadenza?.DateDescription;
				else
					Reload();
			}
			else
			{
				_scadenzeItem.AddRange(from s in _scadenze
									   select ClientSideInterfaceFactory.NewScadenzaListItem(s.ScadenzaName,
																							 s.Scadenza?.DateDescription));
			}
		}

		private void OnObjectChanged(IDBObject obj)
		{
			if (obj is IScadenzaAdapter scadOwner && _scadenze.Contains(scadOwner))
			{
				UpdateItems(scadOwner);
				_view.RefreshScadenze();
			}
			else if (obj is IScadenzaAdapter)
				Reload();
		}
		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is IScadenzaAdapter scadOwner)
			{
				if (scadOwner == _activeScad)
					_updatePresenter.Close();
				Reload();
			}
		}

		public void OnCancelEdit()
		{
		}

		private void OnScadenzaEdit(int index)
		{
			_activeScad = _scadenze[index];

			using (var updateDialog = ClientSideInterfaceFactory.NewUpdateScadenzaDialog())
			{
				_updatePresenter = new UpdateScadenzaPresenter(updateDialog, _activeScad);
				if (updateDialog.ShowDialog() == DialogResult.OK)
				{
					_server.UpdateScadenza(_activeScad, _updatePresenter.Scadenza);
				}
			}
			_updatePresenter = null;
			_activeScad = null;
		}
	}
}
