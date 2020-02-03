using EliteAPI.Bindings;
using EliteAPI.Discord;
using EliteAPI.Status;
using Newtonsoft.Json;
using Somfic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace EliteAPI
{
    /// <summary>
    /// Main EliteAPI class.
    /// </summary>
    public class EliteDangerousAPI : IEliteDangerousAPI
    {
        //Credits to DarkWanderer for this fix.
        private class UnsafeNativeMethods
        {
            [DllImport("Shell32.dll")]
            public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);
        }

        /// <summary>
        /// Set to true when the API is ready.
        /// </summary>
        public bool IsReady { get; internal set; }

        /// <summary>
        /// The standard Directory of the Player Journal files (C:\Users\%username%\Saved Games\Frontier Developments\Elite Dangerous).
        /// </summary>
        public static DirectoryInfo StandardDirectory
        {
            get
            {
                int result = UnsafeNativeMethods.SHGetKnownFolderPath(new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"), 0, new IntPtr(0), out IntPtr path);
                if (result >= 0)
                {
                    try { return new DirectoryInfo(Marshal.PtrToStringUni(path) + @"\Frontier Developments\Elite Dangerous"); }
                    catch { return new DirectoryInfo(Directory.GetCurrentDirectory()); }
                }
                else
                {
                    return new DirectoryInfo(Directory.GetCurrentDirectory());
                }
            }
        }

        /// <summary>
        /// The version of EliteAPI.
        /// </summary>
        public static string Version => "2.3.1.0";

        /// <summary>
        /// Whether the API is currently running.
        /// </summary>
        public bool IsRunning { get; private set; } = false;

        /// <summary>
        /// The Journal directory that is being used by the API.
        /// </summary>
        public DirectoryInfo JournalDirectory { get; private set; }

        /// <summary>
        /// Object that holds all the events.
        /// </summary>
        public Events.EventHandler Events { get; internal set; }

        /// <summary>
        /// Objects that holds all logging related functions.
        /// </summary>
        public Logger Logger { get; private set; }

        /// <summary>
        /// Holds the ship's current status.
        /// </summary>
        public GameStatus Status { get; internal set; }

        /// <summary>
        /// Holds the ship's current cargo situation.
        /// </summary>
        public ShipCargo Cargo { get; internal set; }

        /// <summary>
        /// Returns all the modules installed on the current ship.
        /// </summary>
        public ShipModules Modules => ShipModules.FromFile(new FileInfo(JournalDirectory.FullName + "\\ModulesInfo.json"), this);

        /// <summary>
        /// Holds information on all key bindings in the game set by the user.
        /// </summary>
        public UserBindings Bindings
        {
            get
            {
                try
                {
                    string wantedFile = File.ReadAllText($@"C:\Users\{Environment.UserName}\AppData\Local\Frontier Developments\Elite Dangerous\Options\Bindings\StartPreset.start") + ".binds";
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(wantedFile);
                    return JsonConvert.DeserializeObject<UserBindings>(JsonConvert.SerializeXmlNode(xml));
                }
                catch { return new UserBindings(); }
            }
        }

        /// <summary>
        /// Holds information about the commander.
        /// </summary>
        public CommanderStatus Commander { get; internal set; }

        /// <summary>
        /// Holds information about the last known location of the commander.
        /// </summary>
        public LocationStatus Location { get; internal set; }

        internal StatusWatcher StatusWatcher { get; set; }
        internal CargoWatcher CargoWatcher { get; set; }
        internal JournalParser JournalParser { get; set; }

        /// <summary>
        /// Rich presence service for Discord.
        /// </summary>
        public RichPresenceClient DiscordRichPresence { get; internal set; }

        /// <summary>
        /// Whether the API should skip the processing of previous events before the API was started.
        /// </summary>
        public bool SkipCatchUp { get; internal set; }

        /// <summary>
        /// Creates a new EliteDangerousAPI object using the standard Journal directory.
        /// </summary>
        public EliteDangerousAPI()
        {
            //Set the fields to the parameters.
            JournalDirectory = StandardDirectory;
            SkipCatchUp = false;

            //Create the logger.
            Logger = new Logger();
        }

        /// <summary>
        /// Creates a new EliteDangerousAPI object.
        /// </summary>
        /// <param name="JournalDirectory">The directory in which the Player Journals are located.</param>
        public EliteDangerousAPI(DirectoryInfo JournalDirectory)
        {
            //Set the fields to the parameters.
            this.JournalDirectory = JournalDirectory;
            SkipCatchUp = false;

            //Create the logger.
            Logger = new Logger();
        }

        /// <summary>
        /// Creates a new EliteDangerousAPI object using the standard Journal directory.
        /// </summary>
        /// <param name="SkipCatchUp">Whether the API should skip the processing of previous events before the API was started.</param>
        public EliteDangerousAPI(bool SkipCatchUp)
        {
            //Set the fields to the parameters.
            JournalDirectory = StandardDirectory;
            this.SkipCatchUp = SkipCatchUp;

            //Create the logger.
            Logger = new Logger();
        }

        /// <summary>
        /// Creates a new EliteDangerousAPI object.
        /// </summary>
        /// <param name="journalDirectory">The directory in which the Player Journals are located.</param>
        /// <param name="skipCatchUp">Whether the API should skip the processing of previous events before the API was started.</param>
        public EliteDangerousAPI(DirectoryInfo journalDirectory, bool skipCatchUp)
        {
            //Set the fields to the parameters.
            JournalDirectory = journalDirectory;
            SkipCatchUp = skipCatchUp;

            //Create the logger.
            Logger = new Logger();
        }

        /// <summary>
        /// Checks for a new update.
        /// </summary>
        /// <returns>Returns true if a newer version is available.</returns>
        private bool CheckForUpdate()
        {
            Logger.Log(Severity.Debug, "Checking for updates from GitHub.");

            try
            {
                string latestVersionString;

                using (var webClient = new WebClient())
                {
                    latestVersionString = webClient.DownloadString("https://raw.githubusercontent.com/EliteAPI/EliteAPI/master/EliteAPI/versioncontrol.version").Trim();
                }

                Logger.Log(Severity.Debug, $"Latest version: {latestVersionString} (curr. {Version}).");

                var latestVersion = System.Version.Parse(latestVersionString);
                var currentVersion = System.Version.Parse(Version);

                var hasBiggerVersion = currentVersion < latestVersion;

                if (hasBiggerVersion)
                {
                    Logger.Log($"A new update ({latestVersionString}) is available. Visit github.com/EliteAPI/EliteAPI to download the latest version.");

                    return true;
                }

                Logger.Log(Severity.Debug, "EliteAPI is up-to-date with the latest version.");
            }
            catch (Exception ex)
            {
                Logger.Log(Severity.Debug, "Could not check for updates.", ex);
            }
            
            return false;
        }

        /// <summary>
        /// Resets the API.
        /// </summary>
        public void Reset()
        {
            //Reset services.
            try { Events = new Events.EventHandler(); } catch (Exception ex) { Logger.Log(Severity.Warning, "Couldn't instantiate service 'Events'.", ex); }
            try { Commander = new CommanderStatus(this); } catch (Exception ex) { Logger.Log(Severity.Warning, "Couldn't instantiate service 'Commander'.", ex); }
            try { Location = new LocationStatus(this); } catch (Exception ex) { Logger.Log(Severity.Warning, "Couldn't instantiate service 'Location'.", ex); }
            try { DiscordRichPresence = new RichPresenceClient(this); } catch (Exception ex) { Logger.Log(Severity.Warning, "Couldn't instantiate service 'DiscordRichPresence'.", ex); }
            try { StatusWatcher = new StatusWatcher(this); } catch (Exception ex) { Logger.Log(Severity.Warning, "Couldn't instantiate service 'StatusWatcher'.", ex); }
            try { CargoWatcher = new CargoWatcher(this); } catch (Exception ex) { Logger.Log(Severity.Warning, "Couldn't instantiate service 'CargoWatcher'.", ex); }
            try { Status = EliteAPI.Status.GameStatus.FromFile(new FileInfo(JournalDirectory + "//Status.json"), this); } catch (Exception ex) { Logger.Log(Severity.Warning, "Couldn't instantiate service 'Status'.", ex); }
            try { JournalParser = new JournalParser(this); } catch (Exception ex) { Logger.Log(Severity.Warning, "Couldn't instantiate service 'JournalParser'.", ex); } 
            JournalParser.processedLogs = new List<string>();
        }

        /// <summary>
        /// Starts the API.
        /// </summary>
        public void Start(bool runRichPresence = true)
        {
            OnError += (sender, e) =>
            {
                Logger.Log(Severity.Error, e.Item1, e.Item2);
                Logger.Log(Severity.Warning, "EliteAPI stumbled upon a critical error and cannot continue.", new Exception("ELITEAPI TERMINATED"));
            };
            OnReady += (sender, e) => Logger.Success("EliteAPI is ready.");

            var s = new Stopwatch();
            s.Start();

            Logger.Log("Starting EliteAPI.");
            Logger.Log(Severity.Debug, "EliteAPI by CMDR Somfic (discord.gg/jwpFUPZ) (github.com/EliteAPI/EliteAPI).");
            Logger.Log(Severity.Debug, $"EliteAPI v{Version}.");

            //Check for updates.
            CheckForUpdate();

            Logger.Log(Severity.Debug, "Checking journal directory.");

            if (!Directory.Exists(JournalDirectory.FullName))
            {
                if (JournalDirectory.FullName != StandardDirectory.FullName)
                {
                    Logger.Log(Severity.Warning, $"{JournalDirectory.Name} does not exist.",
                        new DirectoryNotFoundException($"'{JournalDirectory.FullName}' could not be found."));
                    Logger.Log(Severity.Debug, "Trying standard journal directory instead.");
                }

                if (!Directory.Exists(StandardDirectory.FullName))
                {
                    OnError?.Invoke(this,
                        new Tuple<string, Exception>(
                            "The default journal directory does not exist on this machine. This error usually occurs when Elite: Dangerous hasn't been run on this machine yet.",
                            new DirectoryNotFoundException($"'{StandardDirectory.FullName}' could not be found.")));

                    return;
                }

                JournalDirectory = StandardDirectory;
            }

            Logger.Log($"Journal directory set to '{JournalDirectory}'.");

            //Mark the API as running.
            IsRunning = true;

            //We'll process the journal one time first, to catch up.
            //Select the last edited Journal file.
            FileInfo journalFile;

            //Find the last edited Journal file.
            try
            {
                Logger.Log(Severity.Debug, "Searching for 'Journal.*.log' files.");
                journalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).First();
                Logger.Log(Severity.Debug, $"Found '{journalFile}'.");
            }
            catch (Exception ex)
            {
                IsRunning = false;
                OnError?.Invoke(this, new Tuple<string, Exception>($"Could not find Journal files in '{JournalDirectory}'.", ex));

                return;
            }

            //Check for the support JSON files.
            var foundStatus = false;

            try
            {
                //Status.json.
                if (File.Exists(Path.Combine(JournalDirectory.FullName, "\\Status.json")))
                {
                    Logger.Log(Severity.Debug, "Found 'Status.json'.");
                    foundStatus = true;
                }
                else
                {
                    Logger.Log(Severity.Warning, "Could not find 'Status.json' file.");
                    foundStatus = false;
                }

                //Cargo.json.
                if (File.Exists(Path.Combine(JournalDirectory.FullName, "\\Cargo.json")))
                {
                    Logger.Log(Severity.Debug, "Found 'Cargo.json'.");
                }
                else
                {
                    Logger.Log(Severity.Warning, "Could not find 'Cargo.json' file.");
                }

                //Shipyard.json.
                Logger.Log(Severity.Debug, File.Exists(Path.Combine(JournalDirectory.FullName, "\\Shipyard.json"))
                    ? "Found 'Shipyard.json'."
                    : "Could not find 'Shipyard.json' file.");

                //Outfitting.json.
                Logger.Log(Severity.Debug, File.Exists(Path.Combine(JournalDirectory.FullName, "\\Outfitting.json"))
                    ? "Found 'Outfitting.json'."
                    : "Could not find 'Outfitting.json' file.");

                //Market.json.
                Logger.Log(Severity.Debug, File.Exists(Path.Combine(JournalDirectory.FullName, "\\Market.json"))
                    ? "Found 'Market.json'."
                    : "Could not find 'Market.json' file.");

                //ModulesInfo.json.
                if (File.Exists(Path.Combine(JournalDirectory.FullName, "\\ModulesInfo.json")))
                {
                    Logger.Log(Severity.Debug, "Found 'ModulesInfo.json'.");
                }
                else
                {
                    Logger.Log(Severity.Debug, "Could not find 'ModulesInfo.json' file.");
                }
            }
            catch { }

            if (foundStatus)
            {
                Logger.Log("Found Journal and Status files.");
            }
            else
            {
                Logger.Log(Severity.Error, "Could not find Status.json.", new FileNotFoundException("This error usually occurs when Elite: Dangerous hasn't been run on this machine yet.", $"{JournalDirectory.FullName}\\Status.json"));
                Logger.Log("Live updates, such as the landing gear & hardpoints, are not supported without access to 'Status.json'. The Status file is only created after the first run of Elite: Dangerous. If this is not the first time you're running Elite: Dangerous on this machine, change the journal directory.");
                Logger.Log(Severity.Warning, "A critical part of EliteAPI will be offline.", new Exception("PROCEEDING WITH LIMITED FUNCTIONALITY"));
                Logger.Log("Proceeding in 20 seconds ...");
                Thread.Sleep(20000);
            }

            Reset();

            //Check if Elite: Dangerous is running.
            if (!Status.IsRunning)
            {
                Logger.Log(Severity.Warning, "Elite: Dangerous is not in-game.");
            }

            //Process the journal file.
            if (!SkipCatchUp)
            {
                Logger.Log(Severity.Debug, "Catching up with past events from this session.");
            }

            JournalParser.ProcessJournal(journalFile, SkipCatchUp, false, true);

            if (!SkipCatchUp)
            {
                Logger.Log(Severity.Debug, "Catchup on past events completed.");
            }

            //Go async.
            Task.Run(() =>
            {
                //Run for as long as we're running.
                while (IsRunning)
                {
                    //Select the last edited Journal file.
                    var newJournalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).First();

                    if (journalFile.FullName != newJournalFile.FullName)
                    {
                        Logger.Log(Severity.Info, $"Switched to '{newJournalFile}'.");
                        JournalParser.processedLogs.Clear();
                    }

                    journalFile = newJournalFile;

                    //Process the journal file.
                    JournalParser.ProcessJournal(journalFile, false);

                    //Wait half a second to avoid overusing the CPU.
                    Thread.Sleep(500);
                }
            });

            s.Stop();

            Logger.Log(Severity.Debug, $"Finished in {s.ElapsedMilliseconds}ms.");
            IsReady = true;
            OnReady?.Invoke(this, EventArgs.Empty);

            if (runRichPresence)
            {
                //Start the Rich Presence.
                DiscordRichPresence.TurnOn();
            }
        }

        /// <summary>
        ///     Changes the journal directory.
        /// </summary>
        /// <param name="newJournalDirectory">The new journal directory.</param>
        public void ChangeJournal(DirectoryInfo newJournalDirectory)
        {
            if (newJournalDirectory == JournalDirectory) { }
            else if (Logger != null)
            {
                JournalDirectory = newJournalDirectory;
                Logger.Log(Severity.Debug, $"Changed Journal directory to '{newJournalDirectory}'.");
            }
        }

        /// <summary>
        /// Stops the API.
        /// </summary>
        public void Stop()
        {
            //Mark the API as not running.
            IsRunning = false;

            Logger.Log("EliteAPI has been terminated.");

            OnQuit?.Invoke(this, EventArgs.Empty);
        }

        internal void TriggerOnLoad(string message, float percentage)
        {
            OnLoad?.Invoke(this, new Tuple<string, float>(message, percentage));
        }

        /// <summary>
        /// Gets triggered when EliteAPI has successfully loaded up.
        /// </summary>
        public event EventHandler OnReady;

        /// <summary>
        /// Gets triggered when EliteAPI is closing.
        /// </summary>
        public event EventHandler OnQuit;

        /// <summary>
        /// Gets triggered when EliteAPI could not successfully load up.
        /// </summary>
        public event EventHandler<Tuple<string, Exception>> OnError;

        /// <summary>
        /// Gets triggered when EliteAPI is starting up.
        /// </summary>
        public event EventHandler<Tuple<string, float>> OnLoad;
    }
}
