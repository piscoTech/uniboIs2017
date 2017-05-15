using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ServerSide.Interface
{

	public delegate void CreateClientHandler();

	public interface IServerWindow
	{
		bool CanTerminate { set; } 
		event CreateClientHandler CreateClient;
		void UpdateCounter(int activeConnections);

		void Run();
	}
}
