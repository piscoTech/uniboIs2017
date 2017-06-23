using System;

namespace Flotta.Model
{
	public class ScadenzaFormatDescriptor
	{
		private readonly ScadenzaFormat _formatter;
		private readonly ScadenzaFormatAttribute _attr;

		internal ScadenzaFormatDescriptor(ScadenzaFormat form, ScadenzaFormatAttribute attr)
		{
			if (attr == null || form == null)
				throw new ArgumentNullException();

			_formatter = form;
			_attr = attr;
		}

		public ScadenzaFormat Formatter => _formatter;
		public string Name => _attr.Name;
		public int Order => _attr.Order;

		public bool IsFormat(Scadenza scad)
		{
			return _formatter.GetType() == scad.Formatter.GetType();
		}
	}
}
