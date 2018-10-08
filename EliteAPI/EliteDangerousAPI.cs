using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace EliteAPI
{
    public class EliteDangerousAPI
    {
        private DirectoryInfo _playerJournalDirectory;

        /// <summary>
        /// Contains information on the most recent body visited.
        /// </summary>
        public Body lastBody = new Body();

        /// <summary>
        /// Contains information on the most recent system visited.
        /// </summary>
        public System lastSystem = new System();

        /// <summary>
        /// Contains information on the most recent station visited.
        /// </summary>
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
            this.SupercruiseExitEvent += EliteDangerousAPI_SupercruiseExitEvent;
            this.DockingRequestedEvent += EliteDangerousAPI_DockingRequestedEvent;
        }

        /// <summary>
        /// Stops the processing of the log file.
        /// </summary>
        public void Stop()
        {
            isRunning = false;
            this.LocationEvent -= EliteDangerousAPI_LocationEvent;
            this.DockedEvent -= EliteDangerousAPI_DockedEvent;
            this.FSDJumpEvent -= EliteDangerousAPI_FSDJumpEvent;
            this.SupercruiseEntryEvent -= EliteDangerousAPI_SupercruiseEntryEvent;
            this.SupercruiseExitEvent -= EliteDangerousAPI_SupercruiseExitEvent;
            this.DockingRequestedEvent -= EliteDangerousAPI_DockingRequestedEvent;
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
                default:
                    //File.AppendAllText(@"D:\NotAddedEvents.txt", json + Environment.NewLine);
                    break;

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
                    ScannedEvent?.Invoke(this, JsonConvert.DeserializeObject<ScannedInfo>(json));
                    break;

                case "Interdicted":
                    InterdictedEvent?.Invoke(this, JsonConvert.DeserializeObject<InterdictedInfo>(json));
                    break;

                case "ReceiveText":
                    ReceiveTextEvent?.Invoke(this, JsonConvert.DeserializeObject<ReceiveTextInfo>(json));
                    break;

                case "DockingTimeout":
                    DockingTimeoutEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingTimeoutInfo>(json));
                    break;

                case "ApproachSettlement":
                    ApproachSettlementEvent?.Invoke(this, JsonConvert.DeserializeObject<ApproachSettlementInfo>(json));
                    break;

                case "ApproachBody":
                    ApproachBodyEvent?.Invoke(this, JsonConvert.DeserializeObject<ApproachBodyInfo>(json));
                    break;

                case "Touchdown":
                    TouchdownEvent?.Invoke(this, JsonConvert.DeserializeObject<TouchdownInfo>(json));
                    break;

                case "Liftoff":
                    LiftoffEvent?.Invoke(this, JsonConvert.DeserializeObject<LiftoffInfo>(json));
                    break;

                case "LeaveBody":
                    LeaveBodyEvent?.Invoke(this, JsonConvert.DeserializeObject<LeaveBodyInfo>(json));
                    break;

                case "MissionAccepted":
                    MissionAcceptedEvent?.Invoke(this, JsonConvert.DeserializeObject<MissionAcceptedInfo>(json));
                    break;

                case "MissionAbandoned":
                    MissionAbandonedEvent?.Invoke(this, JsonConvert.DeserializeObject<MissionAbandonedInfo>(json));
                    break;

                case "MissionCompleted":
                    MissionCompletedEvent?.Invoke(this, JsonConvert.DeserializeObject<MissionCompletedInfo>(json));
                    break;

                case "Missions":
                    MissionsEvent?.Invoke(this, JsonConvert.DeserializeObject<MissionsInfo>(json));
                    break;

                case "Outfitting":
                    OutfittingEvent?.Invoke(this, JsonConvert.DeserializeObject<OutfittingInfo>(json));
                    break;

                case "Friends":
                    FriendsEvent?.Invoke(this, JsonConvert.DeserializeObject<FriendsInfo>(json));
                    break;

                case "Materials":
                    MaterialsEvent?.Invoke(this, JsonConvert.DeserializeObject<MaterialsInfo>(json));
                    break;

                case "NpcCrewPaidWage":
                    NpcCrewPaidWageEvent?.Invoke(this, JsonConvert.DeserializeObject<NpcCrewPaidWageInfo>(json));
                    break;

                case "RepairAll":
                    RepairAllEvent?.Invoke(this, JsonConvert.DeserializeObject<RepairAllInfo>(json));
                    break;

                case "RefuelAll":
                    RefuelAllEvent?.Invoke(this, JsonConvert.DeserializeObject<RefuelAllInfo>(json));
                    break;

                case "StoredModules":
                    StoredModulesEvent?.Invoke(this, JsonConvert.DeserializeObject<StoredModulesInfo>(json));
                    break;

                case "Cargo":
                    CargoEvent?.Invoke(this, JsonConvert.DeserializeObject<CargoInfo>(json));
                    break;

                case "MarketBuy":
                    MarketBuyEvent?.Invoke(this, JsonConvert.DeserializeObject<MarketBuyInfo>(json));
                    break;

                case "MarketSell":
                    MarketSellEvent?.Invoke(this, JsonConvert.DeserializeObject<MarketSellInfo>(json));
                    break;

                case "ModuleBuy":
                    ModuleBuyEvent?.Invoke(this, JsonConvert.DeserializeObject<ModuleBuyInfo>(json));
                    break;

                case "ModuleSell":
                    ModuleSellEvent?.Invoke(this, JsonConvert.DeserializeObject<ModuleSellInfo>(json));
                    break;

                case "EjectCargo":
                    EjectCargoEvent?.Invoke(this, JsonConvert.DeserializeObject<EjectCargoInfo>(json));
                    break;

                case "StoredShips":
                    StoredShipsEvent?.Invoke(this, JsonConvert.DeserializeObject<StoredShipsInfo>(json));
                    break;

                case "ShipyardBuy":
                    ShipyardBuyEvent?.Invoke(this, JsonConvert.DeserializeObject<ShipyardBuyInfo>(json));
                    break;

                case "ShipyardSell":
                    ShipyardSellEvent?.Invoke(this, JsonConvert.DeserializeObject<ShipyardSellInfo>(json));
                    break;

                case "ShipyardSwap":
                    ShipyardSwapEvent?.Invoke(this, JsonConvert.DeserializeObject<ShipyardSwapInfo>(json));
                    break;

                case "Shipyard":
                    ShipyardEvent?.Invoke(this, JsonConvert.DeserializeObject<ShipyardInfo>(json));
                    break;

                case "Market":
                    MarketEvent?.Invoke(this, JsonConvert.DeserializeObject<MarketInfo>(json));
                    break;

                case "Repair":
                    RepairEvent?.Invoke(this, JsonConvert.DeserializeObject<RepairInfo>(json));
                    break;

                case "RefuelPartial":
                    RefuelPartialEvent?.Invoke(this, JsonConvert.DeserializeObject<RefuelPartialInfo>(json));
                    break;

                case "Fileheader":
                    FileheaderEvent?.Invoke(this, JsonConvert.DeserializeObject<FileheaderInfo>(json));
                    break;

                case "ShipyardTransfer":
                    ShipyardTransferEvent?.Invoke(this, JsonConvert.DeserializeObject<ShipyardTransferInfo>(json));
                    break;

                case "DiscoveryScan":
                    DiscoveryScanEvent?.Invoke(this, JsonConvert.DeserializeObject<DiscoveryScanInfo>(json));
                    break;

                case "Bounty":
                    BountyEvent?.Invoke(this, JsonConvert.DeserializeObject<BountyInfo>(json));
                    break;

                case "Scan":
                    ScanEvent?.Invoke(this, JsonConvert.DeserializeObject<ScanInfo>(json));
                    break;

                case "Shutdown":
                    ShutdownEvent?.Invoke(this, JsonConvert.DeserializeObject<ShutdownInfo>(json));
                    break;

                case "FuelScoop":
                    FuelScoopEvent?.Invoke(this, JsonConvert.DeserializeObject<FuelScoopInfo>(json));
                    break;

                case "LaunchFighter":
                    LaunchFighterEvent?.Invoke(this, JsonConvert.DeserializeObject<LaunchFighterInfo>(json));
                    break;
            }
        }

        /// <summary>
        /// Triggered whenever a player scoops fuel from a star.
        /// </summary>
        public event EventHandler<LaunchFighterInfo> LaunchFighterEvent;

        /// <summary>
        /// Triggered whenever a player scoops fuel from a star.
        /// </summary>
        public event EventHandler<FuelScoopInfo> FuelScoopEvent;

        /// <summary>
        /// Triggered whenever a player logs off.
        /// </summary>
        public event EventHandler<ShutdownInfo> ShutdownEvent;

        /// <summary>
        /// Triggered whenever a player scans a planet or star with the special scanner.
        /// </summary>
        public event EventHandler<ScanInfo> ScanEvent;

        /// <summary>
        /// Triggered whenever a player receives a bounty from killing a player or NPC.
        /// </summary>
        public event EventHandler<BountyInfo> BountyEvent;

        /// <summary>
        /// Triggered whenever a player scans a starsystem, often happens partially automatically when a player enters a starsystem.
        /// </summary>
        public event EventHandler<DiscoveryScanInfo> DiscoveryScanEvent;

        /// <summary>
        /// Triggered whenever a player requests a ship to be transferred.
        /// </summary>
        public event EventHandler<ShipyardTransferInfo> ShipyardTransferEvent;

        /// <summary>
        /// Triggered whenever the game launches, contains basic version info.
        /// </summary>
        public event EventHandler<FileheaderInfo> FileheaderEvent;

        /// <summary>
        /// Triggered whenever a player refuels 10%.
        /// </summary>
        public event EventHandler<RefuelPartialInfo> RefuelPartialEvent;

        /// <summary>
        /// Triggered whenever a player repairs a single module.
        /// </summary>
        public event EventHandler<RepairInfo> RepairEvent;

        /// <summary>
        /// Triggered whenever the player opens the station's market.
        /// </summary>
        public event EventHandler<MarketInfo> MarketEvent;

        /// <summary>
        /// Triggered whenever the player opens the station's shipyard.
        /// </summary>
        public event EventHandler<ShipyardInfo> ShipyardEvent;

        /// <summary>
        /// Triggered whenever the player swaps ships.
        /// </summary>
        public event EventHandler<ShipyardSwapInfo> ShipyardSwapEvent;

        /// <summary>
        /// Triggered whenever the player sells a ship.
        /// </summary>
        public event EventHandler<ShipyardSellInfo> ShipyardSellEvent;

        /// <summary>
        /// Triggered whenever the player buys a new ship.
        /// </summary>
        public event EventHandler<ShipyardBuyInfo> ShipyardBuyEvent;

        /// <summary>
        /// Triggered whenever the player opens the ship management window.
        /// </summary>
        public event EventHandler<StoredShipsInfo> StoredShipsEvent;

        /// <summary>
        /// Triggered whenever the player ejects cargo.
        /// </summary>
        public event EventHandler<EjectCargoInfo> EjectCargoEvent;

        /// <summary>
        /// Triggered when the player sells a module to the station.
        /// </summary>
        public event EventHandler<ModuleSellInfo> ModuleSellEvent;

        /// <summary>
        /// Triggered when the player buys a module from the station.
        /// </summary>
        public event EventHandler<ModuleBuyInfo> ModuleBuyEvent;

        /// <summary>
        /// Triggered when the player sells something to the station market.
        /// </summary>
        public event EventHandler<MarketSellInfo> MarketSellEvent;

        /// <summary>
        /// Triggered when the player buys something from the station market.
        /// </summary>
        public event EventHandler<MarketBuyInfo> MarketBuyEvent;

        /// <summary>
        /// Triggered when the player logs in, shows details about the cargo on the ship.
        /// </summary>
        public event EventHandler<CargoInfo> CargoEvent;

        /// <summary>
        /// Triggered whenever a player goes into outfitting and has stored modules at that station.
        /// </summary>
        public event EventHandler<StoredModulesInfo> StoredModulesEvent;

        /// <summary>
        /// Triggered whenever a player refuels the entire ship at once.
        /// </summary>
        public event EventHandler<RefuelAllInfo> RefuelAllEvent;

        /// <summary>
        /// Triggered whenever a player repairs the entire ship at once.
        /// </summary>
        public event EventHandler<RepairAllInfo> RepairAllEvent;

        /// <summary>
        /// Triggered whenever a crewmember gets paid or when docked.
        /// </summary>
        public event EventHandler<NpcCrewPaidWageInfo> NpcCrewPaidWageEvent;

        /// <summary>
        /// Triggered whenever materials are added/removed, also at startup. 
        /// </summary>
        public event EventHandler<MaterialsInfo> MaterialsEvent;

        /// <summary>
        /// Triggered whenever a friend comes online.
        /// </summary>
        public event EventHandler<FriendsInfo> FriendsEvent;

        /// <summary>
        /// Triggered whenever a player goes into outfitting.
        /// </summary>
        public event EventHandler<OutfittingInfo> OutfittingEvent;

        /// <summary>
        /// Triggered whenever a player logs in, contains mission info.
        /// </summary>
        public event EventHandler<MissionsInfo> MissionsEvent;

        /// <summary>
        /// Triggered whenever a player abandons a mission.
        /// </summary>
        public event EventHandler<MissionCompletedInfo> MissionCompletedEvent;

        /// <summary>
        /// Triggered whenever a player abandons a mission.
        /// </summary>
        public event EventHandler<MissionAbandonedInfo> MissionAbandonedEvent;

        /// <summary>
        /// Triggered whenever a player accepts a new mission.
        /// </summary>
        public event EventHandler<MissionAcceptedInfo> MissionAcceptedEvent;

        /// <summary>
        /// Triggered whenever a player leaves orbital flight / gets away from a planet.
        /// </summary>
        public event EventHandler<LeaveBodyInfo> LeaveBodyEvent;

        /// <summary>
        /// Triggered whenever a player lifts off from a planet.
        /// </summary>
        public event EventHandler<LiftoffInfo> LiftoffEvent;

        /// <summary>
        /// Triggered whenever a player lands on a planet.
        /// </summary>
        public event EventHandler<TouchdownInfo> TouchdownEvent;

        /// <summary>
        /// Triggered whenever a player goes into orbital flight / gets close to a body.
        /// </summary>
        public event EventHandler<ApproachBodyInfo> ApproachBodyEvent;

        /// <summary>
        /// Triggered whenever the save is reset/cleared.
        /// </summary>
        public event EventHandler<ClearSavedGameInfo> ClearSavedGameEvent;

        /// <summary>
        /// Triggered whenever a new commander is created.
        /// </summary>
        public event EventHandler<NewCommanderInfo> NewCommanderEvent;

        /// <summary>
        /// Triggered whenever a player gets into a ship, contains advanced ship details.
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
        public event EventHandler<ScannedInfo> ScannedEvent;

        /// <summary>
        /// Triggered whenever a player recieves a message.
        /// </summary>
        public event EventHandler<ReceiveTextInfo> ReceiveTextEvent;

        /// <summary>
        /// Triggered whenever a player gets successfully interdicted.
        /// </summary>
        public event EventHandler<InterdictedInfo> InterdictedEvent;

        /// <summary>
        /// Triggered whenever docking privileges expire.
        /// </summary>
        public event EventHandler<DockingTimeoutInfo> DockingTimeoutEvent;

        /// <summary>
        /// Triggered whenever a player approaches a settlement.
        /// </summary>
        public event EventHandler<ApproachSettlementInfo> ApproachSettlementEvent;

        private void EliteDangerousAPI_SupercruiseEntryEvent(object sender, SupercruiseEntryInfo e)
        {
            lastSystem.Address = e.SystemAddress;
            lastSystem.Name = e.StarSystem;
        }
        private void EliteDangerousAPI_SupercruiseExitEvent(object sender, SupercruiseExitInfo e)
        {
            lastBody.Name = e.Body;
            lastBody.ID = e.BodyID;
            lastBody.Type = e.BodyType;

            lastSystem.Name = e.StarSystem;
            lastSystem.Address = e.SystemAddress;
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

            lastBody.Name = e.Body;
            lastBody.Type = e.BodyType;
            lastBody.ID = e.BodyID;

        }
        private void EliteDangerousAPI_DockingRequestedEvent(object sender, DockingRequestedInfo e)
        {
            lastStation.Name = e.StationName;
            lastStation.Type = e.StationType;
            lastStation.MarketID = e.MarketID;
        }
    }
}
