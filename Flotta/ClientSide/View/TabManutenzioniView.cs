using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Flotta.ClientSide.View
{
	public interface ITabManutenzioniView
	{
		event Action NuovaManutenzione;
		IEnumerable<IManutenzioneListItem> Manutenzioni { get; set; }
		void RefreshManutenzioni();

		event Action<int> ViewOfficina;
		event Action<int> ModifyManutenzione;
		event Action<int> DeleteManutenzione;
	}

	internal partial class TabManutenzioniView : UserControl, ITabManutenzioniView
	{
		private readonly BindingList<IManutenzioneListItem> _manutenzioni = new BindingList<IManutenzioneListItem>();

		public TabManutenzioniView()
		{
			InitializeComponent();

			manutenzioniList.AutoGenerateColumns = false;
			manutenzioniList.DataSource = _manutenzioni;
			manutenzioniList.DisableSort();
		}

		public IEnumerable<IManutenzioneListItem> Manutenzioni
		{
			get
			{
				return _manutenzioni;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException("No manutenzioni specified");

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

		public event Action NuovaManutenzione;
		public void OnNewManutenzione(object sender, EventArgs e)
		{
			NuovaManutenzione?.Invoke();
		}

		public event Action<int> ViewOfficina;
		public event Action<int> ModifyManutenzione;
		public event Action<int> DeleteManutenzione;
		private void OnCellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Exclude click on header
			if (e.RowIndex < 0)
				return;

			if (e.ColumnIndex == 3)
				ViewOfficina?.Invoke(e.RowIndex);
			else if (e.ColumnIndex == 6)
				ModifyManutenzione?.Invoke(e.RowIndex);
			else if (e.ColumnIndex == 7)
				DeleteManutenzione?.Invoke(e.RowIndex);
		}
	}
}
