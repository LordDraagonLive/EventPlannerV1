using EventPlannerV1.Models;
using EventPlannerV1.Utilites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventPlannerV1
{
    public partial class ContactsView : Form
    {
        User _user;
        int selectedContact;
        int clickCounter = 0;
        //EventContext eventContext;
        public ContactsView()
        {
            InitializeComponent();
        }

        public ContactsView(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void contactsBtn_Click(object sender, EventArgs e)
        {

            AddContactView addContactView = new AddContactView(_user);
            addContactView.ShowDialog(this);
            
        }

        private void ContactsView_Load(object sender, EventArgs e)
        {
            contactsDtGrd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            contactsDtGrd.AutoGenerateColumns = true;
            contactsDtGrd.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            contactsDtGrd.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(26)))), ((int)(((byte)(64)))));
            contactsDtGrd.EnableHeadersVisualStyles = false;
            contactsDtGrd.ColumnHeadersVisible = false;
            contactsDtGrd.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D5EFF2");
            //contactsDtGrd.AlternatingRowsDefaultCellStyle.ForeColor = Color.Azure;

            //for (int i = 0; i < contactsDtGrd.Columns.Count; i++)
            //{
            //    contactsDtGrd.Columns[i].FillWeight = GetFillWeight(contactsDtGrd.Columns[i].Name);
            //    contactsDtGrd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //    contactsDtGrd.Columns[i].MinimumWidth = (int)contactsDtGrd.Columns[i].FillWeight;

            //}

            var delBtnCol = new DataGridViewButtonColumn
            {
                Name = "DelBtn",
                HeaderText = "Delete",
                Text = "X",
                ToolTipText="Delete"
            };
            delBtnCol.UseColumnTextForButtonValue = true;
            delBtnCol.DefaultCellStyle.ForeColor = Color.Red;
            delBtnCol.FlatStyle = FlatStyle.Flat;
            delBtnCol.DefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
            contactsDtGrd.Columns.Add(delBtnCol);
        }

        /// <summary>
        /// Helper method to deteremine the datagrid's cell width
        /// </summary>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        private float GetFillWeight(string FieldName)
        {
            switch (FieldName)
            {
                case "Name":
                    return 200;
                case "Email":
                    return 200;
                case "Address":
                    return 200;
                case "TelNo":
                    return 100;
                case "Note":
                    return 500;
                default:
                    return 100;
            }
        }


        private void ContactsView_Activated(object sender, EventArgs e)
        {
            using (var db = new EventContext())
            {
                ReloadContacts(db);
                contactsDtGrd.Columns["Name"].DisplayIndex = 0;
                //contactsDtGrd.Columns["Email"].DisplayIndex = 1;
                //contactsDtGrd.Columns["Address"].DisplayIndex = 2;
                //contactsDtGrd.Columns["TelNo"].DisplayIndex = 3;
                //contactsDtGrd.Columns["Note"].DisplayIndex = 4;
                //contactsDtGrd.Columns["Email"].HeaderText = "E-Mail";
                contactsDtGrd.Columns["ContactId"].Visible = false;
                contactsDtGrd.Columns["UserId"].Visible = false;
                contactsDtGrd.Columns["User"].Visible = false;
                contactsDtGrd.Columns["Email"].Visible = false;
                contactsDtGrd.Columns["Address"].Visible = false;
                contactsDtGrd.Columns["TelNo"].Visible = false;
                contactsDtGrd.Columns["Note"].Visible = false;
            }           
        }


        private void contactsDtGrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCounter++;
            if (clickCounter == 1)
            {
                this.contactNameTxt.Enabled = true;
                this.contactEmailTxt.Enabled = true;
                this.contactAddressTxt.Enabled = true;
                this.contactTelTxt.Enabled = true;
                this.contactNoteTxt.Enabled = true;
                this.updateContactBtn.Enabled = true;

            }
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int contactId = (int)contactsDtGrd["contactId",e.RowIndex].Value;
                String contactName = contactsDtGrd["Name", e.RowIndex].Value.ToString();


                if (MessageBox.Show("Please confirm before proceed" 
                    + "\n" + "Do you want to delete " + contactName + " from contacts?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //if YES
                    DeleteContact(contactId);
                }


            }
            else
            {
                selectedContact = (int)contactsDtGrd["contactId", e.RowIndex].Value;
                this.contactNameTxt.Text = contactsDtGrd["Name", e.RowIndex].Value.ToString();
                this.contactEmailTxt.Text = contactsDtGrd["Email", e.RowIndex].Value.ToString(); ;
                this.contactAddressTxt.Text = contactsDtGrd["Address", e.RowIndex].Value.ToString(); ;
                this.contactTelTxt.Text = contactsDtGrd["TelNo", e.RowIndex].Value.ToString(); ;
                this.contactNoteTxt.Text = contactsDtGrd["Note", e.RowIndex].Value.ToString(); ;
            }
        }

        /// <summary>
        /// Deletes a contact by contact ID
        /// </summary>
        /// <param name="ContactId"></param>
        private void DeleteContact(int ContactId)
        {
            using (var db = new EventContext())
            {
                var DelContact = (from contact in db.Contacts
                         where contact.ContactId == ContactId
                         select contact).FirstOrDefault();
                try
                {
                    db.Contacts.Remove(DelContact);
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("This contact is being used by one or more events. Delete the related events before deleting this contact!", "Delete Failed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Helper.SaveLog(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Internal Database Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Helper.SaveLog(ex);
                }
                ReloadContacts(db);
            }
        }

        /// <summary>
        /// Reloads the contacts list for chanages
        /// </summary>
        /// <param name="db"></param>
        private void ReloadContacts(EventContext db)
        {
            // Load only the contacts belong to the logged in user
            BindingSource bindingSource = new BindingSource
            {
                DataSource = (from contact in db.Contacts where contact.User.UserId == _user.UserId select contact).ToList()
            };

            contactsDtGrd.DataSource = bindingSource;
        }

        private void updateContactBtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Please confirm before proceed"
                    + "\n" + "Do you want to update this contact?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //if YES
                using (var db = new EventContext())
                {
                    Contact result = (from contact in db.Contacts
                                      where contact.ContactId == selectedContact
                                      select contact).SingleOrDefault();

                    result.Name = this.contactNameTxt.Text.ToString();
                    result.Email = this.contactEmailTxt.Text.ToString();
                    result.Address = this.contactAddressTxt.Text.ToString();
                    result.TelNo = this.contactTelTxt.Text.ToString();
                    result.Note = this.contactNoteTxt.Text.ToString();

                    try
                    {
                        db.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Internal Database Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Helper.SaveLog(ex);
                    }
                    ReloadContacts(db);
                }
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Overview overview = new Overview(_user);
            overview.Show();
            this.Close();
        }
    }
}
