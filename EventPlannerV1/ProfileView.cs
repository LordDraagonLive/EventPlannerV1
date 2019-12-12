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
    public partial class ProfileView : Form
    {
        User _user;
        public ProfileView()
        {
            InitializeComponent();
        }

        public ProfileView(User user)
        {
            InitializeComponent();
            _user = user;
            InitUser();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChngPaswrdTxt_Click(object sender, EventArgs e)
        {
            if (passwordTxt.Text.Equals("") || conPasswordTxt.Text.Equals(""))
            {
                MessageBox.Show("The Password and Confirm Password Fields cannot be empty", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!passwordTxt.Text.Equals(conPasswordTxt.Text))
            {
                MessageBox.Show("The Passwords doesn't match", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new EventContext())
            {
                User result = (from user in db.Users
                                where user.UserId == _user.UserId
                                select user).SingleOrDefault();

                try
                {
                    result.Password = passwordTxt.Text;
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Password change failed", "Database Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Helper.SaveLog(ex);
                    return;
                }
                MessageBox.Show("Password changed successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InitUser()
        {
            usernameTxt.Text = _user.Username;
            nameTxt.Text = _user.Name;
            passwordTxt.Text = _user.Password;
        }
    }
}
