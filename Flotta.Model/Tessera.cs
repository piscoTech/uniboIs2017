using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
    internal class Tessera : ITessera
    {
        private TesseraType _type;
        private String _codice;
        private String _pin;

        public Tessera(String codice, String pin)
        {
            _codice = codice;
            _pin = pin;
        }

        public ITesseraType Type
        {
            get
            {
                return _type as ITesseraType;
            }
        }

        public String Codice
        {
            get
            {
                return _codice;
            }
            set
            {
                _codice = value;
            }
        }

        public String Pin
        {
            get
            {
                return _pin;
            }
            set
            {
                _pin = value;
            }
        }

    }
}
