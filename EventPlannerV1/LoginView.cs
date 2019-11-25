using EventPlannerV1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventPlannerV1
{
    public partial class LoginView : Form
    {
        User _user;

        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            int LoginStatus = CheckLogin(usernameTxt.Text.ToString(), passwordTxt.Text.ToString());

            if (LoginStatus == 1)
            {
                MessageBox.Show("Login Successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Overview overview = new Overview(_user);
                this.Hide();
                overview.Show();
            }
            else if(LoginStatus == 2)
            {
                MessageBox.Show("Login Failed! Please Check username and password", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTxt.Focus();
            }
            else if (LoginStatus == 0)
            {
                MessageBox.Show("Username and Password cannot be empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTxt.Focus();
            }
        }

        private int CheckLogin(String username, String password)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                return 0;
            }

            using (var db = new EventContext())
            {
                var allUsers = from users in db.Users orderby users.Name select users;

                foreach (var user in allUsers)
                {
                    if (user.Username.Equals(username) && user.Password.Equals(password))
                    {
                        _user = user;
                        return 1;
                    }
                }
            }
            return 2;
        }

        private void NewAcctLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterView registerView = new RegisterView();
            this.Hide();
            registerView.Show();
        }

        private void LoginView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
