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
		event Action SaveManutenzione;
		event Action CancelManutenzione;

		DateTime Data { get; set; }
		string Note { get; set; }
		int Tipo { get; set; }
		IList<string> Types { set; }
		float Costo { get; set; }

	}

	internal partial class NewManutenzioneDialog : Form, INewManutenzioneDialog
	{
		internal NewManutenzioneDialog()
		{
			InitializeComponent();

		}

		internal NewManutenzioneDialog(DateTime d, string n, float c) : this()
		{
			data.Value = d;
			note.Text = n;
			costo.Text = Convert.ToString(c);
		}

		private bool _confirmClose = true;
		public bool ConfirmBeforeClosing
		{
			set => _confirmClose = value;
		}

		public event Action SaveManutenzione;
		private void OnSaveManutenzione(object sender, EventArgs e)
		{
			SaveManutenzione?.Invoke();
		}

		public event Action CancelManutenzione;
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
			set => costo.Text = Convert.ToString(value);
		}
	}
}
