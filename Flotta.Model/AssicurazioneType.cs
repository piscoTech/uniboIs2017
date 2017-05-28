using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	[LinkedType("Assicurazioni")]
	public abstract class IAssicurazioneType : LinkedType
	{
	}

	internal class AssicurazioneType : IAssicurazioneType
	{
		public override bool ShouldDisableInsteadOfDelete(IEnumerable<IMezzo> mezzi)
		{
			return false;
		}
	}
}
