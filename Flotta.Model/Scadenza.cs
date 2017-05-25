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
		public abstract bool HasRecurrencyPeriod { get; }

		private DateTime _date;
		private ScadenzaFormat _formatter;

		private uint _recInterval;
		private ScadenzaRecurrencyType _recType;

		public DateTime Date
		{
			get => _date;
			set
			{
				if (!HasDate)
					throw new InvalidOperationException("Scadenza non valida");
				if (value.Date < DateTime.Now.Date)
					throw new ArgumentException("La scadenza non può essere nel passato");

				_date = _formatter?.UpdateDate(value).Date ?? value.Date;
			}
		}

		public bool Expired => HasDate ? Date <= DateTime.Now.Date : false;

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
				Date = value.UpdateDate(_date).Date;
			}
		}

		public uint RecurrencyInterval
		{
			get => _recInterval;
			set
			{
				if (!HasRecurrencyPeriod)
					throw new InvalidOperationException("Scadenza is not recurrent");
				if (value < 1)
					throw new ArgumentException("L'intervallo di ricorrenza deve essere positivo");

				_recInterval = value;
			}
		}

		public ScadenzaRecurrencyType RecurrencyType
		{
			get => _recType;
			set
			{
				if (!HasRecurrencyPeriod)
					throw new InvalidOperationException("Scadenza is not recurrent");
				if (value == null)
					throw new ArgumentNullException("No recurrency type");

				_recType = value;
			}
		}

		public void SetNextDate()
		{
			if (!HasRecurrencyPeriod)
				throw new InvalidOperationException("Scadenza is not recurrent");

			Date = RecurrencyType.NextDate(RecurrencyInterval);
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
			if (HasRecurrencyPeriod)
			{
				scad._recInterval = this._recInterval;
				scad._recType = this._recType;
			}

			return scad;
		}
	}

	abstract class ScadenzaConData : Scadenza
	{
		public sealed override bool HasDate => true;
	}
}
