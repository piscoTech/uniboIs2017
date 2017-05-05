using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;

namespace Flotta.ServerSide
{

	public delegate void ObjectChanged(IDBObject obj);

	public interface IServer
	{
		void ClientDisconnected();
		void ClientConnected();
		event ObjectChanged OnObjectChange;
	}
}
