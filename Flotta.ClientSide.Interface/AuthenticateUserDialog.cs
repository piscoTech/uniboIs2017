using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flotta.ClientSide.Interface
{

    public delegate void ValidatedHandler();
    public delegate bool SubmitHandler(string username, string password);

    public interface IAuthenticateUserDialog : ICloseableDisposable
    {
        void Show();
        string Username { get; set; }
        string Password { get; set; }
        event ValidatedHandler OnValidated;
        event SubmitHandler OnSubmit;
    }

    public partial class AuthenticateUserDialog : Form, IAuthenticateUserDialog
    {
        public event ValidatedHandler OnValidated;
        public event SubmitHandler OnSubmit;

        public AuthenticateUserDialog()
        {
            InitializeComponent();
        }

        public string Username
        {
            get => username.Text;
            set => username.Text = value;
        }

        public string Password
        {
            get => password.Text;
            set => password.Text = value;
        }


        private void submitButton_Click(object sender, EventArgs e)
        {

            if (OnSubmit(Username, Password))
                OnValidated();
            else
            {
                MessageBox.Show("Username o Password errati...");
            }
        }
    }
}
