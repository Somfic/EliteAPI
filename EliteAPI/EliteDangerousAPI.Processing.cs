using EliteAPI.Events;
using EliteAPI.Status.Cargo;
using EliteAPI.Status.Market;
using EliteAPI.Status.Modules;
using EliteAPI.Status.Outfitting;
using EliteAPI.Status.Ship;
using EliteAPI.Status.Shipyard;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Somfic.Logging;
using Somfic.Version;
using Somfic.Version.Github;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EliteAPI.Status;
using EliteAPI.Utilities;

namespace EliteAPI
{
    public partial class EliteDangerousAPI
    {
        private FileInfo JournalFile { get; set; }

        internal static string[] SupportFiles { get; } = { "Status.json", "Cargo.json", "Market.json", "ModulesInfo.json", "Outfitting.json", "Shipyard.json" };

        private readonly ShipStatus oldStatus;
        private readonly CargoStatus oldCargo;
        private readonly MarketStatus oldMarket;
        private readonly ModulesStatus oldModules;
        private readonly OutfittingStatus oldOutfitting;
        private readonly ShipyardStatus oldShipyard;

        private List<string> processedLogs { get; set; }

        private void ProcessFiles(bool raiseEvents)
        {
            try
            {
                // Check if the Journal file hasn't changed.
                var newFileInfoJournalFile = Config.JournalDirectory.GetFiles("Journal.*.log").OrderByDescending(x => x.LastWriteTime).First();
                if (JournalFile.FullName != newFileInfoJournalFile.FullName)
                {
                    Logger.Debug($"Switched to {JournalFile.Name}.");
                    JournalFile = newFileInfoJournalFile;
                }
                

                // Process journal
                foreach (string json in FileReader.ReadAllLines(JournalFile.FullName))
                {
                    if (processedLogs.Contains(json)) { continue; }

                    processedLogs.Add(json);
                    JObject parsedFromGame;
                    object parsedIntoAPI = null;
                    string eventName;

                    // Parse it into dynamic to find the name of the event.
                    try
                    {
                        parsedFromGame = JsonConvert.DeserializeObject<JObject>(json);
                        eventName = ((dynamic)parsedFromGame).@event;
                        Logger.Debug($"Processing event {eventName}.");
                    }
                    catch (Exception ex)
                    {
                        Logger.Warning("Could not process event JSON.", json, ex);
                        continue;
                    }

                    if (!raiseEvents) { continue; }

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
                            Logger.Warning($"Event {eventName} has not been implemented.", JsonConvert.DeserializeObject(json));
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
                        parsedIntoAPI = eventMethod.Invoke(null, new object[] { json, this });

                        var gameProperties = PropertyReader.GetAllChildren(parsedFromGame, eventName);
                        var apiProperties = PropertyReader.GetAllChildren(JObject.FromObject(parsedIntoAPI), eventName);
                        var missing = gameProperties.Except(apiProperties);

                        if (missing.Any())
                        {
                            Logger.Warning($"Event {eventName} could not populate all properties.", missing);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Warning($"Could not execute event {eventName}.", ex);
                    }

                    // Invoke the AllEvent event.
                    if (parsedIntoAPI != null)
                    {
                        Events.InvokeAllEvent((EventBase)parsedIntoAPI);
                    }
                }

                // Process Status.json
                if (File.Exists(Path.Combine(Config.JournalDirectory.FullName, "Status.json")))
                {
                    string json = FileReader.ReadAllText(Path.Combine(Config.JournalDirectory.FullName, "Status.json"));
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        ShipStatus newStatus = JsonConvert.DeserializeObject<ShipStatus>(json);
                        PropertyInfo[] oldProperties = Status.GetType().GetProperties();
                        PropertyInfo[] newProperties = newStatus.GetType().GetProperties();
                    }
                }

                // Process support files
                foreach (string supportFile in SupportFiles)
                {
                    string path = Path.Combine(Config.JournalDirectory.FullName, supportFile);

                    // Skip if the file doesn't exist.
                    if (!File.Exists(path)) { continue; }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Critical error.", ex);
            }
        }
    }
} 