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

	public interface INewManutenzioneDialog : IDisposable
	{
		DialogResult ShowDialog();
		void Close();

		bool ConfirmBeforeClosing { set; }
		event FormClosedEventHandler FormClosed;
		event GenericAction SaveManutenzione;
		event GenericAction CancelManutenzione;


		DateTime Data { get; }
		string Note { get; }
		int Tipo { get; set; }
		IList<string> Types { set; }
		float Costo { get; }

	}

	internal partial class NewManutenzioneDialog : Form, INewManutenzioneDialog
	{
		internal NewManutenzioneDialog()
		{
			InitializeComponent();
			
		}

		private bool _confirmClose = true;
		public bool ConfirmBeforeClosing
		{
			set => _confirmClose = value;
		}

		public event GenericAction SaveManutenzione;
		private void OnSaveManutenzione(object sender, EventArgs e)
		{
			SaveManutenzione?.Invoke();
		}

		public event GenericAction CancelManutenzione;
		private void OnCancelManutenzione(object sender, EventArgs e)
		{
			CancelManutenzione?.Invoke();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			if (_confirmClose)
			{
				if (MessageBox.Show("Sei sicuro di voler annullare la creazione della manutenzione?", "Annulla creazione?", MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					e.Cancel = true;
				}
			}
		}



		public DateTime Data
		{
			get => data.Value;
		}

		public string Note
		{
			get => note.Text;
		}

		public int Tipo
		{
			get => types.SelectedIndex;
			set => types.SelectedIndex = value;
		}

		public IList<string> Types
		{
			set => types.DataSource = value;
		}



		public float Costo
		{
			get
			{
				try
				{
					return Convert.ToSingle(costo.Text);
				}
				catch (Exception)
				{
					return 0;
				}
			}
		}


	}
}
