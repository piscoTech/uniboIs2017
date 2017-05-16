using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface ITessera : IDBObject
	{
		ITesseraType Type { get; }

		String Codice { get; set; }

		String Pin { get; set; }
	}

	internal class Tessera : ITessera
    {
        private TesseraType _type;
        private string _codice;
        private string _pin;

        public Tessera(string codice, string pin)
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

        public string Codice
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

        public string Pin
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
