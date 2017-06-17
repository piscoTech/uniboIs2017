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
		private readonly IServer _server;
		private readonly ITabGeneraleView _view;

		private readonly MezzoTabPresenter _tabs;
		private IMezzo _mezzo;
		private IMezzo Mezzo => _tabs?.Mezzo ?? _mezzo;

		private bool _editMode;
		internal bool EditMode
		{
			get => _editMode;
			set
			{
				_editMode = value;
				Reload();
			}
		}

		private UpdateTesseraPresenter _tesseraPresenter;
		private IDialogPresenter _dispositivoPermessoPresenter;

		///<summary>During editing keeps a local copy of tessere linked to mezzo to edit freely.</summary>
		private List<ITessera> _tessereTmp = null;
		///<summary>During editing keeps the subset of tessere types available, aka non disabled or already linked to mezzo.</summary>
		private List<ITesseraType> _tessereTypes = null;
		///<summary>During editing keeps visual items for tessere corresponding to the list of available types _tessereTypes.</summary>
		private List<ITesseraListItem> _tessereItems = null;

		///<summary>During editing keeps a local copy of dispositivi linked to mezzo to edit freely.</summary>
		private List<IDispositivo> _dispositiviTmp = null;
		///<summary>During editing keeps the subset of dispositivi types available, aka non disabled or already linked to mezzo.</summary>
		private List<IDispositivoType> _dispositiviTypes = null;
		///<summary>During editing keeps visual items for dispositivi corresponding to the list of available types _dispositiviTypes.</summary>
		private List<IDispositivoPermessoListItem> _dispositiviItems = null;

		///<summary>During editing keeps a local copy of permessi linked to mezzo to edit freely.</summary>
		private List<IPermesso> _permessiTmp = null;
		///<summary>During editing keeps the subset of permessi types available, aka non disabled or already linked to mezzo.</summary>
		private List<IPermessoType> _permessiTypes = null;
		///<summary>During editing keeps visual items for permessi corresponding to the list of available types _permessiTypes.</summary>
		private List<IDispositivoPermessoListItem> _permessiItems = null;

		internal TabGeneralePresenter(IServer server, IMezzo mezzo, ITabGeneraleView view) : this(server, view)
		{
			if (mezzo == null)
				throw new ArgumentNullException("No mezzo specified");

			_mezzo = mezzo;
		}

		internal TabGeneralePresenter(IServer server, MezzoTabPresenter tabs, ITabGeneraleView view) : this(server, view)
		{
			if (tabs == null)
				throw new ArgumentNullException("No tab presenter specified");

			_tabs = tabs;
		}

		private TabGeneralePresenter(IServer server, ITabGeneraleView view)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			if (view == null)
				throw new ArgumentNullException("No view specified");

			_server = server;
			_view = view;

			EditMode = false;

			_server.ObjectChanged += OnObjectChangedRemoved;
			_server.ObjectRemoved += OnObjectChangedRemoved;

			_view.DeleteMezzo += OnDeleteMezzo;
			_view.CancelEdit += OnCancelEdit;
			_view.EnterEdit += OnEnterEdit;
			_view.SaveEdit += OnSaveEdit;

			_view.TesseraEdit += OnTesseraEdit;
			_view.TesseraRemove += OnTesseraRemove;

			_view.DispositivoEdit += OnDispositivoEdit;
			_view.DispositivoRemove += OnDispositivoRemove;

			_view.PermessoEdit += OnPermessoEdit;
			_view.PermessoRemove += OnPermessoRemove;
		}

		public void Reload()
		{
			if (Mezzo == null)
				return;

			if (EditMode)
			{
				_tessereTmp = (from t in Mezzo.Tessere select t.Clone() as ITessera).ToList();
				_tessereTypes = (from t in _server.GetLinkedTypes<ITesseraType>() where !t.IsDisabled || (from tt in Mezzo.Tessere select tt.Type).Contains(t) select t).ToList();

				_dispositiviTmp = (from d in Mezzo.Dispositivi select d.Clone() as IDispositivo).ToList();
				_dispositiviTypes = (from d in _server.GetLinkedTypes<IDispositivoType>() where !d.IsDisabled || (from dt in Mezzo.Dispositivi select dt.Type).Contains(d) select d).ToList();

				_permessiTmp = (from p in Mezzo.Permessi select p.Clone() as IPermesso).ToList();
				_permessiTypes = (from p in _server.GetLinkedTypes<IPermessoType>() where !p.IsDisabled || (from pt in Mezzo.Permessi select pt.Type).Contains(p) select p).ToList();
			}
			else
			{
				_tessereTmp = null;
				_tessereTypes = null;
				_tessereItems = null;

				_dispositiviTmp = null;
				_dispositiviTypes = null;
				_dispositiviItems = null;

				_permessiTmp = null;
				_permessiTypes = null;
				_permessiItems = null;
			}

			_view.EditMode = _editMode;

			_view.Modello = Mezzo.Modello ?? "";
			_view.Targa = Mezzo.Targa ?? "";
			_view.Numero = Mezzo.Numero;
			_view.NumeroCartaCircolazione = Mezzo.NumeroCartaCircolazione ?? "";
			_view.NumeroTelaio = Mezzo.NumeroTelaio ?? "";
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

				_dispositiviItems = new List<IDispositivoPermessoListItem>();
				foreach (var dt in _dispositiviTypes)
				{
					IDispositivo disp = (from d in _dispositiviTmp where d.Type == dt select d).ElementAtOrDefault(0);
					_dispositiviItems.Add(ClientSideInterfaceFactory.NewDispositivoPermessoListItem(disp != null, dt.Name, disp?.Allegato?.Path));
				}
				_view.Dispositivi = _dispositiviItems;

				_permessiItems = new List<IDispositivoPermessoListItem>();
				foreach (var pt in _permessiTypes)
				{
					IPermesso perm = (from p in _permessiTmp where p.Type == pt select p).ElementAtOrDefault(0);
					_permessiItems.Add(ClientSideInterfaceFactory.NewDispositivoPermessoListItem(perm != null, pt.Name, perm?.Allegato?.Path));
				}
				_view.Permessi = _permessiItems;
			}
			else
			{
				_view.Tessere = from t in Mezzo.Tessere orderby t.Type.Name select ClientSideInterfaceFactory.NewTesseraListItem(true, t.Type.Name, t.Codice, t.Pin);

				_view.Dispositivi = from d in Mezzo.Dispositivi orderby d.Type.Name select ClientSideInterfaceFactory.NewDispositivoPermessoListItem(true, d.Type.Name, d.Allegato?.Path);

				_view.Permessi = from p in Mezzo.Permessi orderby p.Type.Name select ClientSideInterfaceFactory.NewDispositivoPermessoListItem(true, p.Type.Name, p.Allegato?.Path);
			}
		}

		private void OnObjectChangedRemoved(IDBObject obj)
		{
			// Change in mezzo, and so tessere, dispositivi and permessi, are handled by parent presenters
			if (obj is ITesseraType || obj is IDispositivoType || obj is IPermessoType)
				Reload();
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
			ITesseraListItem ti = _tessereItems[index];
			ITessera t = (from tess in _tessereTmp where tess.Type == tt select tess).ElementAtOrDefault(0)
																				?? ModelFactory.NewTessera(Mezzo, tt);

			_tesseraPresenter = new UpdateTesseraPresenter(_server, t);
			_tesseraPresenter.PresenterClosed += () => _tesseraPresenter = null;
			_tesseraPresenter.TesseraUpdated += () =>
			{
				if (!_tessereTmp.Contains(t))
					_tessereTmp.Add(t);

				ti.InUse = true;
				ti.Codice = t.Codice;
				ti.Pin = t.Pin;

				_view.RefreshTessere();
			};
			_tesseraPresenter.ShowDialog();
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
			_view.RefreshTessere();
		}

		private void OnDispositivoPermessoEdit<T, O>(string desc, T type, IDispositivoPermessoListItem item,
													 List<O> list, Func<IMezzo, T, O> createNew, Action refresh)
			where T : LinkedType
			where O : class, ILinkedObjectWithPDF<T>
		{
			_dispositivoPermessoPresenter?.Close();
			if (!_editMode)
				return;

			var o = (from obj in list where obj.Type == type select obj).ElementAtOrDefault(0)
																		?? createNew(Mezzo, type);

			var presenter = new UpdateDispositivoPermessoPresenter<T, O>(_server, o, desc);
			_dispositivoPermessoPresenter = presenter;
			presenter.PresenterClosed += () => _dispositivoPermessoPresenter = null;
			presenter.DispositivoPermessoUpdated += () =>
			{
				if (!list.Contains(o))
					list.Add(o);

				item.InUse = true;
				item.AllegatoPath = o.Allegato?.Path;

				refresh();
			};
			presenter.ShowDialog();
		}
		private bool OnDispositivoPermessoRemove<T, O>(T type, IDispositivoPermessoListItem item, List<O> list) where T : LinkedType where O : ILinkedObject<T>
		{
			if (!_editMode)
				return false;

			item.InUse = false;
			item.AllegatoPath = null;
			list.Remove((from dp in list where dp.Type == type select dp).ElementAtOrDefault(0));

			return true;
		}

		private void OnDispositivoEdit(int index)
		{
			OnDispositivoPermessoEdit("Dispositivo", _dispositiviTypes[index], _dispositiviItems[index],
									  _dispositiviTmp, ModelFactory.NewDispositivo, _view.RefreshDispositivi);
		}
		private void OnDispositivoRemove(int index)
		{
			if (OnDispositivoPermessoRemove(_dispositiviTypes[index], _dispositiviItems[index], _dispositiviTmp))
				_view.RefreshDispositivi();
		}

		private void OnPermessoEdit(int index)
		{
			OnDispositivoPermessoEdit("Permesso", _permessiTypes[index], _permessiItems[index],
									  _permessiTmp, ModelFactory.NewPermesso, _view.RefreshPermessi);
		}
		private void OnPermessoRemove(int index)
		{
			if (OnDispositivoPermessoRemove(_permessiTypes[index], _permessiItems[index], _permessiTmp))
				_view.RefreshPermessi();
		}

		internal event Action MezzoSaved;
		private void OnSaveEdit()
		{
			if (!EditMode)
				return;

			var errors = _server.UpdateMezzo(Mezzo, null, _view.Modello, _view.Targa, _view.Numero, _view.NumeroCartaCircolazione,
											 null, _view.NumeroTelaio, _view.AnnoImmatricolazione, _view.Portata,
											 _view.Altezza, _view.Lunghezza, _view.Profondita, _view.VolumeCarico,
											 _tessereTmp, _dispositiviTmp, _permessiTmp);

			if (errors.Count() > 0)
				MessageBox.Show(String.Join("\r\n", errors), "Errore");
			else
			{
				// The tab will be automatically reloaded exiting edit mode automatically with the notification from the server
				MezzoSaved?.Invoke();
			}
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

		public void Close()
		{
			_server.ObjectChanged -= OnObjectChangedRemoved;
			_server.ObjectRemoved -= OnObjectChangedRemoved;
		}
	}
}
