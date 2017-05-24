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

	public abstract class Scadenza : ICloneable
	{
		public abstract bool HasDate { get; }
		public abstract bool HasRecurrentPeriod { get; }

		private DateTime _date;
		private ScadenzaFormat _formatter;

		public DateTime Date
		{
			get => _date;
			set
			{
				if (!HasDate)
					throw new InvalidOperationException("Scadenza non valida");
				if (value.Date < DateTime.Now.Date)
					throw new ArgumentException("La scadenza non può essere nel passato");

				_date = value.Date;
			}
		}

		public ScadenzaFormat Formatter
		{
			get => _formatter;
			set
			{
				if (!HasDate)
					throw new InvalidOperationException("Scadenza has not a date");
				if (value == null)
					throw new ArgumentNullException("Formatter is null");

				_formatter = value;
				Date = value.UpdateDate(_date);
			}
		}

		public string DateDescription => HasDate ? _formatter.Format(_date) : "Illimitata";

		public object Clone()
		{
			Scadenza scad = Activator.CreateInstance(this.GetType()) as Scadenza;

			if (HasDate)
			{
				scad._date = this._date;
				scad._formatter = this._formatter;
			}
			if (HasRecurrentPeriod)
			{
				// Period should be defined as a value type
			}

			return scad;
		}
	}

	abstract class ScadenzaConData : Scadenza
	{
		public sealed override bool HasDate => true;
	}
}
