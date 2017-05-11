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

	public delegate void MezzoTabAction(int index);

	internal partial class MezzoTabControl : UserControl, IMezzoTabControl
	{
		internal MezzoTabControl()
		{
			InitializeComponent();
		}

		public int CurrentTab
		{
			get
			{
				return tabControl.SelectedIndex;
			}
			set
			{
				tabControl.SelectedIndex = value;
			}
		}

		public ITabViewGenerale GeneraleTab
		{
			get => tabViewGenerale;
		}

		public event GenericAction ExitEdit;
		public event MezzoTabAction TabChanged;
		private void OnTabChange(object sender, TabControlEventArgs e)
		{
			ExitEdit?.Invoke();
			TabChanged?.Invoke(tabControl.SelectedIndex);
		}
	}
}
