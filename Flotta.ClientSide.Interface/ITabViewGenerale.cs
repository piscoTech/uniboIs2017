using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public interface ITabViewGenerale
	{
		event GenericAction EnterEdit;
		event GenericAction CancelEdit;
		event GenericAction SaveEdit;

		string Title { get; set; }
		bool EditMode { set; }
	}
}
