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

		private readonly IServer _server;
		private readonly ITabScadenzeView _view;

		private readonly MezzoTabPresenter _tabs;

		private readonly List<IScadenzaOwner> _scadenze = new List<IScadenzaOwner>();
		private readonly List<IScadenzaListItem> _scadenzeItem = new List<IScadenzaListItem>();

		private UpdateScadenzaPresenter _updatePresenter = null;
		private RenewScadenzaPresenter _renewPresenter = null;

		internal TabScadenzePresenter(IServer server, MezzoTabPresenter tabs, ITabScadenzeView view)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			if (tabs == null)
				throw new ArgumentNullException("No tab presenter specified");

			if (view == null)
				throw new ArgumentNullException("No view specified");

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
			_scadenze.AddRange(ModelFactory.GetAllScadenzeForMezzo(_tabs.Mezzo));

			UpdateItems(null);
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
				{
					Reload();
					return;
				}

				_view.RefreshScadenze();
			}
			else
			{
				_scadenzeItem.Clear();
				_scadenzeItem.AddRange(from s in _scadenze
									   select ClientSideInterfaceFactory.NewScadenzaListItem(s.ScadenzaName,
																							 s.Scadenza?.DateDescription,
																							 s.Scadenza?.Expired ?? false,
																							 s.Scadenza?.HasDate ?? false
																							));
				_view.Scadenze = _scadenzeItem;
			}
		}

		private void OnObjectChanged(IDBObject obj)
		{
			if (obj is IScadenzaOwner scadOwner && scadOwner.Mezzo == _tabs.Mezzo)
			{
				if (_scadenze.Contains(scadOwner))
				{
					UpdateItems(scadOwner);
				}
				else
					Reload();
			}
			else if (obj is LinkedType)
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
