using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
    public interface IUser
    {
        string Username { get; }
        string Password { get; }
    }

    internal class User : IUser
    {
        private string _username;
        private string _password;

        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}
