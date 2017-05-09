using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public class Permesso : IDBObject
	{

		private PermessoType _type;

		public PermessoType Type
		{
			get
			{
				return _type;
			}
		}

	}
}
