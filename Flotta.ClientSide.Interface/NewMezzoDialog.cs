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
	public interface INewMezzoDialog
	{
		DialogResult ShowDialog();
		void Close();

		ITabGeneraleView TabGenerale { get; }

		bool ConfirmBeforeClosing { set; }
		event FormClosedEventHandler FormClosed;
		event GenericAction SaveMezzo;
	}

	public partial class NewMezzoDialog : Form, INewMezzoDialog
	{

		private bool _confirmClose = true;

		public NewMezzoDialog()
		{
			InitializeComponent();

			tabGeneraleView.EditMode = true;
			tabGeneraleView.CancelEdit += () => this.Close();
			tabGeneraleView.SaveEdit += OnSaveEdit;
		}

		public bool ConfirmBeforeClosing
		{
			set => _confirmClose = value;
		}

		public ITabGeneraleView TabGenerale
		{
			get => tabGeneraleView;
		}

		public event GenericAction SaveMezzo;
		private void OnSaveEdit()
		{
			SaveMezzo?.Invoke();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			if (_confirmClose)
			{
				if (MessageBox.Show("Sei sicuro di voler annullare la creazione del mezzo?", "Annulla creazione?", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					e.Cancel = true;
				}
			}
		}

	}
}
