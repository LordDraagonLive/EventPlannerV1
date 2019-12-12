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
    public partial class PredictionReportView : Form
    {
        User _user;
        DateTime nxtMonthStart;
        DateTime nxtMonthEnd;
        DateTime prevMonthStart;
        DateTime prevMonthEnd;
        int totalNoEvents;
        Decimal totalTimeSpend;

        public PredictionReportView()
        {
            InitializeComponent();
        }

        public PredictionReportView(User user)
        {
            InitializeComponent();
            _user = user;
            nxtMonthStart = DateTime.Now.AddMinutes(1);
            nxtMonthEnd = nxtMonthStart.AddMonths(1);
            prevMonthStart = DateTime.Now.AddMinutes(-1);
            prevMonthEnd = prevMonthStart.AddMonths(-1);

            InitPrevMonthResults();
            CalculateAvgTimeSpend();
        }

        /// <summary>
        /// Initialize Previous month's details
        /// </summary>
        private void InitPrevMonthResults()
        {
            nxtMonthStartTxt.Text = nxtMonthStart.ToString("dd-MM-yyyy HH:mm");
            nxtMonthEndTxt.Text = nxtMonthEnd.ToString("dd-MM-yyyy HH:mm");
            prevMonthStartTxt.Text = prevMonthStart.ToString("dd-MM-yyyy HH:mm");
            prevMonthEndTxt.Text = prevMonthEnd.ToString("dd-MM-yyyy HH:mm");

            using (var db = new EventContext())
            {
                IEnumerable<Event> result = (from usrEvnt in db.Events where usrEvnt.User.UserId == _user.UserId && usrEvnt.EndDateTime < DateTime.Now select usrEvnt).ToList();
                // Set the number of total events
                totalNoEvents = result.Count();
                totalEventsTxt.Text = totalNoEvents.ToString();
                IEnumerable<MonthlyEvent> prevMonthResult = result.Select(usrEvnt => new MonthlyEvent {
                    EventTitle = usrEvnt.EventTitle,
                    StartDateTime = usrEvnt.StartDateTime,
                    EndDateTime = usrEvnt.EndDateTime,
                    TotalTime = (Decimal)Math.Round(usrEvnt.EndDateTime.Subtract(usrEvnt.StartDateTime).TotalMinutes, 10)/1440 //returns value in days
                });
                // Get the total time spend for all the events in the prev month
                foreach (MonthlyEvent item in prevMonthResult)
                {
                    totalTimeSpend += item.TotalTime;
                }
                totalTimeSpendTxt.Text = (totalTimeSpend * 24).ToString();
            }

        }

        /// <summary>
        /// Struct to hold the necessary details
        /// of the events and the total time of each event
        /// </summary>
        struct MonthlyEvent
        {
            public String EventTitle;
            public DateTime StartDateTime;
            public DateTime EndDateTime;
            public Decimal TotalTime;
        }

        private void CalculateAvgTimeSpend()
        {
            Decimal totalDays = (Decimal)(prevMonthStart - prevMonthEnd).TotalDays;

            // Monthly usage in hrs
            Decimal avgMonthlyEventTime = totalTimeSpend * 24;
            monthlyResultTxt.Text = avgMonthlyEventTime.ToString();

            //Daily usage in hrs
            Decimal avgDailyEventTime = (totalTimeSpend / totalDays) * 24;
            dailyResultTxt.Text = avgDailyEventTime.ToString();


            //Weekly usage in hrs
            Decimal avgWeeklyEventTime = (totalTimeSpend / 4) * 24; // convert total time spend to days
            weeklyResultTxt.Text = avgWeeklyEventTime.ToString();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Overview overview = new Overview(_user);
            overview.Show();
            this.Close();
        }

    }
}
