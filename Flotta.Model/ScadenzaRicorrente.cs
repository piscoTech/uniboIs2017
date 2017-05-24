using System;
namespace Flotta.Model
{
	[ScadenzaTypeAttribute("Ricorrente", 1)]
	class ScadenzaRicorrente : ScadenzaConData
	{
		public override bool HasRecurrencyPeriod => true;
	}
}
