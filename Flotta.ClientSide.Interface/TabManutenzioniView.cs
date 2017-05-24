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
		event Action EnterEdit;
		event Action CancelEdit;
		event Action SaveEdit;
		event Action<int> ModifyManutenzione;
		event Action<int> DeleteManutenzione;
		event Action NuovaManutenzione;
		IEnumerable<IManutenzioneListItem> Manutenzioni { get; set; }
		void RefreshManutenzioni();
	}

	internal partial class TabManutenzioniView : UserControl, ITabManutenzioniView
	{
		private BindingList<IManutenzioneListItem> _manutenzioni = new BindingList<IManutenzioneListItem>();

		public TabManutenzioniView()
		{
			InitializeComponent();

			manutenzioniList.AutoGenerateColumns = false;
			manutenzioniList.DataSource = _manutenzioni;
		}

		public IEnumerable<IManutenzioneListItem> Manutenzioni
		{
			get
			{
				return _manutenzioni;
			}
			set
			{
				_manutenzioni.Clear();
				foreach (IManutenzioneListItem m in value)
				{
					_manutenzioni.Add(m);
				}
			}
		}

		public void RefreshManutenzioni()
		{
			manutenzioniList.Refresh();
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

		public event Action NuovaManutenzione;
		public void OnNewManutenzione(object sender, EventArgs e)
		{
			NuovaManutenzione?.Invoke();
		}



		public event Action<int> ModifyManutenzione;
		public event Action<int> DeleteManutenzione;
		private void OnCellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Exclude click on header
			if (e.RowIndex < 0)
				return;

			if (e.ColumnIndex == 4)
				ModifyManutenzione?.Invoke(e.RowIndex);
			if (e.ColumnIndex == 5)
				DeleteManutenzione?.Invoke(e.RowIndex);
		}



	}
}
