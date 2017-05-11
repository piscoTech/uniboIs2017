using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flotta.ClientSide;

namespace Flotta.ClientSide.Interface
{

	public delegate void GenericAction();
	public delegate void MezzoListAction(int index);

	internal partial class ClientWindow : Form, IClientWindow
	{

		private BindingList<MezzoListItem> _mezziList = new BindingList<MezzoListItem>();

		internal ClientWindow()
		{
			InitializeComponent();

			HasMezzo = false;

			BindMezziList();
		}

		private void BindMezziList()
		{
			mezziList.AutoGenerateColumns = false;

			DataGridViewCell cell = new DataGridViewTextBoxCell();
			DataGridViewTextBoxColumn colMezziName = new DataGridViewTextBoxColumn()
			{
				CellTemplate = cell,
				Name = "Mezzi",
				HeaderText = "Mezzi",
				DataPropertyName = "Description"
			};
			mezziList.Columns.Add(colMezziName);

			mezziList.DataSource = _mezziList;
		}

		public List<IMezzoListItem> MezziList
		{
			set
			{
				_mezziList.Clear();
				foreach (IMezzoListItem m in value)
				{
					if (m is MezzoListItem) _mezziList.Add(m as MezzoListItem);
				}
			}
		}

		public IMezzoTabControl MezzoTabControl { get => mezzoTabControl; }
		public bool HasMezzo
		{
			set
			{
				noSelectionLbl.Visible = !value;
				mezzoTabControl.Visible = value;
			}
		}

		public event GenericAction WindowClose;
		private void CloseClient(object sender, FormClosedEventArgs e)
		{
			WindowClose();
		}

		public event MezzoListAction MezzoSelected;
		private void MezzoClicked(object sender, DataGridViewCellEventArgs e)
		{
			MezzoSelected?.Invoke(e.RowIndex);
		}

	}
}
