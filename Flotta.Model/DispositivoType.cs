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
			return (from t in (
						from m in mezzi
						select (
							from t in m.Dispositivi
							where t.Type == this
							select t.Type
						)
					  )
					where t.Count() > 0
					select t).Count() > 0;
		}
	}
}
