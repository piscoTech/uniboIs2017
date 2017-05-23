using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	[LinkedTypeAttribute("Permessi")]
	public abstract class IPermessoType : LinkedType
	{
	}

	internal class PermessoType : IPermessoType
	{
		public override bool ShouldDisableInsteadOfDelete(IEnumerable<IMezzo> mezzi)
		{
			return (from t in (
						from m in mezzi
						select (
							from t in m.Permessi
							where t.Type == this
							select t.Type
						)
					  )
					where t.Count() > 0
					select t).Count() > 0;
		}
	}
}
