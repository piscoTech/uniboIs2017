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
	class NewManutenzionePresenter
	{
		private IServer _server;
		private IManutenzione _manutenzione;

		private INewManutenzioneDialog _window;

		internal NewManutenzionePresenter(IServer server, IManutenzione manut, INewManutenzioneDialog window)
		{
			_server = server;
			_window = window;

			_manutenzione = manut;

			_window.SaveManutenzione += OnSave;
			_window.CancelManutenzione += OnCancel;
			_window.Types = (from m in _server.GetLinkedTypes<IManutenzioneType>() select m.Name).ToList();
		}

		private void OnCancel()
		{
			_window.Close();
		}

		private void OnSave()
		{
			var errors = _server.UpdateManutenzione(_manutenzione, _window.Data, _window.Note,
													_server.GetLinkedTypes<IManutenzioneType>().ElementAtOrDefault(_window.Tipo),
													_window.Costo);

			if (errors.Count() > 0) MessageBox.Show(String.Join("\r\n", errors), "Errore");

			else
			{
				_window.ConfirmBeforeClosing = false;
				_window.Close();
			}
		}
	}
}
