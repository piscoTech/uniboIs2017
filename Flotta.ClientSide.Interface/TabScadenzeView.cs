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
	public interface ITabScadenzeView
	{
		IEnumerable<IScadenzaListItem> Scadenze { set; }
		void RefreshScadenze();

		event Action<int> ScadenzaEdit;
		event Action<int> ScadenzaRenew;
	}

	internal partial class TabScadenzeView : UserControl, ITabScadenzeView
	{
		private BindingList<IScadenzaListItem> _scadenzeList = new BindingList<IScadenzaListItem>();

		internal TabScadenzeView()
		{
			InitializeComponent();

			BindScadenzeList();
		}

		private void BindScadenzeList()
		{
			scadenzeList.AutoGenerateColumns = false;

			DataGridViewCell cell;
			cell = new DataGridViewTextBoxCell();
			DataGridViewTextBoxColumn colScadName = new DataGridViewTextBoxColumn()
			{
				CellTemplate = cell,
				Name = "Name",
				HeaderText = "Name",
				DataPropertyName = "Name"
			};
			scadenzeList.Columns.Add(colScadName);

			DataGridViewTextBoxColumn colScadDate = new DataGridViewTextBoxColumn()
			{
				CellTemplate = cell,
				Name = "Scadenza",
				HeaderText = "Scadenza",
				DataPropertyName = "DateDescription"
			};
			scadenzeList.Columns.Add(colScadDate);

			DataGridViewButtonColumn colScadEdit = new DataGridViewButtonColumn()
			{
				HeaderText = "",
				Name = "Modifica",
				Text = "Modifica",
				UseColumnTextForButtonValue = true,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 60
			};
			scadenzeList.Columns.Add(colScadEdit);

			DataGridViewButtonColumn colScadRenew = new DataGridViewButtonColumn()
			{
				HeaderText = "",
				Name = "Renew",
				Text = "Rinnova",
				UseColumnTextForButtonValue = true,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 60
			};
			scadenzeList.Columns.Add(colScadRenew);

			scadenzeList.DisableSort();
			scadenzeList.DataSource = _scadenzeList;
		}

		public IEnumerable<IScadenzaListItem> Scadenze
		{
			set
			{
				_scadenzeList.Clear();
				foreach (var s in value)
					_scadenzeList.Add(s);
			}
		}

		public void RefreshScadenze()
		{
			scadenzeList.Refresh();
		}

		public event Action<int> ScadenzaEdit;
		public event Action<int> ScadenzaRenew;
		private void OnScadenzaClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			if (e.ColumnIndex == 2)
				ScadenzaEdit?.Invoke(e.RowIndex);
			else if (e.ColumnIndex == 3 && _scadenzeList[e.RowIndex].CanRenew)
				ScadenzaRenew?.Invoke(e.RowIndex);
		}

		protected void OnScadenzaRowPaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			var rowStyle = scadenzeList.Rows[e.RowIndex].DefaultCellStyle;
			rowStyle.BackColor = _scadenzeList[e.RowIndex].Expired ? Color.Red : Color.Empty;
		}
	}
}
