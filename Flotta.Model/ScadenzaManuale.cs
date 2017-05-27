using System;
namespace Flotta.Model
{
	[ScadenzaType("Manuale", 0)]
	class ScadenzaManuale : ScadenzaConData
	{
		public override bool HasRecurrencyPeriod => false;
	}
}
