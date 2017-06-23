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
	public interface IUpdateOfficinaDialog : ICloseableDisposable
	{
		DialogResult ShowDialog();

		string Nome { get; set; }
		string Telefono { get; set; }
		string Via { get; set; }
		string Cap { get; set; }
		string Citta { get; set; }
		string Provincia { get; set; }
		string Nazione { get; set; }

		bool EditMode { set; }
		event Action EnterEdit, SaveEdit, CancelEdit;
	}

	internal partial class UpdateOfficinaDialog : Form, IUpdateOfficinaDialog
	{
		internal UpdateOfficinaDialog()
		{
			InitializeComponent();
		}

		public string Nome
		{
			get => name.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No name specified");

				name.Text = value;
			}
		}

		public string Telefono
		{
			get => phone.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No phone specified");

				phone.Text = value;
			}
		}

		public string Via
		{
			get => street.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No street specified");

				street.Text = value;
			}
		}

		public string Cap
		{
			get => zipCode.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No zip code specified");

				zipCode.Text = value;
			}
		}

		public string Citta
		{
			get => city.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No city specified");

				city.Text = value;
			}
		}

		public string Provincia
		{
			get => province.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No province specified");

				province.Text = value;
			}
		}

		public string Nazione
		{
			get => state.Text;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No state specified");

				state.Text = value;
			}
		}

		public bool EditMode
		{
			set
			{
				foreach (var control in controlContainer.Controls)
				{
					if (control is TextBox text)
						text.ReadOnly = !value;
				}

				saveBtn.Visible = cancelBtn.Visible = value;
				editBtn.Visible = !value;
			}
		}

		public event Action EnterEdit;
		private void OnEdit(object sender, EventArgs e)
		{
			EnterEdit?.Invoke();
		}

		public event Action SaveEdit;
		private void OnSave(object sender, EventArgs e)
		{
			SaveEdit?.Invoke();
		}

		public event Action CancelEdit;
		private void OnCancelEdit(object sender, EventArgs e)
		{
			CancelEdit?.Invoke();
		}
	}
}
