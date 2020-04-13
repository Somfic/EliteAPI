using EliteAPI.Status;
using EliteAPI.Status.Cargo;
using EliteAPI.Status.Market;
using EliteAPI.Status.Modules;
using EliteAPI.Status.Outfitting;
using EliteAPI.Status.Ship;
using EliteAPI.Status.Shipyard;
using Newtonsoft.Json;
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

        public void Start()
        {
            // Display information.
            Logger.Log($"EliteAPI v{Version}.");
            Logger.Debug("By CMDR Somfic and contributors.");

            // Check for a newer version.
            CheckVersion();

            // Check the journal directory.
            if (!CheckDirectory())
            {
                // If the check was not successful, try changing to the standard journal directory.
                if (Config.JournalDirectory != StandardDirectory)
                {
                    Config.JournalDirectory = StandardDirectory;
                    if (!CheckDirectory())
                    {
                        // If the check was again not successful, do not continue.
                        Logger.Special("EliteAPI cannot continue, please change the Journal directory and try again.");
                        return;
                    }

                    Logger.Debug("Working from standard Journal directory instead.");
                }
            }

            // Get the last edited Journal file.
            JournalFile = Config.JournalDirectory.GetFiles("Journal.*.log").OrderByDescending(x => x.LastWriteTime).First();
            Logger.Debug($"{JournalFile.Name} selected.");

            // Start processing the files async.
            IsRunning = true;
            Task.Run(() =>
            {
                List<string> processed = new List<string>();
                List<string> processedStatus = new List<string>();

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

                                dynamic parsed;
                                string eventName;

                                // Parse it into dynamic to find the name of the event.
                                try
                                {
                                    parsed = JsonConvert.DeserializeObject<dynamic>(json);
                                    eventName = parsed.@event;
                                }
                                catch (Exception ex)
                                {
                                    Logger.Warning("Could not process event JSON.", json, ex);
                                    continue;
                                }

                                Logger.Debug($"Processing {eventName}.");

                                // Invoke the [eventName]Info.Process() method to trigger the individual event.
                                try
                                {
                                    // Find the class
                                    Type eventClass = Assembly.GetExecutingAssembly().GetTypes()
                                        .First(x => x.Name == $"{eventName}Info");

                                    // Find the method
                                    MethodInfo eventMethod = eventClass.GetMethod("Process",
                                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public |
                                        BindingFlags.Static);

                                    // Invoke the method
                                    parsed = eventMethod.Invoke(null, new object[] {json, this});
                                }
                                catch (Exception ex)
                                {
                                    Logger.Warning($"Could not find or execute event {eventName}.", ex);
                                }

                                // Invoke the AllEvent event.
                                Events.InvokeAllEvent(parsed);
                            }
                        }

                        // Process support files
                        foreach (string supportFile in SupportFiles)
                        {
                            string path = Path.Combine(Config.JournalDirectory.FullName, supportFile);

                            // Skip if the file doesn't exist.
                            if (!File.Exists(path))
                            {
                                continue;
                            }

                            switch (supportFile)
                            {
                                case "Status.json":
                                    var newStatus = Process<ShipStatus>(path, Status) as ShipStatus;
                                    
                                    break;

                                case "Cargo.json":
                                    var newCargo = Process<CargoStatus>(path, Cargo) as CargoStatus;
                                    break;

                                case "Market.json":
                                    var newMarket = Process<MarketStatus>(path, Market) as MarketStatus;
                                    break;

                                case "ModulesInfo.json":
                                    var newModules = Process<ModulesStatus>(path, Modules) as ModulesStatus;
                                    break;

                                case "Outfitting.json":
                                    var newOutfitting = Process<OutfittingStatus>(path, Outfitting) as OutfittingStatus;
                                    break;

                                case "Shipyard.json":
                                    var newShipyard = Process<ShipyardStatus>(path, Shipyard) as ShipyardStatus;
                                    break;
                            }
                        }

                        Logger.Log(Status.Gear);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Critical error.", ex);
                    }
                }

                Console.Beep();
            });
        }

        private IStatus Process<T>(string file, IStatus fallback) where T : IStatus
        {
            string json = FileReader.ReadAllText(file);
            if (string.IsNullOrWhiteSpace(json)) { return fallback; }

            T result;
            try
            {
                result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Couldn't process {file}.", ex);
                return null;
            }
        }

        private bool CheckDirectory()
        {
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