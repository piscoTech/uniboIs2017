using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public static class ModelFactory
	{
		public static IMezzo NewMezzo ()
		{
			return new Mezzo();
		}
	}
}
