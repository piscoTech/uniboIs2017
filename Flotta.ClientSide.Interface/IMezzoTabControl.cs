using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public interface IMezzoTabControl
	{
		event GenericAction ExitEdit;
		event MezzoTabAction TabChanged;

		int CurrentTab { get; set; }

		ITabGeneraleView GeneraleTab { get; }
	}
}
