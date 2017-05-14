using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
    public interface IOfficina : IDBObject
    {
        string Nome { get; set; }
        string Telefono { get; set; }
        string Via { get; set; }
        string Cap { get; set; }
        string Citta { get; set; }
        string Provincia { get; set; }
        string Nazione { get; set; }
    }
}
