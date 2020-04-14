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

namespace EliteAPI
{
    public class EliteDangerousAPI
    {
        public EliteDangerousAPI(EliteConfiguration configuration = null)
        {
            if (configuration == null) { configuration = new EliteConfiguration(); }

            Config = configuration;
        }

        public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static DirectoryInfo StandardDirectory => GetStandardDirectory();

        public EliteConfiguration Config { get; private set; }

        public bool IsRunning { get; private set; }

        public Events.EventHandler Events { get; private set; } = new Events.EventHandler();

        public ShipStatus Status { get; private set; } = new ShipStatus();

        public CargoStatus Cargo { get; private set; } = new CargoStatus();

        public MarketStatus Market { get; private set; } = new MarketStatus();

        public ModulesStatus Modules { get; private set; } = new ModulesStatus();

        public OutfittingStatus Outfitting { get; private set; } = new OutfittingStatus();

        public ShipyardStatus Shipyard { get; private set; } = new ShipyardStatus();

        private FileInfo JournalFile { get; set; }

        private string[] SupportFiles { get; } = { "Status.json", "Cargo.json", "Market.json", "ModulesInfo.json", "Outfitting.json", "Shipyard.json" };

        private readonly ShipStatus oldStatus;
        private readonly CargoStatus oldCargo;
        private readonly MarketStatus oldMarket;
        private readonly ModulesStatus oldModules;
        private readonly OutfittingStatus oldOutfitting;
        private readonly ShipyardStatus oldShipyard;

        public void Start()
        {
            // Display information.
            Logger.Log($"EliteAPI v{Version}.");
            Logger.Debug("By CMDR Somfic and contributors.");

            // Check for a newer version.
            CheckVersion();

            bool canContinue = CheckDirectory();

            if (!canContinue && Config.JournalDirectory != StandardDirectory)
            {
                // Check again with the standard directory.
                Config.JournalDirectory = StandardDirectory;
                canContinue = CheckDirectory();
                if (canContinue) { Logger.Log($"Changed Journal directory to {StandardDirectory.FullName}."); }
            }

            if (!canContinue)
            {
                // If the check was not successful, do not continue.
                Logger.Special("EliteAPI cannot continue, please change the Journal directory and try again.");
                return;
            }

            // Get the last edited Journal file.
            JournalFile = Config.JournalDirectory.GetFiles("Journal.*.log").OrderByDescending(x => x.LastWriteTime).First();
            Logger.Debug($"{JournalFile.Name} selected.");

            // Start processing the files async.
            IsRunning = true;
            Task.Run(() =>
            {
                List<string> processed = new List<string>();

                while (IsRunning)
                {
                    try
                    {
                        Console.Title = DateTime.Now.Millisecond.ToString();

                        // Process journal
                        foreach (string json in FileReader.ReadAllLines(JournalFile.FullName))
                        {
                            if (!processed.Contains(json))
                            {
                                processed.Add(json);

                                JObject parsed;
                                EventBase parsedInClass = null;
                                string eventName;

                                // Parse it into dynamic to find the name of the event.
                                try
                                {
                                    parsed = JsonConvert.DeserializeObject<JObject>(json);
                                    eventName = ((dynamic)parsed).@event;
                                    Logger.Debug($"Processing event {eventName}.");
                                }
                                catch (Exception ex)
                                {
                                    Logger.Warning("Could not process event JSON.", json, ex);
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
                                        Logger.Warning($"Event {eventName} has not been implemented.");
                                        Logger.Debug(json);
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
                                    parsedInClass = (EventBase)eventMethod.Invoke(null, new object[] { json, this });

                                    IEnumerable<string> parsedProperties = parsedInClass.GetType().GetProperties().Select(x => x.Name.ToUpper());
                                    IEnumerable<string> parsedAll = parsed.Properties().Select(x => x.Name.ToUpper());

                                    if (parsedProperties.Count() < parsedAll.Count())
                                    {
                                        IEnumerable<string> missingProperties = parsedAll.Except(parsedProperties);
                                        Logger.Warning($"Event {eventName} couldn't populate all fields.");
                                        Logger.Debug($" Missing fields: '{string.Join(", ", missingProperties)}'.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Warning($"Could not execute event {eventName}.", ex);
                                }

                                // Invoke the AllEvent event.
                                if (parsedInClass != null)
                                {
                                    Events.InvokeAllEvent(parsedInClass);
                                }
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
            });
        }

        private bool CheckDirectory()
        {
            Logger.Debug($"Checking Journal directory {Config.JournalDirectory.FullName}.");

            // Check if exists.
            if (!Config.JournalDirectory.Exists)
            {
                Logger.Warning("The Journal directory does not exist.", new DirectoryNotFoundException($"The directory {Config.JournalDirectory.FullName} could not be found."));
                return false;
            }

            // Check if has Journal files
            const string filter = "Journal.*.log";
            if (Config.JournalDirectory.GetFiles(filter).Length == 0)
            {
                Logger.Warning("The Journal directory does not contain any Journal log files.", new FileNotFoundException($"No {filter} file could be found.", Path.Combine(Config.JournalDirectory.FullName, filter)));
                return false;
            }

            // Check if has Status.json file
            if (Config.JournalDirectory.GetFiles("Status.json").Length != 1)
            {
                Logger.Warning("The Journal directory does not contain a Status.json.", new FileNotFoundException($"No Status.json file could be found.", Path.Combine(Config.JournalDirectory.FullName, "Status.json")));
                return false;
            }

            // Check the other support files.
            foreach (string supportFile in SupportFiles)
            {
                if (supportFile == "Status.json") { continue; }
                if (Config.JournalDirectory.GetFiles(supportFile).Length != 1)
                {
                    Logger.Debug($"The Journal directory does not contain a {supportFile}.", new FileNotFoundException($"No {supportFile} file could be found.", Path.Combine(Config.JournalDirectory.FullName, supportFile)));
                }
            }

            return true;
        }

        private static DirectoryInfo GetStandardDirectory()
        {
            DirectoryInfo fallBackDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            // Don't try to find the special folder if not on Windows.
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return fallBackDirectory;
            }

            int result = UnsafeNativeMethods.SHGetKnownFolderPath(new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"), 0, new IntPtr(0), out IntPtr path);
            if (result >= 0)
            {
                try { return new DirectoryInfo(Marshal.PtrToStringUni(path) + "/Frontier Developments/Elite Dangerous"); }
                catch { return fallBackDirectory; }
            }

            return fallBackDirectory;
        }

        public bool CheckVersion()
        {
            Logger.Debug("Checking for new updates on github.com/EliteAPI/EliteAPI.");
            VersionController version = new GithubVersionControl("EliteAPI", "EliteAPI");

            Logger.Log($"Latest version: {version.Latest} (current: {version.This}).");

            if (version.This < version.Latest)
            {
                Logger.Log($"A new update ({version.Latest}) is available. Visit github.com/EliteAPI/EliteAPI to download the latest version.");

                return true;
            }

            return false;
        }
    }
}