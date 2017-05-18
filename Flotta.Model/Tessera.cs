using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface ITessera : IDBObject, ICloneable
	{
		ITesseraType Type { get; }
		String Codice { get; }
		String Pin { get; }

		IEnumerable<string> Update(string codice, string pin);
	}

	internal class Tessera : ITessera
	{
		private ITesseraType _type;
		private string _codice;
		private string _pin;

		internal Tessera(ITesseraType type)
		{
			_type = type;
		}

		private Tessera(ITesseraType type, string codice, string pin)
		{
			_type = type;
			_codice = codice;
			_pin = pin;
		}

		public ITesseraType Type
		{
			get
			{
				return _type;
			}
		}

		public string Codice
		{
			get
			{
				return _codice;
			}
		}

		public string Pin
		{
			get
			{
				return _pin;
			}
		}

		public IEnumerable<string> Update(string codice, string pin)
		{
			List<String> errors = new List<string>();
			Regex alphaNum = new Regex(@"^[0-9]+$");

			codice = codice?.Trim();
			pin = pin?.Trim();
			if (String.IsNullOrEmpty(codice))
				errors.Add(_type.Name + ": codice non specificato");
			else if (!alphaNum.IsMatch(pin))
				errors.Add(_type.Name + ": codice non valido, usa solo 0-9");

			if (String.IsNullOrEmpty(pin))
				errors.Add(_type.Name + ": PIN non specificato");
			else if (!alphaNum.IsMatch(pin))
				errors.Add(_type.Name + ": PIN non valido, usa solo 0-9");

			if (errors.Count > 0)
				return errors;

			_codice = codice;
			_pin = pin;

			return errors;
		}

		public object Clone()
		{
			return new Tessera(_type, _codice, _pin);
		}
	}
}
