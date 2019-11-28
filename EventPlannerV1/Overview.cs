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

        private void addEventBtn_Click(object sender, EventArgs e)
        {
            //Get End time as the new event time
            String newEventTime = endDtPicker.Value.ToString();

            AddEventView addEventView = new AddEventView(_user);
            addEventView.ShowDialog(this);
        }

        private void Overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
