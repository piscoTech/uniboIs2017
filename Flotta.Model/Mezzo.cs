using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
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
        private HashSet<Permesso> _permessi; // Ho usato un Set perchè non interessa l'ordine, useremo quello alfabetico di PermessoType.Name
        private HashSet<Tessera> _tessere;
        private HashSet<Dispositivo> _dispositivi;
        

		public string Modello
		{
			get
			{
				return _modello;
			}

			set
			{
				_modello = value;
			}
		}
		public string Targa
		{
			get
			{
				return _targa;
			}

			set
			{
				_targa = value;
			}
		}
		public uint Numero
		{
			get
			{
				return _numero;
			}

			set
			{
				_numero = value;
			}
		}
		public string NumeroTelaio
		{
			get
			{
				return _numeroTelaio;
			}

			set
			{
				_numeroTelaio = value;
			}
		}
		public uint AnnoImmatricolazione
		{
			get
			{
				return _annoImmatricolazione;
			}

			set
			{
				_annoImmatricolazione = value;
			}
		}
		public float Portata
		{
			get
			{
				return _portata;
			}

			set
			{
				_portata = value;
			}
		}
		public float Altezza
		{
			get
			{
				return _altezza;
			}

			set
			{
				_altezza = value;
			}
		}
		public float Lunghezza
		{
			get
			{
				return _lunghezza;
			}

			set
			{
				_lunghezza = value;
			}
		}
		public float Profondita
		{
			get
			{
				return _profondita;
			}

			set
			{
				_profondita = value;
			}
		}
		public float VolumeCarico
		{
			get
			{
				return _volumeCarico;
			}

			set
			{
				_volumeCarico = value;
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

        public bool AddTessera(ITessera t)
        {
            bool exist = false;
            foreach (Tessera te in _tessere)
            {
                if (te.Type.Name.Equals(t.Type.Name))
                {
                    exist = true;
                    break;
                }   
            }
            if (!exist) _tessere.Add(t as Tessera);
            return !exist;
        }

        public bool AddDispositivo(IDispositivo d)
        {
            bool exist = false;
            foreach (Dispositivo di in _dispositivi)
            {
                if (di.Type.Name.Equals(d.Type.Name))
                {
                    exist = true;
                    break;
                }        
            }
            if (!exist) _dispositivi.Add(d as Dispositivo);
            return !exist;
        }

        public bool AddPermesso(IPermesso p)
		{
            bool exist = false;
            foreach (Permesso pe in _permessi)
            {
                if (pe.Type.Name.Equals(p.Type.Name))
                {
                    exist = true;
                    break;
                }
            }
            if (!exist) _permessi.Add(p as Permesso);
            return !exist;
        }

        public void RemoveTessera(ITesseraType tessera)
        {
            foreach (Tessera t in _tessere)
            {
                if (t.Type.Equals(tessera))
                    _tessere.Remove(t);
            }
        }

        public void RemoveDispositivo(IDispositivoType dispositivo)
        {
            foreach (Dispositivo d in _dispositivi)
            {
                if (d.Type.Equals(dispositivo))
                    _dispositivi.Remove(d);
            }
        }

        public void RemovePermesso(IPermessoType permesso)
        {
            foreach(Permesso p in _permessi)
            {
                if (p.Type.Equals(permesso))
                    _permessi.Remove(p);
            }
        }

        private bool checkType(IEnumerable<LinkedObject> array)
        {
            List<LinkedObject> o = new List<LinkedObject>();

            foreach(LinkedObject l in array)
            {
                if (!o.Contains(l))
                    o.Add(l);
                else
                    return false;
            }

            return true;
        }

        public bool IsValid
        {
            get => !String.IsNullOrEmpty(_modello) && !String.IsNullOrEmpty(_targa) &&
                   !String.IsNullOrEmpty(_numeroTelaio) && _portata > 0 && _altezza > 0 &&
                   _lunghezza > 0 && _profondita > 0 && _volumeCarico > 0 &&
                   checkType(from t in _tessere select t.Type) &&
                   checkType(from d in _dispositivi select d.Type) &&
                   checkType(from p in _permessi select p.Type);
        }
 

	}
}
