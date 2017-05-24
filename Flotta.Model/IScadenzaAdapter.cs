using System;

namespace Flotta.Model
{
	public interface IScadenzaAdapter : IDBObject
	{
		Scadenza Scadenza { get; set; }
		string ScadenzaName { get; }
	}
}
