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
	public partial class NewMezzoInterface : Form, INewMezzoInterface
	{

		private bool _confirmClose = true;

		public NewMezzoInterface()
		{
			InitializeComponent();

			tabViewGenerale.EditMode = true;
			tabViewGenerale.CancelEdit += () => this.Close();
			tabViewGenerale.SaveEdit += OnSaveEdit;
		}

		public bool ConfirmBeforeClosing
		{
			set => _confirmClose = value;
		}

		public ITabGeneraleView TabGenerale
		{
			get => tabViewGenerale;
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
