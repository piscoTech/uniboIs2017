using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ServerSide;
using Flotta.Model;
using Flotta.ClientSide.Interface;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	class UpdateManutenzionePresenter : IDialogPresenter
	{
		private IServer _server;
		private IManutenzione _manutenzione;
		private List<IManutenzioneType> _types;
		private List<IOfficina> _officine;

		private IUpdateManutenzioneDialog _window;

		internal UpdateManutenzionePresenter(IServer server, IManutenzione manut)
		{
			_server = server;
			_manutenzione = manut;

			_server.ObjectChanged += OnObjectChangedRemoved;
			_server.ObjectRemoved += OnObjectChangedRemoved;
			_server.ObjectRemoved += OnObjectRemoved;
		}

		public void ShowDialog()
		{
			using (_window = ClientSideInterfaceFactory.NewUpdateManutenzioneDialog())
			{
				_window.Validation = () =>
				{
					var errors = _server.UpdateManutenzione(_manutenzione, _window.Data, _window.Note,
															_types.ElementAtOrDefault(_window.Tipo), _window.Costo,
															null, _officine.ElementAtOrDefault(_window.Officina));

					if (errors.Count() > 0)
					{
						MessageBox.Show(String.Join("\r\n", errors), "Errore");
						return false;
					}
					else
						return true;
				};
				_window.Data = _manutenzione.Data;
				_window.Note = _manutenzione.Note ?? "";
				_window.Costo = _manutenzione.Costo;

				ReloadLists();
				_window.ShowDialog();
			}
			Close();
		}

		private void ReloadLists()
		{
			_types = (from m in _server.GetLinkedTypes<IManutenzioneType>()
					  where !m.IsDisabled || (_manutenzione.Type != null && m == _manutenzione.Type)
					  select m).ToList();

			_officine = (from o in _server.Officine
						 where !o.IsDisabled || (_manutenzione.Officina != null && o == _manutenzione.Officina)
						 select o).ToList();

			_window.Types = (from t in _types select t.Name).ToList();

			_window.Officine = (from o in _officine select o.Nome).ToList();

			int indexTipo = _types.IndexOf(_manutenzione.Type);
			if (indexTipo >= 0)
				_window.Tipo = indexTipo;

			int indexOfficina = _officine.IndexOf(_manutenzione.Officina);
			if (indexOfficina >= 0)
				_window.Officina = indexOfficina;
		}

		private void OnObjectChangedRemoved(IDBObject obj)
		{
			if (obj is IManutenzioneType || obj is IOfficina)
				ReloadLists();
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is IManutenzione m && m == _manutenzione)
				Close();
		}

		public event Action PresenterClosed;
		public void Close()
		{
			var win = _window;
			_window = null;

			win?.Close();
			win?.Dispose();
			PresenterClosed?.Invoke();
		}
	}
}
