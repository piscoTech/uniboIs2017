﻿using System;
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
		private List<IOfficina> _officine;

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
													_window.Costo, null, _officine.ElementAt(_window.Officina));

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
			
			_officine = (from o in _server.Officine select o).ToList();

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
