using System;

namespace Flotta.Model
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	internal class ScadenzaTypeAttribute : Attribute
	{
		private string _name;
		private int _order;
		internal ScadenzaTypeAttribute(string name, int order)
		{
			Name = name;
			_order = order;
		}

		internal string Name
		{
			get { return _name; }
			set
			{
				if (String.IsNullOrEmpty(value))
					throw new ArgumentException("String.IsNullOrEmpty(value)");
				_name = value;
			}
		}

		internal int Order => _order;
	}

	public abstract class Scadenza
	{
		public abstract bool HasDate { get; }
		public abstract bool HasRecurrentPeriod { get; }

		private DateTime _date;

		public DateTime Date
		{
			get => _date;
			set
			{
				if (!HasDate)
					throw new InvalidOperationException("Scadenza has not a date");
				if (value.Date < DateTime.Now.Date)
					throw new ArgumentException("Date is in the past");

				_date = value.Date;
			}
		}
	}

	abstract class ScadenzaConData : Scadenza
	{
		public sealed override bool HasDate => true;
	}
}
