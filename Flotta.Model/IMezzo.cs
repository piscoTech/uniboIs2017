using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IMezzo : IDBObject
	{
		string Modello { get; }
		string Targa { get; }
		uint Numero { get; }
		string NumeroTelaio { get; }
		uint AnnoImmatricolazione { get; }
		float Portata { get; }
		float Altezza { get; }
		float Lunghezza { get; }
		float Profondita { get; }
		float VolumeCarico { get; }
		ITessera[] Tessere { get; }
		IDispositivo[] Dispositivi { get; }
		IPermesso[] Permessi { get; }

		IEnumerable<string> Update(string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondità, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi);

	}
}
