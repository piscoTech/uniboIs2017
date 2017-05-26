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

		private IManutenzione _curManut = null;
		private UpdateManutenzionePresenter _curPresenter = null;

		internal TabManutenzioniPresenter(IServer server, MezzoTabPresenter tabs, ITabManutenzioniView view)
		{
			_server = server;
			_tabs = tabs;
			_view = view;

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
			_manutenzioneListItem = (from m in _manutenzioniList
									 select ClientSideInterfaceFactory.NewManutenzioneListItem(m.Data.ToString("dd/MM/yyyy"),
																							   m.Note,
																							   m.Type.Name,
																							   m.Costo,
																							   m.Allegato?.Path)).ToList();
			_view.Manutenzioni = _manutenzioneListItem;
		}

		public void OnCancelEdit()
		{
		}

		private void OnNuovaManutenzione()
		{
			DoEdit(ModelFactory.NewManutenzione(_tabs.Mezzo));
		}

		public void OnModifyManutenzione(int row)
		{
			DoEdit(_manutenzioniList[row]);
		}

		private void DoEdit(IManutenzione m)
		{
			using (IUpdateManutenzioneDialog dialog = ClientSideInterfaceFactory.NewUpdateManutenzioneDialog())
			{
				_curManut = m;
				_curPresenter = new UpdateManutenzionePresenter(_server, _curManut, dialog);

				dialog.ShowDialog();
			}
			_curManut = null;
			_curPresenter = null;
		}

		public void OnDeleteManutenzione(int row)
		{
			if (MessageBox.Show("Sei sicuro di voler eliminare la manutenzione in data " + _manutenzioniList[row].Data.ToString("dd/MM/yyyy") + "?", "Elimina", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				_server.DeleteManutenzione(_manutenzioniList[row]);
			}
		}

		private void OnObjectChanged(IDBObject o)
		{
			if (o is IManutenzioneType)
				Reload();
			else if (o is IManutenzione m && m.Mezzo == _tabs.Mezzo)
			{
				if (m == _curManut)
				{
					_curPresenter.Close();
					_curPresenter = null;
					_curManut = null;
				}

				int index = _manutenzioniList.IndexOf(m);
				if (index < 0)
				{
					Reload();
					return;
				}

				IManutenzioneListItem item = _manutenzioneListItem.ElementAtOrDefault(index);
				if (item != null)
				{
					item.Date = m.Data.ToString("dd/MM/yyyy");
					item.Tipo = m.Type.Name;
					item.Note = m.Note;
					item.Costo = m.Costo;
					item.AllegatoPath = m.Allegato?.Path;

					_view.RefreshManutenzioni();
				}
			}
		}

		private void OnObjectRemoved(IDBObject o)
		{
			if (o is IManutenzione m && m.Mezzo == _tabs.Mezzo && _manutenzioniList.Contains(m))
			{
				if (m == _curManut)
				{
					_curPresenter.Close();
					_curPresenter = null;
					_curManut = null;
				}

				Reload();
			}
		}
	}
}
