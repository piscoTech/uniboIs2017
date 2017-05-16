using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IMezzo : IDBObject
	{
		string Modello { get; }
		string Targa { get; }
		uint Numero { get; }
		string NumeroTelaio { get; }
		uint AnnoImmatricolazione { get; }
		float Portata { get; }
		float Altezza { get; }
		float Lunghezza { get; }
		float Profondita { get; }
		float VolumeCarico { get; }
		ITessera[] Tessere { get; }
		IDispositivo[] Dispositivi { get; }
		IPermesso[] Permessi { get; }

		IEnumerable<string> Update(string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondità, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi);

	}

	internal class Mezzo : IMezzo
	{

		private string _modello;
		private string _targa;
		private uint _numero;
		private string _numeroTelaio;
		private uint _annoImmatricolazione;
		private float _portata;
		private float _altezza;
		private float _lunghezza;
		private float _profondita;
		private float _volumeCarico;
		private HashSet<Tessera> _tessere = new HashSet<Tessera>();
		private HashSet<Dispositivo> _dispositivi = new HashSet<Dispositivo>();
		private HashSet<Permesso> _permessi = new HashSet<Permesso>();

		public string Modello
		{
			get
			{
				return _modello;
			}
		}
		public string Targa
		{
			get
			{
				return _targa;
			}
		}
		public uint Numero
		{
			get
			{
				return _numero;
			}
		}
		public string NumeroTelaio
		{
			get
			{
				return _numeroTelaio;
			}
		}
		public uint AnnoImmatricolazione
		{
			get
			{
				return _annoImmatricolazione;
			}
		}
		public float Portata
		{
			get
			{
				return _portata;
			}
		}
		public float Altezza
		{
			get
			{
				return _altezza;
			}
		}
		public float Lunghezza
		{
			get
			{
				return _lunghezza;
			}
		}
		public float Profondita
		{
			get
			{
				return _profondita;
			}
		}
		public float VolumeCarico
		{
			get
			{
				return _volumeCarico;
			}
		}
		public ITessera[] Tessere
		{
			get
			{
				return _tessere.ToArray();
			}
		}
		public IDispositivo[] Dispositivi
		{
			get
			{
				return _dispositivi.ToArray();
			}
		}
		public IPermesso[] Permessi
		{
			get
			{
				return _permessi.ToArray();
			}
		}

		private bool CheckType(IEnumerable<LinkedObject> array)
		{
			List<LinkedObject> o = new List<LinkedObject>();

			foreach (LinkedObject l in array)
			{
				if (!o.Contains(l))
					o.Add(l);
				else
					return false;
			}

			return true;
		}

		public IEnumerable<String> Update(string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondita, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi)
		{
			List<String> errors = new List<string>();
			Regex alphaNum = new Regex(@"^[A-Z0-9]+$");

			modello = modello?.Trim();
			targa = targa?.Trim()?.ToUpper();
			numeroTelaio = numeroTelaio?.Trim()?.ToUpper();
			if (String.IsNullOrEmpty(modello))
				errors.Add("Modello non specificato");

			if (String.IsNullOrEmpty(targa))
				errors.Add("Targa non specificata");
			else if (!alphaNum.IsMatch(targa))
				errors.Add("Targa non valida, usa solo A-Z e 0-9");

			if (numero <= 0)
				errors.Add("Il numero deve essere positivo");

			if (String.IsNullOrEmpty(numeroTelaio))
				errors.Add("Numero di telaio non specificato");
			else if (!alphaNum.IsMatch(numeroTelaio))
				errors.Add("Numero di telaio non valido, usa solo A-Z e 0-9");

			if (annoImmatricolazione <= 0)
				errors.Add("Anno di immatricolazione non valido");

			if (portata < 0)
				errors.Add("La portata deve essere positiva o 0 per non specificata");

			if (altezza < 0)
				errors.Add("L'altezza deve essere positiva o 0 per non specificata");

			if (lunghezza < 0)
				errors.Add("La lunghezza deve essere positiva o 0 per non specificata");

			if (profondita < 0)
				errors.Add("La profondità deve essere positiva o 0 per non specificata");

			if (volumeCarico < 0)
				errors.Add("Il volume di carico deve essere positivo o 0 per non specificato");

			if (!CheckType(from t in tessere select t.Type))
				errors.Add("Una o più tipi di tessera sono stati usati più di una volta");

			if (!CheckType(from d in dispositivi select d.Type))
				errors.Add("Una o più tipi di dispositivo sono stati usati più di una volta");

			if (!CheckType(from p in permessi select p.Type))
				errors.Add("Una o più tipi di permesso sono stati usati più di una volta");

			if (errors.Count > 0)
				return errors;

			_modello = modello;
			_targa = targa;
			_numero = numero;
			_numeroTelaio = numeroTelaio;
			_annoImmatricolazione = annoImmatricolazione;
			_portata = portata;
			_altezza = altezza;
			_lunghezza = lunghezza;
			_profondita = profondita;
			_volumeCarico = volumeCarico;

			_tessere.Clear() ;
			_tessere.Concat(tessere);
			_dispositivi.Clear();
			_dispositivi.Concat(dispositivi);
			_permessi.Clear();
			_permessi.Concat(permessi);

			return errors;
		}


	}
}
