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
	public interface IUsersManagerWindow : ICloseableDisposable
	{
		void Show();
		event FormClosedEventHandler FormClosed;
		IEnumerable<IUserListItem> UsersList { set; }

		event Action CreateNewUser;
		event Action<int> DeleteUser;
		event Action<int> EditUser;
	}

	partial class UsersManagerWindow : Form, IUsersManagerWindow
	{
		private readonly BindingList<IUserListItem> _usersList
			= new BindingList<IUserListItem>();

		public UsersManagerWindow()
		{
			InitializeComponent();

			BindUsersList();
		}

		private void BindUsersList()
		{
			usersList.AutoGenerateColumns = false;

			DataGridViewCell cell = new DataGridViewTextBoxCell();
			DataGridViewTextBoxColumn colTypeName = new DataGridViewTextBoxColumn()
			{
				CellTemplate = cell,
				Name = "Username",
				HeaderText = "Username",
				DataPropertyName = "Username"
			};
			usersList.Columns.Add(colTypeName);

			cell = new DataGridViewCheckBoxCell();
			DataGridViewCheckBoxColumn colTypeAdmin = new DataGridViewCheckBoxColumn()
			{
				CellTemplate = cell,
				Name = "Admin",
				HeaderText = "Admin",
				DataPropertyName = "IsAdmin",
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 75
			};
			usersList.Columns.Add(colTypeAdmin);

			DataGridViewButtonColumn colTypeEdit = new DataGridViewButtonColumn()
			{
				HeaderText = "",
				Name = "Modifica",
				Text = "Modifica",
				UseColumnTextForButtonValue = true,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 60
			};
			usersList.Columns.Add(colTypeEdit);

			DataGridViewButtonColumn colTypeDelete = new DataGridViewButtonColumn()
			{
				HeaderText = "",
				Name = "Elimina",
				Text = "Elimina",
				UseColumnTextForButtonValue = true,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 60
			};
			usersList.Columns.Add(colTypeDelete);

			usersList.DisableSort();
			usersList.DataSource = _usersList;
		}

		public IEnumerable<IUserListItem> UsersList
		{
			set
			{
				if (value == null)
					throw new ArgumentNullException("No users specified");

				_usersList.Clear();
				foreach (IUserListItem u in value)
				{
					_usersList.Add(u);
				}
			}
		}

		public event Action CreateNewUser;
		private void OnCreateNewUser(object sender, EventArgs e)
		{
			CreateNewUser?.Invoke();
		}

		public event Action<int> DeleteUser;
		public event Action<int> EditUser;
		private void OnCellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Exclude click on header
			if (e.RowIndex < 0)
				return;

			if (e.ColumnIndex == 2)
				EditUser?.Invoke(e.RowIndex);
			if (e.ColumnIndex == 3)
				DeleteUser?.Invoke(e.RowIndex);
		}
	}
}
