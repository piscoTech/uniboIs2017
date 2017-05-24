using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ClientSide.Interface;
using Flotta.Model;
using Flotta.ServerSide;

namespace Flotta.ClientSide
{
	internal class MezzoTabPresenter
	{

		private IServer _server;
		private Client _client;
		private IMezzo _mezzo;

		private IMezzoTabView _tabControl;
		private ITabPresenter[] _tabPresenters = new ITabPresenter[5];

		internal MezzoTabPresenter(IServer server, Client client, IMezzoTabView tabControl)
		{
			_server = server;
			_client = client;
			_tabControl = tabControl;

			_tabPresenters[0] = new TabGeneralePresenter(_server, this, _tabControl.GeneraleTab);
			// Scadenze
			_tabPresenters[2] = new TabManutenzioniPresenter(_server, this, _tabControl.ManutenzioniTab);
			// Galleria
			// Incidenti

			_tabControl.CurrentTab = 0;
			_tabControl.TabChanged += OnTabChange;
			OnTabChange(_tabControl.CurrentTab);
		}

		internal IMezzo Mezzo
		{
			get
			{
				return _mezzo;
			}
			set
			{
				_mezzo = value;
				_tabControl.CurrentTab = 0;
				ReloadTab();
			}
		}

		internal event Action OnExitEdit;
		private void ExitEdit()
		{
			OnExitEdit();
		}

		private void OnTabChange(int index)
		{
			foreach(ITabPresenter tab in _tabPresenters)
			{
				if (tab == null)
					continue;

				tab.OnCancelEdit();

				if (tab == _tabPresenters[index])
					tab.Reload();
			}
		}

		internal void ReloadTab()
		{
			OnTabChange(_tabControl.CurrentTab);
		}

	}
}
