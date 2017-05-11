using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
    internal class Dispositivo : IDispositivo
    {
        private DispositivoType _type;

        public IDispositivoType Type
        {
            get
            {
                return _type;
            }
        }


    }
}
