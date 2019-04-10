using EliteAPI.Bindings;
using EliteAPI.Discord;
using EliteAPI.Status;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        /// <summary>
        /// The standard Directory of the Player Journal files (C:\Users\%username%\Saved Games\Frontier Developments\Elite Dangerous).
        /// </summary>
        public static DirectoryInfo StandardDirectory
        {
            get
            {
                try
                {
                    return new DirectoryInfo($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous");
                }
                catch { return new DirectoryInfo(Directory.GetCurrentDirectory()); }
            }
        }

        /// <summary>
        /// The version of EliteAPI.
        /// </summary>
        public string Version => "2.0.2.3";

        /// <summary>
        /// Whether the API is currently running.
        /// </summary>
        public bool IsRunning { get; internal set; } = false;

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
        public Logging.Logger Logger { get; internal set; }

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
        /// Holds the ship's current materials situation.
        /// </summary>
        public Events.MaterialsInfo Materials { get; internal set; }

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
        internal MaterialWatcher MaterialWatcher { get; set; }

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

            //Reset the API.
            Reset();
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

            //Reset the API.
            Reset();
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

            //Reset the API.
            Reset();
        }

        /// <summary>
        /// Creates a new EliteDangerousAPI object.
        /// </summary>
        /// <param name="JournalDirectory">The directory in which the Player Journals are located.</param>
        /// <param name="SkipCatchUp">Whether the API should skip the processing of previous events before the API was started.</param>
        public EliteDangerousAPI(DirectoryInfo JournalDirectory, bool SkipCatchUp)
        {
            //Set the fields to the parameters.
            this.JournalDirectory = JournalDirectory;
            this.SkipCatchUp = SkipCatchUp;

            //Reset the API.
            Reset();
        }

        /// <summary>
        /// Resets the API.
        /// </summary>
        public void Reset()
        {
            //Reset services.
            Logger = new Logging.Logger(this);
            try { Events = new Events.EventHandler(); } catch (Exception ex) { Logger.LogWarning("Couldn't instantiate service 'Events'.", ex); }
            try { Commander = new CommanderStatus(this); } catch (Exception ex) { Logger.LogWarning("Couldn't instantiate service 'Commander'.", ex); }
            try { Location = new LocationStatus(this); } catch (Exception ex) { Logger.LogWarning("Couldn't instantiate service 'Location'.", ex); }
            try { DiscordRichPresence = new RichPresenceClient(this); } catch (Exception ex) { Logger.LogWarning("Couldn't instantiate service 'DiscordRichPresence'.", ex); }
            try { StatusWatcher = new StatusWatcher(this); } catch (Exception ex) { Logger.LogWarning("Couldn't instantiate service 'StatusWatcher'.", ex); }
            try { CargoWatcher = new CargoWatcher(this); } catch (Exception ex) { Logger.LogWarning("Couldn't instantiate service 'CargoWatcher'.", ex); }
            try { Status = EliteAPI.Status.GameStatus.FromFile(new FileInfo(JournalDirectory + "//Status.json"), this); } catch (Exception ex) { Logger.LogWarning("Couldn't instantiate service 'Status'.", ex); }
            try { JournalParser = new JournalParser(this); } catch (Exception ex) { Logger.LogWarning("Couldn't instantiate service 'JournalParser'.", ex); }
            try { MaterialWatcher = new MaterialWatcher(this); } catch (Exception ex) { Logger.LogWarning("Couldn't instantiate service 'MaterialWatcher'.", ex); }
            JournalParser.processedLogs = new List<string>();
        }

        /// <summary>
        /// Starts the API.
        /// </summary>
        public void Start()
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            Logger.LogInfo("Starting EliteAPI.");
            Logger.LogDebug("EliteAPI v" + Version + ".");
            Logger.LogInfo($"Journal directory set to '{JournalDirectory}'.");

            //Mark the API as running.
            IsRunning = true;

            //We'll process the journal one time first, to catch up.
            //Select the last edited Journal file.
            FileInfo journalFile = null;

            //Find the last edited Journal file.
            try
            {
                Logger.LogDebug($"Searching for 'Journal.*.log' files.");
                journalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).First();
                Logger.LogDebug($"Found '{journalFile}'.");
            }
            catch (Exception ex)
            {
                IsRunning = false;
                OnError?.Invoke(this, new Tuple<string, Exception>($"Could not find Journal files in '{JournalDirectory}'", ex));
                return;
            }

            //Check for the support JSON files.
            bool foundStatus = false;

            try
            {
                //Status.json.
                if (File.Exists(JournalDirectory.FullName + "\\Status.json")) { Logger.LogDebug("Found 'Status.json'."); foundStatus = true; }
                else { Logger.LogWarning($"Could not find 'Status.json' file."); foundStatus = false; }

                //Cargo.json.
                if (File.Exists(JournalDirectory.FullName + "\\Cargo.json")) { Logger.LogDebug("Found 'Cargo.json'."); }
                else { Logger.LogWarning($"Could not find 'Cargo.json' file."); }

                //Shipyard.json.
                if (File.Exists(JournalDirectory.FullName + "\\Shipyard.json")) { Logger.LogDebug("Found 'Shipyard.json'."); }
                else { Logger.LogDebug($"Could not find 'Shipyard.json' file."); }

                //Outfitting.json.
                if (File.Exists(JournalDirectory.FullName + "\\Outfitting.json")) { Logger.LogDebug("Found 'Outfitting.json'."); }
                else { Logger.LogDebug($"Could not find 'Outfitting.json' file."); }

                //Market.json.
                if (File.Exists(JournalDirectory.FullName + "\\Market.json")) { Logger.LogDebug("Found 'Market.json'."); }
                else { Logger.LogDebug($"Could not find 'Market.json' file."); }

                //ModulesInfo.json.
                if (File.Exists(JournalDirectory.FullName + "\\ModulesInfo.json")) { Logger.LogDebug("Found 'ModulesInfo.json'."); }
                else { Logger.LogDebug($"Could not find 'ModulesInfo.json' file."); }
            }
            catch { }

            if (foundStatus) { Logger.LogInfo("Found Journal and Status files."); }

            //Check if Elite: Dangerous is running.
            if (!Status.IsRunning) { Logger.LogWarning("Elite: Dangerous is not running."); }

            //Process the journal file.
            JournalParser.ProcessJournal(journalFile, SkipCatchUp);

            //Go async.
            Task.Run(() =>
            {
                //Run for as long as we're running.
                while (IsRunning)
                {
                    //Select the last edited Journal file.
                    FileInfo newJournalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).First();
                    if (journalFile.FullName != newJournalFile.FullName) { Logger.LogDebug($"Switched to '{newJournalFile}'."); JournalParser.processedLogs.Clear(); }
                    journalFile = newJournalFile;

                    //Process the journal file.
                    JournalParser.ProcessJournal(journalFile, false);

                    //Wait half a second to avoid overusing the CPU.
                    Thread.Sleep(500);
                }
            });

            s.Stop();

            Logger.LogDebug($"Finished in {s.ElapsedMilliseconds}ms.");
            OnReady?.Invoke(this, EventArgs.Empty);
        }

        public void ChangeJournal(DirectoryInfo newJournalDirectory)
        {
            if (Logger != null) { Logger.LogDebug($"Changed Journal Directory to '{newJournalDirectory}'."); }
            JournalDirectory = newJournalDirectory;
        }

        /// <summary>
        /// Stops the API.
        /// </summary>
        public void Stop()
        {
            //Mark the API as not running.
            IsRunning = false;

            Logger.LogInfo("EliteAPI has been terminated.");

            OnQuit?.Invoke(this, EventArgs.Empty);
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
    }
}
