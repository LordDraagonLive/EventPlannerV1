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
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            AddUserTest(usernameTxt.Text.ToString(), passwordTxt.Text.ToString());

        }

        private String AddUserTest(String username, String password)
        {

            using (var db = new EventContext())
            {
                String name = "John";

                var user = new User { Name = name, Username = username, Password = password };
                db.Users.Add(user);
                db.SaveChanges();


                var query = from u in db.Users orderby u.Name select u;
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

            }
            return "Successs";
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
