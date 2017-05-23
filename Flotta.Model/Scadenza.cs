using System;

namespace Flotta.Model
{
	public abstract class Scadenza
	{
		public abstract bool HasDate { get; }
		public abstract bool HasFormat { get; }
		public abstract bool HasRecurrentPeriod { get; }

		protected abstract string _description { get; }
		private DateTime _date;

		public string Description => _description;
		public DateTime Date
		{
			get => _date;
			set
			{
				if (!HasDate)
					throw new InvalidOperationException("Scadenza has not a date");
				if (value == null)
					throw new ArgumentNullException("Date is null");
				if (value < DateTime.Now)
					throw new ArgumentException("Date is in the past");

				_date = value;
			}
		}
	}

	public abstract class ScadenzaConData : Scadenza
	{
		public sealed override bool HasDate => true;
		public override bool HasFormat => true;
		public override bool HasRecurrentPeriod => true;
	}
}
