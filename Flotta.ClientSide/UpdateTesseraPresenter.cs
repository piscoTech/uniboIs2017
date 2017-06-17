using System;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using System.Linq;
using Flotta.Model;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	internal class UpdateTesseraPresenter : IDialogPresenter
	{
		private readonly IServer _server;
		private IUpdateTesseraDialog _window;
		private readonly ITessera _tessera;

		internal UpdateTesseraPresenter(IServer server, ITessera t)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			if (t == null)
				throw new ArgumentNullException("No tessera specified");

			_server = server;
			_tessera = t;
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			// Change in mezzo, and so tessere, dispositivi and permessi, are handled by parent presenters
			if (obj is ITesseraType tt && tt == _tessera.Type)
				Close();
		}

		public void ShowDialog()
		{
			using (_window = ClientSideInterfaceFactory.NewUpdateTesseraDialog())
			{
				_server.ObjectRemoved += OnObjectRemoved;

				_window.Codice = _tessera.Codice ?? "";
				_window.Pin = _tessera.Pin ?? "";
				_window.Validation = () =>
				{
					var errors = _tessera.Update(_window.Codice, _window.Pin);
					if (errors.Count() > 0)
					{
						MessageBox.Show(String.Join("\r\n", errors), "Errore");
						return false;
					}
					else
						return true;
				};

				if (_window.ShowDialog() == DialogResult.OK)
				{
					TesseraUpdated?.Invoke();
				}
			}
			Close();
		}

		public event Action TesseraUpdated;
		public event Action PresenterClosed;
		public void Close()
		{
			_server.ObjectRemoved -= OnObjectRemoved;

			var win = _window;
			_window = null;

			win?.Close();
			win.Dispose();
			PresenterClosed?.Invoke();
		}
	}
}
