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

	public interface IMezzoTabView
	{
		event Action ExitEdit;
		event MezzoTabAction TabChanged;

		int CurrentTab { get; set; }

		ITabGeneraleView GeneraleTab { get; }
	}

	internal partial class MezzoTabView : UserControl, IMezzoTabView
	{
		internal MezzoTabView()
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

		public ITabGeneraleView GeneraleTab
		{
			get => tabGeneraleView;
		}

		public event Action ExitEdit;
		public event MezzoTabAction TabChanged;
		private void OnTabChange(object sender, TabControlEventArgs e)
		{
			ExitEdit?.Invoke();
			TabChanged?.Invoke(tabControl.SelectedIndex);
		}
	}
}
