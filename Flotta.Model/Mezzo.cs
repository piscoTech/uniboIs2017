﻿using System;
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

		[MezzoScadenza("Carta di circolazione", 0)]
		Scadenza ScadenzaCartaCircolazione { get; set; }
		[MezzoScadenza("Tagliando", 1)]
		Scadenza ScadenzaTagliando { get; set; }

		IEnumerable<string> Update(string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondita, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi);
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
		private HashSet<ITessera> _tessere = new HashSet<ITessera>();
		private HashSet<IDispositivo> _dispositivi = new HashSet<IDispositivo>();
		private HashSet<IPermesso> _permessi = new HashSet<IPermesso>();

		private Scadenza _scadCartaCircolazione, _scadTagliando;

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

		public Scadenza ScadenzaCartaCircolazione
		{
			get => _scadCartaCircolazione;
			set => _scadCartaCircolazione = value;
		}
		public Scadenza ScadenzaTagliando
		{
			get => _scadTagliando;
			set => _scadTagliando = value;
		}

		private bool CheckType(IEnumerable<LinkedType> array)
		{
			List<LinkedType> o = new List<LinkedType>();

			foreach (LinkedType l in array)
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

			if (tessere.Any((ITessera t) => t.Mezzo != this))
				errors.Add("Una o più tessere non appartengono al mezzo corrente");
			else if (!CheckType(from t in tessere select t.Type))
				errors.Add("Una o più tipi di tessera sono stati usati più di una volta");
			else if ((from t in tessere select t.IsValid).Contains(false))
				errors.Add("Una o più tessere non sono valide");

			if (dispositivi.Any((IDispositivo d) => d.Mezzo != this))
				errors.Add("Uno o più dispositivi non appartengono al mezzo corrente");
			else if (!CheckType(from d in dispositivi select d.Type))
				errors.Add("Una o più tipi di dispositivo sono stati usati più di una volta");
			else if ((from d in dispositivi select d.IsValid).Contains(false))
				errors.Add("Una o più dispositivi non sono validi");

			if (permessi.Any((IPermesso p) => p.Mezzo != this))
				errors.Add("Uno o più permessi non appartengono al mezzo corrente");
			else if (!CheckType(from p in permessi select p.Type))
				errors.Add("Una o più tipi di permesso sono stati usati più di una volta");
			else if ((from p in permessi select p.IsValid).Contains(false))
				errors.Add("Una o più permessi non sono validi");

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

			// We cannot create a new set from the passed collections as it contains clones of the originals and the reference to scadenze may have changed

			// Drop removed items, we clone Linq result to break any dependecy to the modified collections
			foreach (ITessera tess in (from t in _tessere where !(from nt in tessere select nt.Type).Contains(t.Type) select t).ToArray())
			{
				_tessere.Remove(tess);
			}
			foreach (IDispositivo disp in (from d in _dispositivi where !(from nd in dispositivi select nd.Type).Contains(d.Type) select d).ToArray())
			{
				_dispositivi.Remove(disp);
			}
			foreach (IPermesso perm in (from p in _permessi where !(from np in permessi select np.Type).Contains(p.Type) select p).ToArray())
			{
				_permessi.Remove(perm);
			}
			// Update kept items
			foreach (ITessera tess in tessere)
			{
				(from t in _tessere where t.Type == tess.Type select t).ElementAtOrDefault(0)?.Update(tess.Codice, tess.Pin);
			}
			foreach (IDispositivo disp in dispositivi)
			{
				(from d in _dispositivi where d.Type == disp.Type select d).ElementAtOrDefault(0)?.Update(disp.Allegato);
			}
			foreach (IPermesso perm in permessi)
			{
				(from p in _permessi where p.Type == perm.Type select p).ElementAtOrDefault(0)?.Update(perm.Allegato);
			}
			// Add new items, we clone Linq result to break any dependecy to the modified collections
			foreach (ITessera tess in (from t in tessere where !(from ot in _tessere select ot.Type).Contains(t.Type) select t).ToArray())
			{
				_tessere.Add(tess);
			}
			foreach (IDispositivo disp in (from d in dispositivi where !(from od in _dispositivi select od.Type).Contains(d.Type) select d).ToArray())
			{
				_dispositivi.Add(disp);
			}
			foreach (IPermesso perm in (from p in permessi where !(from op in _permessi select op.Type).Contains(p.Type) select p).ToArray())
			{
				_permessi.Add(perm);
			}

			return errors;
		}
	}
}
