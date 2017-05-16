using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ClientSide.Interface;
using Flotta.Model;
using Flotta.ServerSide;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	internal class TabGeneralePresenter : ITabPresenter
	{

		private IServer _server;
		private MezzoTabPresenter _tabs;
		private ITabGeneraleView _view;

		private IMezzo Mezzo
		{
			get => _tabs.Mezzo;
		}

		private bool _editMode;
		private bool EditMode
		{
			get => _editMode;
			set
			{
				_editMode = value;
				Reload();
			}
		}

		internal TabGeneralePresenter(IServer server, MezzoTabPresenter tabs, ITabGeneraleView view)
		{
			_server = server;
			_tabs = tabs;
			_view = view;

			EditMode = false;

			_view.DeleteMezzo += OnDeleteMezzo;
			_view.CancelEdit += OnCancelEdit;
			_view.EnterEdit += OnEnterEdit;
			_view.SaveEdit += OnSaveEdit;
		}

		public void Reload()
		{
			if (_tabs.Mezzo == null)
				return;

			_view.Modello = Mezzo.Modello;
			_view.Targa = Mezzo.Targa;
			_view.Numero = Mezzo.Numero;
			_view.NumeroTelaio = Mezzo.NumeroTelaio;
			_view.AnnoImmatricolazione = Mezzo.AnnoImmatricolazione;
			_view.Portata = Mezzo.Portata;
			_view.Altezza = Mezzo.Altezza;
			_view.Lunghezza = Mezzo.Lunghezza;
			_view.Profondita = Mezzo.Profondita;
			_view.VolumeCarico = Mezzo.VolumeCarico;

			_view.EditMode = _editMode;
		}

		private void OnEnterEdit()
		{
			if (EditMode)
				return;

			EditMode = true;
		}

		public void OnCancelEdit()
		{
			if (!EditMode)
				return;

			EditMode = false;
		}

		private void OnSaveEdit()
		{
			if (!EditMode)
				return;

			var errors =_server.UpdateMezzo(_tabs.Mezzo, true, _view.Modello, _view.Targa, _view.Numero, _view.NumeroTelaio, _view.AnnoImmatricolazione, _view.Portata, _view.Altezza, _view.Lunghezza, _view.Profondita, _view.VolumeCarico, _tabs.Mezzo.Tessere, _tabs.Mezzo.Dispositivi, _tabs.Mezzo.Permessi);

			if (errors.Count() > 0) MessageBox.Show(String.Join("\r\n", errors), "Errore");
			
			// The tab will be automatically reloaded exiting edit mode automatically with the notification from the server
		}

		private void OnDeleteMezzo()
		{
			if(MessageBox.Show("Sei sicuro di voler cancellare il mezzo corrente?", "Elimina mezzo", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (!_server.DeleteMezzo(_tabs.Mezzo))
					MessageBox.Show("Errore durante l'eliminazione del mezzo", "Errore");

				// The tab will be automatically reloaded exiting display mode automatically with the notification from the server
			}
		}
	}
}
