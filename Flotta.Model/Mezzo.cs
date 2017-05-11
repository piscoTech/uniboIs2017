using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	internal class Mezzo : IDBObject
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
		public IDispositivo[] Dispostivi
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

        public void AddTessera(ITessera t)
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
        }

        public void AddDispositivo(IDispositivo d)
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
        }

        public void AddPermesso(IPermesso p)
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
        }

	}
}
