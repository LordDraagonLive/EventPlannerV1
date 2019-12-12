using EventPlannerV1.Models;
using EventPlannerV1.Utilites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventPlannerV1
{
    public partial class Overview : Form
    {
        private User _user;
        private List<Event> _events;

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
            //Application.Exit();
        }

        /// <summary>
        /// Retrieves all the events and updates the custom control panel
        /// </summary>
        private void InitEvents()
        {
            using (var db = new EventContext())
            {
                _events = (from userEvent in db.Events where (userEvent.User.UserId == _user.UserId)
                           select userEvent).ToList();
                _events = _events.Where(usrEvnt => (usrEvnt.StartDateTime>= startDtPicker.Value 
                && usrEvnt.EndDateTime>= startDtPicker.Value 
                && usrEvnt.StartDateTime<=endDtPicker.Value 
                && usrEvnt.EndDateTime<= endDtPicker.Value)).ToList();

                SetRepeatEvent();

                foreach (var userEvent in _events)
                {
                    EventDetailsPanel eventDetailsPanel = new EventDetailsPanel(_user, userEvent);
                    eventDetailsPanel.Tag = userEvent.EventId;
                    eventDetailsPanel.RepeatButtonClick += EventDetailsPanel_RepeatButtonClick;
                    eventDetailsPanel.RemoveButtonClick += EventDetailsPanel_RemoveButtonClick;
                    eventDetailsPanel.EditButtonClick += EventDetailsPanel_EditButtonClick;
                    eventDetailsPanel.ControlDoubleClick += EventDetailsPanel_ControlDoubleClick;
                    flowLayoutPanel1.Controls.Add(eventDetailsPanel);
                }
            }

        }


        /// <summary>
        /// Get all recurring events and if an
        /// event is expired then set the recurr day
        /// </summary>
        private void SetRepeatEvent()
        {
            //List<EventRepeatStat> eventRepeatStats = new List<EventRepeatStat>();
            List<Event> repeatinEvents = new List<Event>(_events.Where(userEvnt => userEvnt.Recurr == true));
            foreach (var usrEvnt in repeatinEvents)
            {
                DateTime repeatStartDateTime = usrEvnt.StartDateTime.AddDays(1);
                DateTime repeatEndDateTime = usrEvnt.EndDateTime.AddDays(1);

                // check if the event has ended
                if ((usrEvnt.StartDateTime < DateTime.Now) && (usrEvnt.EndDateTime < DateTime.Now))
                {
                    //Update previous recuring events to stop recurring
                    // In db and the XML file
                    usrEvnt.Recurr = false;
                    UpdateEvent(usrEvnt); // update xml is inside this func

                    // if event ended start repeat for the next day
                    usrEvnt.Recurr = true;
                    usrEvnt.StartDateTime = repeatStartDateTime;
                    usrEvnt.EndDateTime = repeatEndDateTime;
                    // add as a new event to the db and the xml file
                    AddNewEvent(usrEvnt);
                }
            }


        }

        ///// <summary>
        ///// Struct which holds the event
        ///// repetition data
        ///// </summary>
        //struct EventRepeatStat
        //{
        //    public Event UserEvent;
        //    public DateTime RepeatStartDateTime;
        //    public DateTime RepeatEndDateTime;
        //}

        /// <summary>
        /// Allow user to see an event's
        /// full details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventDetailsPanel_ControlDoubleClick(object sender, EventArgs e)
        {
            EventDetailsPanel temp = (EventDetailsPanel)sender;
            Event userEvent = temp.Event;

            EventView eventView = new EventView(userEvent, _user);
            eventView.ShowDialog(this);
        }

        private void EventDetailsPanel_EditButtonClick(object sender, EventArgs e)
        {
            EventDetailsPanel temp = (EventDetailsPanel)sender;
            Event userEvent = temp.Event;

            //MessageBox.Show("Edit btn click!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            // Redirect to the edit event view
            EditEventView editEventView = new EditEventView(userEvent, _user);
            editEventView.ShowDialog(this);
        }

        private void EventDetailsPanel_RemoveButtonClick(object sender, EventArgs e)
        {

            EventDetailsPanel temp = (EventDetailsPanel)sender;
            Event delEvent = temp.Event;
            if (MessageBox.Show("Please confirm before proceed"
                                + "\n" + "Do you want to Delete event: '" + delEvent.EventTitle + "' ?",
                                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //if YES
                DeleteEvent(delEvent.EventId);
            }
        }

        private void EventDetailsPanel_RepeatButtonClick(object sender, EventArgs e)
        {
            EventDetailsPanel temp = (EventDetailsPanel)sender;
            Event tempEvent = temp.Event;

            // Switch the Recurr property
            tempEvent.Recurr = !tempEvent.Recurr;

            UpdateEvent(tempEvent);
            flowLayoutPanel1.Controls.Clear();
            InitEvents();

        }

        /// <summary>
        /// Refresh the view every time 
        /// the window gains focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Overview_Activated(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            InitEvents();
        }

        /// <summary>
        /// Updates the provided event in the DB.
        /// </summary>
        /// <param name="evnt"></param>
        /// <returns></returns>
        private async void UpdateEvent(Event evnt)
        {
            using (var db = new EventContext())
            {

                Event result = (from userEvent in db.Events
                                    where userEvent.EventId == evnt.EventId
                                    select userEvent).SingleOrDefault();
                
                try
                {
                    //result = evnt;
                    result.EventTitle = evnt.EventTitle;
                    result.StartDateTime = evnt.StartDateTime;
                    result.EndDateTime = evnt.EndDateTime;
                    result.Recurr = evnt.Recurr;
                    result.EventNote = evnt.EventNote;
                    db.SaveChanges();
                    // Write to xml

                    await System.Threading.Tasks.Task.Run(() => Helper.UpdateEventXmlParser(result));
                    //await Helper.UpdateEventXmlParser(result);
                    //Helper.UpdateEventXmlParser(result);

                }
                catch (Exception ex)
                {
                    Utilites.Helper.SaveLog(ex);
                    MessageBox.Show("Internal Database Error! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        /// <summary>
        /// Deletes a event by event ID
        /// </summary>
        /// <param name="EventId"></param>
        private async void DeleteEvent(int EventId)
        {
            using (var db = new EventContext())
            {
                var DelEvent = (from userEvent in db.Events
                                  where userEvent.EventId == EventId
                                  select userEvent).FirstOrDefault();

                try
                {
                    db.Events.Remove(DelEvent);
                    db.SaveChanges();
                    // Write to xml
                    await System.Threading.Tasks.Task.Run(() => Helper.RemoveEventXmlParser(DelEvent));
                    //await Helper.RemoveEventXmlParser(DelEvent);
                    //Helper.RemoveEventXmlParser(DelEvent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Internal Database Error! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Helper.SaveLog(ex);
                    return;
                }
                flowLayoutPanel1.Controls.Clear();
                InitEvents();
                MessageBox.Show("Event '"+ DelEvent.EventTitle +"' successfully deleted! ", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Refresh the events list when start date range changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startDtPicker_ValueChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            InitEvents();
        }

        /// <summary>
        /// Refersh the events list when end date range changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endDtPicker_ValueChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            InitEvents();
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        /// <summary>
        /// Adds new event to the DB and the XML
        /// </summary>
        private async void AddNewEvent(Event newEvent)
        {
           
            using (var db = new EventContext())
            {

                // check if event type is appointment or task
                if (newEvent.EventType.Equals("Appointment"))
                {
                    newEvent = new Appointment { EventTitle = newEvent.EventTitle, StartDateTime = newEvent.StartDateTime, EndDateTime = newEvent.EndDateTime, ContactId = ((Appointment)newEvent).ContactId, Recurr = newEvent.Recurr, Location = ((Appointment)newEvent).Location, EventNote = newEvent.EventNote, EventType = "Appointment", UserId = newEvent.UserId };
                }
                else
                {
                    newEvent = new Models.Task { EventTitle = newEvent.EventTitle, StartDateTime = newEvent.StartDateTime, EndDateTime = newEvent.EndDateTime, Recurr = newEvent.Recurr, EventNote = newEvent.EventNote, EventType = "Task", UserId = newEvent.UserId };
                }


                try
                {
                    db.Events.Add(newEvent);
                    db.SaveChanges();

                    // Write to xml
                    await System.Threading.Tasks.Task.Run(() => Helper.AddEventXmlParser(newEvent));
                    //await Helper.AddEventXmlParser(newEvent);
                    //Helper.AddEventXmlParser(newEvent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Internal Database Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Helper.SaveLog(ex);
                    return;
                }

                //MessageBox.Show("Event Addition Successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();

            }

        }

        private void showPredictBtn_Click(object sender, EventArgs e)
        {
            PredictionReportView predictionReport = new PredictionReportView(_user);
            predictionReport.Show();
            this.Close();

        }

        private void Overview_Load(object sender, EventArgs e)
        {
            //InitEvents();
        }
    }
}
