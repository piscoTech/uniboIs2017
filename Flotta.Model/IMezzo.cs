using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
    public interface IMezzo : IDBObject
    {
        string Modello { get; set; }
        string Targa { get; set; }
        uint Numero { get; set; }
        string NumeroTelaio { get; set; }
        uint AnnoImmatricolazione { get; set; }
        float Portata { get; set; }
        float Altezza { get; set; }
        float Lunghezza { get; set; }
        float Profondita { get; set; }
        float VolumeCarico { get; set; }
        ITessera[] Tessere { get; }
        IDispositivo[] Dispositivi { get; }
        IPermesso[] Permessi { get; }
        bool IsValid { get; }

        bool AddTessera(ITessera tessera);
        bool AddDispositivo(IDispositivo dispositivo);
        bool AddPermesso(IPermesso permesso);
        void RemoveTessera(ITesseraType tessera);
        void RemoveDispositivo(IDispositivoType dispositivo);
        void RemovePermesso(IPermessoType permesso);

    }
}
