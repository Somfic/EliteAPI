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

namespace EliteAPI
{
    public partial class EliteDangerousAPI
    {
        private FileInfo JournalFile { get; set; }

        internal static string[] SupportFiles { get; } =
            {"Status.json", "Cargo.json", "Market.json", "ModulesInfo.json", "Outfitting.json", "Shipyard.json"};

        private List<string> processedLogs { get; set; }

        private void ProcessFiles(bool raiseEvents)
        {
            try
            {
                // Check if the Journal file hasn't changed.
                FileInfo newFileInfoJournalFile = Config.JournalDirectory.GetFiles("Journal.*.log")
                    .OrderByDescending(x => x.LastWriteTime).First();
                if (JournalFile.FullName != newFileInfoJournalFile.FullName)
                {
                    Logger.Debug($"Switched to {JournalFile.Name}.");
                    JournalFile = newFileInfoJournalFile;
                }


                // Process journal
                foreach (string json in FileReader.ReadAllLines(JournalFile.FullName))
                {
                    if (processedLogs.Contains(json))
                    {
                        continue;
                    }

                    processedLogs.Add(json);
                    JObject parsedFromGame;
                    object parsedIntoAPI = null;
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

                    // Invoke the [eventName]Info.Process() method to trigger the individual event.
                    try
                    {
                        Type eventClass;

                        // Find the class
                        try
                        {
                            eventClass = Assembly.GetExecutingAssembly().GetTypes()
                                .First(x => x.Name == $"{eventName}Info");
                        }
                        catch (InvalidOperationException)
                        {
                            Logger.Warning($"Event {eventName} has not been implemented.",
                                JsonConvert.DeserializeObject(json));
                            Events.InvokeMissingEvent(JsonConvert.DeserializeObject(json));
                            continue;
                        }
                        catch (Exception ex)
                        {
                            Logger.Warning($"Event {eventName} could not be processed.", ex);
                            Events.InvokeMissingEvent(JsonConvert.DeserializeObject(json));
                            continue;
                        }


                        // Find the method
                        MethodInfo eventMethod = eventClass.GetMethod("Process",
                            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public |
                            BindingFlags.Static);

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

                // Process Status.json
                if (File.Exists(Path.Combine(Config.JournalDirectory.FullName, "Status.json")))
                {
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
            catch (Exception ex)
            {
                Logger.Error("Critical error.", ex);
            }
        }
    }
}