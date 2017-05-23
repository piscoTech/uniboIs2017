using System;

namespace Flotta.Model
{
	public class ScadenzaTypeDescriptor
	{
		private Type _type;

		internal ScadenzaTypeDescriptor(Type type)
		{
			if (!typeof(Scadenza).IsAssignableFrom(type) || type.IsAbstract)
				throw new ArgumentException("Type is not an concrete subclass of Scadenza");

			_type = type;
		}

		public Scadenza NewInstance()
		{
			return (Scadenza)Activator.CreateInstance(_type, true);
		}
	}
}
