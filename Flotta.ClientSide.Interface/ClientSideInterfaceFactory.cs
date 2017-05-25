﻿using System;
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

		public static ILinkedTypeManagerWindow NewLinkedTypeManagerWindow()
		{
			return new LinkedTypeManagerWindow();
		}

		public static ILinkedTypeListItem NewLinkedTypeListItem(string name, bool disabled)
		{
			return new LinkedTypeListItem(name, disabled);
		}

		public static IUpdateLinkedTypeDialog NewUpdateLinkedTypeDialog()
		{
			return new UpdateLinkedTypeDialog();
		}

		public static ITesseraListItem NewTesseraListItem(bool inUse, string type, string codice, string pin)
		{
			return new TesseraListItem(inUse, type, codice, pin);
		}

		public static IDispositivoPermessoListItem NewDispositivoPermessoListItem(bool inUse, string type, string allegatoPath)
		{
			return new DispositivoPermessoListItem(inUse, type, allegatoPath);
		}

		public static IUpdateTesseraDialog NewUpdateTesseraDialog()
		{
			return new UpdateTesseraDialog();
		}

		public static IUpdateDispositivoPermessoDialog NewUpdateDispositivoPermessoDialog()
		{
			return new UpdateDispositivoPermessoDialog();
		}

		public static IScadenzaListItem NewScadenzaListItem(string name, string date, bool expired, bool canRenew)
		{
			return new ScadenzaListItem(name, date, expired, canRenew);
		}

		public static IUpdateScadenzaDialog NewUpdateScadenzaDialog()
		{
			return new UpdateScadenzaDialog();
		}

		public static IRenewScadenzaDialog NewRenewScadenzaDialog()
		{
			return new RenewScadenzaDialog();
		}
	}
}
