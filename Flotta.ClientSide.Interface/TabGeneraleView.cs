using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flotta.ClientSide.Interface
{
	public interface ITabGeneraleView
	{
		event Action DeleteMezzo;
		event Action EnterEdit;
		event Action CancelEdit;
		event Action SaveEdit;

		string Modello { get; set; }
		string Targa { get; set; }
		uint Numero { get; set; }
		string NumeroCartaCircolazione { get; set; }
		string NumeroTelaio { get; set; }
		uint AnnoImmatricolazione { get; set; }
		float Portata { get; set; }
		float Altezza { get; set; }
		float Lunghezza { get; set; }
		float Profondita { get; set; }
		float VolumeCarico { get; set; }

		IEnumerable<ITesseraListItem> Tessere { set; }
		IEnumerable<IDispositivoPermessoListItem> Dispositivi { set; }
		IEnumerable<IDispositivoPermessoListItem> Permessi { set; }

		void RefreshTessere();
		void RefreshDispositivi();
		void RefreshPermessi();

		event Action<int> TesseraEdit;
		event Action<int> TesseraRemove;

		event Action<int> DispositivoEdit;
		event Action<int> DispositivoRemove;

		event Action<int> PermessoEdit;
		event Action<int> PermessoRemove;

		bool EditMode { set; }
	}

	internal partial class TabGeneraleView : UserControl, ITabGeneraleView
	{
		private bool _editMode;
		private readonly BindingList<ITesseraListItem> _tessere = new BindingList<ITesseraListItem>();
		private readonly BindingList<IDispositivoPermessoListItem> _dispositivi = new BindingList<IDispositivoPermessoListItem>();
		private readonly BindingList<IDispositivoPermessoListItem> _permessi = new BindingList<IDispositivoPermessoListItem>();

		internal TabGeneraleView()
		{
			InitializeComponent();

			tessereList.AutoGenerateColumns = false;
			dispositiviList.AutoGenerateColumns = false;
			permessiList.AutoGenerateColumns = false;

			tessereList.DataSource = _tessere;
			dispositiviList.DataSource = _dispositivi;
			permessiList.DataSource = _permessi;
		}

		public event Action EnterEdit;
		private void OnEnterEdit(object sender, EventArgs e)
		{
			EnterEdit?.Invoke();
		}

		public event Action CancelEdit;
		private void OnCancelEdit(object sender, EventArgs e)
		{
			CancelEdit?.Invoke();
		}

		public event Action SaveEdit;
		private void OnSaveEdit(object sender, EventArgs e)
		{
			SaveEdit?.Invoke();
		}

		public event Action DeleteMezzo;
		private void OnDelete(object sender, EventArgs e)
		{
			DeleteMezzo?.Invoke();
		}

		public string Modello
		{
			get => modello.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No modello specified");

				modello.Text = value;
			}
		}

		public string Targa
		{
			get => targa.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No targa specified");

				targa.Text = value;
			}
		}

		public uint Numero
		{
			get
			{
				try
				{
					return Convert.ToUInt32(numero.Text);
				}
				catch (Exception)
				{
					return 0;
				}
			}
			set => numero.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public string NumeroCartaCircolazione
		{
			get => numCartaCircolazione.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No numero carta circolazione specified");

				numCartaCircolazione.Text = value;
			}
		}

		public string NumeroTelaio
		{
			get => numeroTelaio.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No numero telaio specified");

				numeroTelaio.Text = value;
			}
		}

		public uint AnnoImmatricolazione
		{
			get
			{
				try
				{
					return Convert.ToUInt32(annoImmatricolazione.Text);
				}
				catch (Exception)
				{
					return 0;
				}
			}
			set => annoImmatricolazione.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float Portata
		{
			get
			{
				if (portata.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(portata.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => portata.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float Altezza
		{
			get
			{
				if (altezza.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(altezza.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => altezza.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float Lunghezza
		{
			get
			{
				if (lunghezza.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(lunghezza.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => lunghezza.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float Profondita
		{
			get
			{
				if (profondita.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(profondita.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => profondita.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float VolumeCarico
		{
			get
			{
				if (volumeCarico.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(volumeCarico.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => volumeCarico.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public IEnumerable<ITesseraListItem> Tessere
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No tessere specified");

				_tessere.Clear();
				// As _tessere is the DataSource of the corresponding data grid we must change the existing collection
				foreach (var t in value)
					_tessere.Add(t);
			}
		}

		public IEnumerable<IDispositivoPermessoListItem> Dispositivi
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No dispositivi specified");

				_dispositivi.Clear();
				// As _tessere is the DataSource of the corresponding data grid we must change the existing collection
				foreach (var t in value)
					_dispositivi.Add(t);
			}
		}

		public IEnumerable<IDispositivoPermessoListItem> Permessi
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No permessi specified");

				_permessi.Clear();
				// As _tessere is the DataSource of the corresponding data grid we must change the existing collection
				foreach (var t in value)
					_permessi.Add(t);
			}
		}

		public void RefreshTessere()
		{
			tessereList.Refresh();
		}

		public void RefreshDispositivi()
		{
			dispositiviList.Refresh();
		}

		public void RefreshPermessi()
		{
			permessiList.Refresh();
		}

		public bool EditMode
		{
			set
			{
				_editMode = value;

				enterEditBtn.Visible = !value;
				deleteBtn.Visible = !value;
				cancelEditBtn.Visible = value;
				saveEditBtn.Visible = value;

				foreach (var control in controlContainer.Controls)
				{
					if (control is TextBox text)
						text.ReadOnly = !value;
				}

				#region Tessere List Setup
				{
					tessereList.Columns.Clear();

					DataGridViewCell cell;
					if (value)
					{
						cell = new DataGridViewCheckBoxCell();
						DataGridViewCheckBoxColumn colTypeInUse = new DataGridViewCheckBoxColumn()
						{
							CellTemplate = cell,
							Name = "InUse",
							HeaderText = "",
							DataPropertyName = "InUse",
							AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
							Width = 20
						};
						tessereList.Columns.Add(colTypeInUse);
					}

					cell = new DataGridViewTextBoxCell();
					DataGridViewTextBoxColumn colTypeName = new DataGridViewTextBoxColumn()
					{
						CellTemplate = cell,
						Name = "Tessere",
						HeaderText = "Tessere",
						DataPropertyName = "Type"
					};
					tessereList.Columns.Add(colTypeName);

					DataGridViewTextBoxColumn colCode = new DataGridViewTextBoxColumn()
					{
						CellTemplate = cell,
						Name = "Codice",
						HeaderText = "Codice",
						DataPropertyName = "Codice"
					};
					tessereList.Columns.Add(colCode);

					DataGridViewTextBoxColumn colPin = new DataGridViewTextBoxColumn()
					{
						CellTemplate = cell,
						Name = "PIN",
						HeaderText = "PIN",
						DataPropertyName = "Pin"
					};
					tessereList.Columns.Add(colPin);

					if (value)
					{
						DataGridViewButtonColumn colTypeEdit = new DataGridViewButtonColumn()
						{
							HeaderText = "",
							Name = "Modifica",
							Text = "Modifica",
							UseColumnTextForButtonValue = true,
							AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
							Width = 60
						};
						tessereList.Columns.Add(colTypeEdit);

						DataGridViewButtonColumn colTypeRemove = new DataGridViewButtonColumn()
						{
							HeaderText = "",
							Name = "Rimuovi",
							Text = "Rimuovi",
							UseColumnTextForButtonValue = true,
							AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
							Width = 60
						};
						tessereList.Columns.Add(colTypeRemove);
					}

					tessereList.DisableSort();
					tessereList.Refresh();
				}
				#endregion

				#region Dispositivi & Permessi List Setup
				foreach (var group in new Tuple<DataGridView, string>[] { new Tuple<DataGridView, string>(dispositiviList, "Dispositivi"), new Tuple<DataGridView, string>(permessiList, "Permessi") })
				{
					var list = group.Item1;
					list.Columns.Clear();

					DataGridViewCell cell;
					if (value)
					{
						cell = new DataGridViewCheckBoxCell();
						DataGridViewCheckBoxColumn colTypeInUse = new DataGridViewCheckBoxColumn()
						{
							CellTemplate = cell,
							Name = "InUse",
							HeaderText = "",
							DataPropertyName = "InUse",
							AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
							Width = 20
						};
						list.Columns.Add(colTypeInUse);
					}

					cell = new DataGridViewTextBoxCell();
					DataGridViewTextBoxColumn colTypeName = new DataGridViewTextBoxColumn()
					{
						CellTemplate = cell,
						Name = group.Item2,
						HeaderText = group.Item2,
						DataPropertyName = "Type"
					};
					list.Columns.Add(colTypeName);

					DataGridViewTextBoxColumn colAttachment = new DataGridViewTextBoxColumn()
					{
						CellTemplate = cell,
						Name = "Allegato",
						HeaderText = "Allegato",
						DataPropertyName = "AllegatoPath"
					};
					list.Columns.Add(colAttachment);

					if (value)
					{
						DataGridViewButtonColumn colTypeEdit = new DataGridViewButtonColumn()
						{
							HeaderText = "",
							Name = "Modifica",
							Text = "Modifica",
							UseColumnTextForButtonValue = true,
							AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
							Width = 60
						};
						list.Columns.Add(colTypeEdit);

						DataGridViewButtonColumn colTypeRemove = new DataGridViewButtonColumn()
						{
							HeaderText = "",
							Name = "Rimuovi",
							Text = "Rimuovi",
							UseColumnTextForButtonValue = true,
							AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
							Width = 60
						};
						list.Columns.Add(colTypeRemove);
					}
					list.DisableSort();
				}
				#endregion
			}
		}

		public event Action<int> TesseraEdit;
		public event Action<int> TesseraRemove;
		private void OnTesseraClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || !_editMode)
				return;

			if (e.ColumnIndex == 4)
				TesseraEdit?.Invoke(e.RowIndex);
			else if (e.ColumnIndex == 5)
				TesseraRemove?.Invoke(e.RowIndex);
		}

		public event Action<int> DispositivoEdit;
		public event Action<int> DispositivoRemove;
		private void OnDispositivoClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || !_editMode)
				return;

			if (e.ColumnIndex == 3)
				DispositivoEdit?.Invoke(e.RowIndex);
			else if (e.ColumnIndex == 4)
				DispositivoRemove?.Invoke(e.RowIndex);
		}

		public event Action<int> PermessoEdit;
		public event Action<int> PermessoRemove;
		private void OnPermessoClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || !_editMode)
				return;

			if (e.ColumnIndex == 3)
				PermessoEdit?.Invoke(e.RowIndex);
			else if (e.ColumnIndex == 4)
				PermessoRemove?.Invoke(e.RowIndex);
		}
	}
}
