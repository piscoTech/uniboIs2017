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

		private List<IScadenzaOwner> _scadenze = new List<IScadenzaOwner>();
		private List<IScadenzaListItem> _scadenzeItem = new List<IScadenzaListItem>();

		private UpdateScadenzaPresenter _updatePresenter = null;
		private RenewScadenzaPresenter _renewPresenter = null;

		internal TabScadenzePresenter(IServer server, MezzoTabPresenter tabs, ITabScadenzeView view)
		{
			_tabs = tabs;

			_server = server;
			_view = view;

			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;

			_view.ScadenzaEdit += OnScadenzaEdit;
			_view.ScadenzaRenew += OnScadenzaRenew;
		}

		public void Reload()
		{
			if (_tabs.Mezzo == null)
				return;

			_updatePresenter?.Close();
			_renewPresenter?.Close();

			_scadenze.Clear();
			_scadenzeItem.Clear();

			_scadenze.AddRange(ModelFactory.GetScadenzeForMezzo(_tabs.Mezzo));
			_scadenze.AddRange(from t in _tabs.Mezzo.Tessere orderby t.Type.Name select t);
			_scadenze.AddRange(from d in _tabs.Mezzo.Dispositivi orderby d.Type.Name select d);
			_scadenze.AddRange(from p in _tabs.Mezzo.Permessi orderby p.Type.Name select p);

			UpdateItems(null);
			_view.Scadenze = _scadenzeItem;
		}

		private void UpdateItems(IScadenzaOwner scadOwner)
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
				{
					item.Date = scadOwner.Scadenza?.DateDescription;
					item.Expired = scadOwner.Scadenza?.Expired ?? false;
				}
				else
					Reload();
			}
			else
			{
				_scadenzeItem.AddRange(from s in _scadenze
									   select ClientSideInterfaceFactory.NewScadenzaListItem(s.ScadenzaName,
																							 s.Scadenza?.DateDescription,
																							 s.Scadenza?.Expired ?? false,
																							 s.Scadenza?.HasDate ?? false
																							));
			}
		}

		private void OnObjectChanged(IDBObject obj)
		{
			if (obj is IScadenzaOwner scadOwner && scadOwner.Mezzo == _tabs.Mezzo)
			{
				if (_scadenze.Contains(scadOwner))
				{
					UpdateItems(scadOwner);
					_view.RefreshScadenze();
				}
				else
					Reload();
			}
			else if (obj is ITesseraType || obj is IDispositivoType || obj is IPermessoType)
				Reload();
		}
		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is IScadenzaOwner scadOwner && scadOwner.Mezzo == _tabs.Mezzo)
				Reload();
		}

		public void OnCancelEdit()
		{
		}

		private void OnScadenzaEdit(int index)
		{
			_updatePresenter = new UpdateScadenzaPresenter(_server, _scadenze[index]);
			_updatePresenter.PresenterClosed += () => _updatePresenter = null;
			_updatePresenter.ShowDialog();
		}

		private void OnScadenzaRenew(int index)
		{
			_renewPresenter = new RenewScadenzaPresenter(_server, _scadenze[index]);
			_renewPresenter.PresenterClosed += () => _renewPresenter = null;
			_renewPresenter.ShowDialog();
		}
	}
}
