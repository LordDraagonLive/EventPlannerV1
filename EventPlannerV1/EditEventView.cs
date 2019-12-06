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

    public partial class EditEventView : Form
    {
        Event _userEvent;
        User _user;
        List<Contact> userContacts;

        //Dynamic UI elements
        Label startsAtLabel;
        DateTimePicker startsAtDtPicker;
        Label endsAtLabel;
        DateTimePicker endsAtDtPicker;
        Label locationLbl;
        TextBox locationTxt;
        Label contactLbl;
        ComboBox eventContactsDropdown;
        Label eventNoteLbl;
        TextBox eventNoteTxt;
        Label eventRepeatLbl;
        ComboBox repeatEventDropdown;
        Label eventTypeLbl;
        RadioButton appointRadBtn;
        RadioButton taskRadBtn;
        Label eventTitleLbl;
        TextBox eventTitleTxt;


        public EditEventView()
        {
            InitializeComponent();
        }

        public EditEventView(Event userEvent, User user)
        {
            _userEvent = userEvent;
            _user = user;
            InitializeComponent();
            InitDynamicUI();
        }

        private void EditEventView_Load(object sender, EventArgs e)
        {

            // set the dynamic values to the controls
            startsAtDtPicker.Value = _userEvent.StartDateTime;
            endsAtDtPicker.Value = _userEvent.EndDateTime;
            eventNoteTxt.Text = _userEvent.EventNote;
            if (_userEvent.Recurr == true)
            {
                repeatEventDropdown.SelectedIndex = 0;
            }
            else if (_userEvent.Recurr == false)
            {
                repeatEventDropdown.SelectedIndex = 1;
            }
            eventTitleTxt.Text = _userEvent.EventTitle;

            //populate combo box with contacts of the logged in user
            using (var db = new EventContext())
            {
                List<Contact> dropDownContacts = (from contact in db.Contacts where contact.User.UserId == _user.UserId select contact).ToList();
                userContacts = dropDownContacts;
                dropDownContacts.Insert(0, new Contact() { Name = "<< No Contact >>" });

                if (_userEvent.GetType() == typeof(Appointment))
                {

                    if (((Appointment)_userEvent).ContactId != 0)
                    {
                        int? userEventContactId = ((Appointment)_userEvent).ContactId;
                        Contact defaultContact = userContacts.Where(contact => contact.ContactId == userEventContactId).FirstOrDefault();

                        dropDownContacts.Remove(defaultContact);
                        dropDownContacts.Insert(0, defaultContact);
                    }
                }

                eventContactsDropdown.DataSource = dropDownContacts;
                eventContactsDropdown.ValueMember = "ContactId";
                eventContactsDropdown.DisplayMember = "Name";

            }
            //if (((Appointment)_userEvent).ContactId != 0)
            //{
            //    int? userEventContactId = ((Appointment)_userEvent).ContactId;
            //    Contact defaultContact = userContacts.Where(contact => contact.ContactId == userEventContactId).FirstOrDefault();

            //    eventContactsDropdown.SelectedText = defaultContact.Name;
            //}

            // Add the dynamic UI controls to the view
            this.Controls.Add(startsAtLabel);
            this.Controls.Add(startsAtDtPicker);
            this.Controls.Add(endsAtLabel);
            this.Controls.Add(endsAtDtPicker);
            this.Controls.Add(eventNoteLbl);
            this.Controls.Add(eventNoteTxt);
            this.Controls.Add(eventRepeatLbl);
            this.Controls.Add(repeatEventDropdown);
            this.Controls.Add(eventTypeLbl);
            this.Controls.Add(appointRadBtn);
            this.Controls.Add(taskRadBtn);
            this.Controls.Add(eventTitleLbl);
            this.Controls.Add(eventTitleTxt);

            if (_userEvent.EventType.Equals("Task"))
            {
                this.Controls.Remove(locationLbl);
                this.Controls.Remove(locationTxt);
                this.Controls.Remove(contactLbl);
                this.Controls.Remove(eventContactsDropdown);

                // Set value from db
                appointRadBtn.Checked = false;
                taskRadBtn.Checked = true;
            }
            else
            {
                appointRadBtn.Checked = true;
                taskRadBtn.Checked = false;

                // Add the dynamic UI controls to the view
                this.Controls.Add(locationLbl);
                this.Controls.Add(locationTxt);
                this.Controls.Add(contactLbl);
                this.Controls.Add(eventContactsDropdown);

                locationTxt.Text = ((Appointment)_userEvent).Location;
                
                //if (((Appointment)_userEvent).ContactId!=0)
                //{
                //    eventContactsDropdown.Text = ((Appointment)_userEvent).Contact.Name;
                //}
            }

        }

        private void TaskRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            EventTypeClick("Task");
        }

        private void AppointRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            EventTypeClick("Appoint");
        }

        private void editEventBtn_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        /// <summary>
        /// Updates the db record with the user edited fields
        /// </summary>
        private async void EditEvent()
        {
            if (MessageBox.Show("Please confirm before proceed"
                   + "\n" + "Do you want to update this event?",
                   "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //if YES
                String eventTitle = eventTitleTxt.Text.ToString();
                DateTime startDateTime = startsAtDtPicker.Value;
                DateTime endDateTime = endsAtDtPicker.Value;
                String repeatEvent = repeatEventDropdown.Text;
                bool repeatEventBool = true;
                bool taskRadVal = taskRadBtn.Checked;
                bool appointRadVal = appointRadBtn.Checked;
                String eventLocation = locationTxt.Text.ToString();
                String eventContact = eventContactsDropdown.Text;
                String eventNote = eventNoteTxt.Text.ToString();


                int ValidationStatus = ValidateEvents();

                if (ValidationStatus == 1)
                {
                    MessageBox.Show("Start Date/Time cannot be higher than the End Date/Time!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    startsAtDtPicker.Focus();
                    return;
                }
                else if (ValidationStatus == 2)
                {
                    MessageBox.Show("Event Title cannot be empty!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    eventTitleTxt.Focus();
                    return;
                }

                // Set the Event repetition status
                if (repeatEvent.Equals("Don't Repeat"))
                {
                    repeatEventBool = false;
                }

                using (var db = new EventContext())
                {
                    Event result = (from userEvent in db.Events
                                    where userEvent.EventId == _userEvent.EventId
                                    select userEvent).SingleOrDefault();

                    // check if event type is appointment or task
                    if (appointRadVal == true)
                    {
                        Contact selectedContact = userContacts.Where(i => i.Name == eventContact).FirstOrDefault();
                        //if (selectedContact.Name.Equals("<< No Contact >>"))
                        //{
                        //    selectedContact = null;
                        //}

                        int resultId = result.EventId;
                        var DelEvent = (from userEvent in db.Events
                                        where userEvent.EventId == resultId
                                        select userEvent).FirstOrDefault();
                        db.Events.Remove(DelEvent);
                        db.SaveChanges();
                        //Delete record in the xml file
                        await System.Threading.Tasks.Task.Run(() => Helper.RemoveEventXmlParser(DelEvent));

                        if (selectedContact.Name.Equals("<< No Contact >>"))
                        {
                            result = new Appointment { EventTitle = eventTitle, StartDateTime = startDateTime, EndDateTime = endDateTime, Contact = null, Recurr = repeatEventBool, Location = eventLocation, EventNote = eventNote, EventType = "Appointment", UserId = _user.UserId };
                        }
                        else
                        {
                            result = new Appointment { EventTitle = eventTitle, StartDateTime = startDateTime, EndDateTime = endDateTime, ContactId = selectedContact.ContactId, Recurr = repeatEventBool, Location = eventLocation, EventNote = eventNote, EventType = "Appointment", UserId = _user.UserId };
                        }
                    }
                    else
                    {
                        int resultId = result.EventId;
                        var DelEvent = (from userEvent in db.Events
                                          where userEvent.EventId == resultId
                                          select userEvent).FirstOrDefault();
                        db.Events.Remove(DelEvent);
                        db.SaveChanges();
                        //Delete record in the xml file
                        await System.Threading.Tasks.Task.Run(() => Helper.RemoveEventXmlParser(DelEvent));

                        result = new Models.Task {EventId=resultId, EventTitle = eventTitle, StartDateTime = startDateTime, EndDateTime = endDateTime, Recurr = repeatEventBool, EventNote = eventNote, EventType = "Task", UserId = _user.UserId };
                    }



                    try
                    {
                        db.Events.Add(result);
                        db.SaveChanges();

                        //Add record in the xml file
                        await System.Threading.Tasks.Task.Run(() => Helper.AddEventXmlParser(result));
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Internal Database Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Helper.SaveLog(ex);
                        return;
                    }

                    MessageBox.Show("Event Update Successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
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
                this.eventNoteLbl.Location = new System.Drawing.Point(12, 274);
                this.editEventBtn.Location = new System.Drawing.Point(343, 414);
                this.eventNoteTxt.Location = new System.Drawing.Point(137, 274);

            }
            else if (eventType.Equals("Appoint"))
            {
                // Change UI controls position
                this.eventNoteLbl.Location = new System.Drawing.Point(12, 350);
                this.editEventBtn.Location = new System.Drawing.Point(340, 463);
                this.eventNoteTxt.Location = new System.Drawing.Point(137, 350);

                // Add the dynamic UI controls to the view
                this.Controls.Add(locationLbl);
                this.Controls.Add(locationTxt);
                this.Controls.Add(contactLbl);
                this.Controls.Add(eventContactsDropdown);

            }
        }

        /// <summary>
        /// Initializes the Dynamic UI Controls
        /// </summary>
        private void InitDynamicUI()
        {

            startsAtLabel = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(12, 86),
                Name = "startsAtLabel",
                Size = new System.Drawing.Size(77, 18),
                TabIndex = 29,
                Text = "Starts At"
            };
            startsAtDtPicker = new DateTimePicker
            {
                CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                CalendarForeColor = System.Drawing.Color.Navy,
                CalendarMonthBackground = System.Drawing.Color.Azure,
                CalendarTitleForeColor = System.Drawing.Color.Navy,
                CustomFormat = "MMMM, dd, yyyy hh:mm:ss",
                Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Format = System.Windows.Forms.DateTimePickerFormat.Custom,
                //ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(137, 86),
                Name = "startsAtDtPicker",
                Size = new System.Drawing.Size(218, 21),
                TabIndex = 29,
            };

            endsAtLabel = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(482, 86),
                Name = "endsAtLabel",
                Size = new System.Drawing.Size(77, 18),
                TabIndex = 29,
                Text = "Ends At"
            };
            endsAtDtPicker = new DateTimePicker
            {
                CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                CalendarForeColor = System.Drawing.Color.Navy,
                CalendarMonthBackground = System.Drawing.Color.Azure,
                CalendarTitleForeColor = System.Drawing.Color.Navy,
                CustomFormat = "MMMM, dd, yyyy hh:mm:ss",
                Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Format = System.Windows.Forms.DateTimePickerFormat.Custom,
                //ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(572, 86),
                Name = "endsAtDtPicker",
                Size = new System.Drawing.Size(218, 21),
                TabIndex = 29,
            };

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

            eventNoteLbl = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(12, 266),
                Name = "eventNoteLbl",
                Size = new System.Drawing.Size(77, 18),
                TabIndex = 29,
                Text = "Note"
            };
            eventNoteTxt = new TextBox
            {
                Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.RoyalBlue,
                Location = new System.Drawing.Point(137, 274),
                Multiline = true,
                Name = "eventNoteTxt",
                Size = new System.Drawing.Size(319, 94),
                TabIndex = 33
            };

            eventRepeatLbl = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(12, 184),
                Name = "eventRepeatLbl",
                Size = new System.Drawing.Size(118, 18),
                TabIndex = 42,
                Text = "Repeat Event"
            };
            repeatEventDropdown = new ComboBox
            {
                BackColor = System.Drawing.Color.Azure,
                Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.RoyalBlue,
                FormattingEnabled = false,
                Location = new System.Drawing.Point(137, 181),
                MaxDropDownItems = 2,
                Name = "repeatEventDropdown",
                Size = new System.Drawing.Size(319, 24),
                TabIndex = 43,
                Text = "Repeat"
            };
            repeatEventDropdown.Items.AddRange(new object[] { "Repeat", "Don\'t Repeat" });

            eventTypeLbl = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(12, 229),
                Name = "eventTypeLbl",
                Size = new System.Drawing.Size(97, 18),
                TabIndex = 29,
                Text = "Event Type"
            };
            appointRadBtn = new RadioButton
            {
                AutoSize = true,
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(271, 231),
                Name = "appointRadBtn",
                Size = new System.Drawing.Size(84, 17),
                TabIndex = 29,
                Text = "Appointment",
                UseVisualStyleBackColor = true
            };
            appointRadBtn.CheckedChanged += new System.EventHandler(this.AppointRadBtn_CheckedChanged);
            taskRadBtn = new RadioButton
            {
                AutoSize = true,
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(137, 231),
                Name = "taskRadBtn",
                Size = new System.Drawing.Size(49, 17),
                TabIndex = 29,
                Text = "Task",
                UseVisualStyleBackColor = true
            };
            taskRadBtn.CheckedChanged += new System.EventHandler(this.TaskRadBtn_CheckedChanged);

            eventTitleLbl = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Navy,
                Location = new System.Drawing.Point(12, 135),
                Name = "eventTitleLbl",
                Size = new System.Drawing.Size(97, 18),
                TabIndex = 29,
                Text = "Event Title"
            };
            eventTitleTxt = new TextBox
            {
                Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.RoyalBlue,
                Location = new System.Drawing.Point(137, 132),
                Name = "titleTxt",
                Size = new System.Drawing.Size(319, 23),
                TabIndex = 33
            };

        }



        /// <summary>
        /// Simple validation on edit event fields
        /// </summary>
        /// <returns></returns>
        private int ValidateEvents()
        {
            if (startsAtDtPicker.Value.ToString().Equals(endsAtDtPicker.Value.ToString()))
            {
                if (eventTitleTxt.Text.ToString().Equals("")) { return 2; }
                else { return 0; }
            }
            else if (startsAtDtPicker.Value > endsAtDtPicker.Value) { return 1; }
            else if (eventTitleTxt.Text.ToString().Equals("")) { return 2; }
            else { return 0; }
        }
    }
}
