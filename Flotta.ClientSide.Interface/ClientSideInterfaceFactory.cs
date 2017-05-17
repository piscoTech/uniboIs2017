using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public static class ClientSideInterfaceFactory
	{

		public static IClientWindow NewClientWindow()
		{
			return new ClientWindow();
		}

		public static IMezzoListItem NewMezzoListItem(uint numero, string modello, string targa)
		{
			return new MezzoListItem(numero, modello, targa);
		}

		public static INewMezzoDialog NewNewMezzoDialog()
		{
			return new NewMezzoDialog();
		}

		public static ILinkedObjectManagerWindow NewLinkedObjectManagerWindow()
		{
			return new LinkedObjectManagerWindow();
		}

		public static ILinkedObjectListItem NewLinkedObjectListItem(string name, bool disabled)
		{
			return new LinkedObjectListItem(name, disabled);
		}

		public static IUpdateLinkedObjectDialog NewUpdateLinkedObjectDialog()
		{
			return new UpdateLinkedObjectDialog();
		}

		public static ITesseraListItem NewTesseraListItem(bool inUse, string type, string codice, string pin)
		{
			return new TesseraListItem(inUse, type, codice, pin);
		}

	}
}
