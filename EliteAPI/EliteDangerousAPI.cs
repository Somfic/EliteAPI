using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

using EliteAPI.Bindings;
using EliteAPI.Discord;
using EliteAPI.Status;

using Newtonsoft.Json;

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
        public static DirectoryInfo StandardDirectory { get => new DirectoryInfo($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous"); }

        /// <summary>
        /// The version of EliteAPI.
        /// </summary>
        public string Version { get { return "2.0.2.0"; } }

        /// <summary>
        /// Whether the API is currently running.
        /// </summary>
        public bool IsRunning { get; internal set; }

        /// <summary>
        /// The Journal directory that is being used by the API.
        /// </summary>
        public DirectoryInfo JournalDirectory { get; internal set; }

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
        public ShipStatus Status { get; internal set; }

        /// <summary>
        /// Holds the ship's current cargo situation.
        /// </summary>
        public ShipCargo Cargo { get; internal set; }

        /// <summary>
        /// Returns all the modules installed on the current ship.
        /// </summary>
        public ShipModules Modules { get { return ShipModules.FromFile(new FileInfo(JournalDirectory.FullName + "\\ModulesInfo.json"), this); } }

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
        /// Creates a new EliteDangerousAPI object.
        /// </summary>
        /// <param name="JournalDirectory">The directory in which the Player Journals are located.</param>
        /// <param name="SkipCatchUp">Whether the API should skip the processing of previous events before the API was started.</param>
        public EliteDangerousAPI(DirectoryInfo JournalDirectory, bool SkipCatchUp = true)
        {
            //Set the fields to the parameters.
            this.JournalDirectory = JournalDirectory;
            this.SkipCatchUp = SkipCatchUp;
            JournalParser = new JournalParser(this);

            //Reset the API.
            Reset();
        }

        /// <summary>
        /// Resets the API.
        /// </summary>
        public void Reset()
        {
            //Reset services.
            this.Events = new Events.EventHandler();
            this.Logger = new Logging.Logger();
            this.Commander = new CommanderStatus(this);
            this.Location = new LocationStatus(this);
            this.DiscordRichPresence = new RichPresenceClient(this);
            this.StatusWatcher = new StatusWatcher(this);
            this.CargoWatcher = new CargoWatcher(this);
            this.Status = ShipStatus.FromFile(new FileInfo(JournalDirectory + "//Status.json"), this);
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

            //Mark the API as running.
            IsRunning = true;

            //We'll process the journal one time first, to catch up.
            //Select the last edited Journal file.
            FileInfo journalFile = null;

            //Find the last edited Journal file.
            try
            {
                Logger.LogDebug($"Searching for 'Journal.*.log' files in {JournalDirectory}.");
                journalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).First();
                Logger.LogDebug($"Found '{journalFile}'.");
                Logger.LogSuccess("Found Journal files."); 
            }
            catch(Exception ex) { IsRunning = false; Logger.LogError("Could not start EliteAPI. Could not find Journal files.", ex); return; }

            //Check if Elite: Dangerous is running by checking the last event for 'Shutdown'.
            try
            {
                dynamic e = JsonConvert.DeserializeObject<dynamic>(File.ReadAllLines(journalFile.FullName).Last());
                if(e.@event == "Shutdown") { Logger.LogWarning("Elite: Dangerous is not running."); }
            }
            catch { }

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
                    if(journalFile.FullName != newJournalFile.FullName) { Logger.LogDebug($"Switched to '{newJournalFile}'."); JournalParser.processedLogs.Clear(); }
                    journalFile = newJournalFile;

                    //Process the journal file.
                    JournalParser.ProcessJournal(journalFile, false);

                    //Wait half a second to avoid overusing the CPU.
                    Thread.Sleep(500);
                }
            });

            s.Stop();

            Logger.LogDebug($"Finished in {s.ElapsedMilliseconds}ms.");
        }

        /// <summary>
        /// Stops the API.
        /// </summary>
        public void Stop()
        {
            //Mark the API as not running.
            IsRunning = false;

            Logger.LogInfo("Stopping EliteAPI.");
        }

        /// <summary>
        /// Gets triggered when EliteAPI has successfully loaded up.
        /// </summary>
        public event System.EventHandler OnReady;

        /// <summary>
        /// Gets triggered when EliteAPI could not successfully load up.
        /// </summary>
        public event System.EventHandler OnError;
    }
}
