using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public abstract class IPDF : File
	{
	}

	internal class PDF : IPDF
	{
		public override bool IsValid => false;
	}
}
