using System;

namespace Flotta.Model
{
	public class LinkedTypeDescriptor
	{
		private Type _type;
     	private string _desc;
		private Delegate _creator;

		internal LinkedTypeDescriptor(Type type, string description, Delegate creator)
		{
			if (!typeof(LinkedType).IsAssignableFrom(type) || !type.IsAbstract)
				throw new ArgumentException("Type is not an abstract LinkedObject");
			if (creator.Method.GetParameters().Length != 0 || !type.IsAssignableFrom(creator.Method.ReturnType))
				throw new ArgumentException("Creator does not take zero argument and return the passed type");
			if (String.IsNullOrEmpty(description))
				throw new ArgumentException("Invalid description");

			_type = type;
			_desc = description;
			_creator = creator;
		}

        public string Description => _desc;
		public Type Type => _type;
		public Delegate Creator => _creator;
    }
}
