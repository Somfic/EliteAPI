using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Somfic.Logging;

namespace EliteAPI
{
    internal class JournalParser
    {
        internal JournalParser(EliteDangerousAPI EliteAPI)
        {
            this.EliteAPI = EliteAPI;
        }

        private readonly EliteDangerousAPI EliteAPI;
        internal List<string> processedLogs = new List<string>();
        private int totalLines;

        public void ProcessJournal(FileInfo logFile, bool doNotTrigger = true, bool printJson = true, bool triggerOnLoad = false)
        {

            try
            {
                var readAllLines = FileReader.ReadAllLines(logFile.FullName);

                if (triggerOnLoad)
                {
                    totalLines = readAllLines.Count();
                }

                var i = 0;

                foreach (var line in readAllLines.Where(e => !processedLogs.Contains(e)))
                {
                    string eventName = "";

                    if (!doNotTrigger)
                    {
                        eventName = ProcessJson(line, printJson);
                    }

                    processedLogs.Add(line);

                    if (!triggerOnLoad)
                    {
                        continue;
                    }

                    i++;

                    EliteAPI.TriggerOnLoad(eventName, (float)i / totalLines);
                }
            }
            catch (Exception ex) { Logger.Log(Severity.Error, "Could not process Journal file.", ex); }
        }

        private string ProcessJson(string json, bool printJson)
        {
            dynamic parsed = null;
            var eventName = "";

            PropertyInfo[] properties = null;

            try
            {
                //Turn the JSON into an object to find out which event it is.
                parsed = JsonConvert.DeserializeObject<dynamic>(json);

                eventName = parsed.@event;

                if (printJson)
                {
                    Logger.Log(Severity.Debug, $"Processing event '{eventName}'.", (object)parsed);
                }
                else
                {
                    Logger.Log(Severity.Debug, $"Processing event '{eventName}'.");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Severity.Warning, $"Couldn't process {eventName}.", ex);
            }

            try
            {
                var eventClass = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name == $"{eventName}Info");

                try
                {
                    var eventMethod = eventClass.GetMethod("Process", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                    try
                    {
                        if (eventMethod != null)
                        {
                            parsed = eventMethod.Invoke(null, new object[] {json, EliteAPI});
                        }

                        properties = parsed.GetType().GetProperties();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(Severity.Error, $"Could not invoke event method '{eventName}Info.Process()'.", (object)parsed, ex);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(Severity.Debug, $"Could not find event method '{eventName}Info.Process()'.", (object)parsed, ex);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Severity.Debug, $"Could not find event class '{eventName}Info'.", (object)parsed, ex);
            }

            //Invoke the AllEvent.
            try
            {
                EliteAPI.Events.InvokeAllEvent(parsed);
            }
            catch (Exception ex)
            {
                Logger.Log(Severity.Error, $"Could not invoke AllEvent for '{eventName}'.", ex);
            }

            return eventName;
        }
    }
}