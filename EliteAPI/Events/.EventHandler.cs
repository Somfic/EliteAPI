namespace EliteAPI.Events
{
    using System;

    public class EventHandler
    {
        public event EventHandler<bool> StatusDockedEvent;
        public bool InvokeStatusDocked(bool e) { StatusDockedEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusLandedEvent;
        public bool InvokeStatusLanded(bool e) { StatusLandedEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusFsdCooldownEvent;
        public bool InvokeStatusFsdCooldown(bool e) { StatusFsdCooldownEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusGearEvent;
        public bool InvokeStatusGear(bool e) { StatusGearEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusShieldsEvent;
        public bool InvokeStatusShields(bool e) { StatusShieldsEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusSupercruiseEvent;
        public bool InvokeStatusSupercruise(bool e) { StatusSupercruiseEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusFlightAssistEvent;
        public bool InvokeStatusFlightAssist(bool e) { StatusFlightAssistEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusHardpointsEvent;
        public bool InvokeStatusHardpoints(bool e) { StatusHardpointsEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusWingingEvent;
        public bool InvokeStatusWinging(bool e) { StatusWingingEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusLightsEvent;
        public bool InvokeStatusLights(bool e) { StatusLightsEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusCargoScoopEvent;
        public bool InvokeStatusCargoScoop(bool e) { StatusCargoScoopEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusSilentRunningEvent;
        public bool InvokeStatusSilentRunning(bool e) { StatusSilentRunningEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusScoopingEvent;
        public bool InvokeStatusScooping(bool e) { StatusScoopingEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusSrvHandbreakEvent;
        public bool InvokeStatusSrvHandbreak(bool e) { StatusSrvHandbreakEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusSrvTurrentEvent;
        public bool InvokeStatusSrvTurrent(bool e) { StatusSrvTurrentEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusSrvNearShipEvent;
        public bool InvokeStatusSrvNearShip(bool e) { StatusSrvNearShipEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusSrvDriveAssistEvent;
        public bool InvokeStatusSrvDriveAssist(bool e) { StatusSrvDriveAssistEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusMassLockedEvent;
        public bool InvokeStatusMassLocked(bool e) { StatusMassLockedEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusFsdChargingEvent;
        public bool InvokeStatusFsdCharging(bool e) { StatusFsdChargingEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusFsdCooldowEvent;
        public bool InvokeStatusFsdCooldow(bool e) { StatusFsdCooldowEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusLowFuelEvent;
        public bool InvokeStatusLowFuel(bool e) { StatusLowFuelEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusOverheatingEvent;
        public bool InvokeStatusOverheating(bool e) { StatusOverheatingEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusHasLatLongEvent;
        public bool InvokeStatusHasLatLong(bool e) { StatusHasLatLongEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusInDangerEvent;
        public bool InvokeStatusInDanger(bool e) { StatusInDangerEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusInInterdictionEvent;
        public bool InvokeStatusInInterdiction(bool e) { StatusInInterdictionEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusInMothershipEvent;
        public bool InvokeStatusInMothership(bool e) { StatusInMothershipEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusInFighterEvent;
        public bool InvokeStatusInFighter(bool e) { StatusInFighterEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusInSRVEvent;
        public bool InvokeStatusInSRV(bool e) { StatusInSRVEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusAnalysisModeEvent;
        public bool InvokeStatusAnalysisMode(bool e) { StatusAnalysisModeEvent?.Invoke(this, e); return e; }

        public event EventHandler<bool> StatusNightVisionEvent;
        public bool InvokeStatusNightVision(bool e) { StatusNightVisionEvent?.Invoke(this, e); return e; }

        //AllEvents
        public event EventHandler<dynamic> AllEvent;
        public dynamic InvokeAllEvent(dynamic arg) { AllEvent?.Invoke(null, arg); return arg; }

        //LeftSquadron
        public event EventHandler<LeftSquadronInfo> LeftSquadronEvent;
        public LeftSquadronInfo InvokeLeftSquadronEvent(LeftSquadronInfo arg) { LeftSquadronEvent?.Invoke(null, arg); return arg; }

        //HeatWarning
        public event EventHandler<HeatWarningInfo> HeatWarningEvent;
        public HeatWarningInfo InvokeHeatWarningEvent(HeatWarningInfo arg) { HeatWarningEvent?.Invoke(null, arg); return arg; }

        //ShieldState
        public event EventHandler<ShieldStateInfo> ShieldStateEvent;
        public ShieldStateInfo InvokeShieldStateEvent(ShieldStateInfo arg) { ShieldStateEvent?.Invoke(null, arg); return arg; }

        //VehicleSwitch
        public event EventHandler<VehicleSwitchInfo> VehicleSwitchEvent;        
        public VehicleSwitchInfo InvokeVehicleSwitchEvent(VehicleSwitchInfo arg) { VehicleSwitchEvent?.Invoke(null, arg); return arg; }

        //DockFighter
        public event EventHandler<DockFighterInfo> DockFighterEvent;
        public DockFighterInfo InvokeDockFighterEvent(DockFighterInfo arg) { DockFighterEvent?.Invoke(null, arg); return arg; }

        //LaunchSRV
        public event EventHandler<LaunchSRVInfo> LaunchSRVEvent;
        public LaunchSRVInfo InvokeLaunchSRVEvent(LaunchSRVInfo arg) { LaunchSRVEvent?.Invoke(null, arg); return arg; }

        //SelfDestruct
        public event EventHandler<SelfDestructInfo> SelfDestructEvent;
        public SelfDestructInfo InvokeSelfDestructEvent(SelfDestructInfo arg) { SelfDestructEvent?.Invoke(null, arg); return arg; }

        //DockSRV
        public event EventHandler<DockSRVInfo> DockSRVEvent;
        public DockSRVInfo InvokeDockSRVEvent(DockSRVInfo arg) { DockSRVEvent?.Invoke(null, arg); return arg; }

        //HeatDamage
        public event EventHandler<HeatDamageInfo> HeatDamageEvent;
        public HeatDamageInfo InvokeHeatDamageEvent(HeatDamageInfo arg) { HeatDamageEvent?.Invoke(null, arg); return arg; }

        //LaunchFighter
        public event EventHandler<LaunchFighterInfo> LaunchFighterEvent;
        public LaunchFighterInfo InvokeLaunchFighterEvent(LaunchFighterInfo arg) { LaunchFighterEvent?.Invoke(null, arg); return arg; }

        //DatalinkScan
        public event EventHandler<DatalinkScanInfo> DatalinkScanEvent;
        public DatalinkScanInfo InvokeDatalinkScanEvent(DatalinkScanInfo arg) { DatalinkScanEvent?.Invoke(null, arg); return arg; }

        //CockpitBreached
        public event EventHandler<CockpitBreachedInfo> CockpitBreachedEvent;
        public CockpitBreachedInfo InvokeCockpitBreachedEvent(CockpitBreachedInfo arg) { CockpitBreachedEvent?.Invoke(null, arg); return arg; }

        //JetConeBoost
        public event EventHandler<JetConeBoostInfo> JetConeBoostEvent;
        public JetConeBoostInfo InvokeJetConeBoostEvent(JetConeBoostInfo arg) { JetConeBoostEvent?.Invoke(null, arg); return arg; }

        //PowerplayLeave
        public event EventHandler<PowerplayLeaveInfo> PowerplayLeaveEvent;
        public PowerplayLeaveInfo InvokePowerplayLeaveEvent(PowerplayLeaveInfo arg) { PowerplayLeaveEvent?.Invoke(null, arg); return arg; }

        //Interdiction
        public event EventHandler<InterdictionInfo> InterdictionEvent;
        public InterdictionInfo InvokeInterdictionEvent(InterdictionInfo arg) { InterdictionEvent?.Invoke(null, arg); return arg; }

        //USSDrop
        public event EventHandler<USSDropInfo> USSDropEvent;
        public USSDropInfo InvokeUSSDropEvent(USSDropInfo arg) { USSDropEvent?.Invoke(null, arg); return arg; }

        //PowerplayCollect
        public event EventHandler<PowerplayCollectInfo> PowerplayCollectEvent;
        public PowerplayCollectInfo InvokePowerplayCollectEvent(PowerplayCollectInfo arg) { PowerplayCollectEvent?.Invoke(null, arg); return arg; }

        //PowerplayDeliver
        public event EventHandler<PowerplayDeliverInfo> PowerplayDeliverEvent;
        public PowerplayDeliverInfo InvokePowerplayDeliverEvent(PowerplayDeliverInfo arg) { PowerplayDeliverEvent?.Invoke(null, arg); return arg; }

        //PayLegacyFines
        public event EventHandler<PayLegacyFinesInfo> PayLegacyFinesEvent;
        public PayLegacyFinesInfo InvokePayLegacyFinesEvent(PayLegacyFinesInfo arg) { PayLegacyFinesEvent?.Invoke(null, arg); return arg; }

        //EngineerApply
        public event EventHandler<EngineerApplyInfo> EngineerApplyEvent;
        public EngineerApplyInfo InvokeEngineerApplyEvent(EngineerApplyInfo arg) { EngineerApplyEvent?.Invoke(null, arg); return arg; }

        //WingLeave
        public event EventHandler<WingLeaveInfo> WingLeaveEvent;
        public WingLeaveInfo InvokeWingLeaveEvent(WingLeaveInfo arg) { WingLeaveEvent?.Invoke(null, arg); return arg; }

        //SystemsShutdown
        public event EventHandler<SystemsShutdownInfo> SystemsShutdownEvent;
        public SystemsShutdownInfo InvokeSystemsShutdownEvent(SystemsShutdownInfo arg) { SystemsShutdownEvent?.Invoke(null, arg); return arg; }

        //HullDamage
        public event EventHandler<HullDamageInfo> HullDamageEvent;
        public HullDamageInfo InvokeHullDamageEvent(HullDamageInfo arg) { HullDamageEvent?.Invoke(null, arg); return arg; }

        //BuyDrones
        public event EventHandler<BuyDronesInfo> BuyDronesEvent;
        public BuyDronesInfo InvokeBuyDronesEvent(BuyDronesInfo arg) { BuyDronesEvent?.Invoke(null, arg); return arg; }

        //RestockVehicle
        public event EventHandler<RestockVehicleInfo> RestockVehicleEvent;
        public RestockVehicleInfo InvokeRestockVehicleEvent(RestockVehicleInfo arg) { RestockVehicleEvent?.Invoke(null, arg); return arg; }

        //BuyAmmo
        public event EventHandler<BuyAmmoInfo> BuyAmmoEvent;
        public BuyAmmoInfo InvokeBuyAmmoEvent(BuyAmmoInfo arg) { BuyAmmoEvent?.Invoke(null, arg); return arg; }

        //MiningRefined
        public event EventHandler<MiningRefinedInfo> MiningRefinedEvent;
        public MiningRefinedInfo InvokeMiningRefinedEvent(MiningRefinedInfo arg) { MiningRefinedEvent?.Invoke(null, arg); return arg; }

        //DatalinkVoucher
        public event EventHandler<DatalinkVoucherInfo> DatalinkVoucherEvent;
        public DatalinkVoucherInfo InvokeDatalinkVoucherEvent(DatalinkVoucherInfo arg) { DatalinkVoucherEvent?.Invoke(null, arg); return arg; }

        //Scanned
        public event EventHandler<ScannedInfo> ScannedEvent;
        public ScannedInfo InvokeScannedEvent(ScannedInfo arg) { ScannedEvent?.Invoke(null, arg); return arg; }

        //ChangeCrewRole
        public event EventHandler<ChangeCrewRoleInfo> ChangeCrewRoleEvent;
        public ChangeCrewRoleInfo InvokeChangeCrewRoleEvent(ChangeCrewRoleInfo arg) { ChangeCrewRoleEvent?.Invoke(null, arg); return arg; }

        //Touchdown
        public event EventHandler<TouchdownInfo> TouchdownEvent;
        public TouchdownInfo InvokeTouchdownEvent(TouchdownInfo arg) { TouchdownEvent?.Invoke(null, arg); return arg; }

        //SendText
        public event EventHandler<SendTextInfo> SendTextEvent;
        public SendTextInfo InvokeSendTextEvent(SendTextInfo arg) { SendTextEvent?.Invoke(null, arg); return arg; }

        //RefuelAll
        public event EventHandler<RefuelAllInfo> RefuelAllEvent;
        public RefuelAllInfo InvokeRefuelAllEvent(RefuelAllInfo arg) { RefuelAllEvent?.Invoke(null, arg); return arg; }

        //EndCrewSession
        public event EventHandler<EndCrewSessionInfo> EndCrewSessionEvent;
        public EndCrewSessionInfo InvokeEndCrewSessionEvent(EndCrewSessionInfo arg) { EndCrewSessionEvent?.Invoke(null, arg); return arg; }

        //Liftoff
        public event EventHandler<LiftoffInfo> LiftoffEvent;
        public LiftoffInfo InvokeLiftoffEvent(LiftoffInfo arg) { LiftoffEvent?.Invoke(null, arg); return arg; }

        //EscapeInterdiction
        public event EventHandler<EscapeInterdictionInfo> EscapeInterdictionEvent;
        public EscapeInterdictionInfo InvokeEscapeInterdictionEvent(EscapeInterdictionInfo arg) { EscapeInterdictionEvent?.Invoke(null, arg); return arg; }

        //WingAdd
        public event EventHandler<WingAddInfo> WingAddEvent;
        public WingAddInfo InvokeWingAddEvent(WingAddInfo arg) { WingAddEvent?.Invoke(null, arg); return arg; }

        //SellDrones
        public event EventHandler<SellDronesInfo> SellDronesEvent;
        public SellDronesInfo InvokeSellDronesEvent(SellDronesInfo arg) { SellDronesEvent?.Invoke(null, arg); return arg; }

        //Fileheader
        public event EventHandler<FileheaderInfo> FileheaderEvent;
        public FileheaderInfo InvokeFileheaderEvent(FileheaderInfo arg) { FileheaderEvent?.Invoke(null, arg); return arg; }

        //Interdicted
        public event EventHandler<InterdictedInfo> InterdictedEvent;
        public InterdictedInfo InvokeInterdictedEvent(InterdictedInfo arg) { InterdictedEvent?.Invoke(null, arg); return arg; }

        //CrewMemberJoins
        public event EventHandler<CrewMemberJoinsInfo> CrewMemberJoinsEvent;
        public CrewMemberJoinsInfo InvokeCrewMemberJoinsEvent(CrewMemberJoinsInfo arg) { CrewMemberJoinsEvent?.Invoke(null, arg); return arg; }

        //CrewMemberQuits
        public event EventHandler<CrewMemberQuitsInfo> CrewMemberQuitsEvent;
        public CrewMemberQuitsInfo InvokeCrewMemberQuitsEvent(CrewMemberQuitsInfo arg) { CrewMemberQuitsEvent?.Invoke(null, arg); return arg; }

        //CrewMemberRoleChange
        public event EventHandler<CrewMemberRoleChangeInfo> CrewMemberRoleChangeEvent;
        public CrewMemberRoleChangeInfo InvokeCrewMemberRoleChangeEvent(CrewMemberRoleChangeInfo arg) { CrewMemberRoleChangeEvent?.Invoke(null, arg); return arg; }

        //PVPKill
        public event EventHandler<PVPKillInfo> PVPKillEvent;
        public PVPKillInfo InvokePVPKillEvent(PVPKillInfo arg) { PVPKillEvent?.Invoke(null, arg); return arg; }

        //JoinACrew
        public event EventHandler<JoinACrewInfo> JoinACrewEvent;
        public JoinACrewInfo InvokeJoinACrewEvent(JoinACrewInfo arg) { JoinACrewEvent?.Invoke(null, arg); return arg; }

        //QuitACrew
        public event EventHandler<QuitACrewInfo> QuitACrewEvent;
        public QuitACrewInfo InvokeQuitACrewEvent(QuitACrewInfo arg) { QuitACrewEvent?.Invoke(null, arg); return arg; }

        //Progress
        public event EventHandler<ProgressInfo> ProgressEvent;
        public ProgressInfo InvokeProgressEvent(ProgressInfo arg) { ProgressEvent?.Invoke(null, arg); return arg; }

        //Promotion
        public event EventHandler<PromotionInfo> PromotionEvent;
        public PromotionInfo InvokePromotionEvent(PromotionInfo arg) { PromotionEvent?.Invoke(null, arg); return arg; }

        //Rank
        public event EventHandler<RankInfo> RankEvent;
        public RankInfo InvokeRankEvent(RankInfo arg) { RankEvent?.Invoke(null, arg); return arg; }

        //CommitCrime
        public event EventHandler<CommitCrimeInfo> CommitCrimeEvent;
        public CommitCrimeInfo InvokeCommitCrimeEvent(CommitCrimeInfo arg) { CommitCrimeEvent?.Invoke(null, arg); return arg; }

        //EngineerContribution
        public event EventHandler<EngineerContributionInfo> EngineerContributionEvent;
        public EngineerContributionInfo InvokeEngineerContributionEvent(EngineerContributionInfo arg) { EngineerContributionEvent?.Invoke(null, arg); return arg; }

        //Music
        public event EventHandler<MusicInfo> MusicEvent;
        public MusicInfo InvokeMusicEvent(MusicInfo arg) { MusicEvent?.Invoke(null, arg); return arg; }

        //Died
        public event EventHandler<DiedInfo> DiedEvent;
        public DiedInfo InvokeDiedEvent(DiedInfo arg) { DiedEvent?.Invoke(null, arg); return arg; }

        //Passengers
        public event EventHandler<PassengersInfo> PassengersEvent;
        public PassengersInfo InvokePassengersEvent(PassengersInfo arg) { PassengersEvent?.Invoke(null, arg); return arg; }

        //SearchAndRescue
        public event EventHandler<SearchAndRescueInfo> SearchAndRescueEvent;
        public SearchAndRescueInfo InvokeSearchAndRescueEvent(SearchAndRescueInfo arg) { SearchAndRescueEvent?.Invoke(null, arg); return arg; }

        //KickCrewMember
        public event EventHandler<KickCrewMemberInfo> KickCrewMemberEvent;
        public KickCrewMemberInfo InvokeKickCrewMemberEvent(KickCrewMemberInfo arg) { KickCrewMemberEvent?.Invoke(null, arg); return arg; }

        //RedeemVoucher
        public event EventHandler<RedeemVoucherInfo> RedeemVoucherEvent;
        public RedeemVoucherInfo InvokeRedeemVoucherEvent(RedeemVoucherInfo arg) { RedeemVoucherEvent?.Invoke(null, arg); return arg; }

        //Resurrect
        public event EventHandler<ResurrectInfo> ResurrectEvent;
        public ResurrectInfo InvokeResurrectEvent(ResurrectInfo arg) { ResurrectEvent?.Invoke(null, arg); return arg; }

        //CommunityGoalJoin
        public event EventHandler<CommunityGoalJoinInfo> CommunityGoalJoinEvent;
        public CommunityGoalJoinInfo InvokeCommunityGoalJoinEvent(CommunityGoalJoinInfo arg) { CommunityGoalJoinEvent?.Invoke(null, arg); return arg; }

        //CommunityGoal
        public event EventHandler<CommunityGoalInfo> CommunityGoalEvent;
        public CommunityGoalInfo InvokeCommunityGoalEvent(CommunityGoalInfo arg) { CommunityGoalEvent?.Invoke(null, arg); return arg; }

        //RepairDrone
        public event EventHandler<RepairDroneInfo> RepairDroneEvent;
        public RepairDroneInfo InvokeRepairDroneEvent(RepairDroneInfo arg) { RepairDroneEvent?.Invoke(null, arg); return arg; }

        //Repair
        public event EventHandler<RepairInfo> RepairEvent;
        public RepairInfo InvokeRepairEvent(RepairInfo arg) { RepairEvent?.Invoke(null, arg); return arg; }

        //JetConeDamage
        public event EventHandler<JetConeDamageInfo> JetConeDamageEvent;
        public JetConeDamageInfo InvokeJetConeDamageEvent(JetConeDamageInfo arg) { JetConeDamageEvent?.Invoke(null, arg); return arg; }

        //CommunityGoalDiscard
        public event EventHandler<CommunityGoalDiscardInfo> CommunityGoalDiscardEvent;
        public CommunityGoalDiscardInfo InvokeCommunityGoalDiscardEvent(CommunityGoalDiscardInfo arg) { CommunityGoalDiscardEvent?.Invoke(null, arg); return arg; }

        //MissionAccepted
        public event EventHandler<MissionAcceptedInfo> MissionAcceptedEvent;
        public MissionAcceptedInfo InvokeMissionAcceptedEvent(MissionAcceptedInfo arg) { MissionAcceptedEvent?.Invoke(null, arg); return arg; }

        //BuyExplorationData
        public event EventHandler<BuyExplorationDataInfo> BuyExplorationDataEvent;
        public BuyExplorationDataInfo InvokeBuyExplorationDataEvent(BuyExplorationDataInfo arg) { BuyExplorationDataEvent?.Invoke(null, arg); return arg; }

        //RepairAll
        public event EventHandler<RepairAllInfo> RepairAllEvent;
        public RepairAllInfo InvokeRepairAllEvent(RepairAllInfo arg) { RepairAllEvent?.Invoke(null, arg); return arg; }

        //CrewLaunchFighter
        public event EventHandler<CrewLaunchFighterInfo> CrewLaunchFighterEvent;
        public CrewLaunchFighterInfo InvokeCrewLaunchFighterEvent(CrewLaunchFighterInfo arg) { CrewLaunchFighterEvent?.Invoke(null, arg); return arg; }

        //MaterialDiscarded
        public event EventHandler<MaterialDiscardedInfo> MaterialDiscardedEvent;
        public MaterialDiscardedInfo InvokeMaterialDiscardedEvent(MaterialDiscardedInfo arg) { MaterialDiscardedEvent?.Invoke(null, arg); return arg; }

        //NewCommander
        public event EventHandler<NewCommanderInfo> NewCommanderEvent;
        public NewCommanderInfo InvokeNewCommanderEvent(NewCommanderInfo arg) { NewCommanderEvent?.Invoke(null, arg); return arg; }

        //CommunityGoalReward
        public event EventHandler<CommunityGoalRewardInfo> CommunityGoalRewardEvent;
        public CommunityGoalRewardInfo InvokeCommunityGoalRewardEvent(CommunityGoalRewardInfo arg) { CommunityGoalRewardEvent?.Invoke(null, arg); return arg; }

        //PowerplayVote
        public event EventHandler<PowerplayVoteInfo> PowerplayVoteEvent;
        public PowerplayVoteInfo InvokePowerplayVoteEvent(PowerplayVoteInfo arg) { PowerplayVoteEvent?.Invoke(null, arg); return arg; }

        //PowerplayJoin
        public event EventHandler<PowerplayJoinInfo> PowerplayJoinEvent;
        public PowerplayJoinInfo InvokePowerplayJoinEvent(PowerplayJoinInfo arg) { PowerplayJoinEvent?.Invoke(null, arg); return arg; }

        //PowerplayDefect
        public event EventHandler<PowerplayDefectInfo> PowerplayDefectEvent;
        public PowerplayDefectInfo InvokePowerplayDefectEvent(PowerplayDefectInfo arg) { PowerplayDefectEvent?.Invoke(null, arg); return arg; }

        //MissionFailed
        public event EventHandler<MissionFailedInfo> MissionFailedEvent;
        public MissionFailedInfo InvokeMissionFailedEvent(MissionFailedInfo arg) { MissionFailedEvent?.Invoke(null, arg); return arg; }

        //MissionRedirected
        public event EventHandler<MissionRedirectedInfo> MissionRedirectedEvent;
        public MissionRedirectedInfo InvokeMissionRedirectedEvent(MissionRedirectedInfo arg) { MissionRedirectedEvent?.Invoke(null, arg); return arg; }

        //Shutdown
        public event EventHandler<ShutdownInfo> ShutdownEvent;
        public ShutdownInfo InvokeShutdownEvent(ShutdownInfo arg) { ShutdownEvent?.Invoke(null, arg); return arg; }

        //ModuleInfo
        public event EventHandler<ModuleInfoInfo> ModuleInfoEvent;
        public ModuleInfoInfo InvokeModuleInfoEvent(ModuleInfoInfo arg) { ModuleInfoEvent?.Invoke(null, arg); return arg; }

        //Market
        public event EventHandler<MarketInfo> MarketEvent;
        public MarketInfo InvokeMarketEvent(MarketInfo arg) { MarketEvent?.Invoke(null, arg); return arg; }

        //MassModuleStore
        public event EventHandler<MassModuleStoreInfo> MassModuleStoreEvent;
        public MassModuleStoreInfo InvokeMassModuleStoreEvent(MassModuleStoreInfo arg) { MassModuleStoreEvent?.Invoke(null, arg); return arg; }

        //MaterialDiscovered
        public event EventHandler<MaterialDiscoveredInfo> MaterialDiscoveredEvent;
        public MaterialDiscoveredInfo InvokeMaterialDiscoveredEvent(MaterialDiscoveredInfo arg) { MaterialDiscoveredEvent?.Invoke(null, arg); return arg; }

        //MaterialCollected
        public event EventHandler<MaterialCollectedInfo> MaterialCollectedEvent;
        public MaterialCollectedInfo InvokeMaterialCollectedEvent(MaterialCollectedInfo arg) { MaterialCollectedEvent?.Invoke(null, arg); return arg; }

        //SRVDestroyed
        public event EventHandler<SRVDestroyedInfo> SRVDestroyedEvent;
        public SRVDestroyedInfo InvokeSRVDestroyedEvent(SRVDestroyedInfo arg) { SRVDestroyedEvent?.Invoke(null, arg); return arg; }

        //DockingDenied
        public event EventHandler<DockingDeniedInfo> DockingDeniedEvent;
        public DockingDeniedInfo InvokeDockingDeniedEvent(DockingDeniedInfo arg) { DockingDeniedEvent?.Invoke(null, arg); return arg; }

        //UnderAttack
        public event EventHandler<UnderAttackInfo> UnderAttackEvent;
        public UnderAttackInfo InvokeUnderAttackEvent(UnderAttackInfo arg) { UnderAttackEvent?.Invoke(null, arg); return arg; }

        //ShipTargeted
        public event EventHandler<ShipTargetedInfo> ShipTargetedEvent;
        public ShipTargetedInfo InvokeShipTargetedEvent(ShipTargetedInfo arg) { ShipTargetedEvent?.Invoke(null, arg); return arg; }

        //Shipyard
        public event EventHandler<ShipyardInfo> ShipyardEvent;
        public ShipyardInfo InvokeShipyardEvent(ShipyardInfo arg) { ShipyardEvent?.Invoke(null, arg); return arg; }

        //Outfitting
        public event EventHandler<OutfittingInfo> OutfittingEvent;
        public OutfittingInfo InvokeOutfittingEvent(OutfittingInfo arg) { OutfittingEvent?.Invoke(null, arg); return arg; }

        //PowerplayFastTrack
        public event EventHandler<PowerplayFastTrackInfo> PowerplayFastTrackEvent;
        public PowerplayFastTrackInfo InvokePowerplayFastTrackEvent(PowerplayFastTrackInfo arg) { PowerplayFastTrackEvent?.Invoke(null, arg); return arg; }

        //Powerplay
        public event EventHandler<PowerplayInfo> PowerplayEvent;
        public PowerplayInfo InvokePowerplayEvent(PowerplayInfo arg) { PowerplayEvent?.Invoke(null, arg); return arg; }

        //CollectCargo
        public event EventHandler<CollectCargoInfo> CollectCargoEvent;
        public CollectCargoInfo InvokeCollectCargoEvent(CollectCargoInfo arg) { CollectCargoEvent?.Invoke(null, arg); return arg; }

        //FetchRemoteModule
        public event EventHandler<FetchRemoteModuleInfo> FetchRemoteModuleEvent;
        public FetchRemoteModuleInfo InvokeFetchRemoteModuleEvent(FetchRemoteModuleInfo arg) { FetchRemoteModuleEvent?.Invoke(null, arg); return arg; }

        //ModuleStore
        public event EventHandler<ModuleStoreInfo> ModuleStoreEvent;
        public ModuleStoreInfo InvokeModuleStoreEvent(ModuleStoreInfo arg) { ModuleStoreEvent?.Invoke(null, arg); return arg; }

        //ShipyardBuy
        public event EventHandler<ShipyardBuyInfo> ShipyardBuyEvent;
        public ShipyardBuyInfo InvokeShipyardBuyEvent(ShipyardBuyInfo arg) { ShipyardBuyEvent?.Invoke(null, arg); return arg; }

        //ShipyardNew
        public event EventHandler<ShipyardNewInfo> ShipyardNewEvent;
        public ShipyardNewInfo InvokeShipyardNewEvent(ShipyardNewInfo arg) { ShipyardNewEvent?.Invoke(null, arg); return arg; }

        //ModuleBuy
        public event EventHandler<ModuleBuyInfo> ModuleBuyEvent;
        public ModuleBuyInfo InvokeModuleBuyEvent(ModuleBuyInfo arg) { ModuleBuyEvent?.Invoke(null, arg); return arg; }

        //ModuleRetrieve
        public event EventHandler<ModuleRetrieveInfo> ModuleRetrieveEvent;
        public ModuleRetrieveInfo InvokeModuleRetrieveEvent(ModuleRetrieveInfo arg) { ModuleRetrieveEvent?.Invoke(null, arg); return arg; }

        //AfmuRepairs
        public event EventHandler<AfmuRepairsInfo> AfmuRepairsEvent;
        public AfmuRepairsInfo InvokeAfmuRepairsEvent(AfmuRepairsInfo arg) { AfmuRepairsEvent?.Invoke(null, arg); return arg; }

        //LaunchDrone
        public event EventHandler<LaunchDroneInfo> LaunchDroneEvent;
        public LaunchDroneInfo InvokeLaunchDroneEvent(LaunchDroneInfo arg) { LaunchDroneEvent?.Invoke(null, arg); return arg; }

        //MarketSell
        public event EventHandler<MarketSellInfo> MarketSellEvent;
        public MarketSellInfo InvokeMarketSellEvent(MarketSellInfo arg) { MarketSellEvent?.Invoke(null, arg); return arg; }

        //ModuleSell
        public event EventHandler<ModuleSellInfo> ModuleSellEvent;
        public ModuleSellInfo InvokeModuleSellEvent(ModuleSellInfo arg) { ModuleSellEvent?.Invoke(null, arg); return arg; }

        //FuelScoop
        public event EventHandler<FuelScoopInfo> FuelScoopEvent;
        public FuelScoopInfo InvokeFuelScoopEvent(FuelScoopInfo arg) { FuelScoopEvent?.Invoke(null, arg); return arg; }

        //FighterDestroyed
        public event EventHandler<FighterDestroyedInfo> FighterDestroyedEvent;
        public FighterDestroyedInfo InvokeFighterDestroyedEvent(FighterDestroyedInfo arg) { FighterDestroyedEvent?.Invoke(null, arg); return arg; }

        //DiscoveryScan
        public event EventHandler<DiscoveryScanInfo> DiscoveryScanEvent;
        public DiscoveryScanInfo InvokeDiscoveryScanEvent(DiscoveryScanInfo arg) { DiscoveryScanEvent?.Invoke(null, arg); return arg; }

        //LeaveBody
        public event EventHandler<LeaveBodyInfo> LeaveBodyEvent;
        public LeaveBodyInfo InvokeLeaveBodyEvent(LeaveBodyInfo arg) { LeaveBodyEvent?.Invoke(null, arg); return arg; }

        //PowerplayVoucher
        public event EventHandler<PowerplayVoucherInfo> PowerplayVoucherEvent;
        public PowerplayVoucherInfo InvokePowerplayVoucherEvent(PowerplayVoucherInfo arg) { PowerplayVoucherEvent?.Invoke(null, arg); return arg; }

        //Reputation
        public event EventHandler<ReputationInfo> ReputationEvent;
        public ReputationInfo InvokeReputationEvent(ReputationInfo arg) { ReputationEvent?.Invoke(null, arg); return arg; }

        //NavBeaconScan
        public event EventHandler<NavBeaconScanInfo> NavBeaconScanEvent;
        public NavBeaconScanInfo InvokeNavBeaconScanEvent(NavBeaconScanInfo arg) { NavBeaconScanEvent?.Invoke(null, arg); return arg; }

        //Missions
        public event EventHandler<MissionsInfo> MissionsEvent;
        public MissionsInfo InvokeMissionsEvent(MissionsInfo arg) { MissionsEvent?.Invoke(null, arg); return arg; }

        //Friends
        public event EventHandler<FriendsInfo> FriendsEvent;
        public FriendsInfo InvokeFriendsEvent(FriendsInfo arg) { FriendsEvent?.Invoke(null, arg); return arg; }

        //ShipyardSell
        public event EventHandler<ShipyardSellInfo> ShipyardSellEvent;
        public ShipyardSellInfo InvokeShipyardSellEvent(ShipyardSellInfo arg) { ShipyardSellEvent?.Invoke(null, arg); return arg; }

        //MissionAbandoned
        public event EventHandler<MissionAbandonedInfo> MissionAbandonedEvent;
        public MissionAbandonedInfo InvokeMissionAbandonedEvent(MissionAbandonedInfo arg) { MissionAbandonedEvent?.Invoke(null, arg); return arg; }

        //ScientificResearch
        public event EventHandler<ScientificResearchInfo> ScientificResearchEvent;
        public ScientificResearchInfo InvokeScientificResearchEvent(ScientificResearchInfo arg) { ScientificResearchEvent?.Invoke(null, arg); return arg; }

        //DockingTimeout
        public event EventHandler<DockingTimeoutInfo> DockingTimeoutEvent;
        public DockingTimeoutInfo InvokeDockingTimeoutEvent(DockingTimeoutInfo arg) { DockingTimeoutEvent?.Invoke(null, arg); return arg; }

        //DockingCancelled
        public event EventHandler<DockingCancelledInfo> DockingCancelledEvent;
        public DockingCancelledInfo InvokeDockingCancelledEvent(DockingCancelledInfo arg) { DockingCancelledEvent?.Invoke(null, arg); return arg; }

        //DockingRequested
        public event EventHandler<DockingRequestedInfo> DockingRequestedEvent;
        public DockingRequestedInfo InvokeDockingRequestedEvent(DockingRequestedInfo arg) { DockingRequestedEvent?.Invoke(null, arg); return arg; }

        //DockingGranted
        public event EventHandler<DockingGrantedInfo> DockingGrantedEvent;
        public DockingGrantedInfo InvokeDockingGrantedEvent(DockingGrantedInfo arg) { DockingGrantedEvent?.Invoke(null, arg); return arg; }

        //Undocked
        public event EventHandler<UndockedInfo> UndockedEvent;
        public UndockedInfo InvokeUndockedEvent(UndockedInfo arg) { UndockedEvent?.Invoke(null, arg); return arg; }

        //CrewHire
        public event EventHandler<CrewHireInfo> CrewHireEvent;
        public CrewHireInfo InvokeCrewHireEvent(CrewHireInfo arg) { CrewHireEvent?.Invoke(null, arg); return arg; }

        //Screenshot
        public event EventHandler<ScreenshotInfo> ScreenshotEvent;
        public ScreenshotInfo InvokeScreenshotEvent(ScreenshotInfo arg) { ScreenshotEvent?.Invoke(null, arg); return arg; }

        //Synthesis
        public event EventHandler<SynthesisInfo> SynthesisEvent;
        public SynthesisInfo InvokeSynthesisEvent(SynthesisInfo arg) { SynthesisEvent?.Invoke(null, arg); return arg; }

        //FighterRebuilt
        public event EventHandler<FighterRebuiltInfo> FighterRebuiltEvent;
        public FighterRebuiltInfo InvokeFighterRebuiltEvent(FighterRebuiltInfo arg) { FighterRebuiltEvent?.Invoke(null, arg); return arg; }

        //SellExplorationData
        public event EventHandler<SellExplorationDataInfo> SellExplorationDataEvent;
        public SellExplorationDataInfo InvokeSellExplorationDataEvent(SellExplorationDataInfo arg) { SellExplorationDataEvent?.Invoke(null, arg); return arg; }

        //RebootRepair
        public event EventHandler<RebootRepairInfo> RebootRepairEvent;
        public RebootRepairInfo InvokeRebootRepairEvent(RebootRepairInfo arg) { RebootRepairEvent?.Invoke(null, arg); return arg; }

        //Scan
        public event EventHandler<ScanInfo> ScanEvent;
        public ScanInfo InvokeScanEvent(ScanInfo arg) { ScanEvent?.Invoke(null, arg); return arg; }

        //WingInvite
        public event EventHandler<WingInviteInfo> WingInviteEvent;
        public WingInviteInfo InvokeWingInviteEvent(WingInviteInfo arg) { WingInviteEvent?.Invoke(null, arg); return arg; }

        //StartJump
        public event EventHandler<StartJumpInfo> StartJumpEvent;
        public StartJumpInfo InvokeStartJumpEvent(StartJumpInfo arg) { StartJumpEvent?.Invoke(null, arg); return arg; }

        //SupercruiseExit
        public event EventHandler<SupercruiseExitInfo> SupercruiseExitEvent;
        public SupercruiseExitInfo InvokeSupercruiseExitEvent(SupercruiseExitInfo arg) { SupercruiseExitEvent?.Invoke(null, arg); return arg; }

        //PayBounties
        public event EventHandler<PayBountiesInfo> PayBountiesEvent;
        public PayBountiesInfo InvokePayBountiesEvent(PayBountiesInfo arg) { PayBountiesEvent?.Invoke(null, arg); return arg; }

        //PowerplaySalary
        public event EventHandler<PowerplaySalaryInfo> PowerplaySalaryEvent;
        public PowerplaySalaryInfo InvokePowerplaySalaryEvent(PowerplaySalaryInfo arg) { PowerplaySalaryEvent?.Invoke(null, arg); return arg; }

        //ShipyardTransfer
        public event EventHandler<ShipyardTransferInfo> ShipyardTransferEvent;
        public ShipyardTransferInfo InvokeShipyardTransferEvent(ShipyardTransferInfo arg) { ShipyardTransferEvent?.Invoke(null, arg); return arg; }

        //TechnologyBroker
        public event EventHandler<TechnologyBrokerInfo> TechnologyBrokerEvent;
        public TechnologyBrokerInfo InvokeTechnologyBrokerEvent(TechnologyBrokerInfo arg) { TechnologyBrokerEvent?.Invoke(null, arg); return arg; }

        //PayFines
        public event EventHandler<PayFinesInfo> PayFinesEvent;
        public PayFinesInfo InvokePayFinesEvent(PayFinesInfo arg) { PayFinesEvent?.Invoke(null, arg); return arg; }

        //Bounty
        public event EventHandler<BountyInfo> BountyEvent;
        public BountyInfo InvokeBountyEvent(BountyInfo arg) { BountyEvent?.Invoke(null, arg); return arg; }

        //MaterialTrade
        public event EventHandler<MaterialTradeInfo> MaterialTradeEvent;
        public MaterialTradeInfo InvokeMaterialTradeEvent(MaterialTradeInfo arg) { MaterialTradeEvent?.Invoke(null, arg); return arg; }

        //ReceiveText
        public event EventHandler<ReceiveTextInfo> ReceiveTextEvent;
        public ReceiveTextInfo InvokeReceiveTextEvent(ReceiveTextInfo arg) { ReceiveTextEvent?.Invoke(null, arg); return arg; }

        //ModuleSellRemote
        public event EventHandler<ModuleSellRemoteInfo> ModuleSellRemoteEvent;
        public ModuleSellRemoteInfo InvokeModuleSellRemoteEvent(ModuleSellRemoteInfo arg) { ModuleSellRemoteEvent?.Invoke(null, arg); return arg; }

        //ShipyardSwap
        public event EventHandler<ShipyardSwapInfo> ShipyardSwapEvent;
        public ShipyardSwapInfo InvokeShipyardSwapEvent(ShipyardSwapInfo arg) { ShipyardSwapEvent?.Invoke(null, arg); return arg; }

        //MarketBuy
        public event EventHandler<MarketBuyInfo> MarketBuyEvent;
        public MarketBuyInfo InvokeMarketBuyEvent(MarketBuyInfo arg) { MarketBuyEvent?.Invoke(null, arg); return arg; }

        //CargoDepot
        public event EventHandler<CargoDepotInfo> CargoDepotEvent;
        public CargoDepotInfo InvokeCargoDepotEvent(CargoDepotInfo arg) { CargoDepotEvent?.Invoke(null, arg); return arg; }

        //FactionKillBond
        public event EventHandler<FactionKillBondInfo> FactionKillBondEvent;
        public FactionKillBondInfo InvokeFactionKillBondEvent(FactionKillBondInfo arg) { FactionKillBondEvent?.Invoke(null, arg); return arg; }

        //StoredModules
        public event EventHandler<StoredModulesInfo> StoredModulesEvent;
        public StoredModulesInfo InvokeStoredModulesEvent(StoredModulesInfo arg) { StoredModulesEvent?.Invoke(null, arg); return arg; }

        //WingJoin
        public event EventHandler<WingJoinInfo> WingJoinEvent;
        public WingJoinInfo InvokeWingJoinEvent(WingJoinInfo arg) { WingJoinEvent?.Invoke(null, arg); return arg; }

        //ApproachBody
        public event EventHandler<ApproachBodyInfo> ApproachBodyEvent;
        public ApproachBodyInfo InvokeApproachBodyEvent(ApproachBodyInfo arg) { ApproachBodyEvent?.Invoke(null, arg); return arg; }

        //EngineerProgress
        public event EventHandler<EngineerProgressInfo> EngineerProgressEvent;
        public EngineerProgressInfo InvokeEngineerProgressEvent(EngineerProgressInfo arg) { EngineerProgressEvent?.Invoke(null, arg); return arg; }

        //FSSDiscoveryScan
        public event EventHandler<FSSDiscoveryScanInfo> FSSDiscoveryScanEvent;
        public FSSDiscoveryScanInfo InvokeFSSDiscoveryScanEvent(FSSDiscoveryScanInfo arg) { FSSDiscoveryScanEvent?.Invoke(null, arg); return arg; }

        //SquadronCreated
        public event EventHandler<SquadronCreatedInfo> SquadronCreatedEvent;
        public SquadronCreatedInfo InvokeSquadronCreatedEvent(SquadronCreatedInfo arg) { SquadronCreatedEvent?.Invoke(null, arg); return arg; }

        //Commander
        public event EventHandler<CommanderInfo> CommanderEvent;
        public CommanderInfo InvokeCommanderEvent(CommanderInfo arg) { CommanderEvent?.Invoke(null, arg); return arg; }

        //JoinedSquadron
        public event EventHandler<JoinedSquadronInfo> JoinedSquadronEvent;
        public JoinedSquadronInfo InvokeJoinedSquadronEvent(JoinedSquadronInfo arg) { JoinedSquadronEvent?.Invoke(null, arg); return arg; }

        //EjectCargo
        public event EventHandler<EjectCargoInfo> EjectCargoEvent;
        public EjectCargoInfo InvokeEjectCargoEvent(EjectCargoInfo arg) { EjectCargoEvent?.Invoke(null, arg); return arg; }

        //NpcCrewPaidWage
        public event EventHandler<NpcCrewPaidWageInfo> NpcCrewPaidWageEvent;
        public NpcCrewPaidWageInfo InvokeNpcCrewPaidWageEvent(NpcCrewPaidWageInfo arg) { NpcCrewPaidWageEvent?.Invoke(null, arg); return arg; }

        //Materials
        public event EventHandler<MaterialsInfo> MaterialsEvent;
        public MaterialsInfo InvokeMaterialsEvent(MaterialsInfo arg) { MaterialsEvent?.Invoke(null, arg); return arg; }

        //LoadGame
        public event EventHandler<LoadGameInfo> LoadGameEvent;
        public LoadGameInfo InvokeLoadGameEvent(LoadGameInfo arg) { LoadGameEvent?.Invoke(null, arg); return arg; }

        //SupercruiseEntry
        public event EventHandler<SupercruiseEntryInfo> SupercruiseEntryEvent;
        public SupercruiseEntryInfo InvokeSupercruiseEntryEvent(SupercruiseEntryInfo arg) { SupercruiseEntryEvent?.Invoke(null, arg); return arg; }

        //FSDTarget
        public event EventHandler<FSDTargetInfo> FSDTargetEvent;
        public FSDTargetInfo InvokeFSDTargetEvent(FSDTargetInfo arg) { FSDTargetEvent?.Invoke(null, arg); return arg; }

        //FSSAllBodiesFound
        public event EventHandler<FSSAllBodiesFoundInfo> FSSAllBodiesFoundEvent;
        public FSSAllBodiesFoundInfo InvokeFSSAllBodiesFoundEvent(FSSAllBodiesFoundInfo arg) { FSSAllBodiesFoundEvent?.Invoke(null, arg); return arg; }

        //SAAScanComplete
        public event EventHandler<SAAScanCompleteInfo> SAAScanCompleteEvent;
        public SAAScanCompleteInfo InvokeSAAScanCompleteEvent(SAAScanCompleteInfo arg) { SAAScanCompleteEvent?.Invoke(null, arg); return arg; }

        //CodexEntry
        public event EventHandler<CodexEntryInfo> CodexEntryEvent;
        public CodexEntryInfo InvokeCodexEntryEvent(CodexEntryInfo arg) { CodexEntryEvent?.Invoke(null, arg); return arg; }

        //CrimeVictim
        public event EventHandler<CrimeVictimInfo> CrimeVictimEvent;
        public CrimeVictimInfo InvokeCrimeVictimEvent(CrimeVictimInfo arg) { CrimeVictimEvent?.Invoke(null, arg); return arg; }

        //Loadout
        public event EventHandler<LoadoutInfo> LoadoutEvent;
        public LoadoutInfo InvokeLoadoutEvent(LoadoutInfo arg) { LoadoutEvent?.Invoke(null, arg); return arg; }

        //MissionCompleted
        public event EventHandler<MissionCompletedInfo> MissionCompletedEvent;
        public MissionCompletedInfo InvokeMissionCompletedEvent(MissionCompletedInfo arg) { MissionCompletedEvent?.Invoke(null, arg); return arg; }

        //BuyTradeData
        public event EventHandler<BuyTradeDataInfo> BuyTradeDataEvent;
        public BuyTradeDataInfo InvokeBuyTradeDataEvent(BuyTradeDataInfo arg) { BuyTradeDataEvent?.Invoke(null, arg); return arg; }

        //CrewAssign
        public event EventHandler<CrewAssignInfo> CrewAssignEvent;
        public CrewAssignInfo InvokeCrewAssignEvent(CrewAssignInfo arg) { CrewAssignEvent?.Invoke(null, arg); return arg; }

        //CrewFire
        public event EventHandler<CrewFireInfo> CrewFireEvent;
        public CrewFireInfo InvokeCrewFireEvent(CrewFireInfo arg) { CrewFireEvent?.Invoke(null, arg); return arg; }

        //MultiSellExplorationData
        public event EventHandler<MultiSellExplorationDataInfo> MultiSellExplorationDataEvent;
        public MultiSellExplorationDataInfo InvokeMultiSellExplorationDataEvent(MultiSellExplorationDataInfo arg) { MultiSellExplorationDataEvent?.Invoke(null, arg); return arg; }

        //Location
        public event EventHandler<LocationInfo> LocationEvent;
        public LocationInfo InvokeLocationEvent(LocationInfo arg) { LocationEvent?.Invoke(null, arg); return arg; }

        //AsteroidCracked
        public event EventHandler<AsteroidCrackedInfo> AsteroidCrackedEvent;
        public AsteroidCrackedInfo InvokeAsteroidCrackedEvent(AsteroidCrackedInfo arg) { AsteroidCrackedEvent?.Invoke(null, arg); return arg; }

        //ModuleSwap
        public event EventHandler<ModuleSwapInfo> ModuleSwapEvent;
        public ModuleSwapInfo InvokeModuleSwapEvent(ModuleSwapInfo arg) { ModuleSwapEvent?.Invoke(null, arg); return arg; }

        //DataScanned
        public event EventHandler<DataScannedInfo> DataScannedEvent;
        public DataScannedInfo InvokeDataScannedEvent(DataScannedInfo arg) { DataScannedEvent?.Invoke(null, arg); return arg; }

        //DisbandedSquadron
        public event EventHandler<DisbandedSquadronInfo> DisbandedSquadronEvent;
        public DisbandedSquadronInfo InvokeDisbandedSquadronEvent(DisbandedSquadronInfo arg) { DisbandedSquadronEvent?.Invoke(null, arg); return arg; }

        //AppliedToSquadron
        public event EventHandler<AppliedToSquadronInfo> AppliedToSquadronEvent;
        public AppliedToSquadronInfo InvokeAppliedToSquadronEvent(AppliedToSquadronInfo arg) { AppliedToSquadronEvent?.Invoke(null, arg); return arg; }

        //Docked
        public event EventHandler<DockedInfo> DockedEvent;
        public DockedInfo InvokeDockedEvent(DockedInfo arg) { DockedEvent?.Invoke(null, arg); return arg; }

        //Statistics
        public event EventHandler<StatisticsInfo> StatisticsEvent;
        public StatisticsInfo InvokeStatisticsEvent(StatisticsInfo arg) { StatisticsEvent?.Invoke(null, arg); return arg; }

        //SetUserShipName
        public event EventHandler<SetUserShipNameInfo> SetUserShipNameEvent;
        public SetUserShipNameInfo InvokeSetUserShipNameEvent(SetUserShipNameInfo arg) { SetUserShipNameEvent?.Invoke(null, arg); return arg; }

        //FSDJump
        public event EventHandler<FSDJumpInfo> FSDJumpEvent;
        public FSDJumpInfo InvokeFSDJumpEvent(FSDJumpInfo arg) { FSDJumpEvent?.Invoke(null, arg); return arg; }

        //Cargo
        public event EventHandler<CargoInfo> CargoEvent;
        public CargoInfo InvokeCargoEvent(CargoInfo arg) { CargoEvent?.Invoke(null, arg); return arg; }

        //EngineerCraft
        public event EventHandler<EngineerCraftInfo> EngineerCraftEvent;
        public EngineerCraftInfo InvokeEngineerCraftEvent(EngineerCraftInfo arg) { EngineerCraftEvent?.Invoke(null, arg); return arg; }

        //ApproachSettlement
        public event EventHandler<ApproachSettlementInfo> ApproachSettlementEvent;
        public ApproachSettlementInfo InvokeApproachSettlementEvent(ApproachSettlementInfo arg) { ApproachSettlementEvent?.Invoke(null, arg); return arg; }

        //StoredShips
        public event EventHandler<StoredShipsInfo> StoredShipsEvent;
        public StoredShipsInfo InvokeStoredShipsEvent(StoredShipsInfo arg) { StoredShipsEvent?.Invoke(null, arg); return arg; }

        //FSSSignalDiscovered
        public event EventHandler<FSSSignalDiscoveredInfo> FSSSignalDiscoveredEvent;
        public FSSSignalDiscoveredInfo InvokeFSSSignalDiscoveredEvent(FSSSignalDiscoveredInfo arg) { FSSSignalDiscoveredEvent?.Invoke(null, arg); return arg; }

    }
}