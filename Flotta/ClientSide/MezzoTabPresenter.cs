using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ClientSide.View;
using Flotta.Model;
using Flotta.ServerSide;

namespace Flotta.ClientSide
{
	internal class MezzoTabPresenter
	{

		private readonly IServer _server;
		private IMezzo _mezzo;

		private readonly IMezzoTabView _tabControl;
		private readonly ITabPresenter[] _tabPresenters = new ITabPresenter[5];

		internal MezzoTabPresenter(IServer server, IMezzoTabView tabControl)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			if (tabControl == null)
				throw new ArgumentNullException("No tab control specified");

			_server = server;
			_tabControl = tabControl;

			_tabPresenters[0] = new TabGeneralePresenter(_server, this, _tabControl.GeneraleTab);
			_tabPresenters[1] = new TabScadenzePresenter(_server, this, _tabControl.ScadenzeTab);
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
			foreach (ITabPresenter tab in _tabPresenters)
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

		internal void Close()
		{
			foreach (ITabPresenter tab in _tabPresenters)
				tab?.Close();
		}
	}
}
