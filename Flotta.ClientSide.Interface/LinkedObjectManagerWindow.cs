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
	public interface ILinkedObjectManagerWindow
	{
		DialogResult ShowDialog();
		event FormClosedEventHandler FormClosed;
		IEnumerable<ILinkedObjectListItem> TypeList { set; }

		event GenericAction CreateNewType;
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
			DataGridViewCheckBoxColumn colTypeDisabled = new DataGridViewCheckBoxColumn() {
				CellTemplate = cell,
				Name = "Disabilitato",
				HeaderText = "Disabilitato",
				DataPropertyName = "IsDisabled"
			};
			colTypeDisabled.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			colTypeDisabled.Width = 75;
			typeList.Columns.Add(colTypeDisabled);

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
	}
}
