using System;

namespace Flotta.Model
{
	public class ScadenzaRecurrencyTypeDescriptor
	{
		private readonly ScadenzaRecurrencyType _recType;
		private readonly ScadenzaRecurrencyTypeAttribute _attr;

		internal ScadenzaRecurrencyTypeDescriptor(ScadenzaRecurrencyType recType, ScadenzaRecurrencyTypeAttribute attr)
		{
			if (attr == null || recType == null)
				throw new ArgumentNullException();

			_recType = recType;
			_attr = attr;
		}

		public ScadenzaRecurrencyType RecurrencyType => _recType;
		public string Name => _attr.Name;
		public int Order => _attr.Order;

		public bool IsRecurrencyType(Scadenza scad)
		{
			return _recType.GetType() == scad.RecurrencyType.GetType();
		}
	}
}
