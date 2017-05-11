using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ClientSide.Interface;

namespace Flotta.ClientSide
{
	internal class MezzoTabPresenter
	{

		private Client _client;
		private DummyMezzo _mezzo;

		private IMezzoTabControl _tabControl;
		private ITabPresenter[] _tabPresenters = new ITabPresenter[5];

		internal MezzoTabPresenter(Client client, IMezzoTabControl tabControl)
		{
			_client = client;
			_tabControl = tabControl;

			_tabPresenters[0] = new TabGeneralePresenter(this, _tabControl.GeneraleTab);

			_tabControl.CurrentTab = 0;
			_tabControl.TabChanged += OnTabChange;
			OnTabChange(_tabControl.CurrentTab);
		}

		internal DummyMezzo Mezzo
		{
			get
			{
				return _mezzo;
			}
			set
			{
				_mezzo = value;
				_tabControl.CurrentTab = 0;
				OnTabChange(_tabControl.CurrentTab);
			}
		}

		internal event GenericAction OnExitEdit;
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

	}
}
