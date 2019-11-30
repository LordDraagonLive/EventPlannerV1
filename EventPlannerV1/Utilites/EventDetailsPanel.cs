using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EventPlannerV1.Models;

namespace EventPlannerV1.Utilites
{
    public partial class EventDetailsPanel : UserControl
    {
        private User _user;
        private Event _event;

        public EventDetailsPanel()
        {
            InitializeComponent();
        }

        public EventDetailsPanel(User user, Event userEvent)
        {
            InitializeComponent();
            _user = user;
            _event = userEvent;
        }

        public User User
        {
            get
            {
                return _user;
            }
        }
        public Event Event
        {
            get
            {
                return _event;
            }
        }


        private void EventDetailsPanel_Load(object sender, EventArgs e)
        {
            // set the required values
            EventTitle.Text = _event.EventTitle;
            StartDtPicker.Value = _event.StartDateTime;

            if (_event.Recurr) { RepeatStatBtn.BackColor = Color.LightGreen; RepeatStatBtn.ForeColor = Color.DimGray; }
            else { RepeatStatBtn.BackColor = Color.DimGray; RepeatStatBtn.ForeColor = Color.Azure; }

        }

        public event EventHandler RepeatButtonClick;

        protected void RepeatStatBtn_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.RepeatButtonClick != null)
                RepeatButtonClick(this, e);
        }

        public event EventHandler EditButtonClick;

        protected void EditEventBtn_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.EditButtonClick != null)
                EditButtonClick(this, e);
        }

        public event EventHandler RemoveButtonClick;

        protected void RemoveEventBtn_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.RemoveButtonClick != null)
                RemoveButtonClick(this, e);
        }
    }
}
