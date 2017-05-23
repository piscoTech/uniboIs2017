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
			_presenter.MezzoSaved += OnSave;
		}

		internal event Action<bool> CreationCompleted;
		private void OnCompletion(object sender, FormClosedEventArgs e)
		{
			CreationCompleted?.Invoke(_saved);
			_window.Dispose();
		}

		private void OnSave()
		{
			_saved = true;
			_window.ConfirmBeforeClosing = false;
			_window.Close();
		}

	}
}
