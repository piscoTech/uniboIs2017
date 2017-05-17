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
	public interface ITabGeneraleView
	{
		event GenericAction DeleteMezzo;
		event GenericAction EnterEdit;
		event GenericAction CancelEdit;
		event GenericAction SaveEdit;

		string Modello { get; set; }
		string Targa { get; set; }
		uint Numero { get; set; }
		string NumeroTelaio { get; set; }
		uint AnnoImmatricolazione { get; set; }
		float Portata { get; set; }
		float Altezza { get; set; }
		float Lunghezza { get; set; }
		float Profondita { get; set; }
		float VolumeCarico { get; set; }

		bool EditMode { set; }
	}

	internal partial class TabGeneraleView : UserControl, ITabGeneraleView
	{

		internal TabGeneraleView()
		{
			InitializeComponent();
		}

		public event GenericAction EnterEdit;
		private void OnEnterEdit(object sender, EventArgs e)
		{
			EnterEdit?.Invoke();
		}

		public event GenericAction CancelEdit;
		private void OnCancelEdit(object sender, EventArgs e)
		{
			CancelEdit?.Invoke();
		}

		public event GenericAction SaveEdit;
		private void OnSaveEdit(object sender, EventArgs e)
		{
			SaveEdit?.Invoke();
		}

		public string Modello
		{
			get => modello.Text;
			set => modello.Text = value;
		}

		public string Targa
		{
			get => targa.Text;
			set => targa.Text = value;
		}

		public uint Numero
		{
			get
			{
				try
				{
					return Convert.ToUInt32(numero.Text);
				}
				catch (Exception)
				{
					return 0;
				}
			}
			set => numero.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public string NumeroTelaio
		{
			get => numeroTelaio.Text;
			set => numeroTelaio.Text = value;
		}

		public uint AnnoImmatricolazione
		{
			get
			{
				try
				{
					return Convert.ToUInt32(annoImmatricolazione.Text);
				}
				catch (Exception)
				{
					return 0;
				}
			}
			set => annoImmatricolazione.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float Portata
		{
			get
			{
				if (portata.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(portata.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => portata.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float Altezza
		{
			get
			{
				if (altezza.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(altezza.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => altezza.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float Lunghezza
		{
			get
			{
				if (lunghezza.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(lunghezza.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => lunghezza.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float Profondita
		{
			get
			{
				if (profondita.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(profondita.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => profondita.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public float VolumeCarico
		{
			get
			{
				if (volumeCarico.Text == "")
					return 0;

				try
				{
					return Convert.ToSingle(volumeCarico.Text);
				}
				catch (Exception)
				{
					return -1;
				}
			}
			set => volumeCarico.Text = value > 0 ? Convert.ToString(value) : "";
		}

		public bool EditMode
		{
			set
			{
				enterEditBtn.Visible = !value;
				deleteBtn.Visible = !value;
				cancelEditBtn.Visible = value;
				saveEditBtn.Visible = value;

				foreach (var control in controlContainer.Controls)
				{
					if (control is TextBox text)
						text.ReadOnly = !value;
				}
			}
		}

		public event GenericAction DeleteMezzo;
		private void OnDelete(object sender, EventArgs e)
		{
			DeleteMezzo?.Invoke();
		}
	}
}
