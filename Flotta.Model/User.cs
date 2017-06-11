using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IUser : IDBObject
	{
		string Username { get; }
		bool IsAdmin { get; }

		bool Match(string username, string password);
		IEnumerable<string> ChangePassword(string newPassword, string oldPassword);
		IEnumerable<string> Update(string username, bool isAdmin);
	}

	internal class User : IUser
	{
		private string _username;
		private string _password;
		private bool _isAdmin;

		public string Username => _username;
		public bool IsAdmin => _isAdmin;

		public bool Match(string username, string password)
		{
			return _username == username && _password == password;
		}

		public IEnumerable<string> ChangePassword(string newPassword, string oldPassword)
		{
			List<string> errors = new List<string>();
			if (String.IsNullOrEmpty(newPassword))
				errors.Add("Password non inserita");

			if (_password != null)
			{
				if (oldPassword == null || oldPassword != _password)
					errors.Add("La vecchia password non corrisponde");

				if (_password == newPassword)
					errors.Add("La nuova password deve essere diversa");
			}

			if (errors.Count > 0)
				return errors;

			_password = newPassword;

			return errors;
		}

		public IEnumerable<string> Update(string username, bool isAdmin)
		{
			List<string> errors = new List<string>();

			username = username?.Trim();
			if (String.IsNullOrEmpty(username))
				errors.Add("Nome utente non inserito");

			if (errors.Count > 0)
				return errors;

			_username = username;
			_isAdmin = isAdmin;

			return errors;
		}
	}
}
