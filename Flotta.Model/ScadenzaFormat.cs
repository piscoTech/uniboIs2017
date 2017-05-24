using System;

namespace Flotta.Model
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	internal class ScadenzaFormatAttribute : Attribute
	{
		private string _name;
		private int _order;
		internal ScadenzaFormatAttribute(string name, int order)
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

	public abstract class ScadenzaFormat
	{
		public abstract string Format(DateTime date);
		public abstract DateTime UpdateDate(DateTime date);
	}

	[ScadenzaFormatAttribute("gg/mm/aaaa", 0)]
	class FullDateScadenzaFormat : ScadenzaFormat
	{
		public override string Format(DateTime date)
		{
			return date.ToString("dd/MM/yyyy");
		}

		public override DateTime UpdateDate(DateTime date)
		{
			return date;
		}
	}

	[ScadenzaFormatAttribute("mm/aaaa", 0)]
	class NoDayScadenzaFormat : ScadenzaFormat
	{
		public override string Format(DateTime date)
		{
			return date.ToString("MM/yyyy");
		}

		public override DateTime UpdateDate(DateTime date)
		{
			return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
		}
	}
}
