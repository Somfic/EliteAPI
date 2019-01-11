namespace EliteAPI.Events
{

    using System;

    public static class EventHandler
    {


        //HeatWarning
        public static event EventHandler<HeatWarningInfo> HeatWarningEvent;
        public static HeatWarningInfo InvokeHeatWarningEvent(HeatWarningInfo arg) { HeatWarningEvent?.Invoke(null, arg); return arg; }

        //ShieldState
        public static event EventHandler<ShieldStateInfo> ShieldStateEvent;
        public static ShieldStateInfo InvokeShieldStateEvent(ShieldStateInfo arg) { ShieldStateEvent?.Invoke(null, arg); return arg; }

        //VehicleSwitch
        public static event EventHandler<VehicleSwitchInfo> VehicleSwitchEvent;
        public static VehicleSwitchInfo InvokeVehicleSwitchEvent(VehicleSwitchInfo arg) { VehicleSwitchEvent?.Invoke(null, arg); return arg; }

        //DockFighter
        public static event EventHandler<DockFighterInfo> DockFighterEvent;
        public static DockFighterInfo InvokeDockFighterEvent(DockFighterInfo arg) { DockFighterEvent?.Invoke(null, arg); return arg; }

        //LaunchSRV
        public static event EventHandler<LaunchSRVInfo> LaunchSRVEvent;
        public static LaunchSRVInfo InvokeLaunchSRVEvent(LaunchSRVInfo arg) { LaunchSRVEvent?.Invoke(null, arg); return arg; }

        //SelfDestruct
        public static event EventHandler<SelfDestructInfo> SelfDestructEvent;
        public static SelfDestructInfo InvokeSelfDestructEvent(SelfDestructInfo arg) { SelfDestructEvent?.Invoke(null, arg); return arg; }

        //DockSRV
        public static event EventHandler<DockSRVInfo> DockSRVEvent;
        public static DockSRVInfo InvokeDockSRVEvent(DockSRVInfo arg) { DockSRVEvent?.Invoke(null, arg); return arg; }

        //HeatDamage
        public static event EventHandler<HeatDamageInfo> HeatDamageEvent;
        public static HeatDamageInfo InvokeHeatDamageEvent(HeatDamageInfo arg) { HeatDamageEvent?.Invoke(null, arg); return arg; }

        //LaunchFighter
        public static event EventHandler<LaunchFighterInfo> LaunchFighterEvent;
        public static LaunchFighterInfo InvokeLaunchFighterEvent(LaunchFighterInfo arg) { LaunchFighterEvent?.Invoke(null, arg); return arg; }

        //DatalinkScan
        public static event EventHandler<DatalinkScanInfo> DatalinkScanEvent;
        public static DatalinkScanInfo InvokeDatalinkScanEvent(DatalinkScanInfo arg) { DatalinkScanEvent?.Invoke(null, arg); return arg; }

        //CockpitBreached
        public static event EventHandler<CockpitBreachedInfo> CockpitBreachedEvent;
        public static CockpitBreachedInfo InvokeCockpitBreachedEvent(CockpitBreachedInfo arg) { CockpitBreachedEvent?.Invoke(null, arg); return arg; }

        //JetConeBoost
        public static event EventHandler<JetConeBoostInfo> JetConeBoostEvent;
        public static JetConeBoostInfo InvokeJetConeBoostEvent(JetConeBoostInfo arg) { JetConeBoostEvent?.Invoke(null, arg); return arg; }

        //PowerplayLeave
        public static event EventHandler<PowerplayLeaveInfo> PowerplayLeaveEvent;
        public static PowerplayLeaveInfo InvokePowerplayLeaveEvent(PowerplayLeaveInfo arg) { PowerplayLeaveEvent?.Invoke(null, arg); return arg; }

        //Interdiction
        public static event EventHandler<InterdictionInfo> InterdictionEvent;
        public static InterdictionInfo InvokeInterdictionEvent(InterdictionInfo arg) { InterdictionEvent?.Invoke(null, arg); return arg; }

        //USSDrop
        public static event EventHandler<USSDropInfo> USSDropEvent;
        public static USSDropInfo InvokeUSSDropEvent(USSDropInfo arg) { USSDropEvent?.Invoke(null, arg); return arg; }

        //PowerplayCollect
        public static event EventHandler<PowerplayCollectInfo> PowerplayCollectEvent;
        public static PowerplayCollectInfo InvokePowerplayCollectEvent(PowerplayCollectInfo arg) { PowerplayCollectEvent?.Invoke(null, arg); return arg; }

        //PowerplayDeliver
        public static event EventHandler<PowerplayDeliverInfo> PowerplayDeliverEvent;
        public static PowerplayDeliverInfo InvokePowerplayDeliverEvent(PowerplayDeliverInfo arg) { PowerplayDeliverEvent?.Invoke(null, arg); return arg; }

        //PayLegacyFines
        public static event EventHandler<PayLegacyFinesInfo> PayLegacyFinesEvent;
        public static PayLegacyFinesInfo InvokePayLegacyFinesEvent(PayLegacyFinesInfo arg) { PayLegacyFinesEvent?.Invoke(null, arg); return arg; }

        //EngineerApply
        public static event EventHandler<EngineerApplyInfo> EngineerApplyEvent;
        public static EngineerApplyInfo InvokeEngineerApplyEvent(EngineerApplyInfo arg) { EngineerApplyEvent?.Invoke(null, arg); return arg; }

        //WingLeave
        public static event EventHandler<WingLeaveInfo> WingLeaveEvent;
        public static WingLeaveInfo InvokeWingLeaveEvent(WingLeaveInfo arg) { WingLeaveEvent?.Invoke(null, arg); return arg; }

        //SystemsShutdown
        public static event EventHandler<SystemsShutdownInfo> SystemsShutdownEvent;
        public static SystemsShutdownInfo InvokeSystemsShutdownEvent(SystemsShutdownInfo arg) { SystemsShutdownEvent?.Invoke(null, arg); return arg; }

        //HullDamage
        public static event EventHandler<HullDamageInfo> HullDamageEvent;
        public static HullDamageInfo InvokeHullDamageEvent(HullDamageInfo arg) { HullDamageEvent?.Invoke(null, arg); return arg; }

        //BuyDrones
        public static event EventHandler<BuyDronesInfo> BuyDronesEvent;
        public static BuyDronesInfo InvokeBuyDronesEvent(BuyDronesInfo arg) { BuyDronesEvent?.Invoke(null, arg); return arg; }

        //RestockVehicle
        public static event EventHandler<RestockVehicleInfo> RestockVehicleEvent;
        public static RestockVehicleInfo InvokeRestockVehicleEvent(RestockVehicleInfo arg) { RestockVehicleEvent?.Invoke(null, arg); return arg; }

        //BuyAmmo
        public static event EventHandler<BuyAmmoInfo> BuyAmmoEvent;
        public static BuyAmmoInfo InvokeBuyAmmoEvent(BuyAmmoInfo arg) { BuyAmmoEvent?.Invoke(null, arg); return arg; }

        //MiningRefined
        public static event EventHandler<MiningRefinedInfo> MiningRefinedEvent;
        public static MiningRefinedInfo InvokeMiningRefinedEvent(MiningRefinedInfo arg) { MiningRefinedEvent?.Invoke(null, arg); return arg; }

        //DatalinkVoucher
        public static event EventHandler<DatalinkVoucherInfo> DatalinkVoucherEvent;
        public static DatalinkVoucherInfo InvokeDatalinkVoucherEvent(DatalinkVoucherInfo arg) { DatalinkVoucherEvent?.Invoke(null, arg); return arg; }

        //Scanned
        public static event EventHandler<ScannedInfo> ScannedEvent;
        public static ScannedInfo InvokeScannedEvent(ScannedInfo arg) { ScannedEvent?.Invoke(null, arg); return arg; }

        //ChangeCrewRole
        public static event EventHandler<ChangeCrewRoleInfo> ChangeCrewRoleEvent;
        public static ChangeCrewRoleInfo InvokeChangeCrewRoleEvent(ChangeCrewRoleInfo arg) { ChangeCrewRoleEvent?.Invoke(null, arg); return arg; }

        //Touchdown
        public static event EventHandler<TouchdownInfo> TouchdownEvent;
        public static TouchdownInfo InvokeTouchdownEvent(TouchdownInfo arg) { TouchdownEvent?.Invoke(null, arg); return arg; }

        //SendText
        public static event EventHandler<SendTextInfo> SendTextEvent;
        public static SendTextInfo InvokeSendTextEvent(SendTextInfo arg) { SendTextEvent?.Invoke(null, arg); return arg; }

        //RefuelAll
        public static event EventHandler<RefuelAllInfo> RefuelAllEvent;
        public static RefuelAllInfo InvokeRefuelAllEvent(RefuelAllInfo arg) { RefuelAllEvent?.Invoke(null, arg); return arg; }

        //EndCrewSession
        public static event EventHandler<EndCrewSessionInfo> EndCrewSessionEvent;
        public static EndCrewSessionInfo InvokeEndCrewSessionEvent(EndCrewSessionInfo arg) { EndCrewSessionEvent?.Invoke(null, arg); return arg; }

        //Liftoff
        public static event EventHandler<LiftoffInfo> LiftoffEvent;
        public static LiftoffInfo InvokeLiftoffEvent(LiftoffInfo arg) { LiftoffEvent?.Invoke(null, arg); return arg; }

        //EscapeInterdiction
        public static event EventHandler<EscapeInterdictionInfo> EscapeInterdictionEvent;
        public static EscapeInterdictionInfo InvokeEscapeInterdictionEvent(EscapeInterdictionInfo arg) { EscapeInterdictionEvent?.Invoke(null, arg); return arg; }

        //WingAdd
        public static event EventHandler<WingAddInfo> WingAddEvent;
        public static WingAddInfo InvokeWingAddEvent(WingAddInfo arg) { WingAddEvent?.Invoke(null, arg); return arg; }

        //SellDrones
        public static event EventHandler<SellDronesInfo> SellDronesEvent;
        public static SellDronesInfo InvokeSellDronesEvent(SellDronesInfo arg) { SellDronesEvent?.Invoke(null, arg); return arg; }

        //Fileheader
        public static event EventHandler<FileheaderInfo> FileheaderEvent;
        public static FileheaderInfo InvokeFileheaderEvent(FileheaderInfo arg) { FileheaderEvent?.Invoke(null, arg); return arg; }

        //Interdicted
        public static event EventHandler<InterdictedInfo> InterdictedEvent;
        public static InterdictedInfo InvokeInterdictedEvent(InterdictedInfo arg) { InterdictedEvent?.Invoke(null, arg); return arg; }

        //CrewMemberJoins
        public static event EventHandler<CrewMemberJoinsInfo> CrewMemberJoinsEvent;
        public static CrewMemberJoinsInfo InvokeCrewMemberJoinsEvent(CrewMemberJoinsInfo arg) { CrewMemberJoinsEvent?.Invoke(null, arg); return arg; }

        //CrewMemberQuits
        public static event EventHandler<CrewMemberQuitsInfo> CrewMemberQuitsEvent;
        public static CrewMemberQuitsInfo InvokeCrewMemberQuitsEvent(CrewMemberQuitsInfo arg) { CrewMemberQuitsEvent?.Invoke(null, arg); return arg; }

        //CrewMemberRoleChange
        public static event EventHandler<CrewMemberRoleChangeInfo> CrewMemberRoleChangeEvent;
        public static CrewMemberRoleChangeInfo InvokeCrewMemberRoleChangeEvent(CrewMemberRoleChangeInfo arg) { CrewMemberRoleChangeEvent?.Invoke(null, arg); return arg; }

        //PVPKill
        public static event EventHandler<PVPKillInfo> PVPKillEvent;
        public static PVPKillInfo InvokePVPKillEvent(PVPKillInfo arg) { PVPKillEvent?.Invoke(null, arg); return arg; }

        //JoinACrew
        public static event EventHandler<JoinACrewInfo> JoinACrewEvent;
        public static JoinACrewInfo InvokeJoinACrewEvent(JoinACrewInfo arg) { JoinACrewEvent?.Invoke(null, arg); return arg; }

        //QuitACrew
        public static event EventHandler<QuitACrewInfo> QuitACrewEvent;
        public static QuitACrewInfo InvokeQuitACrewEvent(QuitACrewInfo arg) { QuitACrewEvent?.Invoke(null, arg); return arg; }

        //Progress
        public static event EventHandler<ProgressInfo> ProgressEvent;
        public static ProgressInfo InvokeProgressEvent(ProgressInfo arg) { ProgressEvent?.Invoke(null, arg); return arg; }

        //Promotion
        public static event EventHandler<PromotionInfo> PromotionEvent;
        public static PromotionInfo InvokePromotionEvent(PromotionInfo arg) { PromotionEvent?.Invoke(null, arg); return arg; }

        //Rank
        public static event EventHandler<RankInfo> RankEvent;
        public static RankInfo InvokeRankEvent(RankInfo arg) { RankEvent?.Invoke(null, arg); return arg; }

        //CommitCrime
        public static event EventHandler<CommitCrimeInfo> CommitCrimeEvent;
        public static CommitCrimeInfo InvokeCommitCrimeEvent(CommitCrimeInfo arg) { CommitCrimeEvent?.Invoke(null, arg); return arg; }

        //EngineerContribution
        public static event EventHandler<EngineerContributionInfo> EngineerContributionEvent;
        public static EngineerContributionInfo InvokeEngineerContributionEvent(EngineerContributionInfo arg) { EngineerContributionEvent?.Invoke(null, arg); return arg; }

        //Music
        public static event EventHandler<MusicInfo> MusicEvent;
        public static MusicInfo InvokeMusicEvent(MusicInfo arg) { MusicEvent?.Invoke(null, arg); return arg; }

        //Died
        public static event EventHandler<DiedInfo> DiedEvent;
        public static DiedInfo InvokeDiedEvent(DiedInfo arg) { DiedEvent?.Invoke(null, arg); return arg; }

        //Passengers
        public static event EventHandler<PassengersInfo> PassengersEvent;
        public static PassengersInfo InvokePassengersEvent(PassengersInfo arg) { PassengersEvent?.Invoke(null, arg); return arg; }

        //SearchAndRescue
        public static event EventHandler<SearchAndRescueInfo> SearchAndRescueEvent;
        public static SearchAndRescueInfo InvokeSearchAndRescueEvent(SearchAndRescueInfo arg) { SearchAndRescueEvent?.Invoke(null, arg); return arg; }

        //KickCrewMember
        public static event EventHandler<KickCrewMemberInfo> KickCrewMemberEvent;
        public static KickCrewMemberInfo InvokeKickCrewMemberEvent(KickCrewMemberInfo arg) { KickCrewMemberEvent?.Invoke(null, arg); return arg; }

        //RedeemVoucher
        public static event EventHandler<RedeemVoucherInfo> RedeemVoucherEvent;
        public static RedeemVoucherInfo InvokeRedeemVoucherEvent(RedeemVoucherInfo arg) { RedeemVoucherEvent?.Invoke(null, arg); return arg; }

        //Resurrect
        public static event EventHandler<ResurrectInfo> ResurrectEvent;
        public static ResurrectInfo InvokeResurrectEvent(ResurrectInfo arg) { ResurrectEvent?.Invoke(null, arg); return arg; }

        //CommunityGoalJoin
        public static event EventHandler<CommunityGoalJoinInfo> CommunityGoalJoinEvent;
        public static CommunityGoalJoinInfo InvokeCommunityGoalJoinEvent(CommunityGoalJoinInfo arg) { CommunityGoalJoinEvent?.Invoke(null, arg); return arg; }

        //CommunityGoal
        public static event EventHandler<CommunityGoalInfo> CommunityGoalEvent;
        public static CommunityGoalInfo InvokeCommunityGoalEvent(CommunityGoalInfo arg) { CommunityGoalEvent?.Invoke(null, arg); return arg; }

        //RepairDrone
        public static event EventHandler<RepairDroneInfo> RepairDroneEvent;
        public static RepairDroneInfo InvokeRepairDroneEvent(RepairDroneInfo arg) { RepairDroneEvent?.Invoke(null, arg); return arg; }

        //Repair
        public static event EventHandler<RepairInfo> RepairEvent;
        public static RepairInfo InvokeRepairEvent(RepairInfo arg) { RepairEvent?.Invoke(null, arg); return arg; }

        //JetConeDamage
        public static event EventHandler<JetConeDamageInfo> JetConeDamageEvent;
        public static JetConeDamageInfo InvokeJetConeDamageEvent(JetConeDamageInfo arg) { JetConeDamageEvent?.Invoke(null, arg); return arg; }

        //CommunityGoalDiscard
        public static event EventHandler<CommunityGoalDiscardInfo> CommunityGoalDiscardEvent;
        public static CommunityGoalDiscardInfo InvokeCommunityGoalDiscardEvent(CommunityGoalDiscardInfo arg) { CommunityGoalDiscardEvent?.Invoke(null, arg); return arg; }

        //MissionAccepted
        public static event EventHandler<MissionAcceptedInfo> MissionAcceptedEvent;
        public static MissionAcceptedInfo InvokeMissionAcceptedEvent(MissionAcceptedInfo arg) { MissionAcceptedEvent?.Invoke(null, arg); return arg; }

        //BuyExplorationData
        public static event EventHandler<BuyExplorationDataInfo> BuyExplorationDataEvent;
        public static BuyExplorationDataInfo InvokeBuyExplorationDataEvent(BuyExplorationDataInfo arg) { BuyExplorationDataEvent?.Invoke(null, arg); return arg; }

        //RepairAll
        public static event EventHandler<RepairAllInfo> RepairAllEvent;
        public static RepairAllInfo InvokeRepairAllEvent(RepairAllInfo arg) { RepairAllEvent?.Invoke(null, arg); return arg; }

        //CrewLaunchFighter
        public static event EventHandler<CrewLaunchFighterInfo> CrewLaunchFighterEvent;
        public static CrewLaunchFighterInfo InvokeCrewLaunchFighterEvent(CrewLaunchFighterInfo arg) { CrewLaunchFighterEvent?.Invoke(null, arg); return arg; }

        //MaterialDiscarded
        public static event EventHandler<MaterialDiscardedInfo> MaterialDiscardedEvent;
        public static MaterialDiscardedInfo InvokeMaterialDiscardedEvent(MaterialDiscardedInfo arg) { MaterialDiscardedEvent?.Invoke(null, arg); return arg; }

        //NewCommander
        public static event EventHandler<NewCommanderInfo> NewCommanderEvent;
        public static NewCommanderInfo InvokeNewCommanderEvent(NewCommanderInfo arg) { NewCommanderEvent?.Invoke(null, arg); return arg; }

        //CommunityGoalReward
        public static event EventHandler<CommunityGoalRewardInfo> CommunityGoalRewardEvent;
        public static CommunityGoalRewardInfo InvokeCommunityGoalRewardEvent(CommunityGoalRewardInfo arg) { CommunityGoalRewardEvent?.Invoke(null, arg); return arg; }

        //PowerplayVote
        public static event EventHandler<PowerplayVoteInfo> PowerplayVoteEvent;
        public static PowerplayVoteInfo InvokePowerplayVoteEvent(PowerplayVoteInfo arg) { PowerplayVoteEvent?.Invoke(null, arg); return arg; }

        //PowerplayJoin
        public static event EventHandler<PowerplayJoinInfo> PowerplayJoinEvent;
        public static PowerplayJoinInfo InvokePowerplayJoinEvent(PowerplayJoinInfo arg) { PowerplayJoinEvent?.Invoke(null, arg); return arg; }

        //PowerplayDefect
        public static event EventHandler<PowerplayDefectInfo> PowerplayDefectEvent;
        public static PowerplayDefectInfo InvokePowerplayDefectEvent(PowerplayDefectInfo arg) { PowerplayDefectEvent?.Invoke(null, arg); return arg; }

        //MissionFailed
        public static event EventHandler<MissionFailedInfo> MissionFailedEvent;
        public static MissionFailedInfo InvokeMissionFailedEvent(MissionFailedInfo arg) { MissionFailedEvent?.Invoke(null, arg); return arg; }

        //MissionRedirected
        public static event EventHandler<MissionRedirectedInfo> MissionRedirectedEvent;
        public static MissionRedirectedInfo InvokeMissionRedirectedEvent(MissionRedirectedInfo arg) { MissionRedirectedEvent?.Invoke(null, arg); return arg; }

        //Shutdown
        public static event EventHandler<ShutdownInfo> ShutdownEvent;
        public static ShutdownInfo InvokeShutdownEvent(ShutdownInfo arg) { ShutdownEvent?.Invoke(null, arg); return arg; }

        //ModuleInfo
        public static event EventHandler<ModuleInfoInfo> ModuleInfoEvent;
        public static ModuleInfoInfo InvokeModuleInfoEvent(ModuleInfoInfo arg) { ModuleInfoEvent?.Invoke(null, arg); return arg; }

        //Market
        public static event EventHandler<MarketInfo> MarketEvent;
        public static MarketInfo InvokeMarketEvent(MarketInfo arg) { MarketEvent?.Invoke(null, arg); return arg; }

        //MassModuleStore
        public static event EventHandler<MassModuleStoreInfo> MassModuleStoreEvent;
        public static MassModuleStoreInfo InvokeMassModuleStoreEvent(MassModuleStoreInfo arg) { MassModuleStoreEvent?.Invoke(null, arg); return arg; }

        //MaterialDiscovered
        public static event EventHandler<MaterialDiscoveredInfo> MaterialDiscoveredEvent;
        public static MaterialDiscoveredInfo InvokeMaterialDiscoveredEvent(MaterialDiscoveredInfo arg) { MaterialDiscoveredEvent?.Invoke(null, arg); return arg; }

        //MaterialCollected
        public static event EventHandler<MaterialCollectedInfo> MaterialCollectedEvent;
        public static MaterialCollectedInfo InvokeMaterialCollectedEvent(MaterialCollectedInfo arg) { MaterialCollectedEvent?.Invoke(null, arg); return arg; }

        //SRVDestroyed
        public static event EventHandler<SRVDestroyedInfo> SRVDestroyedEvent;
        public static SRVDestroyedInfo InvokeSRVDestroyedEvent(SRVDestroyedInfo arg) { SRVDestroyedEvent?.Invoke(null, arg); return arg; }

        //DockingDenied
        public static event EventHandler<DockingDeniedInfo> DockingDeniedEvent;
        public static DockingDeniedInfo InvokeDockingDeniedEvent(DockingDeniedInfo arg) { DockingDeniedEvent?.Invoke(null, arg); return arg; }

        //UnderAttack
        public static event EventHandler<UnderAttackInfo> UnderAttackEvent;
        public static UnderAttackInfo InvokeUnderAttackEvent(UnderAttackInfo arg) { UnderAttackEvent?.Invoke(null, arg); return arg; }

        //ShipTargeted
        public static event EventHandler<ShipTargetedInfo> ShipTargetedEvent;
        public static ShipTargetedInfo InvokeShipTargetedEvent(ShipTargetedInfo arg) { ShipTargetedEvent?.Invoke(null, arg); return arg; }

        //Shipyard
        public static event EventHandler<ShipyardInfo> ShipyardEvent;
        public static ShipyardInfo InvokeShipyardEvent(ShipyardInfo arg) { ShipyardEvent?.Invoke(null, arg); return arg; }

        //Outfitting
        public static event EventHandler<OutfittingInfo> OutfittingEvent;
        public static OutfittingInfo InvokeOutfittingEvent(OutfittingInfo arg) { OutfittingEvent?.Invoke(null, arg); return arg; }

        //PowerplayFastTrack
        public static event EventHandler<PowerplayFastTrackInfo> PowerplayFastTrackEvent;
        public static PowerplayFastTrackInfo InvokePowerplayFastTrackEvent(PowerplayFastTrackInfo arg) { PowerplayFastTrackEvent?.Invoke(null, arg); return arg; }

        //Powerplay
        public static event EventHandler<PowerplayInfo> PowerplayEvent;
        public static PowerplayInfo InvokePowerplayEvent(PowerplayInfo arg) { PowerplayEvent?.Invoke(null, arg); return arg; }

        //CollectCargo
        public static event EventHandler<CollectCargoInfo> CollectCargoEvent;
        public static CollectCargoInfo InvokeCollectCargoEvent(CollectCargoInfo arg) { CollectCargoEvent?.Invoke(null, arg); return arg; }

        //FetchRemoteModule
        public static event EventHandler<FetchRemoteModuleInfo> FetchRemoteModuleEvent;
        public static FetchRemoteModuleInfo InvokeFetchRemoteModuleEvent(FetchRemoteModuleInfo arg) { FetchRemoteModuleEvent?.Invoke(null, arg); return arg; }

        //ModuleStore
        public static event EventHandler<ModuleStoreInfo> ModuleStoreEvent;
        public static ModuleStoreInfo InvokeModuleStoreEvent(ModuleStoreInfo arg) { ModuleStoreEvent?.Invoke(null, arg); return arg; }

        //ShipyardBuy
        public static event EventHandler<ShipyardBuyInfo> ShipyardBuyEvent;
        public static ShipyardBuyInfo InvokeShipyardBuyEvent(ShipyardBuyInfo arg) { ShipyardBuyEvent?.Invoke(null, arg); return arg; }

        //ShipyardNew
        public static event EventHandler<ShipyardNewInfo> ShipyardNewEvent;
        public static ShipyardNewInfo InvokeShipyardNewEvent(ShipyardNewInfo arg) { ShipyardNewEvent?.Invoke(null, arg); return arg; }

        //ModuleBuy
        public static event EventHandler<ModuleBuyInfo> ModuleBuyEvent;
        public static ModuleBuyInfo InvokeModuleBuyEvent(ModuleBuyInfo arg) { ModuleBuyEvent?.Invoke(null, arg); return arg; }

        //ModuleRetrieve
        public static event EventHandler<ModuleRetrieveInfo> ModuleRetrieveEvent;
        public static ModuleRetrieveInfo InvokeModuleRetrieveEvent(ModuleRetrieveInfo arg) { ModuleRetrieveEvent?.Invoke(null, arg); return arg; }

        //AfmuRepairs
        public static event EventHandler<AfmuRepairsInfo> AfmuRepairsEvent;
        public static AfmuRepairsInfo InvokeAfmuRepairsEvent(AfmuRepairsInfo arg) { AfmuRepairsEvent?.Invoke(null, arg); return arg; }

        //LaunchDrone
        public static event EventHandler<LaunchDroneInfo> LaunchDroneEvent;
        public static LaunchDroneInfo InvokeLaunchDroneEvent(LaunchDroneInfo arg) { LaunchDroneEvent?.Invoke(null, arg); return arg; }

        //MarketSell
        public static event EventHandler<MarketSellInfo> MarketSellEvent;
        public static MarketSellInfo InvokeMarketSellEvent(MarketSellInfo arg) { MarketSellEvent?.Invoke(null, arg); return arg; }

        //ModuleSell
        public static event EventHandler<ModuleSellInfo> ModuleSellEvent;
        public static ModuleSellInfo InvokeModuleSellEvent(ModuleSellInfo arg) { ModuleSellEvent?.Invoke(null, arg); return arg; }

        //FuelScoop
        public static event EventHandler<FuelScoopInfo> FuelScoopEvent;
        public static FuelScoopInfo InvokeFuelScoopEvent(FuelScoopInfo arg) { FuelScoopEvent?.Invoke(null, arg); return arg; }

        //FighterDestroyed
        public static event EventHandler<FighterDestroyedInfo> FighterDestroyedEvent;
        public static FighterDestroyedInfo InvokeFighterDestroyedEvent(FighterDestroyedInfo arg) { FighterDestroyedEvent?.Invoke(null, arg); return arg; }

        //DiscoveryScan
        public static event EventHandler<DiscoveryScanInfo> DiscoveryScanEvent;
        public static DiscoveryScanInfo InvokeDiscoveryScanEvent(DiscoveryScanInfo arg) { DiscoveryScanEvent?.Invoke(null, arg); return arg; }

        //LeaveBody
        public static event EventHandler<LeaveBodyInfo> LeaveBodyEvent;
        public static LeaveBodyInfo InvokeLeaveBodyEvent(LeaveBodyInfo arg) { LeaveBodyEvent?.Invoke(null, arg); return arg; }

        //PowerplayVoucher
        public static event EventHandler<PowerplayVoucherInfo> PowerplayVoucherEvent;
        public static PowerplayVoucherInfo InvokePowerplayVoucherEvent(PowerplayVoucherInfo arg) { PowerplayVoucherEvent?.Invoke(null, arg); return arg; }

        //Reputation
        public static event EventHandler<ReputationInfo> ReputationEvent;
        public static ReputationInfo InvokeReputationEvent(ReputationInfo arg) { ReputationEvent?.Invoke(null, arg); return arg; }

        //NavBeaconScan
        public static event EventHandler<NavBeaconScanInfo> NavBeaconScanEvent;
        public static NavBeaconScanInfo InvokeNavBeaconScanEvent(NavBeaconScanInfo arg) { NavBeaconScanEvent?.Invoke(null, arg); return arg; }

        //Missions
        public static event EventHandler<MissionsInfo> MissionsEvent;
        public static MissionsInfo InvokeMissionsEvent(MissionsInfo arg) { MissionsEvent?.Invoke(null, arg); return arg; }

        //Friends
        public static event EventHandler<FriendsInfo> FriendsEvent;
        public static FriendsInfo InvokeFriendsEvent(FriendsInfo arg) { FriendsEvent?.Invoke(null, arg); return arg; }

        //ShipyardSell
        public static event EventHandler<ShipyardSellInfo> ShipyardSellEvent;
        public static ShipyardSellInfo InvokeShipyardSellEvent(ShipyardSellInfo arg) { ShipyardSellEvent?.Invoke(null, arg); return arg; }

        //MissionAbandoned
        public static event EventHandler<MissionAbandonedInfo> MissionAbandonedEvent;
        public static MissionAbandonedInfo InvokeMissionAbandonedEvent(MissionAbandonedInfo arg) { MissionAbandonedEvent?.Invoke(null, arg); return arg; }

        //ScientificResearch
        public static event EventHandler<ScientificResearchInfo> ScientificResearchEvent;
        public static ScientificResearchInfo InvokeScientificResearchEvent(ScientificResearchInfo arg) { ScientificResearchEvent?.Invoke(null, arg); return arg; }

        //DockingTimeout
        public static event EventHandler<DockingTimeoutInfo> DockingTimeoutEvent;
        public static DockingTimeoutInfo InvokeDockingTimeoutEvent(DockingTimeoutInfo arg) { DockingTimeoutEvent?.Invoke(null, arg); return arg; }

        //DockingCancelled
        public static event EventHandler<DockingCancelledInfo> DockingCancelledEvent;
        public static DockingCancelledInfo InvokeDockingCancelledEvent(DockingCancelledInfo arg) { DockingCancelledEvent?.Invoke(null, arg); return arg; }

        //DockingRequested
        public static event EventHandler<DockingRequestedInfo> DockingRequestedEvent;
        public static DockingRequestedInfo InvokeDockingRequestedEvent(DockingRequestedInfo arg) { DockingRequestedEvent?.Invoke(null, arg); return arg; }

        //DockingGranted
        public static event EventHandler<DockingGrantedInfo> DockingGrantedEvent;
        public static DockingGrantedInfo InvokeDockingGrantedEvent(DockingGrantedInfo arg) { DockingGrantedEvent?.Invoke(null, arg); return arg; }

        //Undocked
        public static event EventHandler<UndockedInfo> UndockedEvent;
        public static UndockedInfo InvokeUndockedEvent(UndockedInfo arg) { UndockedEvent?.Invoke(null, arg); return arg; }

        //CrewHire
        public static event EventHandler<CrewHireInfo> CrewHireEvent;
        public static CrewHireInfo InvokeCrewHireEvent(CrewHireInfo arg) { CrewHireEvent?.Invoke(null, arg); return arg; }

        //Screenshot
        public static event EventHandler<ScreenshotInfo> ScreenshotEvent;
        public static ScreenshotInfo InvokeScreenshotEvent(ScreenshotInfo arg) { ScreenshotEvent?.Invoke(null, arg); return arg; }

        //Synthesis
        public static event EventHandler<SynthesisInfo> SynthesisEvent;
        public static SynthesisInfo InvokeSynthesisEvent(SynthesisInfo arg) { SynthesisEvent?.Invoke(null, arg); return arg; }

        //FighterRebuilt
        public static event EventHandler<FighterRebuiltInfo> FighterRebuiltEvent;
        public static FighterRebuiltInfo InvokeFighterRebuiltEvent(FighterRebuiltInfo arg) { FighterRebuiltEvent?.Invoke(null, arg); return arg; }

        //SellExplorationData
        public static event EventHandler<SellExplorationDataInfo> SellExplorationDataEvent;
        public static SellExplorationDataInfo InvokeSellExplorationDataEvent(SellExplorationDataInfo arg) { SellExplorationDataEvent?.Invoke(null, arg); return arg; }

        //RebootRepair
        public static event EventHandler<RebootRepairInfo> RebootRepairEvent;
        public static RebootRepairInfo InvokeRebootRepairEvent(RebootRepairInfo arg) { RebootRepairEvent?.Invoke(null, arg); return arg; }

        //Scan
        public static event EventHandler<ScanInfo> ScanEvent;
        public static ScanInfo InvokeScanEvent(ScanInfo arg) { ScanEvent?.Invoke(null, arg); return arg; }

        //WingInvite
        public static event EventHandler<WingInviteInfo> WingInviteEvent;
        public static WingInviteInfo InvokeWingInviteEvent(WingInviteInfo arg) { WingInviteEvent?.Invoke(null, arg); return arg; }

        //StartJump
        public static event EventHandler<StartJumpInfo> StartJumpEvent;
        public static StartJumpInfo InvokeStartJumpEvent(StartJumpInfo arg) { StartJumpEvent?.Invoke(null, arg); return arg; }

        //SupercruiseExit
        public static event EventHandler<SupercruiseExitInfo> SupercruiseExitEvent;
        public static SupercruiseExitInfo InvokeSupercruiseExitEvent(SupercruiseExitInfo arg) { SupercruiseExitEvent?.Invoke(null, arg); return arg; }

        //PayBounties
        public static event EventHandler<PayBountiesInfo> PayBountiesEvent;
        public static PayBountiesInfo InvokePayBountiesEvent(PayBountiesInfo arg) { PayBountiesEvent?.Invoke(null, arg); return arg; }

        //PowerplaySalary
        public static event EventHandler<PowerplaySalaryInfo> PowerplaySalaryEvent;
        public static PowerplaySalaryInfo InvokePowerplaySalaryEvent(PowerplaySalaryInfo arg) { PowerplaySalaryEvent?.Invoke(null, arg); return arg; }

        //ShipyardTransfer
        public static event EventHandler<ShipyardTransferInfo> ShipyardTransferEvent;
        public static ShipyardTransferInfo InvokeShipyardTransferEvent(ShipyardTransferInfo arg) { ShipyardTransferEvent?.Invoke(null, arg); return arg; }

        //TechnologyBroker
        public static event EventHandler<TechnologyBrokerInfo> TechnologyBrokerEvent;
        public static TechnologyBrokerInfo InvokeTechnologyBrokerEvent(TechnologyBrokerInfo arg) { TechnologyBrokerEvent?.Invoke(null, arg); return arg; }

        //PayFines
        public static event EventHandler<PayFinesInfo> PayFinesEvent;
        public static PayFinesInfo InvokePayFinesEvent(PayFinesInfo arg) { PayFinesEvent?.Invoke(null, arg); return arg; }

        //Bounty
        public static event EventHandler<BountyInfo> BountyEvent;
        public static BountyInfo InvokeBountyEvent(BountyInfo arg) { BountyEvent?.Invoke(null, arg); return arg; }

        //MaterialTrade
        public static event EventHandler<MaterialTradeInfo> MaterialTradeEvent;
        public static MaterialTradeInfo InvokeMaterialTradeEvent(MaterialTradeInfo arg) { MaterialTradeEvent?.Invoke(null, arg); return arg; }

        //ReceiveText
        public static event EventHandler<ReceiveTextInfo> ReceiveTextEvent;
        public static ReceiveTextInfo InvokeReceiveTextEvent(ReceiveTextInfo arg) { ReceiveTextEvent?.Invoke(null, arg); return arg; }

        //ModuleSellRemote
        public static event EventHandler<ModuleSellRemoteInfo> ModuleSellRemoteEvent;
        public static ModuleSellRemoteInfo InvokeModuleSellRemoteEvent(ModuleSellRemoteInfo arg) { ModuleSellRemoteEvent?.Invoke(null, arg); return arg; }

        //ShipyardSwap
        public static event EventHandler<ShipyardSwapInfo> ShipyardSwapEvent;
        public static ShipyardSwapInfo InvokeShipyardSwapEvent(ShipyardSwapInfo arg) { ShipyardSwapEvent?.Invoke(null, arg); return arg; }

        //MarketBuy
        public static event EventHandler<MarketBuyInfo> MarketBuyEvent;
        public static MarketBuyInfo InvokeMarketBuyEvent(MarketBuyInfo arg) { MarketBuyEvent?.Invoke(null, arg); return arg; }

        //CargoDepot
        public static event EventHandler<CargoDepotInfo> CargoDepotEvent;
        public static CargoDepotInfo InvokeCargoDepotEvent(CargoDepotInfo arg) { CargoDepotEvent?.Invoke(null, arg); return arg; }

        //FactionKillBond
        public static event EventHandler<FactionKillBondInfo> FactionKillBondEvent;
        public static FactionKillBondInfo InvokeFactionKillBondEvent(FactionKillBondInfo arg) { FactionKillBondEvent?.Invoke(null, arg); return arg; }

        //StoredModules
        public static event EventHandler<StoredModulesInfo> StoredModulesEvent;
        public static StoredModulesInfo InvokeStoredModulesEvent(StoredModulesInfo arg) { StoredModulesEvent?.Invoke(null, arg); return arg; }

        //WingJoin
        public static event EventHandler<WingJoinInfo> WingJoinEvent;
        public static WingJoinInfo InvokeWingJoinEvent(WingJoinInfo arg) { WingJoinEvent?.Invoke(null, arg); return arg; }

        //ApproachBody
        public static event EventHandler<ApproachBodyInfo> ApproachBodyEvent;
        public static ApproachBodyInfo InvokeApproachBodyEvent(ApproachBodyInfo arg) { ApproachBodyEvent?.Invoke(null, arg); return arg; }

        //EngineerProgress
        public static event EventHandler<EngineerProgressInfo> EngineerProgressEvent;
        public static EngineerProgressInfo InvokeEngineerProgressEvent(EngineerProgressInfo arg) { EngineerProgressEvent?.Invoke(null, arg); return arg; }

        //FSSDiscoveryScan
        public static event EventHandler<FSSDiscoveryScanInfo> FSSDiscoveryScanEvent;
        public static FSSDiscoveryScanInfo InvokeFSSDiscoveryScanEvent(FSSDiscoveryScanInfo arg) { FSSDiscoveryScanEvent?.Invoke(null, arg); return arg; }

        //SquadronCreated
        public static event EventHandler<SquadronCreatedInfo> SquadronCreatedEvent;
        public static SquadronCreatedInfo InvokeSquadronCreatedEvent(SquadronCreatedInfo arg) { SquadronCreatedEvent?.Invoke(null, arg); return arg; }

        //Commander
        public static event EventHandler<CommanderInfo> CommanderEvent;
        public static CommanderInfo InvokeCommanderEvent(CommanderInfo arg) { CommanderEvent?.Invoke(null, arg); return arg; }

        //JoinedSquadron
        public static event EventHandler<JoinedSquadronInfo> JoinedSquadronEvent;
        public static JoinedSquadronInfo InvokeJoinedSquadronEvent(JoinedSquadronInfo arg) { JoinedSquadronEvent?.Invoke(null, arg); return arg; }

        //EjectCargo
        public static event EventHandler<EjectCargoInfo> EjectCargoEvent;
        public static EjectCargoInfo InvokeEjectCargoEvent(EjectCargoInfo arg) { EjectCargoEvent?.Invoke(null, arg); return arg; }

        //NpcCrewPaidWage
        public static event EventHandler<NpcCrewPaidWageInfo> NpcCrewPaidWageEvent;
        public static NpcCrewPaidWageInfo InvokeNpcCrewPaidWageEvent(NpcCrewPaidWageInfo arg) { NpcCrewPaidWageEvent?.Invoke(null, arg); return arg; }

        //Materials
        public static event EventHandler<MaterialsInfo> MaterialsEvent;
        public static MaterialsInfo InvokeMaterialsEvent(MaterialsInfo arg) { MaterialsEvent?.Invoke(null, arg); return arg; }

        //LoadGame
        public static event EventHandler<LoadGameInfo> LoadGameEvent;
        public static LoadGameInfo InvokeLoadGameEvent(LoadGameInfo arg) { LoadGameEvent?.Invoke(null, arg); return arg; }

        //SupercruiseEntry
        public static event EventHandler<SupercruiseEntryInfo> SupercruiseEntryEvent;
        public static SupercruiseEntryInfo InvokeSupercruiseEntryEvent(SupercruiseEntryInfo arg) { SupercruiseEntryEvent?.Invoke(null, arg); return arg; }

        //FSDTarget
        public static event EventHandler<FSDTargetInfo> FSDTargetEvent;
        public static FSDTargetInfo InvokeFSDTargetEvent(FSDTargetInfo arg) { FSDTargetEvent?.Invoke(null, arg); return arg; }

        //FSSAllBodiesFound
        public static event EventHandler<FSSAllBodiesFoundInfo> FSSAllBodiesFoundEvent;
        public static FSSAllBodiesFoundInfo InvokeFSSAllBodiesFoundEvent(FSSAllBodiesFoundInfo arg) { FSSAllBodiesFoundEvent?.Invoke(null, arg); return arg; }

        //SAAScanComplete
        public static event EventHandler<SAAScanCompleteInfo> SAAScanCompleteEvent;
        public static SAAScanCompleteInfo InvokeSAAScanCompleteEvent(SAAScanCompleteInfo arg) { SAAScanCompleteEvent?.Invoke(null, arg); return arg; }

        //CodexEntry
        public static event EventHandler<CodexEntryInfo> CodexEntryEvent;
        public static CodexEntryInfo InvokeCodexEntryEvent(CodexEntryInfo arg) { CodexEntryEvent?.Invoke(null, arg); return arg; }

        //CrimeVictim
        public static event EventHandler<CrimeVictimInfo> CrimeVictimEvent;
        public static CrimeVictimInfo InvokeCrimeVictimEvent(CrimeVictimInfo arg) { CrimeVictimEvent?.Invoke(null, arg); return arg; }

        //Loadout
        public static event EventHandler<LoadoutInfo> LoadoutEvent;
        public static LoadoutInfo InvokeLoadoutEvent(LoadoutInfo arg) { LoadoutEvent?.Invoke(null, arg); return arg; }

        //MissionCompleted
        public static event EventHandler<MissionCompletedInfo> MissionCompletedEvent;
        public static MissionCompletedInfo InvokeMissionCompletedEvent(MissionCompletedInfo arg) { MissionCompletedEvent?.Invoke(null, arg); return arg; }

        //BuyTradeData
        public static event EventHandler<BuyTradeDataInfo> BuyTradeDataEvent;
        public static BuyTradeDataInfo InvokeBuyTradeDataEvent(BuyTradeDataInfo arg) { BuyTradeDataEvent?.Invoke(null, arg); return arg; }

        //CrewAssign
        public static event EventHandler<CrewAssignInfo> CrewAssignEvent;
        public static CrewAssignInfo InvokeCrewAssignEvent(CrewAssignInfo arg) { CrewAssignEvent?.Invoke(null, arg); return arg; }

        //CrewFire
        public static event EventHandler<CrewFireInfo> CrewFireEvent;
        public static CrewFireInfo InvokeCrewFireEvent(CrewFireInfo arg) { CrewFireEvent?.Invoke(null, arg); return arg; }

        //MultiSellExplorationData
        public static event EventHandler<MultiSellExplorationDataInfo> MultiSellExplorationDataEvent;
        public static MultiSellExplorationDataInfo InvokeMultiSellExplorationDataEvent(MultiSellExplorationDataInfo arg) { MultiSellExplorationDataEvent?.Invoke(null, arg); return arg; }

        //Location
        public static event EventHandler<LocationInfo> LocationEvent;
        public static LocationInfo InvokeLocationEvent(LocationInfo arg) { LocationEvent?.Invoke(null, arg); return arg; }

        //AsteroidCracked
        public static event EventHandler<AsteroidCrackedInfo> AsteroidCrackedEvent;
        public static AsteroidCrackedInfo InvokeAsteroidCrackedEvent(AsteroidCrackedInfo arg) { AsteroidCrackedEvent?.Invoke(null, arg); return arg; }

        //ModuleSwap
        public static event EventHandler<ModuleSwapInfo> ModuleSwapEvent;
        public static ModuleSwapInfo InvokeModuleSwapEvent(ModuleSwapInfo arg) { ModuleSwapEvent?.Invoke(null, arg); return arg; }

        //DataScanned
        public static event EventHandler<DataScannedInfo> DataScannedEvent;
        public static DataScannedInfo InvokeDataScannedEvent(DataScannedInfo arg) { DataScannedEvent?.Invoke(null, arg); return arg; }

        //DisbandedSquadron
        public static event EventHandler<DisbandedSquadronInfo> DisbandedSquadronEvent;
        public static DisbandedSquadronInfo InvokeDisbandedSquadronEvent(DisbandedSquadronInfo arg) { DisbandedSquadronEvent?.Invoke(null, arg); return arg; }

        //AppliedToSquadron
        public static event EventHandler<AppliedToSquadronInfo> AppliedToSquadronEvent;
        public static AppliedToSquadronInfo InvokeAppliedToSquadronEvent(AppliedToSquadronInfo arg) { AppliedToSquadronEvent?.Invoke(null, arg); return arg; }

        //Docked
        public static event EventHandler<DockedInfo> DockedEvent;
        public static DockedInfo InvokeDockedEvent(DockedInfo arg) { DockedEvent?.Invoke(null, arg); return arg; }

        //Statistics
        public static event EventHandler<StatisticsInfo> StatisticsEvent;
        public static StatisticsInfo InvokeStatisticsEvent(StatisticsInfo arg) { StatisticsEvent?.Invoke(null, arg); return arg; }

        //SetUserShipName
        public static event EventHandler<SetUserShipNameInfo> SetUserShipNameEvent;
        public static SetUserShipNameInfo InvokeSetUserShipNameEvent(SetUserShipNameInfo arg) { SetUserShipNameEvent?.Invoke(null, arg); return arg; }

        //FSDJump
        public static event EventHandler<FSDJumpInfo> FSDJumpEvent;
        public static FSDJumpInfo InvokeFSDJumpEvent(FSDJumpInfo arg) { FSDJumpEvent?.Invoke(null, arg); return arg; }

        //Cargo
        public static event EventHandler<CargoInfo> CargoEvent;
        public static CargoInfo InvokeCargoEvent(CargoInfo arg) { CargoEvent?.Invoke(null, arg); return arg; }

        //EngineerCraft
        public static event EventHandler<EngineerCraftInfo> EngineerCraftEvent;
        public static EngineerCraftInfo InvokeEngineerCraftEvent(EngineerCraftInfo arg) { EngineerCraftEvent?.Invoke(null, arg); return arg; }

        //ApproachSettlement
        public static event EventHandler<ApproachSettlementInfo> ApproachSettlementEvent;
        public static ApproachSettlementInfo InvokeApproachSettlementEvent(ApproachSettlementInfo arg) { ApproachSettlementEvent?.Invoke(null, arg); return arg; }

        //StoredShips
        public static event EventHandler<StoredShipsInfo> StoredShipsEvent;
        public static StoredShipsInfo InvokeStoredShipsEvent(StoredShipsInfo arg) { StoredShipsEvent?.Invoke(null, arg); return arg; }

        //FSSSignalDiscovered
        public static event EventHandler<FSSSignalDiscoveredInfo> FSSSignalDiscoveredEvent;
        public static FSSSignalDiscoveredInfo InvokeFSSSignalDiscoveredEvent(FSSSignalDiscoveredInfo arg) { FSSSignalDiscoveredEvent?.Invoke(null, arg); return arg; }

    }
}