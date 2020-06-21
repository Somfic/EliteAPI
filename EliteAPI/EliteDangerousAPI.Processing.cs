using EliteAPI.Events;
using EliteAPI.Status.Ship;
using EliteAPI.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Somfic.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EliteAPI
{
    public partial class EliteDangerousAPI
    {
        internal static IEnumerable<string> SupportFiles { get; } = new[] { "Status.json", "Cargo.json", "Market.json", "ModulesInfo.json", "Outfitting.json", "Shipyard.json" };

        private FileInfo JournalFile { get; set; }

        internal long lastReadPosition;

        internal FileSystemWatcher watcher = new FileSystemWatcher();

        private HashSet<string> processedLogs = new HashSet<string>();

        private Dictionary<string,  MethodInfo> eventMethods = new Dictionary<string, MethodInfo>();

        private Regex journalPattern = new Regex(@"Journal.*");

        private void ResetProcessing() {
            lastReadPosition = 0;
            processedLogs.Clear();
            eventMethods.Clear();
            JournalFile = null;
        }

        /// <summary>
        /// P
        /// </summary>
        private void PrepareFileProcessing(bool raiseEvents) {
            watcher.NotifyFilter = NotifyFilters.LastWrite
                                | NotifyFilters.FileName
                                | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);

            FileInfo newJournalFile = Config.JournalDirectory.GetFiles("Journal.*.log")
                .Select(x => x.LastWriteTime).Max();
            JournalFile = null;
            if (MaybeSwitchJournalFile(newJournalFile)) {
                ProcessJournalFile(0, raiseEvents);
            }
            ProcessStatusFile(raiseEvents);
        }

        /// Must be called after PrepareFileProcessing
        private void StartFileProcessing() {
            watcher.Path = Config.JournalDirectory.FullName;
            watcher.EnableRaisingEvents = true;
        }

        private void StopFileProcessing() {
            watcher.EnableRaisingEvents = false;
        }

        /// <summary>
        /// OnCreated indicates that a new journal file was created in the directory.
        /// </summary>
        private void OnCreated(object source, FileSystemEventArgs e) {
            try {
                if (!journalPattern.Matches(e.Name)) {
                    return;
                }
                System.IO.FileInfo newJournalFile = JournalDirectory.GetFiles("Journal.*.log").Select(x => x.LastWriteTime).Max();
                if (MaybeSwitchJournalFile(newJournalFile)) {
                    ProcessJournalFile(0, true);
                } 
                ProcessStatusFile(true);
            }
            catch (Exception ex)
            {
                Logger.Warning("Error processing created event.", ex);
            }
        }

        /// <summary>
        /// OnChanged indicates that an existing journal file was changed, and triggers
        /// reading the new data from the journal.
        /// </summary>
        private void OnChanged(object source, FileSystemEventArgs e) {
            try {
                if (e.Name == "Status.json" ) {
                    ProcessStatusFile(true);
                } else if (journalPattern.Matches(e.Name)) {
                    System.IO.FileInfo newJournalFile = new System.IO.FileInfo(JournalFile.FullName);
                    if (newJournalFile.Length > LastReadPosition) {
                        JournalFile = newJournalFile;
                        ProcessJournalFile(lastReadPosition, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Warning("Error processing changed event.", ex);
            }
        }

        /// <summary>
        /// Checks to see if the journal file should be switched.
        /// </summary>
        private bool MaybeSwitchJournalFile(FileInfo newJournalFile) {
            if (JournalFile == null || JournalFile.FullName != newJournalFile.FullName)
            {
                Logger.Debug($"Switched to {JournalFile.Name}.");
                JournalFile = newJournalFile;
                LastReadPosition = 0;
                processedLogs.Clear();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the Process method for the event info.
        /// </summary>
        private MethodInfo FindEventInfoProcessMethod(string eventName) {
            MethodInfo eventMethod = null;
            if (!eventMethods.TryGetValue(eventName, out eventMethod))
            {
                Type eventClass = Assembly.GetExecutingAssembly().GetTypes()
                        .First(x => x.Name == $"{eventName}Info");

                // Find the method
                eventMethod = eventClass.GetMethod("Process",
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public |
                    BindingFlags.Static);            

                eventMethods.Add(eventName, eventMethod);
            }
            return eventMethod;
        }

        /// <summary>
        /// Processes the current 'JournalFile' by reading it line by line.
        /// </summary>
        private void ProcessJournalFile(long seekPosition, bool raiseEvents) {
            FileStream fileStream = JournalFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            if (seekPosition > 0) {
                fileStream.Seek(seekPosition, SeekOrigin.Begin);
            }
            StreamReader streamReader = new StreamReader(fileStream);

            // Read all the unread lines.
            string json;
            while((json = streamReader.ReadLine()) != null)
            {
                // Check whether this line was already processed.
                // NOTE: Elite Dangerous often emits duplicate lines in the log, and each
                // event such as jump, station arrival, etc. emit logs with the same timestamp
                // so there's no single prefix that works as a means of disambiguation.                
                if (processedLogs.Contains(json))
                {
                    continue;
                }
                processedLogs.Add(json);
                LastReadPosition = streamReader.Position;

                JObject parsedFromGame;
                string eventName;

                // Parse it into dynamic to find the name of the event.
                try
                {
                    parsedFromGame = JsonConvert.DeserializeObject<JObject>(json);
                    eventName = ((dynamic) parsedFromGame).@event;
                    Logger.Debug($"Processing event {eventName}.");
                }
                catch (Exception ex)
                {
                    Logger.Warning("Could not process event JSON.", json, ex);
                    continue;
                }

                if (!raiseEvents)
                {
                    continue;
                }

                object parsedIntoAPI = null;

                // Invoke the [eventName]Info.Process() method to trigger the individual event.
                try
                {
                    MethodInfo eventMethod;
                    try
                    {
                       eventMethod = FindEventInfoProcessMethod(eventName);
                    }
                    catch (InvalidOperationException)
                    {
                        Logger.Warning($"Event {eventName} has not been implemented.",
                            JsonConvert.DeserializeObject(json));
                        eventMethod = null;
                    }
                    catch (Exception ex)
                    {
                        Logger.Warning($"Event {eventName} could not be processed.", ex);
                        eventMethod = null;
                    }
                    if (eventMethod == null) {
                        Events.InvokeMissingEvent(JsonConvert.DeserializeObject(json));
                        continue;
                    }

                    // Invoke the method
                    parsedIntoAPI = eventMethod.Invoke(null, new object[] {json, this});

                    string[] gameProperties = PropertyReader.GetAllChildren(parsedFromGame, eventName);
                    string[] apiProperties =
                        PropertyReader.GetAllChildren(JObject.FromObject(parsedIntoAPI), eventName);
                    IEnumerable<string> missing = gameProperties.Except(apiProperties);

                    if (missing.Any())
                    {
                        Logger.Warning(
                            $"Event {eventName} could not populate all properties ({string.Join(", ", missing)}).",
                            JsonConvert.DeserializeObject(json));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warning($"Could not execute event {eventName}.", ex);
                }

                // Invoke the AllEvent event.
                if (parsedIntoAPI != null)
                {
                    Events.InvokeAllEvent((EventBase) parsedIntoAPI);
                }
            }
        }

        /// <summary>
        /// Processes the current 'Status' by reading it line by line.
        /// </summary>
        private void ProcessStatusFile(bool raiseEvents) {
            // Process Status.json
            if (!File.Exists(Path.Combine(Config.JournalDirectory.FullName, "Status.json"))) {
                return;
            }
            string json = FileReader.ReadAllText(Path.Combine(Config.JournalDirectory.FullName, "Status.json"));
            if (!string.IsNullOrWhiteSpace(json))
            {
                ShipStatus newStatus = JsonConvert.DeserializeObject<ShipStatus>(json);

                IEnumerable<PropertyInfo> properties = Status.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    string name = property.Name;
                    string oldValue;
                    string newValue;

                    try
                    {
                        oldValue = property.GetValue(Status).ToString();
                        newValue = property.GetValue(newStatus).ToString();
                    }
                    catch (Exception ex)
                    {
                        Logger.Warning($"Couldn't update status {name}.", ex);
                        continue;
                    }

                    // If the values are the same, skip this status property.
                    if (oldValue == newValue)
                    {
                        continue;
                    }
                    if (!raiseEvents) {
                        // Status is not stored, only change events are currently raised.
                        return;
                    }

                    // Get the dynamic value of the new property.
                    object val = property.GetValue(newStatus);

                    // Execute the event.
                    try
                    {
                        MethodInfo method = Events.GetType().GetMethod($"InvokeStatus{name}",
                            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public |
                            BindingFlags.Static);

                        if (method != null)
                        {
                            Logger.Log(Severity.Debug, $"Setting status {name} to {newValue}.");
                            StatusEvent e = new StatusEvent($"Status.{name}", val);
                            method.Invoke(Events, new object[] {e});
                        }

                        // Invoke AllEvent.
                        Events.InvokeAllEvent(new StatusEvent($"Status.{name}", val));
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(Severity.Debug, $"Could not invoke status event '{name}'.", ex);
                    }
                }

                Status = newStatus;
            }
        }
    }
}