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

	public interface INewManutenzioneDialog
	{
		DialogResult ShowDialog();
		void Close();

		bool ConfirmBeforeClosing { set; }
		event FormClosedEventHandler FormClosed;
		event GenericAction SaveManutenzione;
		event GenericAction CancelManutenzione;


		DateTime Data { get; set; }
		string Note { get; set; }
		string Tipo { get; set; }
		float Costo { get; set; }
		
	}

	public partial class NewManutenzioneDialog : Form, INewManutenzioneDialog
	{
		public NewManutenzioneDialog()
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
			set => data.Value = value;
		}

		public string Note
		{
			get => note.Text;
			set => note.Text = value;
		}

		public string Tipo
		{
			get => tipo.Text;
			set => tipo.Text = value;
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
			set => costo.Text = value > 0 ? Convert.ToString(value) : "";
		}

		
	}
}
