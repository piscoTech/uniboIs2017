using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
    internal class Manutenzione : IManutenzione
    {
        private DateTime _data;
        private string _note;
        private float _costo;
        private IManutenzioneType _type;
         

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
    }
}
