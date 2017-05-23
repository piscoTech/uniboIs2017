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
			_view.ModifyManutenzione += OnModifyManutenzione;
			_view.DeleteManutenzione += OnDeleteManutenzione;
			_view.NuovaManutenzione += OnNuovaManutenzione;
		}

		public void Reload()
		{
			if (_tabs.Mezzo == null)
				return;

			_view.Manutenzioni = from m in _tabs.Mezzo.Manutenzioni select ClientSideInterfaceFactory.NewManutenzioneListItem(m.Data,m.Note,m.Type.Name,m.Costo);
		}

	

		private void UpdateTypeList()
		{

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

		private void OnNuovaManutenzione()
		{
			using (INewManutenzioneDialog dialog = ClientSideInterfaceFactory.NewNewManutenzioneDialog()){
				var presenter = new NewManutenzionePresenter(_server,_tabs.Mezzo, dialog);

				dialog.ShowDialog();
			}
		}

		public void OnModifyManutenzione(int row)
		{
			ClientSideInterfaceFactory.NewNewManutenzioneDialog();
		}

		public void OnDeleteManutenzione(int row)
		{
			//come posso accedere alla datagrid da qui?
		}
	}
}
