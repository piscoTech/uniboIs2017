using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	[LinkedType("Dispositivi")]
	public abstract class IDispositivoType : LinkedType
	{
	}

	internal class DispositivoType : IDispositivoType
	{
		public override bool ShouldDisableInsteadOfDelete(IEnumerable<IMezzo> mezzi)
		{
			return mezzi.Any((IMezzo m) => m.Dispositivi.Any((IDispositivo disp) => disp.Type == this));
		}
	}
}
