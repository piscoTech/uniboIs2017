using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{

	public interface ILinkedObjectListItem
	{
		string Description { get; }
		bool IsDisabled { get; }
	}

	class LinkedObjectListItem : ILinkedObjectListItem
	{
		private string _name;
		private bool _disabled;

		internal LinkedObjectListItem(string name, bool disabled)
		{
			_name = name;
			_disabled = disabled;
		}

		public string Description => _name;
		public bool IsDisabled => _disabled;
	}
}
