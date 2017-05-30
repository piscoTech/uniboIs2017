using System;
namespace Flotta.Model
{
	[ScadenzaType("Ricorrente", 1)]
	class ScadenzaRicorrente : Scadenza
	{
		public override bool HasDate => true;
		public override bool HasRecurrencyPeriod => true;
	}
}
