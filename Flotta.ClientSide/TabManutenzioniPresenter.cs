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
	class TabManutenzioniPresenter : ITabPresenter
	{

		private IServer _server;
		private MezzoTabPresenter _tabs;
		private ITabManutenzioniView _view;
		private List<IManutenzione> _manutenzioniList;
		private List<IManutenzioneListItem> _manutenzioneListItem;

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
			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;
		}

		public void Reload()
		{
			if (_tabs.Mezzo == null)
				return;

			_manutenzioniList = _tabs.Mezzo.Manutenzioni.ToList();
			_manutenzioneListItem= (from m in _manutenzioniList select ClientSideInterfaceFactory.NewManutenzioneListItem(m.Data, m.Note, m.Type.Name, m.Costo)).ToList(); 
			_view.Manutenzioni = _manutenzioneListItem;
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
			using (INewManutenzioneDialog dialog = ClientSideInterfaceFactory.NewNewManutenzioneDialog())
			{
				var presenter = new NewManutenzionePresenter(_server, ModelFactory.NewManutenzione(_tabs.Mezzo), dialog);

				dialog.ShowDialog();
			}
		}

		public void OnModifyManutenzione(int row)
		{
			var dialog = ClientSideInterfaceFactory.NewNewManutenzioneDialog(_view.Manutenzioni.ElementAt(row).Date, _view.Manutenzioni.ElementAt(row).Note, _view.Manutenzioni.ElementAt(row).Costo);
			var presenter = new NewManutenzionePresenter(_server, _manutenzioniList[row], dialog);
			dialog.ShowDialog();

		}

		public void OnDeleteManutenzione(int row)
		{

			if (MessageBox.Show("Sei sicuro di voler eliminare la manutenzione in data" + _manutenzioniList[row].Data.ToString("dd/MM/yyyy") + "?", "Elimina", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				_server.DeleteManutenzione(_manutenzioniList[row]);
			}
			
		}

		private void OnObjectChanged(IDBObject o)
		{
			if (o is IManutenzioneType)
				Reload();

			else if (o is IManutenzione m)
			{
				int index = _manutenzioniList.IndexOf(m);
				if (index < 0)
				{
					Reload();
					return;
				}

				IManutenzioneListItem item = _manutenzioneListItem.ElementAtOrDefault(index);
				if (item != null)
				{
					item.Date = m.Data;
					item.Note = m.Note;
					item.Costo = m.Costo;

					_view.RefreshManutenzioni();
				}
			}

		}

		private void OnObjectRemoved(IDBObject o)
		{
			if (o is IManutenzione m && _manutenzioniList.Contains(m))
			{
				Reload();
			}
		}
		
	}
}
