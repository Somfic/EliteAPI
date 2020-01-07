using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private int totalLines = 0;

        public void ProcessJournal(FileInfo logFile, bool doNotTrigger = true, bool printJson = true, bool triggerOnLoad = false)
        {
            //Create a stream from the log file.
            FileStream fileStream = logFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //Create a stream from the file stream.
            StreamReader streamReader = new StreamReader(fileStream);

            if(triggerOnLoad) { totalLines = File.ReadAllLines(logFile.FullName).Length; }
            int i = 0;

            //Go through the stream.
            while (!streamReader.EndOfStream)
            {
                //If this string hasn't been processed yet, process it and mark it as processed.
                string eventName = "";
                string json = streamReader.ReadLine();
                if (processedLogs.Contains(json)) continue;
                if (!doNotTrigger) { eventName = ProcessJson(json, printJson); } //Only process it if it's marked true.
                processedLogs.Add(json);
                if (!triggerOnLoad) continue;
                i++; EliteAPI.TriggerOnLoad(eventName, (float)i / totalLines);
            }
        }

        private string ProcessJson(string json, bool printJson)
        {
            dynamic obj = null;
            string eventName = "";
            //int amountOfFields = 0;
            //int amountOfProcessedFields = 0;
            PropertyInfo[] originial = new List<PropertyInfo>().ToArray();
            PropertyInfo[] parsed = new List<PropertyInfo>().ToArray();
            try
            {
                //Turn the JSON into an object to find out which event it is.
                obj = JsonConvert.DeserializeObject<dynamic>(json);
                originial = obj.GetType().GetProperties();
                JObject jobj = (JObject)JsonConvert.DeserializeObject(json);
                //amountOfFields = jobj.Count;
                eventName = obj.@event;
                if (printJson) { EliteAPI.Logger.Log(Severity.Debug, $"Processing event '{eventName}'.", (object) obj); }
                else { EliteAPI.Logger.Log(Severity.Debug, $"Processing event '{eventName}'."); }
            }
            catch (Exception ex) { EliteAPI.Logger.Log(Severity.Warning, $"Couldn't process {eventName}.", ex); }
            //Invoke the matching event.
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
                    catch (Exception ex) { EliteAPI.Logger.Log(Severity.Error, $"Could not invoke event method '{eventName}Info.Process()'.", (object)obj, ex); }
                }
                catch (Exception ex) { EliteAPI.Logger.Log(Severity.Debug, $"Could not find event method '{eventName}Info.Process()'.", (object)obj, ex); }
            }
            catch (Exception ex) { EliteAPI.Logger.Log(Severity.Debug, $"Could not find event class '{eventName}Info'.", (object)obj, ex); }
            //Invoke the AllEvent.
            try { EliteAPI.Events.InvokeAllEvent(obj); }
            catch (Exception ex) { EliteAPI.Logger.Log(Severity.Error, $"Could not invoke AllEvent for '{eventName}'.", ex); }
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
