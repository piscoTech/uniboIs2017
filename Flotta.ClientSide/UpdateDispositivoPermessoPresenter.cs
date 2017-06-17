using System;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using System.Linq;
using Flotta.Model;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	internal class UpdateDispositivoPermessoPresenter<T, O> : IDialogPresenter
		where T : LinkedType
		where O : class, ILinkedObjectWithPDF<T>
	{
		private readonly IServer _server;
		private IUpdateDispositivoPermessoDialog _window;
		private readonly O _dispositivoPermesso;

		private readonly string _description;

		internal UpdateDispositivoPermessoPresenter(IServer server, O dispPerm, string description)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			if (dispPerm == null)
				throw new ArgumentNullException("No dispositivo/permesso specified");

			if (description == null)
				throw new ArgumentNullException("No description specified");

			_server = server;
			_dispositivoPermesso = dispPerm;
			_description = description;
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			// Change in mezzo, and so tessere, dispositivi and permessi, are handled by parent presenters
			if (obj is O t && t == _dispositivoPermesso.Type)
				Close();
		}

		public void ShowDialog()
		{
			using (_window = ClientSideInterfaceFactory.NewUpdateDispositivoPermessoDialog())
			{
				_server.ObjectRemoved += OnObjectRemoved;

				_window.Type = _description;
				_window.Path = _dispositivoPermesso.Allegato?.Path ?? "";
				_window.Validation = () =>
				{
					// Files are not supported, all attachment will be null
					var errors = _dispositivoPermesso.Update(null);
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
					DispositivoPermessoUpdated?.Invoke();
				}
			}
			Close();
		}

		public event Action DispositivoPermessoUpdated;
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
