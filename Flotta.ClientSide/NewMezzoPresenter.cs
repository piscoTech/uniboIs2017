using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ClientSide.Interface;
using Flotta.Model;
using System.Windows.Forms;
using Flotta.ServerSide;

namespace Flotta.ClientSide
{
	class NewMezzoPresenter
	{

		private IServer _server;
		private bool _saved = false;
		private IMezzo _mezzo = ModelFactory.NewMezzo();

		private List<ITessera> _tessere = new List<ITessera>();
		private List<ITesseraListItem> _tessereItems = new List<ITesseraListItem>();

		private INewMezzoDialog _window;
		private TabGeneralePresenter _presenter;

		internal NewMezzoPresenter(IServer server, INewMezzoDialog window)
		{
			_server = server;
			_window = window;
			_presenter = new TabGeneralePresenter(_server, _mezzo, _window.TabGenerale)
			{
				EditMode = true
			};

			_window.FormClosed += OnCompletion;
			_window.SaveMezzo += OnSave;
		}

		internal event StatusReportAction CreationCompleted;
		private void OnCompletion(object sender, FormClosedEventArgs e)
		{
			CreationCompleted?.Invoke(_saved);
		}

		private void OnSave()
		{
			ITessera[] t = new ITessera[0];
			IDispositivo[] d = new IDispositivo[0];
			IPermesso[] p = new IPermesso[0];
			var errors = _server.UpdateMezzo(_mezzo, _window.TabGenerale.Modello, _window.TabGenerale.Targa, _window.TabGenerale.Numero, _window.TabGenerale.NumeroTelaio, _window.TabGenerale.AnnoImmatricolazione, _window.TabGenerale.Portata, _window.TabGenerale.Altezza, _window.TabGenerale.Lunghezza, _window.TabGenerale.Profondita, _window.TabGenerale.VolumeCarico, t, d, p);

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
