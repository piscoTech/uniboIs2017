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
		private bool _saved = false;
		private IManutenzione _manutenzione;

		private INewManutenzioneDialog _window;
		
		

		internal NewManutenzionePresenter(IServer server, INewManutenzioneDialog window)
		{
			_server = server;
			_window = window;
			

			_window.FormClosed += OnCompletion;
			_window.SaveManutenzione += OnSave;
			_window.CancelManutenzione += OnCancel;
			
		}

		internal event StatusReportAction CreationCompleted;
		private void OnCompletion(object sender, FormClosedEventArgs e)
		{
			CreationCompleted?.Invoke(_saved);
		}

		private void OnCancel()
		{
			_window.Close();
		}

		private void OnSave()
		{
			if (_manutenzione == null) _manutenzione = ModelFactory.NewManutenzione();
			
			var errors = _server.UpdateManutenzione(_manutenzione, _window.Data, _window.Note,_window.Tipo, _window.Costo);
			
			if (errors.Count() > 0) MessageBox.Show(String.Join("\r\n", errors), "Errore");

			else
			{
				_saved = true;
				_window.ConfirmBeforeClosing = false;
				_window.Close();
			}

		}
	}
}
