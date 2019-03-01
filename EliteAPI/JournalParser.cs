using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Newtonsoft.Json;

namespace EliteAPI
{
    internal class JournalParser
    {
        internal JournalParser(EliteDangerousAPI EliteAPI)
        {

            this.EliteAPI = EliteAPI;
        }

        private EliteDangerousAPI EliteAPI;
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

            try
            {
                //Turn the JSON into an object to find out which event it is.
                obj = JsonConvert.DeserializeObject<dynamic>(json);
                eventName = obj.@event;
                EliteAPI.Logger.LogDebug($"Processing event '{eventName}'.");
            }
            catch (Exception ex) { EliteAPI.Logger.LogWarning($"Couldn't process JSON ({json}).", ex); }

            //Invoke the matching event.
            Type eventClass; MethodInfo eventMethod;

            try
            {
                eventClass = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name == $"{eventName}Info").First();
                try
                {
                    eventMethod = eventClass.GetMethod("Process");
                    try { eventMethod.Invoke(null, new object[] { json, EliteAPI }); }
                    catch (Exception ex) { EliteAPI.Logger.LogError($"Could not invoke event method '{eventName}Info.Process()'.", ex); }
                }
                catch (Exception ex) { EliteAPI.Logger.LogWarning($"Could not find event method '{eventName}Info.Process()'.", ex); }
            }
            catch (Exception ex) { EliteAPI.Logger.LogWarning($"Could not find event class '{eventName}Info'.", ex); }

            //Invoke the AllEvent.
            try { EliteAPI.Events.InvokeAllEvent(obj); }
            catch (Exception ex) { EliteAPI.Logger.LogError($"Could not invoke AllEvent for '{eventName}'.", ex); }
        }
    }
}
