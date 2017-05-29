using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IIncidente : IDBObject
	{
		IMezzo Mezzo { get; }
		DateTime Data { get; }
		IAssicurazioneType Assicurazione { get; }
		IPDF Cid { get; }
		float RimborsoAssicurativo { get; }
		float DannoTotale { get; }
		IEnumerable<IManutenzione> Riparazioni { get; }
		IEnumerable<IImmagine> Foto { get; }

		IEnumerable<string> Update(DateTime d, IAssicurazioneType a, IPDF cid, float rimbass,
								   float dannotot, IOfficina officina, IEnumerable<IManutenzione> riparazioni,
								   IEnumerable<IImmagine> foto);
	}

	internal class Incidente : IIncidente
	{
		private IMezzo _mezzo;
		private DateTime _data = DateTime.Now;
		private IAssicurazioneType _assicurazione;
		private IPDF _cid;
		private float _rimborsoAssicurativo;
		private float _dannoTotale;
		private List<IManutenzione> _riparazioni;
		private List<IImmagine> _foto;

		internal Incidente(IMezzo mezzo)
		{
			if (mezzo == null)
				throw new ArgumentNullException();

			_mezzo = mezzo;
		}

		public IMezzo Mezzo => _mezzo;
		public DateTime Data => _data;
		public IAssicurazioneType Assicurazione => _assicurazione;
		public IPDF Cid => _cid;
		public float RimborsoAssicurativo => _rimborsoAssicurativo;
		public float DannoTotale => _dannoTotale;
		public IEnumerable<IManutenzione> Riparazioni => _riparazioni;
		public IEnumerable<IImmagine> Foto => _foto;

		public IEnumerable<string> Update(DateTime d, IAssicurazioneType a, IPDF cid, float rimbass,
								   float dannotot, IOfficina officina, IEnumerable<IManutenzione> riparazioni,
								   IEnumerable<IImmagine> foto)
		{
			List<string> errors = new List<string>();
			if (d.Date > DateTime.Now.Date)
				errors.Add("La data non può essere nel futuro");

			if (a == null)
				errors.Add("Tipologia assicurativa non valida");

			if (!(cid?.IsValid ?? true))
				errors.Add("CID non valido");

			if (rimbass < 0)
				errors.Add("Il rimborso assicurativo deve essere nullo o positivo");

			if (dannotot < 0)
				errors.Add("Il danno totale deve essere nullo o positivo");

			if (riparazioni.Any((IManutenzione m) => m.Mezzo != this._mezzo))
				errors.Add("Una o più riparazioni non appartiene al mezzo corrente");

			if (foto.Any((IImmagine f) => !this._mezzo.Galleria.Contains(f)))
				errors.Add("Una o più foto non appartiene al mezzo corrente");

			_data = d.Date;
			_assicurazione = a;
			_cid = cid;
			_rimborsoAssicurativo = rimbass;
			_dannoTotale = dannotot;
			_riparazioni = riparazioni.ToList();
			_foto = foto.ToList();

			return errors;
		}
	}
}
