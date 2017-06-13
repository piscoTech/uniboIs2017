using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public interface ILinkedTypeListItem
	{
		string Description { get; }
		bool IsDisabled { get; }
	}

	class LinkedTypeListItem : ILinkedTypeListItem
	{
		private readonly string _name;
		private readonly bool _disabled;

		internal LinkedTypeListItem(string name, bool disabled)
		{
			if (name == null)
				throw new ArgumentNullException("No name specified");

			_name = name;
			_disabled = disabled;
		}

		public string Description => _name;
		public bool IsDisabled => _disabled;
	}
}
