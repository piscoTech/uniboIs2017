using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	abstract class LinkedObject
	{

		private string _name;
		private bool _disabled;

		public string Name
		{
			get => _name;
		}

		public bool IsDisabled
		{
			get => _disabled;
		}

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

	}
}
