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
	internal partial class TabViewGenerale : UserControl, ITabViewGenerale
	{

		internal TabViewGenerale()
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

		public string Title
		{
			get => mezzoTitle.Text;
			set => mezzoTitle.Text = value;
		}

		public bool EditMode
		{
			set
			{
				enterEditBtn.Visible = !value;
				cancelEditBtn.Visible = value;
				saveEditBtn.Visible = value;
			}
		}

	}
}
