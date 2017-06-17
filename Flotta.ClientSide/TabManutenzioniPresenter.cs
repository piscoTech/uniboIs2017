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
		private readonly IServer _server;
		private readonly MezzoTabPresenter _tabs;
		private readonly ITabManutenzioniView _view;
		private List<IManutenzione> _manutenzioniList;
		private List<IManutenzioneListItem> _manutenzioneListItem;

		private IDialogPresenter _curPresenter = null;

		internal TabManutenzioniPresenter(IServer server, MezzoTabPresenter tabs, ITabManutenzioniView view)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			if (tabs == null)
				throw new ArgumentNullException("No tab presenter specified");

			if (view == null)
				throw new ArgumentNullException("No view specified");

			_server = server;
			_tabs = tabs;
			_view = view;

			_view.ModifyManutenzione += OnModifyManutenzione;
			_view.DeleteManutenzione += OnDeleteManutenzione;
			_view.ViewOfficina += OnViewOfficina;
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
																							   m.Allegato?.Path,
																							   m.Officina.Nome)).ToList();
			_view.Manutenzioni = _manutenzioneListItem;
		}

		public void OnCancelEdit()
		{
		}

		private void OnViewOfficina(int index)
		{
			_curPresenter = new UpdateOfficinaPresenter(_server, _manutenzioniList[index].Officina);
			_curPresenter.PresenterClosed += () => _curPresenter = null;
			_curPresenter.ShowDialog();
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
			_curPresenter = new UpdateManutenzionePresenter(_server, m);
			_curPresenter.PresenterClosed += () => _curPresenter = null;
			_curPresenter.ShowDialog();
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
			if (o is IManutenzioneType || o is IOfficina)
				Reload();
			else if (o is IManutenzione m && m.Mezzo == _tabs.Mezzo)
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
					item.Date = m.Data.ToString("dd/MM/yyyy");
					item.Tipo = m.Type.Name;
					item.Note = m.Note;
					item.Costo = m.Costo;
					item.AllegatoPath = m.Allegato?.Path;
					item.Officina = m.Officina.Nome;

					_view.RefreshManutenzioni();
				}
			}
		}

		private void OnObjectRemoved(IDBObject o)
		{
			if (o is IManutenzione m && m.Mezzo == _tabs.Mezzo && _manutenzioniList.Contains(m))
				Reload();
		}

		public void Close()
		{
			_server.ObjectChanged -= OnObjectChanged;
			_server.ObjectRemoved -= OnObjectRemoved;
		}
	}
}
