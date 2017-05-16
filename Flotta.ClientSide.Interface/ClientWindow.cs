using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flotta.ClientSide;

namespace Flotta.ClientSide.Interface
{
	public delegate void GenericAction();
	public delegate void MezzoListAction(int index);

	public interface IClientWindow
	{
		void Show();
		IEnumerable<IMezzoListItem> MezziList { set; }
		IMezzoTabView MezzoTabControl { get; }
		bool HasMezzo { set; }

		event GenericAction WindowClose;
		event MezzoListAction MezzoSelected;
		event GenericAction CreateNewMezzo;

		event GenericAction OpenTesseraTypes;
	}

	internal partial class ClientWindow : Form, IClientWindow
	{

		private BindingList<IMezzoListItem> _mezziList = new BindingList<IMezzoListItem>();

		internal ClientWindow()
		{
			InitializeComponent();

			HasMezzo = false;

			BindMezziList();
		}

		private void BindMezziList()
		{
			mezziList.AutoGenerateColumns = false;

			DataGridViewCell cell = new DataGridViewTextBoxCell();
			DataGridViewTextBoxColumn colMezziName = new DataGridViewTextBoxColumn()
			{
				CellTemplate = cell,
				Name = "Mezzi",
				HeaderText = "Mezzi",
				DataPropertyName = "Description"
			};
			mezziList.Columns.Add(colMezziName);

			mezziList.DataSource = _mezziList;
		}

		public IEnumerable<IMezzoListItem> MezziList
		{
			set
			{
				_mezziList.Clear();
				foreach (IMezzoListItem m in value)
				{
					_mezziList.Add(m);
				}
			}
		}

		public IMezzoTabView MezzoTabControl { get => mezzoTabControl; }
		public bool HasMezzo
		{
			set
			{
				noSelectionLbl.Visible = !value;
				mezzoTabControl.Visible = value;
			}
		}

		public event GenericAction WindowClose;
		private void CloseClient(object sender, FormClosedEventArgs e)
		{
			WindowClose();
		}

		public event MezzoListAction MezzoSelected;
		private void MezzoClicked(object sender, DataGridViewCellEventArgs e)
		{
			// Exclude click on header
			if (e.RowIndex < 0)
				return;

			MezzoSelected?.Invoke(e.RowIndex);
		}

		public event GenericAction CreateNewMezzo;
		private void NewMezzo(object sender, EventArgs e)
		{
			CreateNewMezzo?.Invoke();
		}

		public event GenericAction OpenTesseraTypes;
		private void OnOpenTesseraTypes(object sender, EventArgs e)
		{
			OpenTesseraTypes?.Invoke();
		}

		private void OnOpenDispositivoTypes(object sender, EventArgs e)
		{

		}

		private void OnOpenPermessoTypes(object sender, EventArgs e)
		{

		}

		private void OnOpenManutenzioneTypes(object sender, EventArgs e)
		{

		}
	}
}
