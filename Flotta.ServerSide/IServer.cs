using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;

namespace Flotta.ServerSide
{

	public delegate void ObjectChangedHandler(IDBObject obj);

	public interface IServer
	{
		void ClientDisconnected();
		void ClientConnected();
		event ObjectChangedHandler ObjectChanged;
		event ObjectChangedHandler ObjectRemoved;

		IEnumerable<IMezzo> Mezzi { get; }

		IEnumerable<string> UpdateMezzo(IMezzo mezzo, bool isNew, string modello, string targa, uint numero, string numeroTelaio, uint annoImmatricolazione, float portata, float altezza, float lunghezza, float profondità, float volumeCarico, IEnumerable<ITessera> tessere, IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi);
		bool DeleteMezzo(IMezzo mezzo);
	}
}
