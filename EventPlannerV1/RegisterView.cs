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

            RegisterStatus statusMsg = RegisterUser(fullName, username,password, confirmPassword);

            if (statusMsg.Error == true)
            {
                MessageBox.Show(statusMsg.Message,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                nameTxt.Focus();
            }
            else
            {
                MessageBox.Show(statusMsg.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginView loginView = new LoginView();
                this.Hide();
                loginView.Show();
            }


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

        /// <summary>
        /// Adds user provided data to the database using the db context
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        private RegisterStatus RegisterUser(String fullName, String username, String password, String confirmPassword)
        {
            RegisterStatus registerStatus;

            if (String.IsNullOrWhiteSpace(fullName) || String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password) || String.IsNullOrWhiteSpace(confirmPassword))
            {
                registerStatus = new RegisterStatus()
                {
                    Message = "Required fields are empty!",
                    Error = true
                };
                return registerStatus;
            }

            using (var db = new EventContext())
            {
                if (!IsPasswordEqual(password, confirmPassword))
                {
                    registerStatus = new RegisterStatus()
                    {
                        Message = "Passwords doesn't match!",
                        Error = true
                    };
                    return registerStatus;
                }

                // Get all users in db and validate
                var allUsersQuery = from users in db.Users orderby users.Name select users;

                foreach (var reguser in allUsersQuery)
                {
                    if (reguser.Username.Equals(username))
                    {
                        registerStatus = new RegisterStatus()
                        {
                            Message = "Username already exists!",
                            Error = true
                        };
                        return registerStatus;
                    }
                    else if (!(fullName.Length>=3 && password.Length>= 3))
                    {
                        registerStatus = new RegisterStatus()
                        {
                            Message = "Username and Password size must be more than 2 characters",
                            Error = true
                        };
                        return registerStatus;
                    }
                }

                // Add new user to db
                var newUser = new User { Name = fullName, Username = username, Password = password };
                db.Users.Add(newUser);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    registerStatus = new RegisterStatus()
                    {
                        Message = "Internal Database Error!",
                        Error = true
                    };
                    return registerStatus;
                }

                registerStatus = new RegisterStatus()
                {
                    Message = "User registration successful!",
                    Error = false
                };
                return registerStatus;
            }
        }

        /// <summary>
        /// Simple Struct to hold status messages
        /// </summary>
        struct RegisterStatus
        {
            public String Message;
            public bool Error;

        }
    }
}
