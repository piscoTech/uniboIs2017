using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public interface ITesseraListItem
	{
		bool InUse { get; set; }
		string Type { get; }
		string Codice { get; set; }
		string Pin { get; set; }
	}

	class TesseraListItem : ITesseraListItem
	{

		private bool _inUse;
		private string _type;
		private string _codice;
		private string _pin;

		internal TesseraListItem(bool inUse, string type, string codice, string pin)
		{
			_inUse = inUse;
			_type = type;
			_codice = codice;
			_pin = pin;
		}

		public bool InUse
		{
			get => _inUse;
			set => _inUse = value;
		}

		public string Type
		{
			get => _type;
		}

		public string Codice
		{
			get => _codice;
			set => _codice = value;
		}

		public string Pin
		{
			get => _pin;
			set => _pin = value;
		}
	}
}
