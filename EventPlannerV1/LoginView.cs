using EventPlannerV1.Models;
using EventPlannerV1.Utilites;
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
            // create xml file if not available
            Helper.InitXmlSave();
            this.Controls.Remove(this.pictureBox1);
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Add(this.pictureBox1);
            this.pictureBox1.BringToFront();
            // Get Result from db
            int LoginStatus = await CheckLogin(usernameTxt.Text.ToString(), passwordTxt.Text.ToString());

            //Display appropriate message
            if (LoginStatus == 1)
            {
                this.Controls.Remove(this.pictureBox1);
                MessageBox.Show("Login Successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Overview overview = new Overview(_user);
                this.Hide();
                overview.Show();
            }
            else if(LoginStatus == 2)
            {
                this.Controls.Remove(this.pictureBox1);
                MessageBox.Show("Login Failed! Please Check username and password", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                usernameTxt.Focus();
            }
            else if (LoginStatus == 0)
            {
                this.Controls.Remove(this.pictureBox1);
                MessageBox.Show("Username and Password cannot be empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTxt.Focus();
            }
        }

        /// <summary>
        /// Check if user exists and allow login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<int> CheckLogin(String username, String password)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                return 0;
            }

            using (var db = new EventContext())
            {
                var allUsers = await System.Threading.Tasks.Task.Run(() => from users in db.Users select users);
                //var allUsers = from users in db.Users select users;

                foreach (var user in allUsers)
                {
                    if (user.Username.Equals(username) && user.Password.Equals(password))
                    {
                        _user = user;
                        return 1;
                    }
                }
                //await System.Threading.Tasks.Task.Run(() => db.SaveChangesAsync());
            }
            return 2;
        }

        /// <summary>
        /// redirect user to register user view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
