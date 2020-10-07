using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Models.Exploration;
using EliteAPI.Event.Models.Startup;
using EliteAPI.Event.Models.Travel;

namespace EliteAPI.Event.Handler
{
    public class EventHandler
    {
        //AllEvents
        public event EventHandler<EventBase> AllEvent;

        internal void InvokeAllEvent(EventBase arg) => AllEvent?.Invoke(null, arg);

        //SAASignalsFoundEvent
        public event EventHandler<SAASignalsFoundEvent> SAASignalsFoundEvent;
        internal void InvokeSAASignalsFoundEvent(SAASignalsFoundEvent arg) => SAASignalsFoundEvent?.Invoke(null, arg);


        //NavRoute
        public event EventHandler<NavRouteEvent> NavRouteEvent;

        internal void InvokeNavRouteEvent(NavRouteEvent arg) => NavRouteEvent?.Invoke(null, arg);

        //ReservoirReplenished
        public event EventHandler<ReservoirReplenishedEvent> ReservoirReplenishedEvent;

        internal void InvokeReservoirReplenishedEvent(ReservoirReplenishedEvent arg) => ReservoirReplenishedEvent?.Invoke(null, arg);

        //ProspectedAsteroid
        public event EventHandler<ProspectedAsteroidEvent> ProspectedAsteroidEvent;

        internal void InvokeProspectedAsteroidEvent(ProspectedAsteroidEvent arg) => ProspectedAsteroidEvent?.Invoke(null, arg);

        //LeftSquadron
        public event EventHandler<LeftSquadronEvent> LeftSquadronEvent;

        internal void InvokeLeftSquadronEvent(LeftSquadronEvent arg) => LeftSquadronEvent?.Invoke(null, arg);

        //HeatWarning
        public event EventHandler<HeatWarningEvent> HeatWarningEvent;

        internal void InvokeHeatWarningEvent(HeatWarningEvent arg) => HeatWarningEvent?.Invoke(null, arg);

        //ShieldState
        public event EventHandler<ShieldStateEvent> ShieldStateEvent;

        internal void InvokeShieldStateEvent(ShieldStateEvent arg) => ShieldStateEvent?.Invoke(null, arg);

        //VehicleSwitch
        public event EventHandler<VehicleSwitchEvent> VehicleSwitchEvent;

        internal void InvokeVehicleSwitchEvent(VehicleSwitchEvent arg) => VehicleSwitchEvent?.Invoke(null, arg);

        //DockFighter
        public event EventHandler<DockFighterEvent> DockFighterEvent;

        internal void InvokeDockFighterEvent(DockFighterEvent arg) => DockFighterEvent?.Invoke(null, arg);

        //LaunchSRV
        public event EventHandler<LaunchSRVEvent> LaunchSRVEvent;

        internal void InvokeLaunchSRVEvent(LaunchSRVEvent arg) => LaunchSRVEvent?.Invoke(null, arg);

        //SelfDestruct
        public event EventHandler<SelfDestructEvent> SelfDestructEvent;

        internal void InvokeSelfDestructEvent(SelfDestructEvent arg) => SelfDestructEvent?.Invoke(null, arg);

        //DockSRV
        public event EventHandler<DockSRVEvent> DockSRVEvent;

        internal void InvokeDockSRVEvent(DockSRVEvent arg) => DockSRVEvent?.Invoke(null, arg);

        //HeatDamage
        public event EventHandler<HeatDamageEvent> HeatDamageEvent;

        internal void InvokeHeatDamageEvent(HeatDamageEvent arg) => HeatDamageEvent?.Invoke(null, arg);

        //LaunchFighter
        public event EventHandler<LaunchFighterEvent> LaunchFighterEvent;

        internal void InvokeLaunchFighterEvent(LaunchFighterEvent arg) => LaunchFighterEvent?.Invoke(null, arg);

        //DatalinkScan
        public event EventHandler<DatalinkScanEvent> DatalinkScanEvent;

        internal void InvokeDatalinkScanEvent(DatalinkScanEvent arg) => DatalinkScanEvent?.Invoke(null, arg);

        //CockpitBreached
        public event EventHandler<CockpitBreachedEvent> CockpitBreachedEvent;

        internal void InvokeCockpitBreachedEvent(CockpitBreachedEvent arg) => CockpitBreachedEvent?.Invoke(null, arg);

        //JetConeBoost
        public event EventHandler<JetConeBoostEvent> JetConeBoostEvent;

        internal void InvokeJetConeBoostEvent(JetConeBoostEvent arg) => JetConeBoostEvent?.Invoke(null, arg);

        //PowerplayLeave
        public event EventHandler<PowerplayLeaveEvent> PowerplayLeaveEvent;

        internal void InvokePowerplayLeaveEvent(PowerplayLeaveEvent arg) => PowerplayLeaveEvent?.Invoke(null, arg);

        //Interdiction
        public event EventHandler<InterdictionEvent> InterdictionEvent;

        internal void InvokeInterdictionEvent(InterdictionEvent arg) => InterdictionEvent?.Invoke(null, arg);

        //USSDrop
        public event EventHandler<USSDropEvent> USSDropEvent;

        internal void InvokeUSSDropEvent(USSDropEvent arg) => USSDropEvent?.Invoke(null, arg);

        //PowerplayCollect
        public event EventHandler<PowerplayCollectEvent> PowerplayCollectEvent;

        internal void InvokePowerplayCollectEvent(PowerplayCollectEvent arg) => PowerplayCollectEvent?.Invoke(null, arg);

        //PowerplayDeliver
        public event EventHandler<PowerplayDeliverEvent> PowerplayDeliverEvent;

        internal void InvokePowerplayDeliverEvent(PowerplayDeliverEvent arg) => PowerplayDeliverEvent?.Invoke(null, arg);

        //PayLegacyFines
        public event EventHandler<PayLegacyFinesEvent> PayLegacyFinesEvent;

        internal void InvokePayLegacyFinesEvent(PayLegacyFinesEvent arg) => PayLegacyFinesEvent?.Invoke(null, arg);

        //EngineerApply
        public event EventHandler<EngineerApplyEvent> EngineerApplyEvent;

        internal void InvokeEngineerApplyEvent(EngineerApplyEvent arg) => EngineerApplyEvent?.Invoke(null, arg);

        //WingLeave
        public event EventHandler<WingLeaveEvent> WingLeaveEvent;

        internal void InvokeWingLeaveEvent(WingLeaveEvent arg) => WingLeaveEvent?.Invoke(null, arg);

        //SystemsShutdown
        public event EventHandler<SystemsShutdownEvent> SystemsShutdownEvent;

        internal void InvokeSystemsShutdownEvent(SystemsShutdownEvent arg) => SystemsShutdownEvent?.Invoke(null, arg);

        //HullDamage
        public event EventHandler<HullDamageEvent> HullDamageEvent;

        internal void InvokeHullDamageEvent(HullDamageEvent arg) => HullDamageEvent?.Invoke(null, arg);

        //BuyDrones
        public event EventHandler<BuyDronesEvent> BuyDronesEvent;

        internal void InvokeBuyDronesEvent(BuyDronesEvent arg) => BuyDronesEvent?.Invoke(null, arg);

        //RestockVehicle
        public event EventHandler<RestockVehicleEvent> RestockVehicleEvent;

        internal void InvokeRestockVehicleEvent(RestockVehicleEvent arg) => RestockVehicleEvent?.Invoke(null, arg);

        //BuyAmmo
        public event EventHandler<BuyAmmoEvent> BuyAmmoEvent;

        internal void InvokeBuyAmmoEvent(BuyAmmoEvent arg) => BuyAmmoEvent?.Invoke(null, arg);

        //MiningRefined
        public event EventHandler<MiningRefinedEvent> MiningRefinedEvent;

        internal void InvokeMiningRefinedEvent(MiningRefinedEvent arg) => MiningRefinedEvent?.Invoke(null, arg);

        //DatalinkVoucher
        public event EventHandler<DatalinkVoucherEvent> DatalinkVoucherEvent;

        internal void InvokeDatalinkVoucherEvent(DatalinkVoucherEvent arg) => DatalinkVoucherEvent?.Invoke(null, arg);

        //Scanned
        public event EventHandler<ScannedEvent> ScannedEvent;

        internal void InvokeScannedEvent(ScannedEvent arg) => ScannedEvent?.Invoke(null, arg);

        //ChangeCrewRole
        public event EventHandler<ChangeCrewRoleEvent> ChangeCrewRoleEvent;

        internal void InvokeChangeCrewRoleEvent(ChangeCrewRoleEvent arg) => ChangeCrewRoleEvent?.Invoke(null, arg);

        //Touchdown
        public event EventHandler<TouchdownEvent> TouchdownEvent;

        internal void InvokeTouchdownEvent(TouchdownEvent arg) => TouchdownEvent?.Invoke(null, arg);

        //SendText
        public event EventHandler<SendTextEvent> SendTextEvent;

        internal void InvokeSendTextEvent(SendTextEvent arg) => SendTextEvent?.Invoke(null, arg);

        //RefuelAll
        public event EventHandler<RefuelAllEvent> RefuelAllEvent;

        internal void InvokeRefuelAllEvent(RefuelAllEvent arg) => RefuelAllEvent?.Invoke(null, arg);

        //EndCrewSession
        public event EventHandler<EndCrewSessionEvent> EndCrewSessionEvent;

        internal void InvokeEndCrewSessionEvent(EndCrewSessionEvent arg) => EndCrewSessionEvent?.Invoke(null, arg);

        //Liftoff
        public event EventHandler<LiftoffEvent> LiftoffEvent;

        internal void InvokeLiftoffEvent(LiftoffEvent arg) => LiftoffEvent?.Invoke(null, arg);

        //EscapeInterdiction
        public event EventHandler<EscapeInterdictionEvent> EscapeInterdictionEvent;

        internal void InvokeEscapeInterdictionEvent(EscapeInterdictionEvent arg) => EscapeInterdictionEvent?.Invoke(null, arg);

        //WingAdd
        public event EventHandler<WingAddEvent> WingAddEvent;

        internal void InvokeWingAddEvent(WingAddEvent arg) => WingAddEvent?.Invoke(null, arg);

        //SellDrones
        public event EventHandler<SellDronesEvent> SellDronesEvent;

        internal void InvokeSellDronesEvent(SellDronesEvent arg) => SellDronesEvent?.Invoke(null, arg);

        //Fileheader
        public event EventHandler<FileheaderEvent> FileheaderEvent;

        internal void InvokeFileheaderEvent(FileheaderEvent arg) => FileheaderEvent?.Invoke(null, arg);

        //Interdicted
        public event EventHandler<InterdictedEvent> InterdictedEvent;

        internal void InvokeInterdictedEvent(InterdictedEvent arg) => InterdictedEvent?.Invoke(null, arg);

        //CrewMemberJoins
        public event EventHandler<CrewMemberJoinsEvent> CrewMemberJoinsEvent;

        internal void InvokeCrewMemberJoinsEvent(CrewMemberJoinsEvent arg) => CrewMemberJoinsEvent?.Invoke(null, arg);

        //CrewMemberQuits
        public event EventHandler<CrewMemberQuitsEvent> CrewMemberQuitsEvent;

        internal void InvokeCrewMemberQuitsEvent(CrewMemberQuitsEvent arg) => CrewMemberQuitsEvent?.Invoke(null, arg);

        //CrewMemberRoleChange
        public event EventHandler<CrewMemberRoleChangeEvent> CrewMemberRoleChangeEvent;

        internal void InvokeCrewMemberRoleChangeEvent(CrewMemberRoleChangeEvent arg) => CrewMemberRoleChangeEvent?.Invoke(null, arg);

        //PVPKill
        public event EventHandler<PVPKillEvent> PVPKillEvent;

        internal void InvokePVPKillEvent(PVPKillEvent arg) => PVPKillEvent?.Invoke(null, arg);

        //JoinACrew
        public event EventHandler<JoinACrewEvent> JoinACrewEvent;

        internal void InvokeJoinACrewEvent(JoinACrewEvent arg) => JoinACrewEvent?.Invoke(null, arg);

        //QuitACrew
        public event EventHandler<QuitACrewEvent> QuitACrewEvent;

        internal void InvokeQuitACrewEvent(QuitACrewEvent arg) => QuitACrewEvent?.Invoke(null, arg);

        //Progress
        public event EventHandler<ProgressEvent> ProgressEvent;

        internal void InvokeProgressEvent(ProgressEvent arg) => ProgressEvent?.Invoke(null, arg);

        //Promotion
        public event EventHandler<PromotionEvent> PromotionEvent;

        internal void InvokePromotionEvent(PromotionEvent arg) => PromotionEvent?.Invoke(null, arg);

        //Rank
        public event EventHandler<RankEvent> RankEvent;

        internal void InvokeRankEvent(RankEvent arg) => RankEvent?.Invoke(null, arg);

        //CommitCrime
        public event EventHandler<CommitCrimeEvent> CommitCrimeEvent;

        internal void InvokeCommitCrimeEvent(CommitCrimeEvent arg) => CommitCrimeEvent?.Invoke(null, arg);

        //EngineerContribution
        public event EventHandler<EngineerContributionEvent> EngineerContributionEvent;

        internal void InvokeEngineerContributionEvent(EngineerContributionEvent arg) => EngineerContributionEvent?.Invoke(null, arg);

        //Music
        public event EventHandler<MusicEvent> MusicEvent;

        internal void InvokeMusicEvent(MusicEvent arg) => MusicEvent?.Invoke(null, arg);

        //Died
        public event EventHandler<DiedEvent> DiedEvent;

        internal void InvokeDiedEvent(DiedEvent arg) => DiedEvent?.Invoke(null, arg);

        //Passengers
        public event EventHandler<PassengersEvent> PassengersEvent;

        internal void InvokePassengersEvent(PassengersEvent arg) => PassengersEvent?.Invoke(null, arg);

        //SearchAndRescue
        public event EventHandler<SearchAndRescueEvent> SearchAndRescueEvent;

        internal void InvokeSearchAndRescueEvent(SearchAndRescueEvent arg) => SearchAndRescueEvent?.Invoke(null, arg);

        //KickCrewMember
        public event EventHandler<KickCrewMemberEvent> KickCrewMemberEvent;

        internal void InvokeKickCrewMemberEvent(KickCrewMemberEvent arg) => KickCrewMemberEvent?.Invoke(null, arg);

        //RedeemVoucher
        public event EventHandler<RedeemVoucherEvent> RedeemVoucherEvent;

        internal void InvokeRedeemVoucherEvent(RedeemVoucherEvent arg) => RedeemVoucherEvent?.Invoke(null, arg);

        //Resurrect
        public event EventHandler<ResurrectEvent> ResurrectEvent;

        internal void InvokeResurrectEvent(ResurrectEvent arg) => ResurrectEvent?.Invoke(null, arg);

        //CommunityGoalJoin
        public event EventHandler<CommunityGoalJoinEvent> CommunityGoalJoinEvent;

        internal void InvokeCommunityGoalJoinEvent(CommunityGoalJoinEvent arg) => CommunityGoalJoinEvent?.Invoke(null, arg);

        //CommunityGoal
        public event EventHandler<CommunityGoalEvent> CommunityGoalEvent;

        internal void InvokeCommunityGoalEvent(CommunityGoalEvent arg) => CommunityGoalEvent?.Invoke(null, arg);

        //RepairDrone
        public event EventHandler<RepairDroneEvent> RepairDroneEvent;

        internal void InvokeRepairDroneEvent(RepairDroneEvent arg) => RepairDroneEvent?.Invoke(null, arg);

        //Repair
        public event EventHandler<RepairEvent> RepairEvent;

        internal void InvokeRepairEvent(RepairEvent arg) => RepairEvent?.Invoke(null, arg);

        //JetConeDamage
        public event EventHandler<JetConeDamageEvent> JetConeDamageEvent;

        internal void InvokeJetConeDamageEvent(JetConeDamageEvent arg) => JetConeDamageEvent?.Invoke(null, arg);

        //CommunityGoalDiscard
        public event EventHandler<CommunityGoalDiscardEvent> CommunityGoalDiscardEvent;

        internal void InvokeCommunityGoalDiscard(CommunityGoalDiscardEvent arg) => CommunityGoalDiscardEvent?.Invoke(null, arg);

        //MissionAccepted
        public event EventHandler<MissionAcceptedEvent> MissionAcceptedEvent;

        internal void InvokeMissionAcceptedEvent(MissionAcceptedEvent arg) => MissionAcceptedEvent?.Invoke(null, arg);

        //BuyExplorationData
        public event EventHandler<BuyExplorationDataEvent> BuyExplorationDataEvent;

        internal void InvokeBuyExplorationDataEvent(BuyExplorationDataEvent arg) => BuyExplorationDataEvent?.Invoke(null, arg);

        //RepairAll
        public event EventHandler<RepairAllEvent> RepairAllEvent;

        internal void InvokeRepairAllEvent(RepairAllEvent arg) => RepairAllEvent?.Invoke(null, arg);

        //CrewLaunchFighter
        public event EventHandler<CrewLaunchFighterEvent> CrewLaunchFighterEvent;

        internal void InvokeCrewLaunchFighterEvent(CrewLaunchFighterEvent arg) => CrewLaunchFighterEvent?.Invoke(null, arg);

        //MaterialDiscarded
        public event EventHandler<MaterialDiscardedEvent> MaterialDiscardedEvent;

        internal void InvokeMaterialDiscardedEvent(MaterialDiscardedEvent arg) => MaterialDiscardedEvent?.Invoke(null, arg);

        //NewCommander
        public event EventHandler<NewCommanderEvent> NewCommanderEvent;

        internal void InvokeNewCommanderEvent(NewCommanderEvent arg) => NewCommanderEvent?.Invoke(null, arg);

        //CommunityGoalReward
        public event EventHandler<CommunityGoalRewardEvent> CommunityGoalRewardEvent;

        internal void InvokeCommunityGoalRewardEvent(CommunityGoalRewardEvent arg) => CommunityGoalRewardEvent?.Invoke(null, arg);

        //PowerplayVote
        public event EventHandler<PowerplayVoteEvent> PowerplayVoteEvent;

        internal void InvokePowerplayVoteEvent(PowerplayVoteEvent arg) => PowerplayVoteEvent?.Invoke(null, arg);

        //PowerplayJoin
        public event EventHandler<PowerplayJoinEvent> PowerplayJoinEvent;

        internal void InvokePowerplayJoinEvent(PowerplayJoinEvent arg) => PowerplayJoinEvent?.Invoke(null, arg);

        //PowerplayDefect
        public event EventHandler<PowerplayDefectEvent> PowerplayDefectEvent;

        internal void InvokePowerplayDefectEvent(PowerplayDefectEvent arg) => PowerplayDefectEvent?.Invoke(null, arg);

        //MissionFailed
        public event EventHandler<MissionFailedEvent> MissionFailedEvent;

        internal void InvokeMissionFailedEvent(MissionFailedEvent arg) => MissionFailedEvent?.Invoke(null, arg);

        //MissionRedirected
        public event EventHandler<MissionRedirectedEvent> MissionRedirectedEvent;

        internal void InvokeMissionRedirectedEvent(MissionRedirectedEvent arg) => MissionRedirectedEvent?.Invoke(null, arg);

        //Shutdown
        public event EventHandler<ShutdownEvent> ShutdownEvent;

        internal void InvokeShutdownEvent(ShutdownEvent arg) => ShutdownEvent?.Invoke(null, arg);

        //ModuleEvent
        public event EventHandler<ModuleInfoEvent> ModuleEventEvent;

        internal void InvokeModuleEventEvent(ModuleInfoEvent arg) => ModuleEventEvent?.Invoke(null, arg);

        //Market
        public event EventHandler<MarketEvent> MarketEvent;

        internal void InvokeMarketEvent(MarketEvent arg) => MarketEvent?.Invoke(null, arg);

        //MassModuleStore
        public event EventHandler<MassModuleStoreEvent> MassModuleStoreEvent;

        internal void InvokeMassModuleStoreEvent(MassModuleStoreEvent arg) => MassModuleStoreEvent?.Invoke(null, arg);

        //MaterialDiscovered
        public event EventHandler<MaterialDiscoveredEvent> MaterialDiscoveredEvent;

        internal void InvokeMaterialDiscoveredEvent(MaterialDiscoveredEvent arg) => MaterialDiscoveredEvent?.Invoke(null, arg);

        //MaterialCollected
        public event EventHandler<MaterialCollectedEvent> MaterialCollectedEvent;

        internal void InvokeMaterialCollectedEvent(MaterialCollectedEvent arg) => MaterialCollectedEvent?.Invoke(null, arg);

        //SRVDestroyed
        public event EventHandler<SRVDestroyedEvent> SRVDestroyedEvent;

        internal void InvokeSRVDestroyedEvent(SRVDestroyedEvent arg) => SRVDestroyedEvent?.Invoke(null, arg);

        //DockingDenied
        public event EventHandler<DockingDeniedEvent> DockingDeniedEvent;

        internal void InvokeDockingDeniedEvent(DockingDeniedEvent arg) => DockingDeniedEvent?.Invoke(null, arg);

        //UnderAttack
        public event EventHandler<UnderAttackEvent> UnderAttackEvent;

        internal void InvokeUnderAttackEvent(UnderAttackEvent arg) => UnderAttackEvent?.Invoke(null, arg);

        //ShipTargeted
        public event EventHandler<ShipTargetedEvent> ShipTargetedEvent;

        internal void InvokeShipTargetedEvent(ShipTargetedEvent arg) => ShipTargetedEvent?.Invoke(null, arg);

        //Shipyard
        public event EventHandler<ShipyardEvent> ShipyardEvent;

        internal void InvokeShipyardEvent(ShipyardEvent arg) => ShipyardEvent?.Invoke(null, arg);

        //Outfitting
        public event EventHandler<OutfittingEvent> OutfittingEvent;

        internal void InvokeOutfittingEvent(OutfittingEvent arg) => OutfittingEvent?.Invoke(null, arg);

        //PowerplayFastTrack
        public event EventHandler<PowerplayFastTrackEvent> PowerplayFastTrackEvent;

        internal void InvokePowerplayFastTrackEvent(PowerplayFastTrackEvent arg) => PowerplayFastTrackEvent?.Invoke(null, arg);

        //Powerplay
        public event EventHandler<PowerplayEvent> PowerplayEvent;

        internal void InvokePowerplayEvent(PowerplayEvent arg) => PowerplayEvent?.Invoke(null, arg);

        //CollectCargo
        public event EventHandler<CollectCargoEvent> CollectCargoEvent;

        internal void InvokeCollectCargoEvent(CollectCargoEvent arg) => CollectCargoEvent?.Invoke(null, arg);

        //FetchRemoteModule
        public event EventHandler<FetchRemoteModuleEvent> FetchRemoteModuleEvent;

        internal void InvokeFetchRemoteModuleEvent(FetchRemoteModuleEvent arg) => FetchRemoteModuleEvent?.Invoke(null, arg);

        //ModuleStore
        public event EventHandler<ModuleStoreEvent> ModuleStoreEvent;

        internal void InvokeModuleStoreEvent(ModuleStoreEvent arg) => ModuleStoreEvent?.Invoke(null, arg);

        //ShipyardBuy
        public event EventHandler<ShipyardBuyEvent> ShipyardBuyEvent;

        internal void InvokeShipyardBuyEvent(ShipyardBuyEvent arg) => ShipyardBuyEvent?.Invoke(null, arg);

        //ShipyardNew
        public event EventHandler<ShipyardNewEvent> ShipyardNewEvent;

        internal void InvokeShipyardNewEvent(ShipyardNewEvent arg) => ShipyardNewEvent?.Invoke(null, arg);

        //ModuleBuy
        public event EventHandler<ModuleBuyEvent> ModuleBuyEvent;

        internal void InvokeModuleBuyEvent(ModuleBuyEvent arg) => ModuleBuyEvent?.Invoke(null, arg);

        //ModuleRetrieve
        public event EventHandler<ModuleRetrieveEvent> ModuleRetrieveEvent;

        internal void InvokeModuleRetrieveEvent(ModuleRetrieveEvent arg) => ModuleRetrieveEvent?.Invoke(null, arg);

        //AfmuRepairs
        public event EventHandler<AfmuRepairsEvent> AfmuRepairsEvent;

        internal void InvokeAfmuRepairsEvent(AfmuRepairsEvent arg) => AfmuRepairsEvent?.Invoke(null, arg);

        //LaunchDrone
        public event EventHandler<LaunchDroneEvent> LaunchDroneEvent;

        internal void InvokeLaunchDroneEvent(LaunchDroneEvent arg) => LaunchDroneEvent?.Invoke(null, arg);

        //MarketSell
        public event EventHandler<MarketSellEvent> MarketSellEvent;

        internal void InvokeMarketSellEvent(MarketSellEvent arg) => MarketSellEvent?.Invoke(null, arg);

        //ModuleSell
        public event EventHandler<ModuleSellEvent> ModuleSellEvent;

        internal void InvokeModuleSellEvent(ModuleSellEvent arg) => ModuleSellEvent?.Invoke(null, arg);

        //FuelScoop
        public event EventHandler<FuelScoopEvent> FuelScoopEvent;

        internal void InvokeFuelScoopEvent(FuelScoopEvent arg) => FuelScoopEvent?.Invoke(null, arg);

        //FighterDestroyed
        public event EventHandler<FighterDestroyedEvent> FighterDestroyedEvent;

        internal void InvokeFighterDestroyedEvent(FighterDestroyedEvent arg) => FighterDestroyedEvent?.Invoke(null, arg);

        //DiscoveryScan
        public event EventHandler<DiscoveryScanEvent> DiscoveryScanEvent;

        internal void InvokeDiscoveryScanEvent(DiscoveryScanEvent arg) => DiscoveryScanEvent?.Invoke(null, arg);

        //LeaveBody
        public event EventHandler<LeaveBodyEvent> LeaveBodyEvent;

        internal void InvokeLeaveBodyEvent(LeaveBodyEvent arg) => LeaveBodyEvent?.Invoke(null, arg);

        //PowerplayVoucher
        public event EventHandler<PowerplayVoucherEvent> PowerplayVoucherEvent;

        internal void InvokePowerplayVoucherEvent(PowerplayVoucherEvent arg) => PowerplayVoucherEvent?.Invoke(null, arg);

        //Reputation
        public event EventHandler<ReputationEvent> ReputationEvent;

        internal void InvokeReputationEvent(ReputationEvent arg) => ReputationEvent?.Invoke(null, arg);

        //NavBeaconScan
        public event EventHandler<NavBeaconScanEvent> NavBeaconScanEvent;

        internal void InvokeNavBeaconScanEvent(NavBeaconScanEvent arg) => NavBeaconScanEvent?.Invoke(null, arg);

        //Missions
        public event EventHandler<MissionsEvent> MissionsEvent;

        internal void InvokeMissionsEvent(MissionsEvent arg) => MissionsEvent?.Invoke(null, arg);

        //Friends
        public event EventHandler<FriendsEvent> FriendsEvent;

        internal void InvokeFriendsEvent(FriendsEvent arg) => FriendsEvent?.Invoke(null, arg);

        //ShipyardSell
        public event EventHandler<ShipyardSellEvent> ShipyardSellEvent;

        internal void InvokeShipyardSellEvent(ShipyardSellEvent arg) => ShipyardSellEvent?.Invoke(null, arg);

        //MissionAbandoned
        public event EventHandler<MissionAbandonedEvent> MissionAbandonedEvent;

        internal void InvokeMissionAbandonedEvent(MissionAbandonedEvent arg) => MissionAbandonedEvent?.Invoke(null, arg);

        //ScientificResearch
        public event EventHandler<ScientificResearchEvent> ScientificResearchEvent;

        internal void InvokeScientificResearchEvent(ScientificResearchEvent arg) => ScientificResearchEvent?.Invoke(null, arg);

        //DockingTimeout
        public event EventHandler<DockingTimeoutEvent> DockingTimeoutEvent;

        internal void InvokeDockingTimeoutEvent(DockingTimeoutEvent arg) => DockingTimeoutEvent?.Invoke(null, arg);

        //DockingCancelled
        public event EventHandler<DockingCancelledEvent> DockingCancelledEvent;

        internal void InvokeDockingCancelledEvent(DockingCancelledEvent arg) => DockingCancelledEvent?.Invoke(null, arg);

        //DockingRequested
        public event EventHandler<DockingRequestedEvent> DockingRequestedEvent;

        internal void InvokeDockingRequestedEvent(DockingRequestedEvent arg) => DockingRequestedEvent?.Invoke(null, arg);

        //DockingGranted
        public event EventHandler<DockingGrantedEvent> DockingGrantedEvent;

        internal void InvokeDockingGrantedEvent(DockingGrantedEvent arg) => DockingGrantedEvent?.Invoke(null, arg);

        //Undocked
        public event EventHandler<UndockedEvent> UndockedEvent;

        internal void InvokeUndockedEvent(UndockedEvent arg) => UndockedEvent?.Invoke(null, arg);

        //CrewHire
        public event EventHandler<CrewHireEvent> CrewHireEvent;

        internal void InvokeCrewHireEvent(CrewHireEvent arg) => CrewHireEvent?.Invoke(null, arg);

        //Screenshot
        public event EventHandler<ScreenshotEvent> ScreenshotEvent;

        internal void InvokeScreenshotEvent(ScreenshotEvent arg) => ScreenshotEvent?.Invoke(null, arg);

        //Synthesis
        public event EventHandler<SynthesisEvent> SynthesisEvent;

        internal void InvokeSynthesisEvent(SynthesisEvent arg) => SynthesisEvent?.Invoke(null, arg);

        //FighterRebuilt
        public event EventHandler<FighterRebuiltEvent> FighterRebuiltEvent;

        internal void InvokeFighterRebuiltEvent(FighterRebuiltEvent arg) => FighterRebuiltEvent?.Invoke(null, arg);

        //SellExplorationData
        public event EventHandler<SellExplorationDataEvent> SellExplorationDataEvent;

        internal void InvokeSellExplorationDataEvent(SellExplorationDataEvent arg) => SellExplorationDataEvent?.Invoke(null, arg);

        //RebootRepair
        public event EventHandler<RebootRepairEvent> RebootRepairEvent;

        internal void InvokeRebootRepairEvent(RebootRepairEvent arg) => RebootRepairEvent?.Invoke(null, arg);

        //Scan
        public event EventHandler<ScanEvent> ScanEvent;

        internal void InvokeScanEvent(ScanEvent arg) => ScanEvent?.Invoke(null, arg);

        //WingInvite
        public event EventHandler<WingInviteEvent> WingInviteEvent;

        internal void InvokeWingInviteEvent(WingInviteEvent arg) => WingInviteEvent?.Invoke(null, arg);

        //StartJump
        public event EventHandler<StartJumpEvent> StartJumpEvent;

        internal void InvokeStartJumpEvent(StartJumpEvent arg) => StartJumpEvent?.Invoke(null, arg);

        //SupercruiseExit
        public event EventHandler<SupercruiseExitEvent> SupercruiseExitEvent;

        internal void InvokeSupercruiseExitEvent(SupercruiseExitEvent arg) => SupercruiseExitEvent?.Invoke(null, arg);

        //PayBounties
        public event EventHandler<PayBountiesEvent> PayBountiesEvent;

        internal void InvokePayBountiesEvent(PayBountiesEvent arg) => PayBountiesEvent?.Invoke(null, arg);

        //PowerplaySalary
        public event EventHandler<PowerplaySalaryEvent> PowerplaySalaryEvent;

        internal void InvokePowerplaySalaryEvent(PowerplaySalaryEvent arg) => PowerplaySalaryEvent?.Invoke(null, arg);

        //ShipyardTransfer
        public event EventHandler<ShipyardTransferEvent> ShipyardTransferEvent;

        internal void InvokeShipyardTransferEvent(ShipyardTransferEvent arg) => ShipyardTransferEvent?.Invoke(null, arg);

        //TechnologyBroker
        public event EventHandler<TechnologyBrokerEvent> TechnologyBrokerEvent;

        internal void InvokeTechnologyBrokerEvent(TechnologyBrokerEvent arg) => TechnologyBrokerEvent?.Invoke(null, arg);

        //PayFines
        public event EventHandler<PayFinesEvent> PayFinesEvent;

        internal void InvokePayFinesEvent(PayFinesEvent arg) => PayFinesEvent?.Invoke(null, arg);

        //Bounty
        public event EventHandler<BountyEvent> BountyEvent;

        internal void InvokeBountyEvent(BountyEvent arg) => BountyEvent?.Invoke(null, arg);

        //MaterialTrade
        public event EventHandler<MaterialTradeEvent> MaterialTradeEvent;

        internal void InvokeMaterialTradeEvent(MaterialTradeEvent arg) => MaterialTradeEvent?.Invoke(null, arg);

        //ReceiveText
        public event EventHandler<ReceiveTextEvent> ReceiveTextEvent;

        internal void InvokeReceiveTextEvent(ReceiveTextEvent arg) => ReceiveTextEvent?.Invoke(null, arg);

        //ModuleSellRemote
        public event EventHandler<ModuleSellRemoteEvent> ModuleSellRemoteEvent;

        internal void InvokeModuleSellRemoteEvent(ModuleSellRemoteEvent arg) => ModuleSellRemoteEvent?.Invoke(null, arg);

        //ShipyardSwap
        public event EventHandler<ShipyardSwapEvent> ShipyardSwapEvent;

        internal void InvokeShipyardSwapEvent(ShipyardSwapEvent arg) => ShipyardSwapEvent?.Invoke(null, arg);

        //MarketBuy
        public event EventHandler<MarketBuyEvent> MarketBuyEvent;

        internal void InvokeMarketBuyEvent(MarketBuyEvent arg) => MarketBuyEvent?.Invoke(null, arg);

        //CargoDepot
        public event EventHandler<CargoDepotEvent> CargoDepotEvent;

        internal void InvokeCargoDepotEvent(CargoDepotEvent arg) => CargoDepotEvent?.Invoke(null, arg);

        //KillBond
        public event EventHandler<FactionKillBondEvent> FactionKillBondEvent;

        internal void InvokeFactionKillBondEvent(FactionKillBondEvent arg) => FactionKillBondEvent?.Invoke(null, arg);

        //StoredModules
        public event EventHandler<StoredModulesEvent> StoredModulesEvent;

        internal void InvokeStoredModulesEvent(StoredModulesEvent arg) => StoredModulesEvent?.Invoke(null, arg);

        //WingJoin
        public event EventHandler<WingJoinEvent> WingJoinEvent;

        internal void InvokeWingJoinEvent(WingJoinEvent arg) => WingJoinEvent?.Invoke(null, arg);

        //ApproachBody
        public event EventHandler<ApproachBodyEvent> ApproachBodyEvent;

        internal void InvokeApproachBodyEvent(ApproachBodyEvent arg) => ApproachBodyEvent?.Invoke(null, arg);

        //EngineerProgress
        public event EventHandler<EngineerProgressEvent> EngineerProgressEvent;

        internal void InvokeEngineerProgressEvent(EngineerProgressEvent arg) => EngineerProgressEvent?.Invoke(null, arg);

        //FSSDiscoveryScan
        public event EventHandler<FSSDiscoveryScanEvent> FSSDiscoveryScanEvent;

        internal void InvokeFSSDiscoveryScanEvent(FSSDiscoveryScanEvent arg) => FSSDiscoveryScanEvent?.Invoke(null, arg);

        //SquadronCreated
        public event EventHandler<SquadronCreatedEvent> SquadronCreatedEvent;

        internal void InvokeSquadronCreatedEvent(SquadronCreatedEvent arg) => SquadronCreatedEvent?.Invoke(null, arg);

        //Commander
        public event EventHandler<CommanderEvent> CommanderEvent;

        internal void InvokeCommanderEvent(CommanderEvent arg) => CommanderEvent?.Invoke(null, arg);

        //JoinedSquadron
        public event EventHandler<JoinedSquadronEvent> JoinedSquadronEvent;

        internal void InvokeJoinedSquadronEvent(JoinedSquadronEvent arg) => JoinedSquadronEvent?.Invoke(null, arg);

        //EjectCargo
        public event EventHandler<EjectCargoEvent> EjectCargoEvent;

        internal void InvokeEjectCargoEvent(EjectCargoEvent arg) => EjectCargoEvent?.Invoke(null, arg);

        //NpcCrewPaidWage
        public event EventHandler<NpcCrewPaidWageEvent> NpcCrewPaidWageEvent;

        internal void InvokeNpcCrewPaidWageEvent(NpcCrewPaidWageEvent arg) => NpcCrewPaidWageEvent?.Invoke(null, arg);

        //Materials
        public event EventHandler<MaterialsEvent> MaterialsEvent;

        internal void InvokeMaterialsEvent(MaterialsEvent arg) => MaterialsEvent?.Invoke(null, arg);

        //LoadGame
        public event EventHandler<LoadGameEvent> LoadGameEvent;

        internal void InvokeLoadGameEvent(LoadGameEvent arg) => LoadGameEvent?.Invoke(null, arg);

        //SupercruiseEntry
        public event EventHandler<SupercruiseEntryEvent> SupercruiseEntryEvent;

        internal void InvokeSupercruiseEntryEvent(SupercruiseEntryEvent arg) => SupercruiseEntryEvent?.Invoke(null, arg);

        //FSDTarget
        public event EventHandler<FSDTargetEvent> FSDTargetEvent;

        internal void InvokeFSDTargetEvent(FSDTargetEvent arg) => FSDTargetEvent?.Invoke(null, arg);

        //FSSAllBodiesFound
        public event EventHandler<FSSAllBodiesFoundEvent> FSSAllBodiesFoundEvent;

        internal void InvokeFSSAllBodiesFoundEvent(FSSAllBodiesFoundEvent arg) => FSSAllBodiesFoundEvent?.Invoke(null, arg);

        //SAAScanComplete
        public event EventHandler<SAAScanCompleteEvent> SAAScanCompleteEvent;

        internal void InvokeSAAScanCompleteEvent(SAAScanCompleteEvent arg) => SAAScanCompleteEvent?.Invoke(null, arg);

        //CodexEntry
        public event EventHandler<CodexEntryEvent> CodexEntryEvent;

        internal void InvokeCodexEntryEvent(CodexEntryEvent arg) => CodexEntryEvent?.Invoke(null, arg);

        //CrimeVictim
        public event EventHandler<CrimeVictimEvent> CrimeVictimEvent;

        internal void InvokeCrimeVictimEvent(CrimeVictimEvent arg) => CrimeVictimEvent?.Invoke(null, arg);

        //Loadout
        public event EventHandler<LoadoutEvent> LoadoutEvent;

        internal void InvokeLoadoutEvent(LoadoutEvent arg) => LoadoutEvent?.Invoke(null, arg);

        //MissionCompleted
        public event EventHandler<MissionCompletedEvent> MissionCompletedEvent;

        internal void InvokeMissionCompletedEvent(MissionCompletedEvent arg) => MissionCompletedEvent?.Invoke(null, arg);

        //BuyTradeData
        public event EventHandler<BuyTradeDataEvent> BuyTradeDataEvent;

        internal void InvokeBuyTradeDataEvent(BuyTradeDataEvent arg) => BuyTradeDataEvent?.Invoke(null, arg);

        //CrewAssign
        public event EventHandler<CrewAssignEvent> CrewAssignEvent;

        internal void InvokeCrewAssignEvent(CrewAssignEvent arg) => CrewAssignEvent?.Invoke(null, arg);

        //CrewFire
        public event EventHandler<CrewFireEvent> CrewFireEvent;

        internal void InvokeCrewFireEvent(CrewFireEvent arg) => CrewFireEvent?.Invoke(null, arg);

        //MultiSellExplorationData
        public event EventHandler<MultiSellExplorationDataEvent> MultiSellExplorationDataEvent;

        internal void InvokeMultiSellExplorationDataEvent(MultiSellExplorationDataEvent arg) => MultiSellExplorationDataEvent?.Invoke(null, arg);

        //Location
        public event EventHandler<LocationEvent> LocationEvent;

        internal void InvokeLocationEvent(LocationEvent arg) => LocationEvent?.Invoke(null, arg);

        //AsteroidCracked
        public event EventHandler<AsteroidCrackedEvent> AsteroidCrackedEvent;

        internal void InvokeAsteroidCrackedEvent(AsteroidCrackedEvent arg) => AsteroidCrackedEvent?.Invoke(null, arg);

        //ModuleSwap
        public event EventHandler<ModuleSwapEvent> ModuleSwapEvent;

        internal void InvokeModuleSwapEvent(ModuleSwapEvent arg) => ModuleSwapEvent?.Invoke(null, arg);

        //DataScanned
        public event EventHandler<DataScannedEvent> DataScannedEvent;

        internal void InvokeDataScannedEvent(DataScannedEvent arg) => DataScannedEvent?.Invoke(null, arg);

        //DisbandedSquadron
        public event EventHandler<DisbandedSquadronEvent> DisbandedSquadronEvent;

        internal void InvokeDisbandedSquadronEvent(DisbandedSquadronEvent arg) => DisbandedSquadronEvent?.Invoke(null, arg);

        //AppliedToSquadron
        public event EventHandler<AppliedToSquadronEvent> AppliedToSquadronEvent;

        internal void InvokeAppliedToSquadronEvent(AppliedToSquadronEvent arg) => AppliedToSquadronEvent?.Invoke(null, arg);

        //Docked
        public event EventHandler<DockedEvent> DockedEvent;

        internal void InvokeDockedEvent(DockedEvent arg) => DockedEvent?.Invoke(null, arg);

        //Statistics
        public event EventHandler<StatisticsEvent> StatisticsEvent;

        internal void InvokeStatisticsEvent(StatisticsEvent arg) => StatisticsEvent?.Invoke(null, arg);

        //SetUserShipName
        public event EventHandler<SetUserShipNameEvent> SetUserShipNameEvent;

        internal void InvokeSetUserShipNameEvent(SetUserShipNameEvent arg) => SetUserShipNameEvent?.Invoke(null, arg);

        //FSDJump
        public event EventHandler<FSDJumpEvent> FSDJumpEvent;

        internal void InvokeFSDJumpEvent(FSDJumpEvent arg) => FSDJumpEvent?.Invoke(null, arg);

        //ClearSavedGame
        public event EventHandler<ClearSavedGameEvent> ClearSavedGameEvent;

        internal void InvokeClearSavedGameEvent(ClearSavedGameEvent arg) => ClearSavedGameEvent?.Invoke(null, arg);

        //Cargo
        public event EventHandler<CargoEvent> CargoEvent;

        internal void InvokeCargoEvent(CargoEvent arg) => CargoEvent?.Invoke(null, arg);

        //EngineerCraft
        public event EventHandler<EngineerCraftEvent> EngineerCraftEvent;

        internal void InvokeEngineerCraftEvent(EngineerCraftEvent arg) => EngineerCraftEvent?.Invoke(null, arg);

        //ApproachSettlement
        public event EventHandler<ApproachSettlementEvent> ApproachSettlementEvent;

        internal void InvokeApproachSettlementEvent(ApproachSettlementEvent arg) => ApproachSettlementEvent?.Invoke(null, arg);

        //StoredShips
        public event EventHandler<StoredShipsEvent> StoredShipsEvent;

        internal void InvokeStoredShipsEvent(StoredShipsEvent arg) => StoredShipsEvent?.Invoke(null, arg);

        //FSSSignalDiscovered
        public event EventHandler<FSSSignalDiscoveredEvent> FSSSignalDiscoveredEvent;

        internal void InvokeFSSSignalDiscoveredEvent(FSSSignalDiscoveredEvent arg) => FSSSignalDiscoveredEvent?.Invoke(null, arg);

        //SquadronStartup
        public event EventHandler<SquadronStartupEvent> SquadronStartupEvent;

        internal void InvokeSquadronStartupEvent(SquadronStartupEvent arg) => SquadronStartupEvent?.Invoke(null, arg);
    }
}