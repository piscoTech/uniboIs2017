using System;

namespace Flotta.Model
{
	public interface IScadenzaAdapter : IDBObject
	{
		IMezzo Mezzo { get; }
		Scadenza Scadenza { get; set; }
		string ScadenzaName { get; }
	}
}
