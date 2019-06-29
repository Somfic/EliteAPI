using EliteAPI.Bindings;
using EliteAPI.EDDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace EliteAPI
{
    public class EliteDangerousAPI
    {
        public EDDBApi EDDB;

        public BindingsInfo Bindings;

        private DirectoryInfo _playerJournalDirectory;

        private bool SkipFirstLog;

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
        /// Contains the Status.json data, updated upon request.
        /// </summary>
        public Status Status { get { return JsonConvert.DeserializeObject<Status>(File.ReadAllText(_playerJournalDirectory.GetFiles().Where(x => x.Name == "Status.json").First().FullName)); } }

        /// <summary>
        /// Contains the ModulesInfo.json data, updated upon request.
        /// </summary>
        public ModulesInfo ModulesInfo { get { return JsonConvert.DeserializeObject<ModulesInfo>(File.ReadAllText(_playerJournalDirectory.GetFiles().Where(x => x.Name == "ModulesInfo.json").First().FullName)); } }

        /// <summary>
        /// Contains the Outfitting.json data, updated upon request.
        /// </summary>
        public Outfitting Outfitting { get { return JsonConvert.DeserializeObject<Outfitting>(File.ReadAllText(_playerJournalDirectory.GetFiles().Where(x => x.Name == "Outfitting.json").First().FullName)); } }

        /// <summary>
        /// Contains the Cargo.json data, updated upon request.
        /// </summary>
        public Cargo Cargo { get { return JsonConvert.DeserializeObject<Cargo>(File.ReadAllText(_playerJournalDirectory.GetFiles().Where(x => x.Name == "Cargo.json").First().FullName)); } }

        /// <summary>
        /// Contains the Shipyard.json data, updated upon request.
        /// </summary>
        public Shipyard Shipyard { get { return JsonConvert.DeserializeObject<Shipyard>(File.ReadAllText(_playerJournalDirectory.GetFiles().Where(x => x.Name == "Shipyard.json").First().FullName)); } }

        /// <summary>
        /// Whether the class is processing logs.
        /// </summary>
        public bool isRunning { get; internal set; } 

        /// <summary>
        /// A list of all the processed logs so far.
        /// </summary>
        private List<string> processedLogs;

        /// <summary>
        /// Creates a new API class.
        /// </summary>
        /// <param name="playerJournalDirectory">The folder where the Player Journal is located in.</param>
        /// <param name="skipLogInit">Whether to go back in time in the log to catch all the events.</param>
        public EliteDangerousAPI(DirectoryInfo playerJournalDirectory, bool skipLogInit = true)
        {
            _playerJournalDirectory = playerJournalDirectory;

            SkipFirstLog = skipLogInit;

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

            EDDB = new EDDBApi();
        }

        /// <summary>
        /// Starts the processing of the log file and other API services.
        /// </summary>
        public void Start()
        {
            isRunning = true;
            Task.Run(() => { InitProcessLog(); });
            UpdateBindings(new DirectoryInfo($@"C:\Users\{Environment.UserName}\AppData\Local\Frontier Developments\Elite Dangerous\Options\Bindings"));
            this.LocationEvent += EliteDangerousAPI_LocationEvent;
            this.DockedEvent += EliteDangerousAPI_DockedEvent;
            this.FSDJumpEvent += EliteDangerousAPI_FSDJumpEvent;
            this.SupercruiseEntryEvent += EliteDangerousAPI_SupercruiseEntryEvent;
            this.SupercruiseExitEvent += EliteDangerousAPI_SupercruiseExitEvent;
            this.DockingRequestedEvent += EliteDangerousAPI_DockingRequestedEvent;
            this.StartJumpEvent += EliteDangerousAPI_StartJumpEvent;
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
            this.StartJumpEvent -= EliteDangerousAPI_StartJumpEvent;
        }

        /// <summary>
        /// Initializes the processing of the log.
        /// </summary>
        private void InitProcessLog()
        {
            FileInfo logFile = _playerJournalDirectory
                    .GetFiles("*.log") //Get all files that end with .log.
                    .OrderByDescending(x => x.LastWriteTime) //Order them by last written.
                    .First(); //Get the first one of the ordered list.

            ProcessLog(logFile, !SkipFirstLog);

            while (isRunning)
            {
                logFile = _playerJournalDirectory
                                    .GetFiles("*.log") //Get all files that end with .log.
                                    .OrderByDescending(x => x.LastWriteTime) //Order them by last written.
                                    .First(); //Get the first one of the ordered list.

                ProcessLog(logFile, true);

                Thread.Sleep(333);
            }
        }

        public void UpdateBindings(DirectoryInfo bindingsDirectory)
        {
            try {
                string wantedFile = File.ReadAllText(bindingsDirectory.FullName + @"\StartPreset.start") + ".binds";
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(wantedFile);
                Bindings = JsonConvert.DeserializeObject<BindingsInfo>(JsonConvert.SerializeXmlNode(xml));
            }
            catch { }
        }

        /// <summary>
        /// Process the log file once.
        /// </summary>
        /// <param name="logFile">The log file to process.</param>
        public void ProcessLog(FileInfo logFile, bool actuallyProcess)
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


            AllEvent?.Invoke(this, JsonConvert.DeserializeObject<dynamic>(json));

            switch (eventName)
            {
                default:
                    OtherEvent?.Invoke(this, JsonConvert.DeserializeObject<dynamic>(json));
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

                case "DockFighter":
                    DockFighterEvent?.Invoke(this, JsonConvert.DeserializeObject<DockFighterInfo>(json));
                    break;

                case "FighterRebuilt":
                    FighterRebuiltEvent?.Invoke(this, JsonConvert.DeserializeObject<FighterRebuiltInfo>(json));
                    break;

                case "FighterDestroyed":
                    FighterDestroyedEvent?.Invoke(this, JsonConvert.DeserializeObject<FighterDestroyedInfo>(json));
                    break;

                case "VehicleSwitch":
                    VehicleSwitchEvent?.Invoke(this, JsonConvert.DeserializeObject<VehicleSwitchInfo>(json));
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

                case "BuyAmmo":
                    BuyAmmoEvent?.Invoke(this, JsonConvert.DeserializeObject<BuyAmmoInfo>(json));
                    break;

                case "CommitCrime":
                    CommitCrimeEvent?.Invoke(this, JsonConvert.DeserializeObject<CommitCrimeInfo>(json));
                    break;

                case "PayFine":
                    PayFineEvent?.Invoke(this, JsonConvert.DeserializeObject<PayFineInfo>(json));
                    break;

                case "HeatWarning":
                    HeatWarningEvent?.Invoke(this, JsonConvert.DeserializeObject<HeatWarningInfo>(json));
                    break;

                case "WingInvite":
                    WingInviteEvent?.Invoke(this, JsonConvert.DeserializeObject<WingInviteInfo>(json));
                    break;

                case "WingJoin":
                    WingJoinEvent?.Invoke(this, JsonConvert.DeserializeObject<WingJoinInfo>(json));
                    break;

                case "WingAdd":
                    WingAddEvent?.Invoke(this, JsonConvert.DeserializeObject<WingAddInfo>(json));
                    break;

                case "WingLeave":
                    WingLeaveEvent?.Invoke(this, JsonConvert.DeserializeObject<WingLeaveInfo>(json));
                    break;

                case "NavBeaconScan":
                    NavBeaconScanEvent?.Invoke(this, JsonConvert.DeserializeObject<NavBeaconScanInfo>(json));
                    break;

                case "CargoDepot":
                    CargoDepotEvent?.Invoke(this, JsonConvert.DeserializeObject<CargoDepotInfo>(json));
                    break;

                case "PayFines":
                    PayFinesEvent?.Invoke(this, JsonConvert.DeserializeObject<PayFinesInfo>(json));
                    break;

                case "SellExplorationData":
                    SellExplorationDataEvent?.Invoke(this, JsonConvert.DeserializeObject<SellExplorationDataInfo>(json));
                    break;

                case "FetchRemoteModule":
                    FetchRemoteModuleEvent?.Invoke(this, JsonConvert.DeserializeObject<FetchRemoteModuleInfo>(json));
                    break;

                case "ModuleSellRemote":
                    ModuleSellRemoteEvent?.Invoke(this, JsonConvert.DeserializeObject<ModuleSellRemoteInfo>(json));
                    break;

                case "EscapeInterdiction":
                    EscapeInterdictionEvent?.Invoke(this, JsonConvert.DeserializeObject<EscapeInterdictionInfo>(json));
                    break;

                case "EngineerProgress":
                    EngineerProgressEvent?.Invoke(this, JsonConvert.DeserializeObject<EngineerProgressInfo>(json));
                    break;

                case "FSSSignalDiscovered":
                    FSSSignalDiscoveredEvent?.Invoke(this, JsonConvert.DeserializeObject<FSSSignalDiscoveredInfo>(json));
                    break;

                case "ShipyardNew":
                    ShipyardNewEvent?.Invoke(this, JsonConvert.DeserializeObject<ShipyardNewInfo>(json));
                    break;

                case "BuyDrones":
                    BuyDronesEvent?.Invoke(this, JsonConvert.DeserializeObject<BuyDronesInfo>(json));
                    break;

                case "LaunchDrone":
                    LaunchDroneEvent?.Invoke(this, JsonConvert.DeserializeObject<LaunchDroneInfo>(json));
                    break;  

                case "AsteroidCracked":
                    AsteroidCrackedEvent?.Invoke(this, JsonConvert.DeserializeObject<AsteroidCrackedInfo>(json));
                    break;

                case "FSSDiscoveryScan":
                    FSSDiscoveryScanEvent?.Invoke(this, JsonConvert.DeserializeObject<FSSDiscoveryScanInfo>(json));
                    break;

                case "Powerplay":
                    PowerplayEvent?.Invoke(this, JsonConvert.DeserializeObject<PowerplayInfo>(json));
                    break;

                case "CommunityGoal":
                    CommunityGoalEvent?.Invoke(this, JsonConvert.DeserializeObject<CommunityGoalInfo>(json));
                    break;

                case "FSDTarget":
                    FSDTargetEvent?.Invoke(this, JsonConvert.DeserializeObject<FSDTargetInfo>(json));
                    break;

                case "CodexEntry":
                    CodexEntryEvent?.Invoke(this, JsonConvert.DeserializeObject<CodexEntryInfo>(json));
                    break;

                case "ModuleInfo":
                    ModuleInfoEvent?.Invoke(this, JsonConvert.DeserializeObject<ModuleInfoInfo>(json));
                    break;

                case "RedeemVoucher":
                    RedeemVoucherEvent?.Invoke(this, JsonConvert.DeserializeObject<RedeemVoucherInfo>(json));
                    break;

                case "PowerplaySalary":
                    PowerplaySalaryEvent?.Invoke(this, JsonConvert.DeserializeObject<PowerplaySalaryInfo>(json));
                    break;

                case "SetUserShipName":
                    SetUserShipNameEvent?.Invoke(this, JsonConvert.DeserializeObject<SetUserShipNameInfo>(json));
                    break;

                case "EngineerCraft":
                    EngineerCraftEvent?.Invoke(this, JsonConvert.DeserializeObject<EngineerCraftInfo>(json));
                    break;

                case "ModuleRetrieve":
                    ModuleRetrieveEvent?.Invoke(this, JsonConvert.DeserializeObject<ModuleRetrieveInfo>(json));
                    break;

                case "SellDrones":
                    SellDronesEvent?.Invoke(this, JsonConvert.DeserializeObject<SellDronesInfo>(json));
                    break;

                case "MultiSellExplorationData":
                    MultiSellExplorationDataEvent?.Invoke(this, JsonConvert.DeserializeObject<MultiSellExplorationDataInfo>(json));
                    break;

                case "ModuleSwap":
                    ModuleSwapEvent?.Invoke(this, JsonConvert.DeserializeObject<ModuleSwapInfo>(json));
                    break;

                case "SAAScanComplete":
                    SAAScanCompleteEvent?.Invoke(this, JsonConvert.DeserializeObject<SAAScanCompleteInfo>(json));
                    break;

                case "LaunchSRV":
                    LaunchSRVEvent?.Invoke(this, JsonConvert.DeserializeObject<LaunchSRVInfo>(json));
                    break;

                case "MaterialCollected":
                    MaterialCollectedEvent?.Invoke(this, JsonConvert.DeserializeObject<MaterialCollectedInfo>(json));
                    break;

                case "DockSRV":
                    DockSRVEvent?.Invoke(this, JsonConvert.DeserializeObject<DockSRVInfo>(json));
                    break;

                case "MiningRefined":
                    MiningRefinedEvent?.Invoke(this, JsonConvert.DeserializeObject<MiningRefinedInfo>(json));
                    break;

                case "FSSAllBodiesFound":
                    FSSAllBodiesFoundEvent?.Invoke(this, JsonConvert.DeserializeObject<FSSAllBodiesFoundInfo>(json));
                    break;

                case "MaterialDiscovered":
                    MaterialDiscoveredEvent?.Invoke(this, JsonConvert.DeserializeObject<MaterialDiscoveredInfo>(json));
                    break;

                case "USSDrop":
                    USSDropEvent?.Invoke(this, JsonConvert.DeserializeObject<USSDropInfo>(json));
                    break;

                case "MissionRedirected":
                    MissionRedirectedEvent?.Invoke(this, JsonConvert.DeserializeObject<MissionRedirectedInfo>(json));
                    break;

                case "SendText":
                    SendTextEvent?.Invoke(this, JsonConvert.DeserializeObject<SendTextInfo>(json));
                    break;

                case "SelfDestruct":
                    SelfDestructEvent?.Invoke(this, JsonConvert.DeserializeObject<SelfDestructInfo>(json));
                    break;

                case "HeatDamage":
                    HeatDamageEvent?.Invoke(this, JsonConvert.DeserializeObject<HeatDamageInfo>(json));
                    break;

                case "Died":
                    DiedEvent?.Invoke(this, JsonConvert.DeserializeObject<DiedInfo>(json));
                    break;

                case "Resurrect":
                    ResurrectEvent?.Invoke(this, JsonConvert.DeserializeObject<ResurrectInfo>(json));
                    break;

                case "HullDamage":
                    HullDamageEvent?.Invoke(this, JsonConvert.DeserializeObject<HullDamageInfo>(json));
                    break;

                case "CrewMemberJoins":
                    CrewMemberJoinsEvent?.Invoke(this, JsonConvert.DeserializeObject<CrewMemberJoinsInfo>(json));
                    break;

                case "CrewMemberRoleChange":
                    CrewMemberRoleChangeEvent?.Invoke(this, JsonConvert.DeserializeObject<CrewMemberRoleChangeInfo>(json));
                    break;

                case "CrewLaunchFighter":
                    CrewLaunchFighterEvent?.Invoke(this, JsonConvert.DeserializeObject<CrewLaunchFighterInfo>(json));
                    break;

                case "CrimeVictim":
                    CrimeVictimEvent?.Invoke(this, JsonConvert.DeserializeObject<CrimeVictimInfo>(json));
                    break;

                case "EndCrewSession":
                    EndCrewSessionEvent?.Invoke(this, JsonConvert.DeserializeObject<EndCrewSessionInfo>(json));
                    break;

                case "RestockVehicle":
                    RestockVehicleEvent?.Invoke(this, JsonConvert.DeserializeObject<RestockVehicleInfo>(json));
                    break;

                case "CollectCargo":
                    CollectCargoEvent?.Invoke(this, JsonConvert.DeserializeObject<CollectCargoInfo>(json));
                    break;

                case "DockingCancelled":
                    DockingCancelledEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingCancelledInfo>(json));
                    break;

                case "BuyTradeData":
                    BuyTradeDataEvent?.Invoke(this, JsonConvert.DeserializeObject<BuyTradeDataInfo>(json));
                    break;

                case "BuyExplorationData":
                    BuyExplorationDataEvent?.Invoke(this, JsonConvert.DeserializeObject<BuyExplorationDataInfo>(json));
                    break;

                case "CrewAssign":
                    CrewAssignEvent?.Invoke(this, JsonConvert.DeserializeObject<CrewAssignInfo>(json));
                    break;


                case "CrewHire":
                    CrewHireEvent?.Invoke(this, JsonConvert.DeserializeObject<CrewHireInfo>(json));
                    break;

                case "CrewFire":
                    CrewFireEvent?.Invoke(this, JsonConvert.DeserializeObject<CrewFireInfo>(json));
                    break;

                case "JoinACrew":
                    JoinACrewEvent?.Invoke(this, JsonConvert.DeserializeObject<JoinACrewInfo>(json));
                    break;

                case "ChangeCrewRole":
                    ChangeCrewRoleEvent?.Invoke(this, JsonConvert.DeserializeObject<ChangeCrewRoleInfo>(json));
                    break;

                case "QuitACrew":
                    QuitACrewEvent?.Invoke(this, JsonConvert.DeserializeObject<QuitACrewInfo>(json));
                    break;

                case "Interdiction":
                    InterdictionEvent?.Invoke(this, JsonConvert.DeserializeObject<InterdictionInfo>(json));
                    break;
            }
        }

        public event EventHandler<InterdictionInfo> InterdictionEvent;

        public event EventHandler<BuyTradeDataInfo> BuyTradeDataEvent;

        public event EventHandler<BuyExplorationDataInfo> BuyExplorationDataEvent;

        public event EventHandler<CrewAssignInfo> CrewAssignEvent;

        public event EventHandler<CrewHireInfo> CrewHireEvent;

        public event EventHandler<CrewFireInfo> CrewFireEvent;

        public event EventHandler<JoinACrewInfo> JoinACrewEvent;

        public event EventHandler<ChangeCrewRoleInfo> ChangeCrewRoleEvent;

        public event EventHandler<QuitACrewInfo> QuitACrewEvent;

        public event EventHandler<DockingCancelledInfo> DockingCancelledEvent;

        public event EventHandler<PowerplayInfo> PowerplayEvent;

        public event EventHandler<CommunityGoalInfo> CommunityGoalEvent;

        public event EventHandler<FSDTargetInfo> FSDTargetEvent;

        public event EventHandler<CodexEntryInfo> CodexEntryEvent;

        public event EventHandler<ModuleInfoInfo> ModuleInfoEvent;

        /// <summary>
        /// Triggered whenever a player redeems a voucher.
        /// </summary>
        public event EventHandler<RedeemVoucherInfo> RedeemVoucherEvent;

        /// <summary>
        /// Triggered when a player gets their powerplay salary.
        /// </summary>
        public event EventHandler<PowerplaySalaryInfo> PowerplaySalaryEvent;

        /// <summary>
        /// Triggered whenever a player changes their ship's name.
        /// </summary>
        public event EventHandler<SetUserShipNameInfo> SetUserShipNameEvent;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EngineerCraftInfo> EngineerCraftEvent;

        /// <summary>
        /// Triggered when a player retrieves a module from a station.
        /// </summary>
        public event EventHandler<ModuleRetrieveInfo> ModuleRetrieveEvent;

        /// <summary>
        /// Triggered when a player sells back limpets.
        /// </summary>
        public event EventHandler<SellDronesInfo> SellDronesEvent;

        /// <summary>
        /// Triggered when mass selling exploration data.
        /// </summary>
        public event EventHandler<MultiSellExplorationDataInfo> MultiSellExplorationDataEvent;

        public EventHandler<DockFighterInfo> DockFighterEvent;

        public EventHandler<FighterRebuiltInfo> FighterRebuiltEvent;

        public EventHandler<FighterDestroyedInfo> FighterDestroyedEvent;

        public EventHandler<VehicleSwitchInfo> VehicleSwitchEvent;

        /// <summary>
        /// Triggered when a player swaps modules.
        /// </summary>
        public event EventHandler<ModuleSwapInfo> ModuleSwapEvent;

        public event EventHandler<SAAScanCompleteInfo> SAAScanCompleteEvent;

        public event EventHandler<LaunchSRVInfo> LaunchSRVEvent;

        public event EventHandler<MaterialCollectedInfo> MaterialCollectedEvent;

        public event EventHandler<DockSRVInfo> DockSRVEvent;

        public event EventHandler<MiningRefinedInfo> MiningRefinedEvent;

        public event EventHandler<FSSAllBodiesFoundInfo> FSSAllBodiesFoundEvent;

        public event EventHandler<MaterialDiscoveredInfo> MaterialDiscoveredEvent;

        public event EventHandler<USSDropInfo> USSDropEvent;

        public event EventHandler<MissionRedirectedInfo> MissionRedirectedEvent;

        public event EventHandler<SendTextInfo> SendTextEvent;

        public event EventHandler<SelfDestructInfo> SelfDestructEvent;

        public event EventHandler<HeatDamageInfo> HeatDamageEvent;

        public event EventHandler<DiedInfo> DiedEvent;

        public event EventHandler<ResurrectInfo> ResurrectEvent;

        public event EventHandler<HullDamageInfo> HullDamageEvent;

        public event EventHandler<CrewMemberJoinsInfo> CrewMemberJoinsEvent;

        public event EventHandler<CrewMemberRoleChangeInfo> CrewMemberRoleChangeEvent;

        public event EventHandler<CrewLaunchFighterInfo> CrewLaunchFighterEvent;

        public event EventHandler<CrimeVictimInfo> CrimeVictimEvent;

        public event EventHandler<EndCrewSessionInfo> EndCrewSessionEvent;

        public event EventHandler<RestockVehicleInfo> RestockVehicleEvent;

        public event EventHandler<CollectCargoInfo> CollectCargoEvent;

        /// <summary>
        /// Triggered whenever a discovery scan has been completed.
        /// </summary>
        public event EventHandler<FSSDiscoveryScanInfo> FSSDiscoveryScanEvent;

        /// <summary>
        /// Triggered whenever a player cracks open an asteroid while mining.
        /// </summary>
        public event EventHandler<AsteroidCrackedInfo> AsteroidCrackedEvent;

        /// <summary>
        /// Triggered when a player fires a limpet for any usage.
        /// </summary>
        public event EventHandler<LaunchDroneInfo> LaunchDroneEvent;

        /// <summary>
        /// Triggerd when a player buys limpets.
        /// </summary>
        public event EventHandler<BuyDronesInfo> BuyDronesEvent;

        /// <summary>
        /// Triggered whenever a new ship becomes available in the shipyard.
        /// </summary>
        public event EventHandler<ShipyardNewInfo> ShipyardNewEvent;

        /// <summary>
        /// Triggered whenever a player discovers a new signal in FSS.
        /// </summary>
        public event EventHandler<FSSSignalDiscoveredInfo> FSSSignalDiscoveredEvent;

        /// <summary>
        /// Triggered whenever a play updates their process with engineers.
        /// </summary>
        public event EventHandler<EngineerProgressInfo> EngineerProgressEvent;

        /// <summary>
        /// Triggered whenever a player sells a module remotely.
        /// </summary>
        public event EventHandler<EscapeInterdictionInfo> EscapeInterdictionEvent;

        /// <summary>
        /// Triggered whenever a player sells a module remotely.
        /// </summary>
        public event EventHandler<ModuleSellRemoteInfo> ModuleSellRemoteEvent;

        /// <summary>
        /// Triggered whenever a player requests a remote module.
        /// </summary>
        public event EventHandler<FetchRemoteModuleInfo> FetchRemoteModuleEvent;

        /// <summary>
        /// Triggered whenever a player mass-pays their fines.
        /// </summary>
        public event EventHandler<SellExplorationDataInfo> SellExplorationDataEvent;

        /// <summary>
        /// Triggered whenever a player mass-pays their fines.
        /// </summary>
        public event EventHandler<PayFinesInfo> PayFinesEvent;

        /// <summary>
        /// Triggered whenever a cargo delivery mission gets updated.
        /// </summary>
        public event EventHandler<CargoDepotInfo> CargoDepotEvent;

        /// <summary>
        /// Triggered whenever a player leaves the wing.
        /// </summary>
        public event EventHandler<NavBeaconScanInfo> NavBeaconScanEvent;

        /// <summary>
        /// Triggered whenever a player leaves the wing.
        /// </summary>
        public event EventHandler<WingLeaveInfo> WingLeaveEvent;

        /// <summary>
        /// Triggered whenever another commander gets added to the wing.
        /// </summary>
        public event EventHandler<WingAddInfo> WingAddEvent;

        /// <summary>
        /// Triggered whenever a player joins a wing.
        /// </summary>
        public event EventHandler<WingJoinInfo> WingJoinEvent;

        /// <summary>
        /// Triggered whenever a player gets invited for a wing.
        /// </summary>
        public event EventHandler<WingInviteInfo> WingInviteEvent;

        /// <summary>
        /// Triggered whenever the ships becomes too hot.
        /// </summary>
        public event EventHandler<HeatWarningInfo> HeatWarningEvent;

        /// <summary>
        /// Triggered whenever a player pays their fines.
        /// </summary>
        public event EventHandler<PayFineInfo> PayFineEvent;

        /// <summary>
        /// Triggered whenever a player commits a crime.
        /// </summary>
        public event EventHandler<CommitCrimeInfo> CommitCrimeEvent;

        /// <summary>
        /// Triggered when a player buys ammunition from a station.
        /// </summary>
        public event EventHandler<BuyAmmoInfo> BuyAmmoEvent;

        /// <summary>
        /// Triggered for every event that hasn't been included yet.
        /// </summary>
        public event EventHandler<dynamic> OtherEvent;

        /// <summary>
        /// Triggered on all events.
        /// </summary>
        public event EventHandler<dynamic> AllEvent;

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
        private void EliteDangerousAPI_StartJumpEvent(object sender, StartJumpInfo e)
        {
            lastSystem.Address = e.SystemAddress;
            lastSystem.Class = e.StarClass;
            lastSystem.Name = e.StarSystem;
        }

    }
}
