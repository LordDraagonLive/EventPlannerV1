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
    public partial class EventView : Form
    {
        User _user;
        Event _userEvent;

        public EventView()
        {
            InitializeComponent();
        }

        public EventView(Event userEvent, User user )
        {
            _user = user;
            _userEvent = userEvent;

            InitializeComponent();
            InitForm();

        }

        private void InitForm()
        {
            // Set values to the controls
            startDtPicker.Value = _userEvent.StartDateTime;
            endDtPicker.Value = _userEvent.EndDateTime;
            titleTxt.Text = _userEvent.EventTitle;
            if (_userEvent.Recurr)
            {
                repeatEventTxt.Text = "Repeat";
            }
            else
            {
                repeatEventTxt.Text = "Don't Repeat";
            }
            if (_userEvent.GetType()==typeof(Appointment))
            {
                eventTypeTxt.Text = ((Appointment)_userEvent).EventType;
                contactTxt.Text = GetContact(((Appointment)_userEvent).ContactId).Name;
                locationTxt.Text = ((Appointment)_userEvent).Location;
            }
            else if (_userEvent.GetType() == typeof(Models.Task))
            {
                eventTypeTxt.Text = ((Models.Task)_userEvent).EventType;
            }
            eventNoteTxt.Text = _userEvent.EventNote;

        }

        /// <summary>
        /// Gets the contact using the contact id
        /// </summary>
        /// <param name="ContactId"></param>
        /// <returns></returns>
        private Contact GetContact(int? ContactId)
        {
            using (var db = new EventContext())
            {
                Contact contact= (from selectContact in db.Contacts where selectContact.ContactId == ContactId select selectContact).FirstOrDefault();
                return contact;
            }
        }

    }
}
