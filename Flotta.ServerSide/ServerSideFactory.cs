using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ServerSide.Interface;

namespace Flotta.ServerSide
{
	public static class ServerSideFactory
	{
		public static IServer NewServer(Action clientCreator)
		{
			return new Server() { ClientCreator = clientCreator };
		}
	}
}
