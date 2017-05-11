using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ServerSide;

namespace Flotta.ClientSide
{
	public static class ClientSideFactory
	{
		public static IClient NewClientPresenter(IServer server)
		{
			return (new Client(server));
		}
	}
}
