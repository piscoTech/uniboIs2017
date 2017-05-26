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
	class UpdateManutenzionePresenter
	{
		private IServer _server;
		private IManutenzione _manutenzione;
		private List<IManutenzioneType> _types;

		private IUpdateManutenzioneDialog _window;

		internal UpdateManutenzionePresenter(IServer server, IManutenzione manut, IUpdateManutenzioneDialog window)
		{
			_server = server;
			_window = window;
			_manutenzione = manut;

			_server.ObjectChanged += OnObjectChangedRemoved;
			_server.ObjectRemoved += OnObjectChangedRemoved;

			_window.Validation = () =>
			{
				var errors = _server.UpdateManutenzione(_manutenzione, _window.Data, _window.Note,
													_types.ElementAtOrDefault(_window.Tipo),
													_window.Costo, null);

				if (errors.Count() > 0)
				{
					MessageBox.Show(String.Join("\r\n", errors), "Errore");
					return false;
				}
				else
					return true;
			};
			_window.Data = manut.Data;
			_window.Note = manut.Note ?? "";
			_window.Costo = manut.Costo;

			ReloadLists();
		}

		private void ReloadLists()
		{
			_types = (from m in _server.GetLinkedTypes<IManutenzioneType>()
					  where !m.IsDisabled || (_manutenzione.Type != null && m == _manutenzione.Type)
					  select m).ToList();
			// save list of officine

			_window.Types = (from t in _types select t.Name).ToList();
			// set list of officine

			int index = _types.IndexOf(_manutenzione.Type);
			if (index >= 0)
				_window.Tipo = index;
			// select appropriate officina
		}

		private void OnObjectChangedRemoved(IDBObject obj)
		{
			if (obj is IManutenzioneType)
				ReloadLists();
		}

		internal void Close()
		{
			_window.Close();
			_window.Dispose();
		}
	}
}
