using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide
{
    internal class DummyMezzo
    {

        internal string Nome;
        internal string Targa;
        public string Description
        {
            get
            {
                return Nome + " " + Targa;
            }
        }

    }
}
