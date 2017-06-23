using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class LinkedTypeAttribute : Attribute
	{
		private string _name;
		internal LinkedTypeAttribute(string name)
		{
			Name = name;
		}

		internal string Name
		{
			get { return _name; }
			set
			{
				if (String.IsNullOrEmpty(value))
					throw new ArgumentException("Invalid name");
				_name = value;
			}
		}
	}

	public abstract class LinkedType : IDBObject
	{

		private string _name;
		private bool _disabled;

		public string Name => _name;
		public bool IsDisabled => _disabled;

		public IEnumerable<string> Update(string name)
		{
			List<string> errors = new List<string>();

			name = name?.Trim();
			if (String.IsNullOrEmpty(name))
				errors.Add("Nome non specificato");

			if (errors.Count > 0)
				return errors;

			_name = name;

			return errors;
		}

		public void Disable()
		{
			_disabled = true;
		}

		public abstract bool ShouldDisableInsteadOfDelete(IEnumerable<IMezzo> mezzi);
	}
}
