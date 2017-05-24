using System;
namespace Flotta.Model
{
	[ScadenzaTypeAttribute("Manuale", 0)]
	class ScadenzaManuale : ScadenzaConData
	{
		public override bool HasRecurrentPeriod => false;
	}
}
