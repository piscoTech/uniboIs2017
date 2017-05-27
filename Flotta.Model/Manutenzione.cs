using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IManutenzione : ILinkedObject<IManutenzioneType>
	{
		IMezzo Mezzo { get; }
		DateTime Data { get; }
		string Note { get; }
		float Costo { get; }
		IOfficina Officina { get; }
		IPDF Allegato { get; }

		IEnumerable<string> Update(DateTime d, IManutenzioneType t, string n, float costo, IPDF allegato, IOfficina officina);
	}

	internal class Manutenzione : IManutenzione
	{
		private IMezzo _mezzo;
		private DateTime _data = DateTime.Now;
		private IManutenzioneType _type;
		private string _note;
		private float _costo;
		private IOfficina _officina;
		private IPDF _allegato;

		internal Manutenzione(IMezzo mezzo)
		{
			if (mezzo == null)
				throw new ArgumentNullException();

			_mezzo = mezzo;
		}

		public DateTime Data => _data;
		public string Note => _note;
		public float Costo => _costo;
		public IManutenzioneType Type => _type;
		public IPDF Allegato => _allegato;
		public IMezzo Mezzo => _mezzo;
		public IOfficina Officina => _officina;

		public IEnumerable<string> Update(DateTime d, IManutenzioneType t, string n, float c, IPDF allegato, IOfficina officina)
		{
			List<string> errors = new List<string>();
			if (t == null)
				errors.Add("Tipo non valido");

			if (d.Date > DateTime.Now.Date)
				errors.Add("La data non può essere nel futuro");

			n = n?.Trim() ?? "";

			if (c <= 0)
				errors.Add("Il costo deve essere positivo");

			if (!(allegato?.IsValid ?? true))
				errors.Add("Allegato non valido");

			_data = d;
			_type = t;
			_note = n;
			_costo = c;
			_allegato = allegato;
			_officina = officina;

			return errors;
		}
	}
}
