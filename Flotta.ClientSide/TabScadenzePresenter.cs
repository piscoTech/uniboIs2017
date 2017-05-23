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

		internal TabScadenzePresenter(IServer server, MezzoTabPresenter tabs, ITabScadenzeView view)
		{
			_tabs = tabs;

			_server = server;
			_view = view;

			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;

			//_view.ScadenzaEdit +=;
			//_view.ScadenzaEdit += ;
		}

		public void Reload()
		{
			if (_tabs.Mezzo == null)
				return;

			_scadenze.Clear();
			_scadenzeItem.Clear();

			_scadenze.AddRange(_tabs.Mezzo.Tessere);

			foreach (var s in _scadenze)
			{
				var n = s.ScadenzaName;
				var d = s.Scadenza?.Date;
				var item = ClientSideInterfaceFactory.NewScadenzaListItem(n, d);

				_scadenzeItem.Add(item);
			}
			//_scadenzeItem.AddRange(from s in _scadenze select ClientSideInterfaceFactory.NewScadenzaListItem(s.ScadenzaName, s.Scadenza.Date));
			_view.Scadenze = _scadenzeItem;
		}

		private void OnObjectChanged(IDBObject obj)
		{
			throw new NotImplementedException();
		}
		private void OnObjectRemoved(IDBObject obj)
		{
			throw new NotImplementedException();
		}

		public void OnCancelEdit()
		{
		}
	}
}
