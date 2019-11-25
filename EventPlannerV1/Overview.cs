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
    public partial class Overview : Form
    {
        User _user;
        public Overview()
        {
            InitializeComponent();
        }

        public Overview(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void contactsBtn_Click(object sender, EventArgs e)
        {
            ContactsView contactsView = new ContactsView(_user);
            this.Hide();
            contactsView.Show();
        }
    }
}
