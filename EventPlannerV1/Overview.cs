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
                _events = (from userEvent in db.Events where userEvent.User.UserId == _user.UserId select userEvent).ToList();
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
        }

        private void EventDetailsPanel_EditButtonClick(object sender, EventArgs e)
        {
            
            //MessageBox.Show("Edit btn click!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }

        private void EventDetailsPanel_RemoveButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("Remove btn click!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

    }
}
