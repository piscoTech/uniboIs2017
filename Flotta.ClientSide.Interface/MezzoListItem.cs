using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	class MezzoListItem : IMezzoListItem
	{
		private string _modello;
		private string _targa;

		internal MezzoListItem(string modello, string targa)
		{
			_modello = modello;
			_targa = targa;
		}

		public string Description => _modello + " " + _targa;
	}
}
