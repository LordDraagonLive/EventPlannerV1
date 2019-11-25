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
    public partial class AddContactView : Form
    {
        User _user;
        public AddContactView()
        {
            InitializeComponent();
        }

        public AddContactView(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void addContactBtn_Click(object sender, EventArgs e)
        {
            String contactName = contactNameTxt.Text.ToString();
            String contactEmail = contactEmailTxt.Text.ToString();
            String contactAddress = contactAddressTxt.Text.ToString();
            String contactNote = contactNoteTxt.Text.ToString();
            String contactTelNo = contactTelTxt.Text.ToString();


            using (var db = new EventContext())
            {
                var allContacts = from contact in db.Contacts where contact.User.UserId == _user.UserId select contact;

                foreach (var contact in allContacts)
                {

                    if (contact.Name == contactName)
                    {
                        MessageBox.Show("Contact Name already exists!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        contactNameTxt.Focus();
                    }
                }

                // Add new contact to db
                Contact newContact = new Contact { Name = contactName, Address = contactAddress, Email = contactEmail, TelNo = contactTelNo, Note = contactNote, UserId= _user.UserId };
                db.Contacts.Add(newContact);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Internal Database Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                MessageBox.Show("Contact Addition Successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
    }
}
