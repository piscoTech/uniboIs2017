using System;

namespace Flotta.Model
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	internal class ScadenzaRecurrencyTypeAttribute : Attribute
	{
		private string _name;
		private int _order;
		internal ScadenzaRecurrencyTypeAttribute(string name, int order)
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

	public abstract class ScadenzaRecurrencyType
	{
		public abstract DateTime NextDate(int interval);
	}

	[ScadenzaRecurrencyType("settimane", 0)]
	class WeekScadenzaRecurrencyType : ScadenzaRecurrencyType
	{
		public override DateTime NextDate(int interval)
		{
			return DateTime.Now.Date.AddDays(interval * 7);
		}
	}

	[ScadenzaRecurrencyType("mesi", 1)]
	class MonthScadenzaRecurrencyType : ScadenzaRecurrencyType
	{
		public override DateTime NextDate(int interval)
		{
			return DateTime.Now.Date.AddMonths(interval);
		}
	}

	[ScadenzaRecurrencyType("anni", 2)]
	class YearScadenzaRecurrencyType : ScadenzaRecurrencyType
	{
		public override DateTime NextDate(int interval)
		{
			return DateTime.Now.Date.AddYears(interval);
		}
	}
}
