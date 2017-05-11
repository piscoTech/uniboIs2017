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
}
