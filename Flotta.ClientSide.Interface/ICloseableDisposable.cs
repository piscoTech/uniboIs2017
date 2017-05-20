using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public interface ICloseableDisposable : IDisposable
	{
		void Close();
	}
}
