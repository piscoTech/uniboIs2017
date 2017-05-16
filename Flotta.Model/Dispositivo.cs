using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IDispositivo : IDBObject
	{
		IDispositivoType Type { get; }
	}

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
