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

        public System lastSystem = new System();
        public Station lastStation = new Station();

        /// <summary>
        /// Whether the class is processing logs.
        /// </summary>
        public bool isRunning { get; private set; } 

        /// <summary>
        /// A list of all the processed logs so far.
        /// </summary>
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
            lastStation = new Station();
            lastSystem = new System();
        }
        /// <summary>
        /// Starts the processing of the log file.
        /// </summary>
        public void Start()
        {
            isRunning = true;
            Task.Run(() => { InitProcessLog(); });
            this.LocationEvent += EliteDangerousAPI_LocationEvent;
            this.DockedEvent += EliteDangerousAPI_DockedEvent;
            this.FSDJumpEvent += EliteDangerousAPI_FSDJumpEvent;
            this.SupercruiseEntryEvent += EliteDangerousAPI_SupercruiseEntryEvent;
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

                Thread.Sleep(333);
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
                    ClearSavedGameEvent?.Invoke(this, JsonConvert.DeserializeObject<ClearSavedGameInfo>(json));
                    break;

                case "NewCommander":
                    NewCommanderEvent?.Invoke(this, JsonConvert.DeserializeObject<NewCommanderInfo>(json));
                    break;

                case "LoadGame":
                    LoadGameEvent?.Invoke(this, JsonConvert.DeserializeObject<LoadGameInfo>(json));
                    break;

                case "Commander":
                    CommanderEvent?.Invoke(this, JsonConvert.DeserializeObject<CommanderInfo>(json));
                    break;

                case "Rank":
                    RankEvent?.Invoke(this, JsonConvert.DeserializeObject<RankInfo>(json));
                    break;

                case "Progress":
                    ProgressEvent?.Invoke(this, JsonConvert.DeserializeObject<ProgressInfo>(json));
                    break;

                case "Reputation":
                    ReputationEvent?.Invoke(this, JsonConvert.DeserializeObject<ReputationInfo>(json));
                    break;

                case "Loadout":
                    LoadoutEvent?.Invoke(this, JsonConvert.DeserializeObject<LoadoutInfo>(json));
                    break;

                case "Location":
                    LocationEvent?.Invoke(this, JsonConvert.DeserializeObject<LocationInfo>(json));
                    break;

                case "Statistics":
                    StatisticsEvent?.Invoke(this, JsonConvert.DeserializeObject<StatisticsInfo>(json));
                    break;

                case "Docked":
                    DockedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockedInfo>(json));
                    break;

                case "Undocked":
                    UndockedEvent?.Invoke(this, JsonConvert.DeserializeObject<UndockedInfo>(json));
                    break;

                case "ShipTargeted":
                    ShipTargetedEvent?.Invoke(this, JsonConvert.DeserializeObject<ShipTargetedInfo>(json));
                    break;

                case "DockingDenied":
                    DockingDeniedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingDeniedInfo>(json));
                    break;

                case "DockingGranted":
                    DockingGrantedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingGrantedInfo>(json));
                    break;

                case "DockingRequested":
                    DockingRequestedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingRequestedInfo>(json));
                    break;

                case "StartJump":
                    StartJumpEvent?.Invoke(this, JsonConvert.DeserializeObject<StartJumpInfo>(json));
                    break;

                case "SupercruiseEntry":
                    SupercruiseEntryEvent?.Invoke(this, JsonConvert.DeserializeObject<SupercruiseEntryInfo>(json));
                    break;

                case "SupercruiseExit":
                    SupercruiseExitEvent?.Invoke(this, JsonConvert.DeserializeObject<SupercruiseExitInfo>(json));
                    break;

                case "FSDJump":
                    FSDJumpEvent?.Invoke(this, JsonConvert.DeserializeObject<FSDJumpInfo>(json));
                    break;

                case "Music":
                    MusicEvent?.Invoke(this, JsonConvert.DeserializeObject<MusicInfo>(json));
                    break;

                case "UnderAttack":
                    UnderAttackEvent?.Invoke(this, JsonConvert.DeserializeObject<UnderAttackInfo>(json));
                    break;

                case "Scanned":
                    ScannedEvent?.Invoke(this, JsonConvert.DeserializeObject<ScanInfo>(json));
                    break;

                case "Interdicted":
                    InterdictedEvent?.Invoke(this, JsonConvert.DeserializeObject<InterdictedInfo>(json));
                    break;

                case "ReceiveText":
                    ReceiveTextEvent?.Invoke(this, JsonConvert.DeserializeObject<ReceiveTextInfo>(json));
                    break;
            }
        }

        /// <summary>
        /// Triggered whenever the save is reset/cleared.
        /// </summary>
        public event EventHandler<ClearSavedGameInfo> ClearSavedGameEvent;

        /// <summary>
        /// Triggered whenever a new commander is created.
        /// </summary>
        public event EventHandler<NewCommanderInfo> NewCommanderEvent;

        /// <summary>
        /// Triggered whenever the game starts.
        /// </summary>
        public event EventHandler<LoadGameInfo> LoadGameEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains basic commander info.
        /// </summary>
        public event EventHandler<CommanderInfo> CommanderEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains basic rank info.
        /// </summary>
        public event EventHandler<RankInfo> RankEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains basic rank progress info.
        /// </summary>
        public event EventHandler<ProgressInfo> ProgressEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains basic reputation info.
        /// </summary>
        public event EventHandler<ReputationInfo> ReputationEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains the ship's loadout.
        /// </summary>
        public event EventHandler<LoadoutInfo> LoadoutEvent;

        /// <summary>
        /// Triggered whenever the player has started, contains info about the current location.
        /// </summary>
        public event EventHandler<LocationInfo> LocationEvent;

        /// <summary>
        /// Triggered whenever the player starts, contains all the player's current statistics.
        /// </summary>
        public event EventHandler<StatisticsInfo> StatisticsEvent;

        /// <summary>
        /// Triggered whenever a player docks at a station.
        /// </summary>
        public event EventHandler<DockedInfo> DockedEvent;
        
        /// <summary>
        /// Triggered whenever a player undocks from a station.
        /// </summary>
        public event EventHandler<UndockedInfo> UndockedEvent;

        /// <summary>
        /// Triggered whenever a player targets another ship.
        /// </summary>
        public event EventHandler<ShipTargetedInfo> ShipTargetedEvent;

        /// <summary>
        /// Triggered whenever a player has their docking request denied.
        /// </summary>
        public event EventHandler<DockingDeniedInfo> DockingDeniedEvent;

        /// <summary>
        /// Triggered whenever a player has their docking request granted.
        /// </summary>
        public event EventHandler<DockingGrantedInfo> DockingGrantedEvent;

        /// <summary>
        /// Triggered whenever a player requests docking permissions.
        /// </summary>
        public event EventHandler<DockingRequestedInfo> DockingRequestedEvent;

        /// <summary>
        /// Triggered whenever a player starts jumping.
        /// </summary>
        public event EventHandler<StartJumpInfo> StartJumpEvent;

        /// <summary>
        /// Triggered whenever a player jumped into supercruise.
        /// </summary>
        public event EventHandler<SupercruiseEntryInfo> SupercruiseEntryEvent;

        /// <summary>
        /// Triggered whenever a player left supercruise.
        /// </summary>
        public event EventHandler<SupercruiseExitInfo> SupercruiseExitEvent;

        /// <summary>
        /// Triggered whenever a player is jumping to another system.
        /// </summary>
        public event EventHandler<FSDJumpInfo> FSDJumpEvent;

        /// <summary>
        /// Triggered whenever the music track changes.
        /// </summary>
        public event EventHandler<MusicInfo> MusicEvent;

        /// <summary>
        /// Triggered whenever a player is under attack.
        /// </summary>
        public event EventHandler<UnderAttackInfo> UnderAttackEvent;

        /// <summary>
        /// Triggered whenever a player is being scanned.
        /// </summary>
        public event EventHandler<ScanInfo> ScannedEvent;

        /// <summary>
        /// Triggered whenever a player recieves a message.
        /// </summary>
        public event EventHandler<ReceiveTextInfo> ReceiveTextEvent;

        /// <summary>
        /// Triggered whenever a player gets successfully interdicted.
        /// </summary>
        public event EventHandler<InterdictedInfo> InterdictedEvent;

        private void EliteDangerousAPI_SupercruiseEntryEvent(object sender, SupercruiseEntryInfo e)
        {
            lastSystem.Address = e.SystemAddress;
            lastSystem.Name = e.StarSystem;
        }
        private void EliteDangerousAPI_FSDJumpEvent(object sender, FSDJumpInfo e)
        {
            lastSystem.Address = e.SystemAddress;
            lastSystem.Allegiance = e.SystemAllegiance;
            lastSystem.Economy = e.SystemEconomy;
            lastSystem.Economy_Localised = e.SystemEconomy_Localised;
            lastSystem.Government = e.SystemGovernment;
            lastSystem.Government_Localised = e.SystemGovernment_Localised;
            lastSystem.Name = e.StarSystem;
            lastSystem.Population = e.Population;
            lastSystem.Position = e.StarPos;
            lastSystem.SecondEconomy = e.SystemSecondEconomy;
            lastSystem.SecondEconomy_Localised = e.SystemSecondEconomy_Localised;
            lastSystem.Security = e.SystemSecurity;
            lastSystem.Security_Localised = e.SystemSecurity_Localised;
        }
        private void EliteDangerousAPI_DockedEvent(object sender, DockedInfo e)
        {
            lastSystem.Name = e.StarSystem;
            lastSystem.Address = e.SystemAddress;

            lastStation.Allegiance = e.StationAllegiance;
            lastStation.DistFromStarLS = e.DistFromStarLS;
            lastStation.Economies = e.StationEconomies;
            lastStation.Economy = e.StationEconomy;
            lastStation.Economy_Localised = e.StationEconomy_Localised;
            lastStation.Faction = e.StationFaction;
            lastStation.FactionState = e.FactionState;
            lastStation.Government = e.StationGovernment;
            lastStation.Government_Localised = e.StationGovernment_Localised;
            lastStation.MarketID = e.MarketID;
            lastStation.Name = e.StationName;
            lastStation.Services = e.StationServices;
            lastStation.System = lastSystem;
            lastStation.Type = e.StationType;
        }
        private void EliteDangerousAPI_LocationEvent(object sender, LocationInfo e)
        {
            lastSystem.Address = e.SystemAddress;
            lastSystem.Allegiance = e.SystemAllegiance;
            lastSystem.Economy = e.SystemEconomy;
            lastSystem.Economy_Localised = e.SystemEconomy_Localised;
            lastSystem.FactionState = e.FactionState;
            lastSystem.Government = e.SystemGovernment;
            lastSystem.Government_Localised = e.SystemGovernment_Localised;
            lastSystem.Name = e.StarSystem;
            lastSystem.Population = e.Population;
            lastSystem.Position = e.StarPos;
            lastSystem.SecondEconomy = e.SystemSecondEconomy;
            lastSystem.SecondEconomy_Localised = e.SystemSecondEconomy_Localised;
            lastSystem.Security = e.SystemSecurity;
            lastSystem.Security_Localised = e.SystemSecurity_Localised;
            lastSystem.SystemFaction = e.SystemFaction;

            lastStation.Name = e.StationName;
            lastStation.Type = e.StationType;
            lastStation.System = lastSystem;
        }
    }
}
