using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public interface ITabViewGenerale
	{
		event GenericAction DeleteMezzo;
		event GenericAction EnterEdit;
		event GenericAction CancelEdit;
		event GenericAction SaveEdit;

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

		bool EditMode { set; }
	}
}
