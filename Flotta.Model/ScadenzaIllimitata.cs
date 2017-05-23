using System;
namespace Flotta.Model
{
	class ScadenzaIllimitata : Scadenza
	{
		public override bool HasDate => false;
		public override bool HasFormat => false;
		public override bool HasRecurrentPeriod => false;

		protected override string _description => "Illimitata";
	}
}
