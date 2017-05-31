using System;
using Flotta.ClientSide.Interface;
using Flotta.ServerSide;
using Flotta.Model;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	internal class RenewScadenzaPresenter : IDialogPresenter
	{
		private IServer _server;
		private IRenewScadenzaDialog _window;
		private IScadenzaOwner _scadOwner;

		internal RenewScadenzaPresenter(IServer server, IScadenzaOwner scadOwner)
		{
			_server = server;
			_scadOwner = scadOwner;
		}

		public void ShowDialog()
		{
			Scadenza newScad = _scadOwner.Scadenza.Clone() as Scadenza;
			if (newScad.HasRecurrencyPeriod)
			{
				newScad.SetNextDate();
				_server.UpdateScadenza(_scadOwner, newScad);
			}
			else
			{
				using (_window = ClientSideInterfaceFactory.NewRenewScadenzaDialog())
				{
					_window.Date = newScad.Date;
					_window.ScadName = _scadOwner.ScadenzaName;
					_window.Validation = () =>
					{
						try
						{
							newScad.Date = _window.Date;
							return true;
						}
						catch (Exception e)
						{
							MessageBox.Show(e.Message, "Errore");
							return false;
						}
					};

					if (_window.ShowDialog() == DialogResult.OK)
					{
						_server.UpdateScadenza(_scadOwner, newScad);
					}
				}
			}

			Close();
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is IScadenzaOwner scadOwner && scadOwner == _scadOwner)
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
