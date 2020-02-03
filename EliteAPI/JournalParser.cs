using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var readAllLines = File.ReadAllLines(logFile.FullName);
            
            if (triggerOnLoad)
            {
                
                totalLines = readAllLines.Length;
            }

            var i = 0;

            foreach (var line in readAllLines.Where(e=> !processedLogs.Contains(e) ))
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

        private string ProcessJson(string json, bool printJson)
        {
            dynamic obj = null;
            var eventName = "";

            try
            {
                //Turn the JSON into an object to find out which event it is.
                obj = JsonConvert.DeserializeObject<dynamic>(json);

                eventName = obj.@event;

                if (printJson)
                {
                    EliteAPI.Logger.Log(Severity.Debug, $"Processing event '{eventName}'.", (object) obj);
                }
                else
                {
                    EliteAPI.Logger.Log(Severity.Debug, $"Processing event '{eventName}'.");
                }
            }
            catch (Exception ex)
            {
                EliteAPI.Logger.Log(Severity.Warning, $"Couldn't process {eventName}.", ex);
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
                            var parsedEvent = eventMethod.Invoke(null, new object[] {json, EliteAPI});
                        }

                        //amountOfProcessedFields = parsedEvent.GetType().GetProperties().Length;
                        //parsed = parsedEvent.GetType().GetProperties();
                    }
                    catch (Exception ex)
                    {
                        EliteAPI.Logger.Log(Severity.Error, $"Could not invoke event method '{eventName}Info.Process()'.", (object) obj, ex);
                    }
                }
                catch (Exception ex)
                {
                    EliteAPI.Logger.Log(Severity.Debug, $"Could not find event method '{eventName}Info.Process()'.", (object) obj, ex);
                }
            }
            catch (Exception ex)
            {
                EliteAPI.Logger.Log(Severity.Debug, $"Could not find event class '{eventName}Info'.", (object) obj, ex);
            }

            //Invoke the AllEvent.
            try
            {
                EliteAPI.Events.InvokeAllEvent(obj);
            }
            catch (Exception ex)
            {
                EliteAPI.Logger.Log(Severity.Error, $"Could not invoke AllEvent for '{eventName}'.", ex);
            }
            //if (amountOfProcessedFields < amountOfFields)
            //{
            //    string missingFields = "";
            //    originial.ToList().ForEach(x => missingFields += $"{x.Name}, ");
            //    parsed.ToList().ForEach(x => missingFields.Replace($"{x.Name}, ", ""));
            //    missingFields = missingFields.Substring(0, missingFields.Length - 2) + " were missing";
            //    EliteAPI.Logger.LogEventEventDebug($"Not all fields were parsed for '{eventName}'.", new Exception(missingFields));
            //}

            return eventName;
        }
    }
}