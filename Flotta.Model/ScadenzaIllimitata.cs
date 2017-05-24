using System;
namespace Flotta.Model
{
	[ScadenzaTypeAttribute("Illimitata", 2)]
	class ScadenzaIllimitata : Scadenza
	{
		public override bool HasDate => false;
		public override bool HasRecurrentPeriod => false;
	}
}
