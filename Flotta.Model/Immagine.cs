using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public abstract class IImmagine : File
	{
	}

	internal class Immagine : IImmagine
	{
		public override bool IsValid => false;
	}
}
