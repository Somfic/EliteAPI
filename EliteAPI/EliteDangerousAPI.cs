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
        public string Version => "2.0.2.10";

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
        public Logger Logger { get; internal set; }

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
        /// Checks for a new update.
        /// </summary>
        /// <returns>Returns true if a newer version is available.</returns>
        public bool CheckForUpdate()
        {
            Logger.Debug("Checking for updates from GitHub.");

            try
            {
                WebClient versionChecker = new WebClient();
                string latestVersionString = versionChecker.DownloadString("https://raw.githubusercontent.com/EliteAPI/EliteAPI/master/EliteAPI%202/versioncontrol.version").Trim();

                Logger.Debug($"Latest version: {latestVersionString} (curr. {Version}).");

                int latestVersion = int.Parse(latestVersionString.Replace(".", ""));
                int thisVersoin = int.Parse(Version.Replace(".", ""));

                if (thisVersoin < latestVersion) { Logger.Log($"A new update ({latestVersionString}) is available. Visit github.com/EliteAPI/EliteAPI to download the latest version."); return true; } else { Logger.Debug("EliteAPI is up-to-date with the latest version."); }
            }
            catch (Exception ex) { Logger.Debug("Could not check for updates.", ex); }

            return false;
        }

        /// <summary>
        /// Resets the API.
        /// </summary>
        public void Reset()
        {
            //Reset services.
            Logger = new Logger();
            try { Events = new Events.EventHandler(); } catch (Exception ex) { Logger.Warning("Couldn't instantiate service 'Events'.", ex); }
            try { Commander = new CommanderStatus(this); } catch (Exception ex) { Logger.Warning("Couldn't instantiate service 'Commander'.", ex); }
            try { Location = new LocationStatus(this); } catch (Exception ex) { Logger.Warning("Couldn't instantiate service 'Location'.", ex); }
            try { DiscordRichPresence = new RichPresenceClient(this); } catch (Exception ex) { Logger.Warning("Couldn't instantiate service 'DiscordRichPresence'.", ex); }
            try { StatusWatcher = new StatusWatcher(this); } catch (Exception ex) { Logger.Warning("Couldn't instantiate service 'StatusWatcher'.", ex); }
            try { CargoWatcher = new CargoWatcher(this); } catch (Exception ex) { Logger.Warning("Couldn't instantiate service 'CargoWatcher'.", ex); }
            try { Status = EliteAPI.Status.GameStatus.FromFile(new FileInfo(JournalDirectory + "//Status.json"), this); } catch (Exception ex) { Logger.Warning("Couldn't instantiate service 'Status'.", ex); }
            try { JournalParser = new JournalParser(this); } catch (Exception ex) { Logger.Warning("Couldn't instantiate service 'JournalParser'.", ex); }
            try { MaterialWatcher = new MaterialWatcher(this); } catch (Exception ex) { Logger.Warning("Couldn't instantiate service 'MaterialWatcher'.", ex); }
            JournalParser.processedLogs = new List<string>();
        }

        /// <summary>
        /// Starts the API.
        /// </summary>
        public void Start()
        {
            OnError += (sender, e) => Logger.Error(e.Item1, e.Item2);
            OnReady += (sender, e) => Logger.Success("EliteAPI is ready.");

            Stopwatch s = new Stopwatch();
            s.Start();

            Logger.Log("Starting EliteAPI.");
            Logger.Debug("EliteAPI by CMDR Somfic (discord.gg/jwpFUPZ) (github.com/EliteAPI/EliteAPI).");
            Logger.Debug("EliteAPI v" + Version + ".");

            //Check for updates.
            CheckForUpdate();

            Logger.Log($"Journal directory set to '{JournalDirectory}'.");
            if (!Directory.Exists(JournalDirectory.FullName))
            {
                Logger.Warning("That directory does not exist.");
                if (!Directory.Exists(EliteDangerousAPI.StandardDirectory.FullName))
                {
                    OnError?.Invoke(this, new Tuple<string, Exception>("The default journal directory does not exist on this machine. Please run Elite: Dangerous at least once.", null));
                    return;
                }
            }

            //Mark the API as running.
            IsRunning = true;

            //We'll process the journal one time first, to catch up.
            //Select the last edited Journal file.
            FileInfo journalFile = null;

            //Find the last edited Journal file.
            try
            {
                Logger.Debug($"Searching for 'Journal.*.log' files.");
                journalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).First();
                Logger.Debug($"Found '{journalFile}'.");
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
                if (File.Exists(JournalDirectory.FullName + "\\Status.json")) { Logger.Debug("Found 'Status.json'."); foundStatus = true; }
                else { Logger.Warning($"Could not find 'Status.json' file."); foundStatus = false; }

                //Cargo.json.
                if (File.Exists(JournalDirectory.FullName + "\\Cargo.json")) { Logger.Debug("Found 'Cargo.json'."); }
                else { Logger.Warning($"Could not find 'Cargo.json' file."); }

                //Shipyard.json.
                if (File.Exists(JournalDirectory.FullName + "\\Shipyard.json")) { Logger.Debug("Found 'Shipyard.json'."); }
                else { Logger.Debug($"Could not find 'Shipyard.json' file."); }

                //Outfitting.json.
                if (File.Exists(JournalDirectory.FullName + "\\Outfitting.json")) { Logger.Debug("Found 'Outfitting.json'."); }
                else { Logger.Debug($"Could not find 'Outfitting.json' file."); }

                //Market.json.
                if (File.Exists(JournalDirectory.FullName + "\\Market.json")) { Logger.Debug("Found 'Market.json'."); }
                else { Logger.Debug($"Could not find 'Market.json' file."); }

                //ModulesInfo.json.
                if (File.Exists(JournalDirectory.FullName + "\\ModulesInfo.json")) { Logger.Debug("Found 'ModulesInfo.json'."); }
                else { Logger.Debug($"Could not find 'ModulesInfo.json' file."); }
            }
            catch { }

            if (foundStatus) { Logger.Log("Found Journal and Status files."); }

            //Check if Elite: Dangerous is running.
            if (!Status.IsRunning) { Logger.Warning("Elite: Dangerous is not in-game."); }

            //Process the journal file.
            if (!SkipCatchUp) { Logger.Debug("Catching up with past events from this session."); }
            JournalParser.ProcessJournal(journalFile, SkipCatchUp);
            if (!SkipCatchUp) { Logger.Debug("Catchup on past events completed."); }

            //Go async.
            Task.Run(() =>
            {
                //Run for as long as we're running.
                while (IsRunning)
                {
                    //Select the last edited Journal file.
                    FileInfo newJournalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).First();
                    if (journalFile.FullName != newJournalFile.FullName) { Logger.Debug($"Switched to '{newJournalFile}'."); JournalParser.processedLogs.Clear(); }
                    journalFile = newJournalFile;

                    //Process the journal file.
                    JournalParser.ProcessJournal(journalFile, false);

                    //Wait half a second to avoid overusing the CPU.
                    Thread.Sleep(500);
                }
            });

            s.Stop();

            Logger.Debug($"Finished in {s.ElapsedMilliseconds}ms.");
            IsReady = true;
            OnReady?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Changes the journal directory.
        /// </summary>
        /// <param name="newJournalDirectory">The new journal directory.</param>
        public void ChangeJournal(DirectoryInfo newJournalDirectory)
        {
            if (newJournalDirectory == JournalDirectory) { return; }
            else if (Logger != null)
            {
                JournalDirectory = newJournalDirectory;
                Logger.Debug($"Changed Journal Directory to '{newJournalDirectory}'.");
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
