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
	public delegate void TypeListAction(int index);

	public interface ILinkedObjectManagerWindow
	{
		void Show();
		event FormClosedEventHandler FormClosed;
		IEnumerable<ILinkedObjectListItem> TypeList { set; }

		event GenericAction CreateNewType;
		event TypeListAction DeleteType;
		event TypeListAction EditType;
	}

	partial class LinkedObjectManagerWindow : Form, ILinkedObjectManagerWindow
	{

		private BindingList<ILinkedObjectListItem> _typeList
			= new BindingList<ILinkedObjectListItem>();

		public LinkedObjectManagerWindow()
		{
			InitializeComponent();

			BindMezziList();
		}

		private void BindMezziList()
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

			typeList.DataSource = _typeList;
		}

		public IEnumerable<ILinkedObjectListItem> TypeList
		{
			set
			{
				_typeList.Clear();
				foreach (ILinkedObjectListItem m in value)
				{
					_typeList.Add(m);
				}
			}
		}

		public event GenericAction CreateNewType;
		private void OnCreateNewType(object sender, EventArgs e)
		{
			Console.WriteLine(CreateNewType);
			CreateNewType?.Invoke();
		}

		public event TypeListAction DeleteType;
		public event TypeListAction EditType;
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
	}
}
