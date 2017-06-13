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
	public interface ILinkedTypesManagerWindow : ICloseableDisposable
	{
		void Show();
		event FormClosedEventHandler FormClosed;
		IEnumerable<ILinkedTypeListItem> TypesList { set; }
		string TypeName { set; }

		event Action CreateNewType;
		event Action<int> DeleteType;
		event Action<int> EditType;
	}

	partial class LinkedTypesManagerWindow : Form, ILinkedTypesManagerWindow
	{
		private readonly BindingList<ILinkedTypeListItem> _typeList = new BindingList<ILinkedTypeListItem>();

		public LinkedTypesManagerWindow()
		{
			InitializeComponent();

			BindTypesList();
		}

		private void BindTypesList()
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
				Name = "Modifica",
				Text = "Modifica",
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
			typeList.DataSource = _typeList;
		}

		public IEnumerable<ILinkedTypeListItem> TypesList
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No types specified");

				_typeList.Clear();
				foreach (ILinkedTypeListItem m in value)
				{
					_typeList.Add(m);
				}
			}
		}

		public event Action CreateNewType;
		private void OnCreateNewType(object sender, EventArgs e)
		{
			CreateNewType?.Invoke();
		}

		public event Action<int> DeleteType;
		public event Action<int> EditType;
		private void OnCellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Exclude click on header
			if (e.RowIndex < 0)
				return;

			if (e.ColumnIndex == 2)
				EditType?.Invoke(e.RowIndex);
			if (e.ColumnIndex == 3)
				DeleteType?.Invoke(e.RowIndex);
		}

		public string TypeName
		{
			set => this.Text = "Tipi " + value + " – Flotta";
		}
	}
}
