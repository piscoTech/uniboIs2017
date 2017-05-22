using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using Flotta.Model;


namespace Flotta.ClientSide
{
	class TabManutenzioniPresenter : ITabPresenter
	{

		private IServer _server;
		private MezzoTabPresenter _tabs;
		private ITabManutenzioniView _view;

		private bool _editMode;
		private bool EditMode
		{
			get => _editMode;
			set
			{
				_editMode = value;
				Reload();
			}
		}

		internal TabManutenzioniPresenter(IServer server, MezzoTabPresenter tabs, ITabManutenzioniView view)
		{
			_server = server;
			_tabs = tabs;
			_view = view;

			EditMode = false;

			_view.CancelEdit += OnCancelEdit;
			_view.EnterEdit += OnEnterEdit;
			_view.SaveEdit += OnSaveEdit;
			_view.NuovaManutenzione += OnNuovaManutenzione;
		}

		public void Reload()
		{
			UpdateManutenzioniList();

		}

		private void UpdateManutenzioniList()
		{
			foreach (IManutenzione m in _server.Manutenzioni)
				_view.ManutenzioniList.Rows.Add(m.Data, m.Note, m.Costo, m.Type);
		}

		private void OnEnterEdit()
		{
			if (EditMode)
				return;

			EditMode = true;
		}

		public void OnCancelEdit()
		{
			if (!EditMode)
				return;

			EditMode = false;
		}

		private void OnSaveEdit()
		{
			if (!EditMode)
				return;
		}

		private void OnNuovaManutenzione() {
			using (INewManutenzioneDialog dialog = ClientSideInterfaceFactory.NewNewManutenzioneDialog()){
				var presenter = new NewManutenzionePresenter(_server, dialog);

				dialog.ShowDialog();
			}
		}
	}
}
