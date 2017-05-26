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
			return mezzi.Any((IMezzo m) => m.Permessi.Any((IPermesso perm) => perm.Type == this));
		}
	}
}
