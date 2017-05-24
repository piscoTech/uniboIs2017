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
	public interface IUpdateScadenzaDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();
		string ScadenzaName { set; }

		IList<string> Types { set; }
		int SelectedType { get; set; }

		DateTime Date { get; set; }

		IList<string> Formats { set; }
		int SelectedFormat { get; set; }

		int RecurCount { get; set; }
		int RecurSelectedType { get; set; }

		bool DateFieldsVisible { set; }
		bool RecurFieldVisible { set; }

		Func<bool> Validation { set; }
		event Action TypeChanged;
	}

	internal partial class UpdateScadenzaDialog : Form, IUpdateScadenzaDialog
	{
		private Func<bool> _validation;

		internal UpdateScadenzaDialog()
		{
			InitializeComponent();
		}

		public string ScadenzaName
		{
			set => this.Text = "Modifica scadenza – " + value + " – Flotta";
		}

		public IList<string> Types
		{
			set => type.DataSource = value;
		}

		public int SelectedType
		{
			get => type.SelectedIndex;
			set => type.SelectedIndex = value;
		}

		public DateTime Date
		{
			get => date.Value;
			set => date.Value = value;
		}

		public IList<string> Formats
		{
			set => format.DataSource = value;
		}

		public int SelectedFormat
		{
			get => format.SelectedIndex;
			set => format.SelectedIndex = value;
		}

		public int RecurCount
		{
			get
			{
				try
				{
					return Convert.ToInt32(recurNum.Text);
				}
				catch (Exception)
				{
					return 0;
				}
			}
			set => recurNum.Text = Convert.ToString(value);
		}

		public int RecurSelectedType
		{
			get => recurType.SelectedIndex;
			set => recurType.SelectedIndex = value;
		}

		public bool DateFieldsVisible
		{
			set => dateFields.Visible = value;
		}

		public bool RecurFieldVisible
		{
			set => recurFields.Visible = value;
		}

		public event Action TypeChanged;
		private void OnTypeChanged(object sender, EventArgs e)
		{
			TypeChanged?.Invoke();
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
