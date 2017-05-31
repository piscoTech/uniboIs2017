using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface ITessera : ICloneable, ILinkedObject<ITesseraType>, IScadenzaOwner
	{
		String Codice { get; }
		String Pin { get; }

		IEnumerable<string> Update(string codice, string pin);
		bool IsValid { get; }
	}

	internal class Tessera : ITessera
	{
		private IMezzo _mezzo;
		private ITesseraType _type;
		private string _codice;
		private string _pin;
		private Scadenza _scadenza;

		internal Tessera(IMezzo mezzo, ITesseraType type)
		{
			_mezzo = mezzo;
			_type = type;
		}

		private Tessera(IMezzo mezzo, ITesseraType type, string codice, string pin)
		{
			_mezzo = mezzo;
			_type = type;
			_codice = codice;
			_pin = pin;
		}

		public IMezzo Mezzo => _mezzo;
		public ITesseraType Type => _type;
		public string Codice => _codice;
		public string Pin => _pin;

		public Scadenza Scadenza
		{
			get => _scadenza;
			set => _scadenza = value;
		}
		public string ScadenzaName => "Tessera: " + _type.Name;

		public IEnumerable<string> Update(string codice, string pin)
		{
			List<String> errors = new List<string>();
			Regex alphaNum = new Regex(@"^[0-9]+$");

			codice = codice?.Trim();
			pin = pin?.Trim();
			if (String.IsNullOrEmpty(codice))
				errors.Add("Codice non specificato");
			else if (!alphaNum.IsMatch(codice))
				errors.Add("Codice non valido, usa solo 0-9");

			if (String.IsNullOrEmpty(pin))
				errors.Add("PIN non specificato");
			else if (!alphaNum.IsMatch(pin))
				errors.Add("PIN non valido, usa solo 0-9");

			if (errors.Count > 0)
				return errors;

			_codice = codice;
			_pin = pin;

			return errors;
		}

		public bool IsValid => Update(_codice, _pin).Count() == 0;

		public object Clone()
		{
			return new Tessera(_mezzo, _type, _codice, _pin) { Scadenza = _scadenza };
		}
	}
}
