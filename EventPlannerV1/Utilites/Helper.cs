using EventPlannerV1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EventPlannerV1.Utilites
{
    public class Helper
    {
        // Private Constructor
        private Helper(){}

        private static readonly Object lockingObj = new Object();


        /// <summary>
        /// Async method that logs the relevant data to a log file if an exception occured.
        /// </summary>
        /// <param name="ex"></param>
        public static async void SaveLog(Exception ex)
        {
            StreamWriter writer = new StreamWriter($"Log File - {DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss")}.txt", true); //write the current date to the file
            //await writer.WriteLineAsync(ex.ToString());
            await System.Threading.Tasks.Task.Run(() => writer.WriteLineAsync(ex.ToString()));

            writer.Close(); //close the file again.
            writer.Dispose(); //dispose it from the memory.
        }

        /// <summary>
        /// Validates if a previous xml file exists
        /// </summary>
        public static void InitXmlSave()
        {
            XDocument document = new XDocument();

            //if (!File.Exists("Events.xml"))
            //{
            //    //Populate with data here, then save.
            //    document.Add(new XElement("Root"));
            //    await System.Threading.Tasks.Task.Run(() => document.Save("Events.xml"));
            //    //document.Save("Events.xml");
            //}
            //else
            //{
                try
                {
                //If exists then load it
                //await System.Threading.Tasks.Task.Run(() => XDocument.Load("Events.xml"));
                XDocument.Load("Events.xml");
                }
                catch (Exception)
                {
                    //Populate with data here, then save.
                    document.Add(new XElement("Root"));
                    //await System.Threading.Tasks.Task.Run(() => document.Save("Events.xml"));
                    document.Save("Events.xml");
                }
            //}
        }

        /// <summary>
        /// Saves event addition in a XML file
        /// </summary>
        /// <param name="userEvent"></param>
        public static void AddEventXmlParser(Event userEvent)
        {
            //// create xml file if not available
            //InitXmlSave();

            //XDocument xmlDoc = await System.Threading.Tasks.Task.Run(() => XDocument.Load("Events.xml"));
            XDocument xmlDoc;

            lock (lockingObj)
            {
                xmlDoc = XDocument.Load("Events.xml");

                if (userEvent.GetType() == typeof(Appointment))
                {
                    xmlDoc.Element("Root").Add(new XElement("Events",
                                    new XElement("Event",
                                        new XElement("EventId", userEvent.EventId),
                                        new XElement("EventTitle", userEvent.EventTitle),
                                        new XElement("StartDateTime", userEvent.StartDateTime),
                                        new XElement("EndDateTime", userEvent.EndDateTime),
                                        new XElement("Recurr", userEvent.Recurr),
                                        new XElement("EventNote", userEvent.EventNote),
                                        new XElement("UserId", userEvent.UserId),
                                        new XElement("Location", ((Appointment)userEvent).Location),
                                        new XElement("ContactId", ((Appointment)userEvent).ContactId),
                                        new XElement("EventType", userEvent.EventType))));
                }
                else
                {
                    xmlDoc.Element("Root").Add(new XElement("Events",
                                   new XElement("Event",
                                       new XElement("EventId", userEvent.EventId),
                                       new XElement("EventTitle", userEvent.EventTitle),
                                       new XElement("StartDateTime", userEvent.StartDateTime),
                                       new XElement("EndDateTime", userEvent.EndDateTime),
                                       new XElement("Recurr", userEvent.Recurr),
                                       new XElement("EventNote", userEvent.EventNote),
                                       new XElement("UserId", userEvent.UserId),
                                       new XElement("EventType", userEvent.EventType))));
                } 
            }

            try
            {
                lock (lockingObj)
                {
                    xmlDoc.Save("Events.xml");
                }                
                //await System.Threading.Tasks.Task.Run(() => xmlDoc.Save("Events.xml"));
            }
            catch (Exception ex)
            {
                SaveLog(ex);
            }           
        }


        /// <summary>
        /// Saves event updating in a XML file
        /// </summary>
        /// <param name="userEvent"></param>
        public static void UpdateEventXmlParser(Event userEvent)
        {
            // create xml file if not available
            //InitXmlSave();

            XDocument xmlDoc;

            //XDocument xmlDoc = await System.Threading.Tasks.Task.Run(() => XDocument.Load("Events.xml"));
            lock (lockingObj)
            {
                xmlDoc = XDocument.Load("Events.xml"); 


                XElement selectedNode = (from usrEventXml in xmlDoc.Element("Root").Descendants("Events").Descendants("Event")
                                                      where (usrEventXml.Element("UserId").Value.Equals(userEvent.UserId.ToString()))
                                                      && (usrEventXml.Element("EventId").Value.Equals(userEvent.EventId.ToString()))
                                                      select usrEventXml).FirstOrDefault();

                if (selectedNode is null)
                {
                    SaveLog(new NullReferenceException());
                    return;
                }

                if (userEvent.GetType() == typeof(Appointment))
                {
                    selectedNode.Element("EventTitle").SetValue(((Appointment)userEvent).EventTitle);
                    selectedNode.Element("StartDateTime").SetValue(((Appointment)userEvent).StartDateTime);
                    selectedNode.Element("EndDateTime").SetValue(((Appointment)userEvent).EndDateTime);
                    selectedNode.Element("Recurr").SetValue(((Appointment)userEvent).Recurr);
                    selectedNode.Element("EventNote").SetValue(((Appointment)userEvent).EventNote);
                    selectedNode.Element("Location").SetValue(((Appointment)userEvent).Location);
                    try
                    {
                        selectedNode.Element("ContactId").SetValue(((Appointment)userEvent).ContactId);
                    }
                    catch (NullReferenceException)
                    {
                        selectedNode.Element("ContactId").SetValue("<< No Contact >>");
                    }
                    selectedNode.Element("EventType").SetValue(((Appointment)userEvent).EventType);

                }
                else
                {
                    selectedNode.Element("EventTitle").SetValue(((Models.Task)userEvent).EventTitle);
                    selectedNode.Element("StartDateTime").SetValue(((Models.Task)userEvent).StartDateTime);
                    selectedNode.Element("EndDateTime").SetValue(((Models.Task)userEvent).EndDateTime);
                    selectedNode.Element("Recurr").SetValue(((Models.Task)userEvent).Recurr);
                    selectedNode.Element("EventNote").SetValue(((Models.Task)userEvent).EventNote);
                    selectedNode.Element("EventType").SetValue(((Models.Task)userEvent).EventType);
                }
            }

            try
            {
                lock (lockingObj)
                {
                    xmlDoc.Save("Events.xml"); 
                }
                //await System.Threading.Tasks.Task.Run(() => xmlDoc.Save("Events.xml"));
            }
            catch (Exception ex)
            {
                SaveLog(ex);
            }
            //xmlDoc.Save("Events.xml");
            //await System.Threading.Tasks.Task.Run(() => xmlDoc.Save("Events.xml"));
        }


        /// <summary>
        /// Removes the selected node from the xml file
        /// </summary>
        /// <param name="userEvent"></param>
        public static void RemoveEventXmlParser(Event userEvent)
        {
            // create xml file if not available
            //InitXmlSave();

            //XDocument xmlDoc = await System.Threading.Tasks.Task.Run(() => XDocument.Load("Events.xml"));
            XDocument xmlDoc;
            lock (lockingObj)
            {
                xmlDoc = XDocument.Load("Events.xml");

            }
            var deleteQuery = (from usrEventXml in xmlDoc.Descendants("Event")
                               where (usrEventXml.Element("UserId").Value.Equals(userEvent.UserId.ToString()))
                               && (usrEventXml.Element("EventId").Value.Equals(userEvent.EventId.ToString()))
                               select usrEventXml).FirstOrDefault();
            try
            {
                deleteQuery.Remove();

                lock (lockingObj)
                {
                    xmlDoc.Save("Events.xml");

                }            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal Database Error! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SaveLog(ex);
            }
            //xmlDoc.Save("Events.xml");
            //await System.Threading.Tasks.Task.Run(() => xmlDoc.Save("Events.xml"));
        }

    }
}
