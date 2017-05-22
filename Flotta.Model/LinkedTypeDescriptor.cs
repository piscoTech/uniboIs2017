using System;

namespace Flotta.Model
{
	public class LinkedTypeDescriptor
	{
		private Type _type;
		private string _desc;
		private Type _concreteType;

		internal LinkedTypeDescriptor(Type type, string description, Type concreteType)
		{
			if (!typeof(LinkedType).IsAssignableFrom(type) || !type.IsAbstract)
				throw new ArgumentException("Type is not an abstract LinkedObject");
			if (!type.IsAssignableFrom(concreteType) || concreteType.IsAbstract)
				throw new ArgumentException("Concrete Type is not a concrete subtype of Type");
			if (String.IsNullOrEmpty(description))
				throw new ArgumentException("Invalid description");

			_type = type;
			_desc = description;
			_concreteType = concreteType;
		}

		public string Description => _desc;
		public Type Type => _type;
		internal Type ConcreteType => _concreteType;
	}
}
