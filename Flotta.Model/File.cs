using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public abstract class File : IDBObject
	{
		private string _path = null;

		public string Path => _path;
		public abstract bool IsValid { get; }
	}
}
