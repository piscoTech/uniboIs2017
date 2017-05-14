using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
    public interface IManutenzione : IDBObject
    {
        DateTime Data { get; set; }
        IManutenzioneType Type { get; set; }
        string Note { get; set; }
        float Costo { get; set; }
    }
}
