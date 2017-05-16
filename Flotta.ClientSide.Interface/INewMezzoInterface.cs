using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flotta.ClientSide.Interface
{
	public interface INewMezzoInterface
	{
		DialogResult ShowDialog();
		void Close();

		ITabGeneraleView TabGenerale { get; }

		bool ConfirmBeforeClosing { set; }
		event FormClosedEventHandler FormClosed;
		event GenericAction SaveMezzo;
	}
}
