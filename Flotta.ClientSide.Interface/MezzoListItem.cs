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
		private readonly uint _numero;
		private readonly string _modello;
		private readonly string _targa;

		internal MezzoListItem(uint numero, string modello, string targa)
		{
			if (modello == null)
				throw new ArgumentNullException("No modello specified");

			if (targa == null)
				throw new ArgumentNullException("No targa specified");

			_numero = numero;
			_modello = modello;
			_targa = targa;
		}

		public string Description => _numero + " – " + _modello + " " + _targa;
	}
}
