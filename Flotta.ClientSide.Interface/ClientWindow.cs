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
	public interface IClientWindow : ICloseableDisposable
	{
		void Show();
		IEnumerable<IMezzoListItem> MezziList { set; }
		IMezzoTabView MezzoTabControl { get; }
		bool HasMezzo { set; }
		void SetUserMode(string username, bool isAdmin);

		event Action WindowClose;
		event Action<int> MezzoSelected;
		event Action CreateNewMezzo;
		event Action ManageOfficine;

		event Action ChangePassword;
		event Action ManageUsers;

		void AddNewLinkedType(string title, Action handler);
	}

	internal partial class ClientWindow : Form, IClientWindow
	{

		private readonly BindingList<IMezzoListItem> _mezziList = new BindingList<IMezzoListItem>();

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

			mezziList.DisableSort();
			mezziList.DataSource = _mezziList;
		}

		public void SetUserMode(string username, bool isAdmin)
		{
			if (username == null)
				throw new ArgumentNullException("No username specified");

			currentUserItem.Text = "Benvenuto " + username;
			userAdminActionSeparator.Visible = manageUserItem.Visible = isAdmin;
		}

		public IEnumerable<IMezzoListItem> MezziList
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No mezzi specified");

				_mezziList.Clear();
				foreach (IMezzoListItem m in value)
				{
					_mezziList.Add(m);
				}
			}
		}

		public IMezzoTabView MezzoTabControl => mezzoTabView;
		public bool HasMezzo
		{
			set
			{
				noSelectionLbl.Visible = !value;
				mezzoTabView.Visible = value;
			}
		}

		public event Action WindowClose;
		private void CloseClient(object sender, FormClosedEventArgs e)
		{
			WindowClose();
		}

		public event Action<int> MezzoSelected;
		private void MezzoClicked(object sender, DataGridViewCellEventArgs e)
		{
			// Exclude click on header
			if (e.RowIndex < 0)
				return;

			MezzoSelected?.Invoke(e.RowIndex);
		}

		public event Action CreateNewMezzo;
		private void NewMezzo(object sender, EventArgs e)
		{
			CreateNewMezzo?.Invoke();
		}

		public void AddNewLinkedType(string title, Action handler)
		{
			if (String.IsNullOrEmpty(title))
				throw new ArgumentException("No title specified");

			if (handler == null)
				throw new ArgumentNullException("No handler specified");

			ToolStripMenuItem item = new ToolStripMenuItem()
			{
				Name = title + "MenuItem",
				Text = title
			};
			item.Click += (object sender, EventArgs e) => handler();

			tipiToolStripMenuItem.DropDownItems.Add(item);
		}

		public event Action ManageOfficine;
		private void OnManageOfficine(object sender, EventArgs e)
		{
			ManageOfficine?.Invoke();
		}

		public event Action ChangePassword;
		private void OnChangePassword(object sender, EventArgs e)
		{
			ChangePassword?.Invoke();
		}

		public event Action ManageUsers;
		private void OnManageUsers(object sender, EventArgs e)
		{
			ManageUsers?.Invoke();
		}
	}
}
