using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface ILinkedObject : IDBObject
	{
		string Name { get; }
		bool IsDisabled { get; }
		IEnumerable<string> Update(string name);
		void Disable();
	}
}
