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
	class NewMezzoPresenter : IDialogPresenter
	{
		private readonly IServer _server;
		private readonly IMezzo _mezzo = ModelFactory.NewMezzo();

		private INewMezzoDialog _window;
		private TabGeneralePresenter _presenter;

		internal NewMezzoPresenter(IServer server)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			_server = server;
		}

		public void ShowDialog()
		{
			using (_window = ClientSideInterfaceFactory.NewNewMezzoDialog())
			{
				_presenter = new TabGeneralePresenter(_server, _mezzo, _window.TabGenerale)
				{
					EditMode = true
				};

				_window.FormClosed += (object sender, FormClosedEventArgs e) => Close();
				_presenter.MezzoSaved += OnSave;

				_window.ShowDialog();
			}
			Close();
		}

		private void OnSave()
		{
			_window.ConfirmBeforeClosing = false;
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
