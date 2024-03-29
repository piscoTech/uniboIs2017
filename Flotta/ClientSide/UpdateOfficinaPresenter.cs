﻿using System;
using System.Linq;
using System.Windows.Forms;
using Flotta.ClientSide.View;
using Flotta.Model;
using Flotta.ServerSide;

namespace Flotta.ClientSide
{
	internal class UpdateOfficinaPresenter : IDialogPresenter
	{
		private readonly IServer _server;
		private IUpdateOfficinaDialog _window;
		private bool _editMode;
		private readonly IOfficina _officina;

		internal UpdateOfficinaPresenter(IServer server, IOfficina officina)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			_server = server;

			_editMode = officina == null;
			_officina = officina ?? ModelFactory.NewOfficina();
		}

		public event Action PresenterClosed;
		public void Close()
		{
			_server.ObjectChanged -= OnObjectChanged;
			_server.ObjectRemoved -= OnObjectChanged;

			var win = _window;
			_window = null;

			win?.Close();
			win?.Dispose();
			PresenterClosed?.Invoke();
		}

		private void OnObjectChanged(IDBObject obj)
		{
			if (obj is IOfficina o && o == _officina)
				Reload();
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is IOfficina o && o == _officina)
				Close();
		}

		public void ShowDialog()
		{
			using (_window = ClientSideInterfaceFactory.NewUpdateOfficinaDialog())
			{
				_server.ObjectChanged += OnObjectChanged;
				_server.ObjectRemoved += OnObjectChanged;

				Reload();
				_window.EditMode = _editMode;
				_window.CancelEdit += OnCancelEdit;
				_window.EnterEdit += OnEnterEdit;
				_window.SaveEdit += OnSaveEdit;

				_window.ShowDialog();
			}
			Close();
		}

		private void Reload()
		{
			if (_window == null)
				return;

			_window.Nome = _officina.Nome ?? "";
			_window.Telefono = _officina.Telefono ?? "";
			_window.Via = _officina.Via ?? "";
			_window.Cap = _officina.Cap ?? "";
			_window.Citta = _officina.Citta ?? "";
			_window.Provincia = _officina.Provincia ?? "";
			_window.Nazione = _officina.Nazione ?? "";
		}

		private void OnEnterEdit()
		{
			if (_editMode)
				return;

			_editMode = true;
			_window.EditMode = _editMode;
		}

		private void OnSaveEdit()
		{
			if (!_editMode)
				return;

			var errors = _server.UpdateOfficina(_officina, _window.Nome, _window.Telefono, _window.Via, _window.Cap, _window.Citta, _window.Provincia, _window.Nazione);
			if (errors.Count() > 0)
				MessageBox.Show(String.Join("\r\n", errors), "Errore");
			else
			{
				_editMode = false;
				_window.EditMode = _editMode;

				// Will be automatically reloaded via server notification
			}
		}

		private void OnCancelEdit()
		{
			if (!_editMode)
				return;

			_editMode = false;
			_window.EditMode = _editMode;
			Reload();
		}
	}
}
