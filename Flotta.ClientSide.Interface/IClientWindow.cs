using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{

	public interface IClientWindow
	{
		void Show();
		IEnumerable<IMezzoListItem> MezziList { set; }
		IMezzoTabControl MezzoTabControl { get; }
		bool HasMezzo { set; }

		event GenericAction WindowClose;
		event MezzoListAction MezzoSelected;
		event GenericAction CreateNewMezzo;

		event GenericAction OpenTesseraTypes;
	}
}
