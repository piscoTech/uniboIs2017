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
	internal class TabScadenzePresenter : ITabPresenter
	{

		private IServer _server;
		private ITabScadenzeView _view;

		private MezzoTabPresenter _tabs;

		private List<IScadenzaAdapter> _scadenze = new List<IScadenzaAdapter>();
		private List<IScadenzaListItem> _scadenzeItem = new List<IScadenzaListItem>();

		private IScadenzaAdapter _activeScad = null;
		private UpdateScadenzaPresenter _updatePresenter = null;
		private IRenewScadenzaDialog _renewDialog = null;

		internal TabScadenzePresenter(IServer server, MezzoTabPresenter tabs, ITabScadenzeView view)
		{
			_tabs = tabs;

			_server = server;
			_view = view;

			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;

			_view.ScadenzaEdit += OnScadenzaEdit;
			_view.ScadenzaRenew += OnScadenzaRenew;
		}

		public void Reload()
		{
			if (_tabs.Mezzo == null)
				return;

			_updatePresenter?.Close();
			_renewDialog?.Close();
			_renewDialog?.Dispose();
			_activeScad = null;

			_scadenze.Clear();
			_scadenzeItem.Clear();

			_scadenze.AddRange(ModelFactory.GetScadenzeForMezzo(_tabs.Mezzo));
			_scadenze.AddRange(from t in _tabs.Mezzo.Tessere orderby t.Type.Name select t);
			_scadenze.AddRange(from d in _tabs.Mezzo.Dispositivi orderby d.Type.Name select d);
			_scadenze.AddRange(from p in _tabs.Mezzo.Permessi orderby p.Type.Name select p);

			UpdateItems(null);
			_view.Scadenze = _scadenzeItem;
		}

		private void UpdateItems(IScadenzaAdapter scadOwner)
		{
			if (scadOwner != null)
			{
				int index = _scadenze.IndexOf(scadOwner);
				if (index < 0)
				{
					Reload();
					return;
				}
				IScadenzaListItem item = _scadenzeItem.ElementAtOrDefault(index);
				if (item != null)
				{
					item.Date = scadOwner.Scadenza?.DateDescription;
					item.Expired = scadOwner.Scadenza?.Expired ?? false;
				}
				else
					Reload();
			}
			else
			{
				_scadenzeItem.AddRange(from s in _scadenze
									   select ClientSideInterfaceFactory.NewScadenzaListItem(s.ScadenzaName,
																							 s.Scadenza?.DateDescription,
																							 s.Scadenza?.Expired ?? false,
																							 s.Scadenza?.HasDate ?? false
																							));
			}
		}

		private void OnObjectChanged(IDBObject obj)
		{
			if (obj is IScadenzaAdapter scadOwner && scadOwner.Mezzo == _tabs.Mezzo)
			{
				if (_scadenze.Contains(scadOwner))
				{
					UpdateItems(scadOwner);
					_view.RefreshScadenze();
				}
				else
					Reload();
			}
			else if (obj is ITesseraType || obj is IDispositivoType || obj is IPermessoType)
				Reload();
		}
		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is IScadenzaAdapter scadOwner && scadOwner.Mezzo == _tabs.Mezzo)
			{
				if (scadOwner == _activeScad)
				{
					_renewDialog?.Close();
					_renewDialog?.Dispose();
				}
				Reload();
			}
		}

		public void OnCancelEdit()
		{
		}

		private void OnScadenzaEdit(int index)
		{
			_updatePresenter = new UpdateScadenzaPresenter(_server, _scadenze[index]);
			_updatePresenter.PresenterClosed += () => _updatePresenter = null;
			_updatePresenter.ShowDialog();
		}

		private void OnScadenzaRenew(int index)
		{
			IScadenzaAdapter scad = _scadenze[index];
			Scadenza newScad = scad.Scadenza.Clone() as Scadenza;
			if (scad.Scadenza.HasRecurrencyPeriod)
			{
				newScad.SetNextDate();
				_server.UpdateScadenza(scad, newScad);
			}
			else
			{
				_activeScad = scad;

				using (_renewDialog = ClientSideInterfaceFactory.NewRenewScadenzaDialog())
				{
					_renewDialog.Date = newScad.Date;
					_renewDialog.ScadName = scad.ScadenzaName;
					_renewDialog.Validation = () =>
					{
						try
						{
							newScad.Date = _renewDialog.Date;
							return true;
						}
						catch (Exception e)
						{
							MessageBox.Show(e.Message, "Errore");
							return false;
						}
					};

					if (_renewDialog.ShowDialog() == DialogResult.OK)
					{
						_server.UpdateScadenza(_activeScad, newScad);
					}
				}
				_renewDialog = null;
				_activeScad = null;
			}
		}
	}
}
