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

	internal class MezzoScadenzaAdapter : IScadenzaAdapter
	{
		private IMezzo _mezzo;
		private PropertyInfo _scadProperty;
		private string _name;

		internal MezzoScadenzaAdapter(IMezzo mezzo, PropertyInfo property, string name)
		{
			if (mezzo == null || property == null || String.IsNullOrEmpty(name))
				throw new ArgumentNullException();
			if (!typeof(Scadenza).IsAssignableFrom(property.PropertyType))
				throw new ArgumentException("Invalid property");

			_mezzo = mezzo;
			_scadProperty = property;
			_name = name;
		}

		public IMezzo Mezzo => _mezzo;

		public Scadenza Scadenza
		{
			get => _scadProperty.GetValue(_mezzo, null) as Scadenza;
			set => _scadProperty.SetValue(_mezzo, value, null);
		}

		public string ScadenzaName => _name;
	}
}
