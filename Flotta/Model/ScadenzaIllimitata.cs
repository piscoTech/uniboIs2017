using System;
namespace Flotta.Model
{
	[ScadenzaType("Illimitata", 2)]
	class ScadenzaIllimitata : Scadenza
	{
		public override bool HasDate => false;
		public override bool HasRecurrencyPeriod => false;
	}
}
