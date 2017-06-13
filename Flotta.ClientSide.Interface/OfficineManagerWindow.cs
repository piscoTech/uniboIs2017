using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flotta.ClientSide.Interface
{
	public interface IOfficineManagerWindow : ICloseableDisposable
	{
		void Show();
		event FormClosedEventHandler FormClosed;
		IEnumerable<ILinkedTypeListItem> OfficineList { set; }

		event Action CreateNewOfficina;
		event Action<int> DeleteOfficina;
		event Action<int> ViewOfficina;
	}

	internal partial class OfficineManagerWindow : Form, IOfficineManagerWindow
	{
		private readonly BindingList<ILinkedTypeListItem> _officinaList = new BindingList<ILinkedTypeListItem>();

		internal OfficineManagerWindow()
		{
			InitializeComponent();

			BindOfficineList();
		}

		private void BindOfficineList()
		{
			typeList.AutoGenerateColumns = false;

			DataGridViewCell cell = new DataGridViewTextBoxCell();
			DataGridViewTextBoxColumn colTypeName = new DataGridViewTextBoxColumn()
			{
				CellTemplate = cell,
				Name = "Nome",
				HeaderText = "Nome",
				DataPropertyName = "Description"
			};
			typeList.Columns.Add(colTypeName);

			cell = new DataGridViewCheckBoxCell();
			DataGridViewCheckBoxColumn colTypeDisabled = new DataGridViewCheckBoxColumn()
			{
				CellTemplate = cell,
				Name = "Disabilitato",
				HeaderText = "Disabilitato",
				DataPropertyName = "IsDisabled",
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 75
			};
			typeList.Columns.Add(colTypeDisabled);

			DataGridViewButtonColumn colTypeEdit = new DataGridViewButtonColumn()
			{
				HeaderText = "",
				Name = "Dettagli",
				Text = "Dettagli",
				UseColumnTextForButtonValue = true,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 60
			};
			typeList.Columns.Add(colTypeEdit);

			DataGridViewButtonColumn colTypeDelete = new DataGridViewButtonColumn()
			{
				HeaderText = "",
				Name = "Elimina",
				Text = "Elimina",
				UseColumnTextForButtonValue = true,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 60
			};
			typeList.Columns.Add(colTypeDelete);

			typeList.DisableSort();
			typeList.DataSource = _officinaList;
		}

		public IEnumerable<ILinkedTypeListItem> OfficineList
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No officine specified");

				_officinaList.Clear();
				foreach (ILinkedTypeListItem m in value)
				{
					_officinaList.Add(m);
				}
			}
		}

		public event Action CreateNewOfficina;
		private void OnCreateNewType(object sender, EventArgs e)
		{
			Console.WriteLine(CreateNewOfficina);
			CreateNewOfficina?.Invoke();
		}

		public event Action<int> DeleteOfficina;
		public event Action<int> ViewOfficina;
		private void OnCellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Exclude click on header
			if (e.RowIndex < 0)
				return;

			if (e.ColumnIndex == 2)
				ViewOfficina?.Invoke(e.RowIndex);
			if (e.ColumnIndex == 3)
				DeleteOfficina?.Invoke(e.RowIndex);
		}
	}
}
