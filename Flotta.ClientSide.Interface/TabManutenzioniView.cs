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
	public interface ITabManutenzioniView
	{
		event GenericAction EnterEdit;
		event GenericAction CancelEdit;
		event GenericAction SaveEdit;
		DataGridView ManutenzioniList { get; }
		event Action NuovaManutenzione;
	}

	internal partial class TabManutenzioniView : UserControl, ITabManutenzioniView
	{
		public TabManutenzioniView()
		{
			InitializeComponent();
		}

		

		public event GenericAction EnterEdit;
		private void OnEnterEdit(object sender, EventArgs e)
		{
			EnterEdit?.Invoke();
		}

		public event GenericAction CancelEdit;
		private void OnCancelEdit(object sender, EventArgs e)
		{
			CancelEdit?.Invoke();
		}

		public event GenericAction SaveEdit;
		private void OnSaveEdit(object sender, EventArgs e)
		{
			SaveEdit?.Invoke();
		}

		public event Action NuovaManutenzione;
		public void OnNewManutenzione(object sender, EventArgs e)
		{
			NuovaManutenzione?.Invoke();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		public DataGridView ManutenzioniList
		{
			get => dataGridView1;
		}



	}
}
