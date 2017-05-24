using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface ILinkedObject<T> : IDBObject where T : LinkedType
	{
		T Type { get; }
	}

	public interface ILinkedObjectWithPDF<T> : ILinkedObject<T> where T : LinkedType
	{
		IPDF Allegato { get; }
		IEnumerable<string> Update(IPDF allegato);
	}
}
