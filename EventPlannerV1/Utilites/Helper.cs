using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerV1.Utilites
{
    class Helper
    {
        /// <summary>
        /// Logs the relevant data to a log file if an exception occured.
        /// </summary>
        /// <param name="ex"></param>
        public static void SaveLog(Exception ex)
        {
            StreamWriter writer = new StreamWriter("logs.txt",true);
            writer.WriteLine($"Error Message:({ex.Message}) \tErrorDateTime:({DateTime.Now.ToString()})\t Inner Exception: ({ex.InnerException}) \t Stack Trace: ({ex.StackTrace})"); //write the current date to the file
            writer.Close(); //close the file again.
            writer.Dispose(); //dispose it from the memory.
        }

    }
}
