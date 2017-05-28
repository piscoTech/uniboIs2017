using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IOfficina : IDBObject
	{
		string Nome { get; }
		string Telefono { get; }
		string Via { get; }
		string Cap { get; }
		string Citta { get; }
		string Provincia { get; }
		string Nazione { get; }

		bool IsDisabled { get; }

		IEnumerable<string> Update(string nome, string telefono, string via, string cap, string citta, string provincia, string nazione);
		void Disable();
		bool ShouldDisableInsteadOfDelete(IEnumerable<IMezzo> mezzi);
	}

	internal class Officina : IOfficina
	{
		private string _nome;
		private string _telefono;
		private string _via;
		private string _cap;
		private string _citta;
		private string _provincia;
		private string _nazione;

		private bool _disabled;

		internal Officina()
		{
		}

		public string Nome => _nome;
		public string Telefono => _telefono;
		public string Via => _via;
		public string Cap => _cap;
		public string Citta => _citta;
		public string Provincia => _provincia;
		public string Nazione => _nazione;
		public bool IsDisabled => _disabled;

		public IEnumerable<string> Update(string nome, string telefono, string via, string cap, string citta, string provincia, string nazione)
		{
			List<String> errors = new List<string>();
			Regex num = new Regex(@"^[0-9]+$");
			Regex alpha = new Regex(@"^[A-Z]+$");

			nome = nome?.Trim();
			telefono = telefono?.Trim();
			via = via?.Trim();
			cap = cap?.Trim();
			citta = citta?.Trim();
			provincia = provincia?.Trim()?.ToUpper();
			nazione = nazione?.Trim();

			if (String.IsNullOrEmpty(nome))
				errors.Add("Nome non specificato");

			if (String.IsNullOrEmpty(telefono))
				errors.Add("Targa non specificata");
			else if (!num.IsMatch(telefono))
				errors.Add("Telefono non valido, usa solo 0-9");

			if (String.IsNullOrEmpty(via))
				errors.Add("Via non specificata");

			if (String.IsNullOrEmpty(cap))
				errors.Add("CAP non specificato");
			else if (!num.IsMatch(cap) || cap.Length != 5)
				errors.Add("CAP non valido, usa solo 0-9, lunghezza 5");

			if (String.IsNullOrEmpty(citta))
				errors.Add("Città non specificata");

			if (String.IsNullOrEmpty(provincia))
				errors.Add("Provincia non specificata");
			else if (!alpha.IsMatch(provincia) || provincia.Length != 2)
				errors.Add("Provincia non valida, usa solo A-Z, lunghezza 2");

			if (String.IsNullOrEmpty(nazione))
				errors.Add("Nazione non specificata");

			if (errors.Count > 0)
				return errors;

			_nome = nome;
			_telefono = telefono;
			_via = via;
			_cap = cap;
			_citta = citta;
			_provincia = provincia;
			_nazione = nazione;

			return errors;
		}

		public void Disable()
		{
			_disabled = true;
		}

		public bool ShouldDisableInsteadOfDelete(IEnumerable<IMezzo> mezzi)
		{
			return mezzi.Any((IMezzo m) => m.Manutenzioni.Any((IManutenzione manut) => manut.Officina == this));
		}
	}
}
