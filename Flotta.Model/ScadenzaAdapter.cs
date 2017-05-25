using System;
using System.Reflection;

namespace Flotta.Model
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	internal class MezzoScadenzaAttribute : Attribute
	{
		private string _name;
		private int _order;
		internal MezzoScadenzaAttribute(string name, int order)
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

	public interface IScadenzaAdapter : IDBObject
	{
		Scadenza Scadenza { get; set; }
		string ScadenzaName { get; }
	}

	internal class ScadenzaAdapter : IScadenzaAdapter
	{
		private object _object;
		private PropertyInfo _scadProperty;
		private string _name;

		internal ScadenzaAdapter(object scadenzaOwner, PropertyInfo property, string name)
		{
			if (scadenzaOwner == null || property == null || String.IsNullOrEmpty(name))
				throw new ArgumentNullException();
			if (!typeof(Scadenza).IsAssignableFrom(property.PropertyType))
				throw new ArgumentException("Invalid property");

			_object = scadenzaOwner;
			_scadProperty = property;
			_name = name;
		}

		public Scadenza Scadenza
		{
			get => _scadProperty.GetValue(_object, null) as Scadenza;
			set => _scadProperty.SetValue(_object, value, null);
		}

		public string ScadenzaName => _name;
	}
}
