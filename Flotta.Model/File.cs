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
		private string _path;
		private DateTime _dataCaricamento;

		public string Path => _path;
		public DateTime DataCaricamento => _dataCaricamento;

		public IEnumerable<string> Update(string path)
		{
			string oldPath = Path;
			_path = path;
			if (!this.IsValid)
			{
				_path = oldPath;
				return new string[] { "File non valido, formati validi: " + String.Join(", ", ValidTypes) };
			}

			_dataCaricamento = DateTime.Now;
			return new string[0];
		}

		protected abstract IEnumerable<string> ValidTypes { get; }
		public abstract bool IsValid { get; }
	}
}
