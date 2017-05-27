using System;
namespace Flotta.Model
{
	[ScadenzaType("Ricorrente", 1)]
	class ScadenzaRicorrente : ScadenzaConData
	{
		public override bool HasRecurrencyPeriod => true;
	}
}
