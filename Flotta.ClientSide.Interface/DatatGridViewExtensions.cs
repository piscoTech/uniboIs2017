using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flotta.ClientSide.Interface
{
	public static class DatatGridViewExtensions
	{
		public static void SetSortMode(this DataGridView dataGridView, DataGridViewColumnSortMode sortMode)
		{
			dataGridView.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = sortMode);
		}

		public static void DisableSort(this DataGridView dataGridView)
		{
			dataGridView.SetSortMode(DataGridViewColumnSortMode.NotSortable);
		}
	}
}
