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
            Application.Exit();
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

                foreach (var userEvent in _events)
                {
                    EventDetailsPanel eventDetailsPanel = new EventDetailsPanel(_user, userEvent);
                    eventDetailsPanel.Tag = userEvent.EventId;
                    eventDetailsPanel.RepeatButtonClick += EventDetailsPanel_RepeatButtonClick;
                    eventDetailsPanel.RemoveButtonClick += EventDetailsPanel_RemoveButtonClick;
                    eventDetailsPanel.EditButtonClick += EventDetailsPanel_EditButtonClick;
                    flowLayoutPanel1.Controls.Add(eventDetailsPanel);
                }
            }

            SetRepeatEvent();
        }

        private void SetRepeatEvent()
        {
            List<Event> repeatinEvents = new List<Event>(_events.Where(userEvnt => userEvnt.Recurr == true));
            

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

            int updateStat = UpdateEvent(tempEvent);
            flowLayoutPanel1.Controls.Clear();
            InitEvents();
            if (updateStat == 1)
            {
                MessageBox.Show("Internal Database Error! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Overview_Activated(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            InitEvents();
        }

        private int UpdateEvent(Event evnt)
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

                }
                catch (Exception ex)
                {
                    Utilites.Helper.SaveLog(ex);
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Deletes a event by event ID
        /// </summary>
        /// <param name="EventId"></param>
        private void DeleteEvent(int EventId)
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

    }
}
