using System;

namespace Flotta.Model
{
    public class LinkedTypeDescriptor
    {
        private Type _type;
        private string _desc;

        internal LinkedTypeDescriptor(Type type, string description)
        {
            if (!typeof(LinkedType).IsAssignableFrom(type))
                throw new ArgumentException("Type is not a linked type");
            if (String.IsNullOrEmpty(description))
                throw new ArgumentException("Invalid description");

            _type = type;
            _desc = description;
        }

        public Type Type => _type;
        public string Description => _desc;
    }
}
