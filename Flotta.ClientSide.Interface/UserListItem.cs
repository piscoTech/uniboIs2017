using System;

namespace Flotta.ClientSide.Interface
{
	public interface IUserListItem
	{
		string Username { get; }
		bool IsAdmin { get; }
	}

	class UserListItem : IUserListItem
	{
		private string _name;
		private bool _admin;

		internal UserListItem(string name, bool admin)
		{
			if (name == null)
				throw new ArgumentNullException("No name specified");

			_name = name;
			_admin = admin;
		}

		public string Username => _name;
		public bool IsAdmin => _admin;
	}
}