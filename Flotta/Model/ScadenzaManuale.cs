using System;
namespace Flotta.Model
{
	[ScadenzaType("Manuale", 0)]
	class ScadenzaManuale : Scadenza
	{
		public override bool HasDate => true;
		public override bool HasRecurrencyPeriod => false;
	}
}
