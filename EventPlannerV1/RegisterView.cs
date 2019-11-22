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
    public partial class RegisterView : Form
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Redirects to Login View whilst closing the Register View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginView loginView = new LoginView();
            this.Hide();
            loginView.Show();
        }

        /// <summary>
        /// Overrides default x close button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            // get all vars
            String fullName = nameTxt.Text.ToString();
            String username = usernameTxt.Text.ToString();
            String password = passwordTxt.Text.ToString();
            String confirmPassword = confirmTxt.Text.ToString();

            RegisterUser(fullName, username,password, confirmPassword);

        }

        /// <summary>
        /// Checks if password and confirmPasswords are equal
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        private bool IsPasswordEqual(String password, String confirmPassword)
        {
            if (password.Equals(confirmPassword))
            {
                return true;
            }
            return false;
        }

        private bool RegisterUser(String fullName, String username, String password, String confirmPassword)
        {
            using (var db = new EventContext())
            {

                var user = new User { Name = fullName, Username = username, Password = password };
                db.Users.Add(user);
                db.SaveChanges();


                var query = from u in db.Users orderby u.Name select u;
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

            }

            return false;
        }
    }
}
