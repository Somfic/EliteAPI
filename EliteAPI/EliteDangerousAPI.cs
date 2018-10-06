using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace EliteAPI
{
    public class EliteDangerousAPI
    {
        private DirectoryInfo _playerJournalDirectory;

        /// <summary>
        /// Whether the class is processing logs.
        /// </summary>
        public bool isRunning { get; private set; } 

        private List<string> processedLogs;

        /// <summary>
        /// Creates a new API class.
        /// </summary>
        /// <param name="playerJournalDirectory">The folder where the Player Journal is located in.</param>
        public EliteDangerousAPI(DirectoryInfo playerJournalDirectory)
        {
            _playerJournalDirectory = playerJournalDirectory;

            Reset();
        }

        /// <summary>
        /// Resets everything.
        /// </summary>
        public void Reset()
        {
            processedLogs = new List<string>();
        }

        /// <summary>
        /// Starts the processing of the log file.
        /// </summary>
        public void Start()
        {
            isRunning = true;
            Task.Run(() => { InitProcessLog(); });
        }

        /// <summary>
        /// Stops the processing of the log file.
        /// </summary>
        public void Stop()
        {
            isRunning = false;
        }

        /// <summary>
        /// Initializes the processing of the log.
        /// </summary>
        private void InitProcessLog()
        {
            while(isRunning)
            {
                FileInfo logFile = _playerJournalDirectory
                                    .GetFiles("*.log") //Get all files that end with .log.
                                    .OrderByDescending(x => x.LastWriteTime) //Order them by last written.
                                    .First(); //Get the first one of the ordered list.

                ProcessLog(logFile);

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Process the log file once.
        /// </summary>
        /// <param name="logFile">The log file to process.</param>
        private void ProcessLog(FileInfo logFile, bool actuallyProcess = true)
        {
            //Create a stream from the log file.
            FileStream fileStream = logFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Create a stream from the file stream.
            StreamReader streamReader = new StreamReader(fileStream);

            //Go through the stream.
            while (!streamReader.EndOfStream)
            {
                //If this string hasn't been processed yet, process it and mark it as processed.
                string thisLog = streamReader.ReadLine();
                if (!processedLogs.Contains(thisLog)) {

                    if (actuallyProcess) { Process(thisLog); } //Only process it if it's marked true.
                    processedLogs.Add(thisLog);
                }
            }
        }

        private void Process(string json)
        {
            dynamic dynamicLog = JsonConvert.DeserializeObject(json);
            string eventName = dynamicLog.@event;

            switch (eventName)
            {
                case "ClearSavedGame":
                    ClearSavedGameEvent?.Invoke(this, JsonConvert.DeserializeObject<ClearSavedGame>(json));
                    break;

                case "NewCommander":
                    NewCommanderEvent?.Invoke(this, JsonConvert.DeserializeObject<NewCommander>(json));
                    break;

                case "LoadGame":
                    LoadGameEvent?.Invoke(this, JsonConvert.DeserializeObject<LoadGame>(json));
                    break;

                case "Commander":
                    CommanderEvent?.Invoke(this, JsonConvert.DeserializeObject<Commander>(json));
                    break;

                case "Rank":
                    RankEvent?.Invoke(this, JsonConvert.DeserializeObject<Rank>(json));
                    break;

                case "Progress":
                    ProgressEvent?.Invoke(this, JsonConvert.DeserializeObject<Progress>(json));
                    break;

                case "Reputation":
                    ReputationEvent?.Invoke(this, JsonConvert.DeserializeObject<Reputation>(json));
                    break;

                case "Loadout":
                    LoadoutEvent?.Invoke(this, JsonConvert.DeserializeObject<Loadout>(json));
                    break;

                case "Location":
                    LocationEvent?.Invoke(this, JsonConvert.DeserializeObject<Location>(json));
                    break;

                case "Statistics":
                    StatisticsEvent?.Invoke(this, JsonConvert.DeserializeObject<Statistics>(json));
                    break;

                case "Docked":
                    DockedEvent?.Invoke(this, JsonConvert.DeserializeObject<Docked>(json));
                    break;

                case "Undocked":
                    UndockedEvent?.Invoke(this, JsonConvert.DeserializeObject<Undocked>(json));
                    break;

                case "ShipTargeted":
                    ShipTargetedEvent?.Invoke(this, JsonConvert.DeserializeObject<ShipTargeted>(json));
                    break;

                case "DockingDenied":
                    DockingDeniedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingDenied>(json));
                    break;

                case "DockingGranted":
                    DockingGrantedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingGranted>(json));
                    break;

                case "DockingRequested":
                    DockingRequestedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingRequested>(json));
                    break;

                case "StartJump":
                    StartJumpEvent?.Invoke(this, JsonConvert.DeserializeObject<StartJump>(json));
                    break;

                case "SupercruiseEntry":
                    SupercruiseEntryEvent?.Invoke(this, JsonConvert.DeserializeObject<SupercruiseEntry>(json));
                    break;

                case "SupercruiseExit":
                    SupercruiseExitEvent?.Invoke(this, JsonConvert.DeserializeObject<SupercruiseExit>(json));
                    break;

                case "FSDJump":
                    FSDJumpEvent?.Invoke(this, JsonConvert.DeserializeObject<FSDJump>(json));
                    break;

                case "Music":
                    MusicEvent?.Invoke(this, JsonConvert.DeserializeObject<Music>(json));
                    break;

                case "UnderAttack":
                    UnderAttackEvent?.Invoke(this, JsonConvert.DeserializeObject<UnderAttack>(json));
                    break;
            }
        }

        /// <summary>
        /// Triggered whenever the save is reset/cleared.
        /// </summary>
        public event EventHandler<ClearSavedGame> ClearSavedGameEvent;

        /// <summary>
        /// Triggered whenever a new commander is created.
        /// </summary>
        public event EventHandler<NewCommander> NewCommanderEvent;

        /// <summary>
        /// Triggered whenever the game starts.
        /// </summary>
        public event EventHandler<LoadGame> LoadGameEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains basic commander info.
        /// </summary>
        public event EventHandler<Commander> CommanderEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains basic rank info.
        /// </summary>
        public event EventHandler<Rank> RankEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains basic rank progress info.
        /// </summary>
        public event EventHandler<Progress> ProgressEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains basic reputation info.
        /// </summary>
        public event EventHandler<Reputation> ReputationEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains the ship's loadout.
        /// </summary>
        public event EventHandler<Loadout> LoadoutEvent;

        /// <summary>
        /// Triggered whenever the player has started, contains info about the current location.
        /// </summary>
        public event EventHandler<Location> LocationEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains all the player's current statistics.
        /// </summary>
        public event EventHandler<Statistics> StatisticsEvent;

        /// <summary>
        /// Triggered whenever a player docks at a station.
        /// </summary>
        public event EventHandler<Docked> DockedEvent;
        
        /// <summary>
        /// Triggered whenever a player undocks from a station.
        /// </summary>
        public event EventHandler<Undocked> UndockedEvent;

        /// <summary>
        /// Triggered whenever a player targets another ship.
        /// </summary>
        public event EventHandler<ShipTargeted> ShipTargetedEvent;

        /// <summary>
        /// Triggered whenever a player has their docking request denied.
        /// </summary>
        public event EventHandler<DockingDenied> DockingDeniedEvent;

        /// <summary>
        /// Triggered whenever a player has their docking request granted.
        /// </summary>
        public event EventHandler<DockingGranted> DockingGrantedEvent;

        /// <summary>
        /// Triggered whenever a player requests docking permissions.
        /// </summary>
        public event EventHandler<DockingRequested> DockingRequestedEvent;

        /// <summary>
        /// Triggered whenever a player starts jumping.
        /// </summary>
        public event EventHandler<StartJump> StartJumpEvent;

        /// <summary>
        /// Triggered whenever a player jumped into supercruise.
        /// </summary>
        public event EventHandler<SupercruiseEntry> SupercruiseEntryEvent;

        /// <summary>
        /// Triggered whenever a player left supercruise.
        /// </summary>
        public event EventHandler<SupercruiseExit> SupercruiseExitEvent;

        /// <summary>
        /// Triggered whenever a player is jumping to another system.
        /// </summary>
        public event EventHandler<FSDJump> FSDJumpEvent;

        /// <summary>
        /// Triggered whenever the music track changes.
        /// </summary>
        public event EventHandler<Music> MusicEvent;

        /// <summary>
        /// Triggered whenever a player is under attack.
        /// </summary>
        public event EventHandler<UnderAttack> UnderAttackEvent;
    }
}
