using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerV1.Utilites
{
    class Helper
    {
        //public void AddToLog(String message)
        //{
        //    if (Thread.CurrentThread != m_UIThread)
        //    {
        //        // Need for invoke if called from a different thread
        //        this.Dispatcher.BeginInvoke(
        //            DispatcherPriority.Normal, (ThreadStart)delegate ()
        //            {
        //                AddToLog(message);
        //            });
        //    }
        //    else
        //    {
        //        // add this line at the top of the log
        //        lbLog.Items.Insert(0, message);

        //        // keep only a few lines in the log
        //        while (lbLog.Items.Count > LOG_MAX_LINES)
        //        {
        //            lbLog.Items.RemoveAt(lbLog.Items.Count - 1);
        //        }
        //    }
        //}
    }
}
