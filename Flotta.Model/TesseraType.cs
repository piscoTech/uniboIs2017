using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	[LinkedType("Tessere")]
	public abstract class ITesseraType : LinkedType
	{
	}

	internal class TesseraType : ITesseraType
	{
		public override bool ShouldDisableInsteadOfDelete(IEnumerable<IMezzo> mezzi)
		{
			return mezzi.Any((IMezzo m) => m.Tessere.Any((ITessera tess) => tess.Type == this));
		}
	}
}
