using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ServerSide.View
{
	public static class ServerSideInterfaceFactory
	{
		public static IServerWindow NewServerWindow()
		{
			return new ServerWindow();
		}
	}
}
