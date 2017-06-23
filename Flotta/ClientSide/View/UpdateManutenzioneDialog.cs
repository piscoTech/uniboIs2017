using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flotta.ClientSide.View
{
	public interface IUpdateManutenzioneDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();

		DateTime Data { get; set; }
		string Note { get; set; }
		int Tipo { get; set; }
		int Officina { get; set; }
		IList<string> Types { set; }
		IList<string> Officine { set; }
		float Costo { get; set; }

		Func<bool> Validation { set; }
	}

	internal partial class UpdateManutenzioneDialog : Form, IUpdateManutenzioneDialog
	{
		private Func<bool> _validation;

		internal UpdateManutenzioneDialog()
		{
			InitializeComponent();
		}

		public DateTime Data
		{
			get => date.Value;
			set => date.Value = value;
		}

		public string Note
		{
			get => notes.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No note specified");

				notes.Text = value;
			}
		}

		public int Tipo
		{
			get => type.SelectedIndex;
			set => type.SelectedIndex = value;
		}

		public int Officina
		{
			get => officina.SelectedIndex;
			set => officina.SelectedIndex = value;
		}

		public IList<string> Types
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No types specified");

				type.DataSource = value;
			}
		}

		public IList<string> Officine
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No officine specified");

				officina.DataSource = value;
			}
		}

		public float Costo
		{
			get
			{
				try
				{
					return Convert.ToSingle(cost.Text);
				}
				catch (Exception)
				{
					return 0;
				}
			}
			set => cost.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public Func<bool> Validation
		{
			set => _validation = value;
		}

		private void OnSave(object sender, EventArgs e)
		{
			this.DialogResult = (_validation?.Invoke() ?? false) ? DialogResult.OK : DialogResult.None;
		}
	}
}
