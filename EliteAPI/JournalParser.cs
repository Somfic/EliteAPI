using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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

        public void ProcessJournal(FileInfo logFile, bool doNotTrigger = true)
        {
            //Create a stream from the log file.
            FileStream fileStream = logFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Create a stream from the file stream.
            StreamReader streamReader = new StreamReader(fileStream);

            //Go through the stream.
            while (!streamReader.EndOfStream)
            {
                //If this string hasn't been processed yet, process it and mark it as processed.
                string json = streamReader.ReadLine();
                if (!processedLogs.Contains(json))
                {
                    if (!doNotTrigger) { ProcessJson(json); } //Only process it if it's marked true.
                    processedLogs.Add(json);
                }
            }
        }

        public void ProcessJson(string json)
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
                EliteAPI.Logger.LogDebugEvent($"Processing event '{eventName}'.", obj);
            }
            catch (Exception ex) { EliteAPI.Logger.LogWarning($"Couldn't process JSON ({json}).", ex); }

            //Invoke the matching event.
            Type eventClass; MethodInfo eventMethod;

            try
            {
                eventClass = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name == $"{eventName}Info").First();
                try
                {
                    eventMethod = eventClass.GetMethod("Process", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                    try
                    {
                        object parsedEvent = eventMethod.Invoke(null, new object[] { json, EliteAPI });
                        //amountOfProcessedFields = parsedEvent.GetType().GetProperties().Length;
                        parsed = parsedEvent.GetType().GetProperties();

                    }
                    catch (Exception ex) { EliteAPI.Logger.LogError($"Could not invoke event method '{eventName}Info.Process()'.", ex); }
                }
                catch (Exception ex) { EliteAPI.Logger.LogWarning($"Could not find event method '{eventName}Info.Process()'.", ex); }
            }
            catch (Exception ex) { EliteAPI.Logger.LogWarning($"Could not find event class '{eventName}Info'.", ex); }

            //Invoke the AllEvent.
            try { EliteAPI.Events.InvokeAllEvent(obj); }
            catch (Exception ex) { EliteAPI.Logger.LogError($"Could not invoke AllEvent for '{eventName}'.", ex); }

            //if (amountOfProcessedFields < amountOfFields)
            //{
            //    string missingFields = "";

            //    originial.ToList().ForEach(x => missingFields += $"{x.Name}, ");
            //    parsed.ToList().ForEach(x => missingFields.Replace($"{x.Name}, ", ""));

            //    missingFields = missingFields.Substring(0, missingFields.Length - 2) + " were missing";

            //    EliteAPI.Logger.LogDebug($"Not all fields were parsed for '{eventName}'.", new Exception(missingFields));
            //}
        }
    }
}
