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
		public override bool IsValid => Path?.ToLower().EndsWith(".jpg") ?? false;
		protected override IEnumerable<string> ValidTypes => new string[] {"JPG"};
	}
}
