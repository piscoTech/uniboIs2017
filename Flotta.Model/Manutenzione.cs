using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IManutenzione : ILinkedObject<IManutenzioneType>
	{
		DateTime Data { get; set; }
		string Note { get; set; }
		float Costo { get; set; }
		IMezzo Mezzo { get; }
		IEnumerable<string> Update(DateTime d, IManutenzioneType t, string n, float costo);
	}

	internal class Manutenzione : IManutenzione
    {
        private DateTime _data;
        private string _note;
        private float _costo;
        private IManutenzioneType _type;
		private IMezzo _mezzo;
         
		internal Manutenzione(IMezzo mezzo)
		{
			if (mezzo == null)
				throw new ArgumentNullException();

			_mezzo = mezzo;
		}

        public DateTime Data
        {
            get { return _data;  }
            set { _data = value; }
        }

        public string Note
        {
            get { return _note;  }
            set { _note = value; }
        }

        public float Costo
        {
            get { return _costo;  }
            set { _costo = value; }
        }

        public IManutenzioneType Type
        {
            get { return _type; }
            set { _type = value; }
        }

		public IMezzo Mezzo
		{
			get { return _mezzo;  }
		}

		public IEnumerable<string> Update(DateTime d, IManutenzioneType t, string n, float c)
		{
			_data = d;
			_type = t;
			_note = n;
			_costo = c;

			return new string[0];
		}
	}
}
