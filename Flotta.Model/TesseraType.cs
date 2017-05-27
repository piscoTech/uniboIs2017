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
			return (from t in (
						from m in mezzi
						select (
							from t in m.Tessere
							where t.Type == this
							select t.Type
						)
					  )
					where t.Count() > 0
					select t).Count() > 0;
		}
	}
}
