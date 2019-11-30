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
using Task = EventPlannerV1.Models.Task;

namespace EventPlannerV1
{
    public partial class AddEventView : Form
    {
        User _user;
        List<Contact> userContacts;

        //Dynamic UI elements
        Label locationLbl;
        TextBox locationTxt;
        Label contactLbl;
        ComboBox eventContactsDropdown;

        public AddEventView()
        {
            InitializeComponent();
        }

        public AddEventView(User user)
        {
            _user = user;
            InitializeComponent();
            InitDynamicUI();
        }

        private void taskRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            EventTypeClick("Task");
        }

        private void appointRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            EventTypeClick("Appoint");
        }

        /// <summary>
        /// Change visibility of UI controls according to the event type
        /// </summary>
        /// <param name="eventType"></param>
        private void EventTypeClick(String eventType)
        {
            if (eventType.Equals("Task"))
            {
                // Remove the UI controls if task
                this.Controls.Remove(locationLbl);
                this.Controls.Remove(locationTxt);
                this.Controls.Remove(contactLbl);
                this.Controls.Remove(eventContactsDropdown);

                // Change UI controls position
                this.NoteLbl.Location = new System.Drawing.Point(12, 274);
                this.addNewEventBtn.Location = new System.Drawing.Point(343, 414);
                this.eventNoteTxt.Location = new System.Drawing.Point(137, 274);

            }
            else if (eventType.Equals("Appoint"))
            {
                // Change UI controls position
                this.NoteLbl.Location = new System.Drawing.Point(12, 350);
                this.addNewEventBtn.Location = new System.Drawing.Point(340, 463);
                this.eventNoteTxt.Location = new System.Drawing.Point(137, 350);

                // Add the dynamic UI controls to the view
                this.Controls.Add(locationLbl);
                this.Controls.Add(locationTxt);
                this.Controls.Add(contactLbl);
                this.Controls.Add(eventContactsDropdown);

                //populate combo box with contacts of the logged in user
                using (var db = new EventContext())
                {
                    List<Contact> dropDownContacts = (from contact in db.Contacts where contact.User.UserId == _user.UserId select contact).ToList();
                    userContacts = dropDownContacts;
                    dropDownContacts.Insert(0,new Contact() { Name = "<< No Contact >>" });
                    eventContactsDropdown.DataSource = dropDownContacts;
                    eventContactsDropdown.ValueMember = "ContactId";
                    eventContactsDropdown.DisplayMember = "Name";
                }
            }
        }

        /// <summary>
        /// Initializes the Dynamic UI Controls
        /// </summary>
        private void InitDynamicUI()
        {
            locationLbl = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(12, 266),
                Name = "LocationLbl",
                Size = new System.Drawing.Size(77, 18),
                TabIndex = 29,
                Text = "Location"
            };

            locationTxt = new TextBox
            {
                Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.RoyalBlue,
                Location = new System.Drawing.Point(137, 266),
                Name = "locationTxt",
                Size = new System.Drawing.Size(319, 23),
                TabIndex = 33
            };
            contactLbl = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(12, 310),
                Name = "contactLbl",
                Size = new System.Drawing.Size(71, 18),
                TabIndex = 42,
                Text = "Contact"
            };
            eventContactsDropdown = new ComboBox
            {
                Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.RoyalBlue,
                FormattingEnabled = true,
                Location = new System.Drawing.Point(137, 311),
                Name = "testContactsdropdown",
                Size = new System.Drawing.Size(319, 24),
                TabIndex = 43
            };
        }

        private void AddNewEvent()
        {
            String eventTitle = titleTxt.Text.ToString();
            DateTime startDateTime = startDtPicker.Value;
            DateTime endDateTime = endDtPicker.Value;
            String repeatEvent = repeatEventDropdown.Text;
            bool repeatEventBool = true;
            bool taskRadVal = taskRadBtn.Checked;
            bool appointRadVal = appointRadBtn.Checked;
            String eventLocation = locationTxt.Text.ToString();
            String eventContact = eventContactsDropdown.Text;
            String eventNote = eventNoteTxt.Text.ToString();


            int ValidationStatus = ValidateAddEvent();

            if (ValidationStatus == 1)
            {
                MessageBox.Show("Start Date/Time cannot be higher than the End Date/Time!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startDtPicker.Focus();
                return;
            }
            else if (ValidationStatus == 2)
            {
                MessageBox.Show("Event Title cannot be empty!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                titleTxt.Focus();
                return;
            }

            // Set the Event repetition status
            if (repeatEvent.Equals("Don't Repeat"))
            {
                repeatEventBool = false;
            }

            using (var db = new EventContext())
            {
                var allEvents = from userEvent in db.Events where userEvent.User.UserId == _user.UserId select userEvent;

                foreach (var userEvent in allEvents)
                {
                    if (userEvent.EventTitle == eventTitle)
                    {
                        MessageBox.Show("Title name already exists!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        titleTxt.Focus();
                        return;
                    }
                }

                // Add new event to db
                Event newEvent;

                // check if event type is appointment or task
                if (appointRadVal == true)
                {

                    Contact selectedContact = userContacts.Where(i => i.Name == eventContact).FirstOrDefault();
                    if (selectedContact.Name.Equals("<< No Contact >>"))
                    {
                        selectedContact = null;
                    }
                    newEvent = new Appointment { EventTitle = eventTitle, StartDateTime = startDateTime, EndDateTime=endDateTime,ContactId= selectedContact.ContactId, Recurr=repeatEventBool, Location=eventLocation,EventNote=eventNote, UserId=_user.UserId };
                }
                else
                {
                    newEvent = new Task { EventTitle = eventTitle, StartDateTime = startDateTime, EndDateTime = endDateTime, Recurr = repeatEventBool, EventNote = eventNote, UserId = _user.UserId };
                }
                db.Events.Add(newEvent);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Internal Database Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Event Addition Successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void addNewEventBtn_Click(object sender, EventArgs e)
        {
            AddNewEvent();
        }

        /// <summary>
        /// Simple validation on add event fields
        /// </summary>
        /// <returns></returns>
        private int ValidateAddEvent()
        {
            if (startDtPicker.Value.ToString().Equals(endDtPicker.Value.ToString())){
                if (titleTxt.Text.ToString().Equals("")){return 2;}
                else{return 0;}
            }
            else if (startDtPicker.Value > endDtPicker.Value){return 1;}
            else if (titleTxt.Text.ToString().Equals("")) { return 2; }
            else {return 0;}
        }
    }
}
