using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public interface IMezzoListItem
	{
		string Description { get; }
	}

	class MezzoListItem : IMezzoListItem
	{
		private uint _numero;
		private string _modello;
		private string _targa;

		internal MezzoListItem(uint numero, string modello, string targa)
		{
			_numero = numero;
			_modello = modello;
			_targa = targa;
		}

		public string Description => _numero + " – " + _modello + " " + _targa;
	}
}
