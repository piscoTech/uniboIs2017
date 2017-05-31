using System;

namespace Flotta.Model
{
	public interface IScadenzaOwner : IDBObject
	{
		IMezzo Mezzo { get; }
		Scadenza Scadenza { get; set; }
		string ScadenzaName { get; }
	}
}
