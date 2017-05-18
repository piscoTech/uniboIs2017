﻿using System;
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
		private ITabGeneraleView _view;

		private MezzoTabPresenter _tabs;
		private IMezzo _mezzo;

		private IMezzo Mezzo
		{
			get => _tabs?.Mezzo ?? _mezzo;
		}

		private bool _editMode;
		internal bool EditMode
		{
			get => _editMode;
			set
			{
				_editMode = value;

				if (value)
				{
					_tessereTmp = (from t in Mezzo.Tessere select t.Clone() as ITessera).ToList();
					_tessereTypes = (from t in _server.TesseraTypes where !t.IsDisabled || (from tt in Mezzo.Tessere select tt.Type).Contains(t) select t).ToList();

					//_dispositivoTmp = (from d in Mezzo.Dispositivi select d.Clone()).ToList();

					//_permessiTmp = (from p in Mezzo.Permessi select p.Clone()).ToList();
				}
				else
				{
					_tessereTmp = null;
					_tessereTypes = null;
					_tessereItems = null;

					_dispositivoTmp = null;

					_permessiTmp = null;
				}

				Reload();
			}
		}

		///<summary>During editing keeps a local copy of tessere linked to mezzo to edit freely.</summary>
		private List<ITessera> _tessereTmp = null;
		///<summary>During editing keeps the subset of tessere types available, aka non disabled or already linked to mezzo.</summary>
		private List<ITesseraType> _tessereTypes = null;
		///<summary>During editing keeps visual items for tessere corresponding to the list of available types _tessereTypes.</summary>
		private List<ITesseraListItem> _tessereItems = null;

		private List<IDispositivo> _dispositivoTmp = null;
		// IDispositivoListItem

		private List<IPermesso> _permessiTmp = null;
		// IPermessoListItem

		internal TabGeneralePresenter(IServer server, IMezzo mezzo, ITabGeneraleView view) : this(server, view)
		{
			_mezzo = mezzo;
		}

		internal TabGeneralePresenter(IServer server, MezzoTabPresenter tabs, ITabGeneraleView view) : this(server, view)
		{
			_tabs = tabs;
		}

		private TabGeneralePresenter(IServer server, ITabGeneraleView view)
		{
			_server = server;
			_view = view;

			EditMode = false;

			_view.DeleteMezzo += OnDeleteMezzo;
			_view.CancelEdit += OnCancelEdit;
			_view.EnterEdit += OnEnterEdit;
			_view.SaveEdit += OnSaveEdit;

			_view.TesseraEdit += OnTesseraEdit;
			_view.TesseraRemove += OnTesseraRemove;
		}

		public void Reload()
		{
			if (Mezzo == null)
				return;

			_view.EditMode = _editMode;

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

			if (_editMode)
			{
				_tessereItems = new List<ITesseraListItem>();
				foreach (var tt in _tessereTypes)
				{
					ITessera tess = (from t in _tessereTmp where t.Type == tt select t).ElementAtOrDefault(0);
					_tessereItems.Add(ClientSideInterfaceFactory.NewTesseraListItem(tess != null, tt.Name, tess?.Codice ?? "", tess?.Pin ?? ""));
				}
				_view.Tessere = _tessereItems;
			}
			else
			{
				_view.Tessere = from t in Mezzo.Tessere orderby t.Type.Name select ClientSideInterfaceFactory.NewTesseraListItem(true, t.Type.Name, t.Codice, t.Pin);
			}
		}

		private void OnEnterEdit()
		{
			if (EditMode || _tabs == null)
				return;

			EditMode = true;
		}

		public void OnCancelEdit()
		{
			if (!EditMode || _tabs == null)
				return;

			EditMode = false;
		}

		private void OnTesseraEdit(int index)
		{
			if (!_editMode)
				return;

			ITesseraType tt = _tessereTypes[index];
			var ti = _tessereItems[index];
			var t = (from tess in _tessereTmp where tess.Type == tt select tess).ElementAtOrDefault(0);
			using (var tesseraDialog = ClientSideInterfaceFactory.NewUpdateTesseraDialog())
			{
				tesseraDialog.Codice = t?.Codice ?? "";
				tesseraDialog.Pin = t?.Pin ?? "";
				tesseraDialog.Validation = () =>
				{
					var tess = t ?? ModelFactory.NewTessera(tt);
					var errors = tess.Update(tesseraDialog.Codice, tesseraDialog.Pin);
					if (errors.Count() > 0)
					{
						MessageBox.Show(String.Join("\r\n", errors), "Errore");
						return false;
					}
					else
					{
						if (t == null)
							_tessereTmp.Add(tess);

						ti.InUse = true;
						ti.Codice = tess.Codice;
						ti.Pin = tess.Pin;

						return true;
					}
				};

				if (tesseraDialog.ShowDialog() == DialogResult.OK)
				{
					_view.Tessere = _tessereItems;
				}
			}
		}
		private void OnTesseraRemove(int index)
		{
			if (!_editMode)
				return;

			ITesseraType tt = _tessereTypes[index];
			var ti = _tessereItems[index];
			ti.InUse = false;
			ti.Codice = "";
			ti.Pin = "";
			_tessereTmp.Remove((from t in _tessereTmp where t.Type == tt select t).ElementAtOrDefault(0));
			_view.Tessere = _tessereItems;
		}

		internal event Action MezzoSaved;
		private void OnSaveEdit()
		{
			if (!EditMode)
				return;

			var errors = _server.UpdateMezzo(Mezzo, _view.Modello, _view.Targa, _view.Numero, _view.NumeroTelaio, _view.AnnoImmatricolazione, _view.Portata, _view.Altezza, _view.Lunghezza, _view.Profondita, _view.VolumeCarico, _tessereTmp, Mezzo.Dispositivi, Mezzo.Permessi);

			if (errors.Count() > 0) MessageBox.Show(String.Join("\r\n", errors), "Errore");

			// The tab will be automatically reloaded exiting edit mode automatically with the notification from the server
			MezzoSaved?.Invoke();
		}

		private void OnDeleteMezzo()
		{
			if (_tabs == null)
				return;

			if (MessageBox.Show("Sei sicuro di voler cancellare il mezzo corrente?", "Elimina mezzo", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (!_server.DeleteMezzo(_tabs.Mezzo))
					MessageBox.Show("Errore durante l'eliminazione del mezzo", "Errore");

				// The tab will be automatically reloaded exiting display mode automatically with the notification from the server
			}
		}
	}
}
