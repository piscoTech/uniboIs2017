using System;

namespace Flotta.Model
{
	public class ScadenzaTypeDescriptor
	{
		private readonly Type _type;
		private readonly ScadenzaTypeAttribute _attr;

		internal ScadenzaTypeDescriptor(Type type, ScadenzaTypeAttribute attr)
		{
			if (!typeof(Scadenza).IsAssignableFrom(type) || type.IsAbstract)
				throw new ArgumentException("Type is not an concrete subclass of Scadenza");
			if (attr == null)
				throw new ArgumentNullException();

			_type = type;
			_attr = attr;
		}

		public Scadenza NewInstance => (Scadenza)Activator.CreateInstance(_type, true);
		public string Name => _attr.Name;
		public int Order => _attr.Order;

		public bool IsType(Scadenza type)
		{
			return type.GetType() == _type;
		}
	}
}
