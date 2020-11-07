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
        // AllEvents
        public event EventHandler<EventBase> AllEvent;
        internal void InvokeAllEvent(EventBase arg) => AllEvent?.Invoke(this, arg);
        
		// CapShipBondEvent
        public event EventHandler<CapShipBondEvent> CapShipBondEvent;
        internal void InvokeCapShipBondEvent(CapShipBondEvent arg) => CapShipBondEvent?.Invoke(this, arg);
        
		// SAASignalsFoundEvent
        public event EventHandler<SAASignalsFoundEvent> SAASignalsFoundEvent;
        internal void InvokeSAASignalsFoundEvent(SAASignalsFoundEvent arg) => SAASignalsFoundEvent?.Invoke(this, arg);
        
		// NavRoute
        public event EventHandler<NavRouteEvent> NavRouteEvent;
        internal void InvokeNavRouteEvent(NavRouteEvent arg) => NavRouteEvent?.Invoke(this, arg);
        
		// ReservoirReplenished
        public event EventHandler<ReservoirReplenishedEvent> ReservoirReplenishedEvent;
        internal void InvokeReservoirReplenishedEvent(ReservoirReplenishedEvent arg) => ReservoirReplenishedEvent?.Invoke(this, arg);
        
		// ProspectedAsteroid
        public event EventHandler<ProspectedAsteroidEvent> ProspectedAsteroidEvent;
        internal void InvokeProspectedAsteroidEvent(ProspectedAsteroidEvent arg) => ProspectedAsteroidEvent?.Invoke(this, arg);
        
		// LeftSquadron
        public event EventHandler<LeftSquadronEvent> LeftSquadronEvent;
        internal void InvokeLeftSquadronEvent(LeftSquadronEvent arg) => LeftSquadronEvent?.Invoke(this, arg);
        
		// HeatWarning
        public event EventHandler<HeatWarningEvent> HeatWarningEvent;
        internal void InvokeHeatWarningEvent(HeatWarningEvent arg) => HeatWarningEvent?.Invoke(this, arg);
        
		// ShieldState
        public event EventHandler<ShieldStateEvent> ShieldStateEvent;
        internal void InvokeShieldStateEvent(ShieldStateEvent arg) => ShieldStateEvent?.Invoke(this, arg);
        
		// VehicleSwitch
        public event EventHandler<VehicleSwitchEvent> VehicleSwitchEvent;
        internal void InvokeVehicleSwitchEvent(VehicleSwitchEvent arg) => VehicleSwitchEvent?.Invoke(this, arg);
        
		// DockFighter
        public event EventHandler<DockFighterEvent> DockFighterEvent;
        internal void InvokeDockFighterEvent(DockFighterEvent arg) => DockFighterEvent?.Invoke(this, arg);
        
		// LaunchSRV
        public event EventHandler<LaunchSRVEvent> LaunchSRVEvent;
        internal void InvokeLaunchSRVEvent(LaunchSRVEvent arg) => LaunchSRVEvent?.Invoke(this, arg);
        
		// SelfDestruct
        public event EventHandler<SelfDestructEvent> SelfDestructEvent;
        internal void InvokeSelfDestructEvent(SelfDestructEvent arg) => SelfDestructEvent?.Invoke(this, arg);
        
		// DockSRV
        public event EventHandler<DockSRVEvent> DockSRVEvent;
        internal void InvokeDockSRVEvent(DockSRVEvent arg) => DockSRVEvent?.Invoke(this, arg);
        
		// HeatDamage
        public event EventHandler<HeatDamageEvent> HeatDamageEvent;
        internal void InvokeHeatDamageEvent(HeatDamageEvent arg) => HeatDamageEvent?.Invoke(this, arg);
        
		// LaunchFighter
        public event EventHandler<LaunchFighterEvent> LaunchFighterEvent;
        internal void InvokeLaunchFighterEvent(LaunchFighterEvent arg) => LaunchFighterEvent?.Invoke(this, arg);
        
		// DatalinkScan
        public event EventHandler<DatalinkScanEvent> DatalinkScanEvent;
        internal void InvokeDatalinkScanEvent(DatalinkScanEvent arg) => DatalinkScanEvent?.Invoke(this, arg);
        
		// CockpitBreached
        public event EventHandler<CockpitBreachedEvent> CockpitBreachedEvent;
        internal void InvokeCockpitBreachedEvent(CockpitBreachedEvent arg) => CockpitBreachedEvent?.Invoke(this, arg);
        
		// JetConeBoost
        public event EventHandler<JetConeBoostEvent> JetConeBoostEvent;
        internal void InvokeJetConeBoostEvent(JetConeBoostEvent arg) => JetConeBoostEvent?.Invoke(this, arg);
        
		// PowerplayLeave
        public event EventHandler<PowerplayLeaveEvent> PowerplayLeaveEvent;
        internal void InvokePowerplayLeaveEvent(PowerplayLeaveEvent arg) => PowerplayLeaveEvent?.Invoke(this, arg);
        
		// Interdiction
        public event EventHandler<InterdictionEvent> InterdictionEvent;
        internal void InvokeInterdictionEvent(InterdictionEvent arg) => InterdictionEvent?.Invoke(this, arg);
        
		// USSDrop
        public event EventHandler<USSDropEvent> USSDropEvent;
        internal void InvokeUSSDropEvent(USSDropEvent arg) => USSDropEvent?.Invoke(this, arg);
        
		// PowerplayCollect
        public event EventHandler<PowerplayCollectEvent> PowerplayCollectEvent;
        internal void InvokePowerplayCollectEvent(PowerplayCollectEvent arg) => PowerplayCollectEvent?.Invoke(this, arg);
        
		// PowerplayDeliver
        public event EventHandler<PowerplayDeliverEvent> PowerplayDeliverEvent;
        internal void InvokePowerplayDeliverEvent(PowerplayDeliverEvent arg) => PowerplayDeliverEvent?.Invoke(this, arg);
        
		// PayLegacyFines
        public event EventHandler<PayLegacyFinesEvent> PayLegacyFinesEvent;
        internal void InvokePayLegacyFinesEvent(PayLegacyFinesEvent arg) => PayLegacyFinesEvent?.Invoke(this, arg);
        
		// EngineerApply
        public event EventHandler<EngineerApplyEvent> EngineerApplyEvent;
        internal void InvokeEngineerApplyEvent(EngineerApplyEvent arg) => EngineerApplyEvent?.Invoke(this, arg);
        
		// WingLeave
        public event EventHandler<WingLeaveEvent> WingLeaveEvent;
        internal void InvokeWingLeaveEvent(WingLeaveEvent arg) => WingLeaveEvent?.Invoke(this, arg);
        
		// SystemsShutdown
        public event EventHandler<SystemsShutdownEvent> SystemsShutdownEvent;
        internal void InvokeSystemsShutdownEvent(SystemsShutdownEvent arg) => SystemsShutdownEvent?.Invoke(this, arg);
        
		// HullDamage
        public event EventHandler<HullDamageEvent> HullDamageEvent;
        internal void InvokeHullDamageEvent(HullDamageEvent arg) => HullDamageEvent?.Invoke(this, arg);
        
		// BuyDrones
        public event EventHandler<BuyDronesEvent> BuyDronesEvent;
        internal void InvokeBuyDronesEvent(BuyDronesEvent arg) => BuyDronesEvent?.Invoke(this, arg);
        
		// RestockVehicle
        public event EventHandler<RestockVehicleEvent> RestockVehicleEvent;
        internal void InvokeRestockVehicleEvent(RestockVehicleEvent arg) => RestockVehicleEvent?.Invoke(this, arg);
        
		// BuyAmmo
        public event EventHandler<BuyAmmoEvent> BuyAmmoEvent;
        internal void InvokeBuyAmmoEvent(BuyAmmoEvent arg) => BuyAmmoEvent?.Invoke(this, arg);
        
		// MiningRefined
        public event EventHandler<MiningRefinedEvent> MiningRefinedEvent;
        internal void InvokeMiningRefinedEvent(MiningRefinedEvent arg) => MiningRefinedEvent?.Invoke(this, arg);
        
		// DatalinkVoucher
        public event EventHandler<DatalinkVoucherEvent> DatalinkVoucherEvent;
        internal void InvokeDatalinkVoucherEvent(DatalinkVoucherEvent arg) => DatalinkVoucherEvent?.Invoke(this, arg);
        
		// Scanned
        public event EventHandler<ScannedEvent> ScannedEvent;
        internal void InvokeScannedEvent(ScannedEvent arg) => ScannedEvent?.Invoke(this, arg);
        
		// ChangeCrewRole
        public event EventHandler<ChangeCrewRoleEvent> ChangeCrewRoleEvent;
        internal void InvokeChangeCrewRoleEvent(ChangeCrewRoleEvent arg) => ChangeCrewRoleEvent?.Invoke(this, arg);
        
		// Touchdown
        public event EventHandler<TouchdownEvent> TouchdownEvent;
        internal void InvokeTouchdownEvent(TouchdownEvent arg) => TouchdownEvent?.Invoke(this, arg);
        
		// SendText
        public event EventHandler<SendTextEvent> SendTextEvent;
        internal void InvokeSendTextEvent(SendTextEvent arg) => SendTextEvent?.Invoke(this, arg);
        
		// RefuelAll
        public event EventHandler<RefuelAllEvent> RefuelAllEvent;
        internal void InvokeRefuelAllEvent(RefuelAllEvent arg) => RefuelAllEvent?.Invoke(this, arg);
        
		// EndCrewSession
        public event EventHandler<EndCrewSessionEvent> EndCrewSessionEvent;
        internal void InvokeEndCrewSessionEvent(EndCrewSessionEvent arg) => EndCrewSessionEvent?.Invoke(this, arg);
        
		// Liftoff
        public event EventHandler<LiftoffEvent> LiftoffEvent;
        internal void InvokeLiftoffEvent(LiftoffEvent arg) => LiftoffEvent?.Invoke(this, arg);
        
		// EscapeInterdiction
        public event EventHandler<EscapeInterdictionEvent> EscapeInterdictionEvent;
        internal void InvokeEscapeInterdictionEvent(EscapeInterdictionEvent arg) => EscapeInterdictionEvent?.Invoke(this, arg);
        
		// WingAdd
        public event EventHandler<WingAddEvent> WingAddEvent;
        internal void InvokeWingAddEvent(WingAddEvent arg) => WingAddEvent?.Invoke(this, arg);
        
		// SellDrones
        public event EventHandler<SellDronesEvent> SellDronesEvent;
        internal void InvokeSellDronesEvent(SellDronesEvent arg) => SellDronesEvent?.Invoke(this, arg);
        
		// Fileheader
        public event EventHandler<FileheaderEvent> FileheaderEvent;
        internal void InvokeFileheaderEvent(FileheaderEvent arg) => FileheaderEvent?.Invoke(this, arg);
        
		// Interdicted
        public event EventHandler<InterdictedEvent> InterdictedEvent;
        internal void InvokeInterdictedEvent(InterdictedEvent arg) => InterdictedEvent?.Invoke(this, arg);
        
		// CrewMemberJoins
        public event EventHandler<CrewMemberJoinsEvent> CrewMemberJoinsEvent;
        internal void InvokeCrewMemberJoinsEvent(CrewMemberJoinsEvent arg) => CrewMemberJoinsEvent?.Invoke(this, arg);
        
		// CrewMemberQuits
        public event EventHandler<CrewMemberQuitsEvent> CrewMemberQuitsEvent;
        internal void InvokeCrewMemberQuitsEvent(CrewMemberQuitsEvent arg) => CrewMemberQuitsEvent?.Invoke(this, arg);
        
		// CrewMemberRoleChange
        public event EventHandler<CrewMemberRoleChangeEvent> CrewMemberRoleChangeEvent;
        internal void InvokeCrewMemberRoleChangeEvent(CrewMemberRoleChangeEvent arg) => CrewMemberRoleChangeEvent?.Invoke(this, arg);
        
		// PVPKill
        public event EventHandler<PVPKillEvent> PVPKillEvent;
        internal void InvokePVPKillEvent(PVPKillEvent arg) => PVPKillEvent?.Invoke(this, arg);
        
		// JoinACrew
        public event EventHandler<JoinACrewEvent> JoinACrewEvent;
        internal void InvokeJoinACrewEvent(JoinACrewEvent arg) => JoinACrewEvent?.Invoke(this, arg);
        
		// QuitACrew
        public event EventHandler<QuitACrewEvent> QuitACrewEvent;
        internal void InvokeQuitACrewEvent(QuitACrewEvent arg) => QuitACrewEvent?.Invoke(this, arg);
        
		// Progress
        public event EventHandler<ProgressEvent> ProgressEvent;
        internal void InvokeProgressEvent(ProgressEvent arg) => ProgressEvent?.Invoke(this, arg);
        
		// Promotion
        public event EventHandler<PromotionEvent> PromotionEvent;
        internal void InvokePromotionEvent(PromotionEvent arg) => PromotionEvent?.Invoke(this, arg);
        
		// Rank
        public event EventHandler<RankEvent> RankEvent;
        internal void InvokeRankEvent(RankEvent arg) => RankEvent?.Invoke(this, arg);
        
		// CommitCrime
        public event EventHandler<CommitCrimeEvent> CommitCrimeEvent;
        internal void InvokeCommitCrimeEvent(CommitCrimeEvent arg) => CommitCrimeEvent?.Invoke(this, arg);
        
		// EngineerContribution
        public event EventHandler<EngineerContributionEvent> EngineerContributionEvent;
        internal void InvokeEngineerContributionEvent(EngineerContributionEvent arg) => EngineerContributionEvent?.Invoke(this, arg);
        
		// Music
        public event EventHandler<MusicEvent> MusicEvent;
        internal void InvokeMusicEvent(MusicEvent arg) => MusicEvent?.Invoke(this, arg);
        
		// Died
        public event EventHandler<DiedEvent> DiedEvent;
        internal void InvokeDiedEvent(DiedEvent arg) => DiedEvent?.Invoke(this, arg);
        
		// Passengers
        public event EventHandler<PassengersEvent> PassengersEvent;
        internal void InvokePassengersEvent(PassengersEvent arg) => PassengersEvent?.Invoke(this, arg);
        
		// SearchAndRescue
        public event EventHandler<SearchAndRescueEvent> SearchAndRescueEvent;
        internal void InvokeSearchAndRescueEvent(SearchAndRescueEvent arg) => SearchAndRescueEvent?.Invoke(this, arg);
        
		// KickCrewMember
        public event EventHandler<KickCrewMemberEvent> KickCrewMemberEvent;
        internal void InvokeKickCrewMemberEvent(KickCrewMemberEvent arg) => KickCrewMemberEvent?.Invoke(this, arg);
        
		// RedeemVoucher
        public event EventHandler<RedeemVoucherEvent> RedeemVoucherEvent;
        internal void InvokeRedeemVoucherEvent(RedeemVoucherEvent arg) => RedeemVoucherEvent?.Invoke(this, arg);
        
		// Resurrect
        public event EventHandler<ResurrectEvent> ResurrectEvent;
        internal void InvokeResurrectEvent(ResurrectEvent arg) => ResurrectEvent?.Invoke(this, arg);
        
		// CommunityGoalJoin
        public event EventHandler<CommunityGoalJoinEvent> CommunityGoalJoinEvent;
        internal void InvokeCommunityGoalJoinEvent(CommunityGoalJoinEvent arg) => CommunityGoalJoinEvent?.Invoke(this, arg);
        
		// CommunityGoal
        public event EventHandler<CommunityGoalEvent> CommunityGoalEvent;
        internal void InvokeCommunityGoalEvent(CommunityGoalEvent arg) => CommunityGoalEvent?.Invoke(this, arg);
        
		// RepairDrone
        public event EventHandler<RepairDroneEvent> RepairDroneEvent;
        internal void InvokeRepairDroneEvent(RepairDroneEvent arg) => RepairDroneEvent?.Invoke(this, arg);
        
		// Repair
        public event EventHandler<RepairEvent> RepairEvent;
        internal void InvokeRepairEvent(RepairEvent arg) => RepairEvent?.Invoke(this, arg);
        
		// JetConeDamage
        public event EventHandler<JetConeDamageEvent> JetConeDamageEvent;
        internal void InvokeJetConeDamageEvent(JetConeDamageEvent arg) => JetConeDamageEvent?.Invoke(this, arg);
        
		// CommunityGoalDiscard
        public event EventHandler<CommunityGoalDiscardEvent> CommunityGoalDiscardEvent;
        internal void InvokeCommunityGoalDiscard(CommunityGoalDiscardEvent arg) => CommunityGoalDiscardEvent?.Invoke(this, arg);
        
		// MissionAccepted
        public event EventHandler<MissionAcceptedEvent> MissionAcceptedEvent;
        internal void InvokeMissionAcceptedEvent(MissionAcceptedEvent arg) => MissionAcceptedEvent?.Invoke(this, arg);
        
		// BuyExplorationData
        public event EventHandler<BuyExplorationDataEvent> BuyExplorationDataEvent;
        internal void InvokeBuyExplorationDataEvent(BuyExplorationDataEvent arg) => BuyExplorationDataEvent?.Invoke(this, arg);
        
		// RepairAll
        public event EventHandler<RepairAllEvent> RepairAllEvent;
        internal void InvokeRepairAllEvent(RepairAllEvent arg) => RepairAllEvent?.Invoke(this, arg);
        
		// CrewLaunchFighter
        public event EventHandler<CrewLaunchFighterEvent> CrewLaunchFighterEvent;
        internal void InvokeCrewLaunchFighterEvent(CrewLaunchFighterEvent arg) => CrewLaunchFighterEvent?.Invoke(this, arg);
        
		// MaterialDiscarded
        public event EventHandler<MaterialDiscardedEvent> MaterialDiscardedEvent;
        internal void InvokeMaterialDiscardedEvent(MaterialDiscardedEvent arg) => MaterialDiscardedEvent?.Invoke(this, arg);
        
		// NewCommander
        public event EventHandler<NewCommanderEvent> NewCommanderEvent;
        internal void InvokeNewCommanderEvent(NewCommanderEvent arg) => NewCommanderEvent?.Invoke(this, arg);
        
		// CommunityGoalReward
        public event EventHandler<CommunityGoalRewardEvent> CommunityGoalRewardEvent;
        internal void InvokeCommunityGoalRewardEvent(CommunityGoalRewardEvent arg) => CommunityGoalRewardEvent?.Invoke(this, arg);
        
		// PowerplayVote
        public event EventHandler<PowerplayVoteEvent> PowerplayVoteEvent;
        internal void InvokePowerplayVoteEvent(PowerplayVoteEvent arg) => PowerplayVoteEvent?.Invoke(this, arg);
        
		// PowerplayJoin
        public event EventHandler<PowerplayJoinEvent> PowerplayJoinEvent;
        internal void InvokePowerplayJoinEvent(PowerplayJoinEvent arg) => PowerplayJoinEvent?.Invoke(this, arg);
        
		// PowerplayDefect
        public event EventHandler<PowerplayDefectEvent> PowerplayDefectEvent;
        internal void InvokePowerplayDefectEvent(PowerplayDefectEvent arg) => PowerplayDefectEvent?.Invoke(this, arg);
        
		// MissionFailed
        public event EventHandler<MissionFailedEvent> MissionFailedEvent;
        internal void InvokeMissionFailedEvent(MissionFailedEvent arg) => MissionFailedEvent?.Invoke(this, arg);
        
		// MissionRedirected
        public event EventHandler<MissionRedirectedEvent> MissionRedirectedEvent;
        internal void InvokeMissionRedirectedEvent(MissionRedirectedEvent arg) => MissionRedirectedEvent?.Invoke(this, arg);
        
		// Shutdown
        public event EventHandler<ShutdownEvent> ShutdownEvent;
        internal void InvokeShutdownEvent(ShutdownEvent arg) => ShutdownEvent?.Invoke(this, arg);
        
		// ModuleEvent
        public event EventHandler<ModuleInfoEvent> ModuleEventEvent;
        internal void InvokeModuleEventEvent(ModuleInfoEvent arg) => ModuleEventEvent?.Invoke(this, arg);
        
		// Market
        public event EventHandler<MarketEvent> MarketEvent;
        internal void InvokeMarketEvent(MarketEvent arg) => MarketEvent?.Invoke(this, arg);
        
		// MassModuleStore
        public event EventHandler<MassModuleStoreEvent> MassModuleStoreEvent;
        internal void InvokeMassModuleStoreEvent(MassModuleStoreEvent arg) => MassModuleStoreEvent?.Invoke(this, arg);
        
		// MaterialDiscovered
        public event EventHandler<MaterialDiscoveredEvent> MaterialDiscoveredEvent;
        internal void InvokeMaterialDiscoveredEvent(MaterialDiscoveredEvent arg) => MaterialDiscoveredEvent?.Invoke(this, arg);
        
		// MaterialCollected
        public event EventHandler<MaterialCollectedEvent> MaterialCollectedEvent;
        internal void InvokeMaterialCollectedEvent(MaterialCollectedEvent arg) => MaterialCollectedEvent?.Invoke(this, arg);
        
		// SRVDestroyed
        public event EventHandler<SRVDestroyedEvent> SRVDestroyedEvent;
        internal void InvokeSRVDestroyedEvent(SRVDestroyedEvent arg) => SRVDestroyedEvent?.Invoke(this, arg);
        
		// DockingDenied
        public event EventHandler<DockingDeniedEvent> DockingDeniedEvent;
        internal void InvokeDockingDeniedEvent(DockingDeniedEvent arg) => DockingDeniedEvent?.Invoke(this, arg);
        
		// UnderAttack
        public event EventHandler<UnderAttackEvent> UnderAttackEvent;
        internal void InvokeUnderAttackEvent(UnderAttackEvent arg) => UnderAttackEvent?.Invoke(this, arg);
        
		// ShipTargeted
        public event EventHandler<ShipTargetedEvent> ShipTargetedEvent;
        internal void InvokeShipTargetedEvent(ShipTargetedEvent arg) => ShipTargetedEvent?.Invoke(this, arg);
        
		// Shipyard
        public event EventHandler<ShipyardEvent> ShipyardEvent;
        internal void InvokeShipyardEvent(ShipyardEvent arg) => ShipyardEvent?.Invoke(this, arg);
        
		// Outfitting
        public event EventHandler<OutfittingEvent> OutfittingEvent;
        internal void InvokeOutfittingEvent(OutfittingEvent arg) => OutfittingEvent?.Invoke(this, arg);
        
		// PowerplayFastTrack
        public event EventHandler<PowerplayFastTrackEvent> PowerplayFastTrackEvent;
        internal void InvokePowerplayFastTrackEvent(PowerplayFastTrackEvent arg) => PowerplayFastTrackEvent?.Invoke(this, arg);
        
		// Powerplay
        public event EventHandler<PowerplayEvent> PowerplayEvent;
        internal void InvokePowerplayEvent(PowerplayEvent arg) => PowerplayEvent?.Invoke(this, arg);
        
		// CollectCargo
        public event EventHandler<CollectCargoEvent> CollectCargoEvent;
        internal void InvokeCollectCargoEvent(CollectCargoEvent arg) => CollectCargoEvent?.Invoke(this, arg);
        
		// FetchRemoteModule
        public event EventHandler<FetchRemoteModuleEvent> FetchRemoteModuleEvent;
        internal void InvokeFetchRemoteModuleEvent(FetchRemoteModuleEvent arg) => FetchRemoteModuleEvent?.Invoke(this, arg);
        
		// ModuleStore
        public event EventHandler<ModuleStoreEvent> ModuleStoreEvent;
        internal void InvokeModuleStoreEvent(ModuleStoreEvent arg) => ModuleStoreEvent?.Invoke(this, arg);
        
		// ShipyardBuy
        public event EventHandler<ShipyardBuyEvent> ShipyardBuyEvent;
        internal void InvokeShipyardBuyEvent(ShipyardBuyEvent arg) => ShipyardBuyEvent?.Invoke(this, arg);
        
		// ShipyardNew
        public event EventHandler<ShipyardNewEvent> ShipyardNewEvent;
        internal void InvokeShipyardNewEvent(ShipyardNewEvent arg) => ShipyardNewEvent?.Invoke(this, arg);
        
		// ModuleBuy
        public event EventHandler<ModuleBuyEvent> ModuleBuyEvent;
        internal void InvokeModuleBuyEvent(ModuleBuyEvent arg) => ModuleBuyEvent?.Invoke(this, arg);
        
		// ModuleRetrieve
        public event EventHandler<ModuleRetrieveEvent> ModuleRetrieveEvent;
        internal void InvokeModuleRetrieveEvent(ModuleRetrieveEvent arg) => ModuleRetrieveEvent?.Invoke(this, arg);
        
		// AfmuRepairs
        public event EventHandler<AfmuRepairsEvent> AfmuRepairsEvent;
        internal void InvokeAfmuRepairsEvent(AfmuRepairsEvent arg) => AfmuRepairsEvent?.Invoke(this, arg);
        
		// LaunchDrone
        public event EventHandler<LaunchDroneEvent> LaunchDroneEvent;
        internal void InvokeLaunchDroneEvent(LaunchDroneEvent arg) => LaunchDroneEvent?.Invoke(this, arg);
        
		// MarketSell
        public event EventHandler<MarketSellEvent> MarketSellEvent;
        internal void InvokeMarketSellEvent(MarketSellEvent arg) => MarketSellEvent?.Invoke(this, arg);
        
		// ModuleSell
        public event EventHandler<ModuleSellEvent> ModuleSellEvent;
        internal void InvokeModuleSellEvent(ModuleSellEvent arg) => ModuleSellEvent?.Invoke(this, arg);
        
		// FuelScoop
        public event EventHandler<FuelScoopEvent> FuelScoopEvent;
        internal void InvokeFuelScoopEvent(FuelScoopEvent arg) => FuelScoopEvent?.Invoke(this, arg);
        
		// FighterDestroyed
        public event EventHandler<FighterDestroyedEvent> FighterDestroyedEvent;
        internal void InvokeFighterDestroyedEvent(FighterDestroyedEvent arg) => FighterDestroyedEvent?.Invoke(this, arg);
        
		// DiscoveryScan
        public event EventHandler<DiscoveryScanEvent> DiscoveryScanEvent;
        internal void InvokeDiscoveryScanEvent(DiscoveryScanEvent arg) => DiscoveryScanEvent?.Invoke(this, arg);
        
		// LeaveBody
        public event EventHandler<LeaveBodyEvent> LeaveBodyEvent;
        internal void InvokeLeaveBodyEvent(LeaveBodyEvent arg) => LeaveBodyEvent?.Invoke(this, arg);
        
		// PowerplayVoucher
        public event EventHandler<PowerplayVoucherEvent> PowerplayVoucherEvent;
        internal void InvokePowerplayVoucherEvent(PowerplayVoucherEvent arg) => PowerplayVoucherEvent?.Invoke(this, arg);
        
		// Reputation
        public event EventHandler<ReputationEvent> ReputationEvent;
        internal void InvokeReputationEvent(ReputationEvent arg) => ReputationEvent?.Invoke(this, arg);
        
		// NavBeaconScan
        public event EventHandler<NavBeaconScanEvent> NavBeaconScanEvent;
        internal void InvokeNavBeaconScanEvent(NavBeaconScanEvent arg) => NavBeaconScanEvent?.Invoke(this, arg);
        
		// Missions
        public event EventHandler<MissionsEvent> MissionsEvent;
        internal void InvokeMissionsEvent(MissionsEvent arg) => MissionsEvent?.Invoke(this, arg);
        
		// Friends
        public event EventHandler<FriendsEvent> FriendsEvent;
        internal void InvokeFriendsEvent(FriendsEvent arg) => FriendsEvent?.Invoke(this, arg);
        
		// ShipyardSell
        public event EventHandler<ShipyardSellEvent> ShipyardSellEvent;
        internal void InvokeShipyardSellEvent(ShipyardSellEvent arg) => ShipyardSellEvent?.Invoke(this, arg);
        
		// MissionAbandoned
        public event EventHandler<MissionAbandonedEvent> MissionAbandonedEvent;
        internal void InvokeMissionAbandonedEvent(MissionAbandonedEvent arg) => MissionAbandonedEvent?.Invoke(this, arg);
        
		// ScientificResearch
        public event EventHandler<ScientificResearchEvent> ScientificResearchEvent;
        internal void InvokeScientificResearchEvent(ScientificResearchEvent arg) => ScientificResearchEvent?.Invoke(this, arg);
        
		// DockingTimeout
        public event EventHandler<DockingTimeoutEvent> DockingTimeoutEvent;
        internal void InvokeDockingTimeoutEvent(DockingTimeoutEvent arg) => DockingTimeoutEvent?.Invoke(this, arg);
        
		// DockingCancelled
        public event EventHandler<DockingCancelledEvent> DockingCancelledEvent;
        internal void InvokeDockingCancelledEvent(DockingCancelledEvent arg) => DockingCancelledEvent?.Invoke(this, arg);
        
		// DockingRequested
        public event EventHandler<DockingRequestedEvent> DockingRequestedEvent;
        internal void InvokeDockingRequestedEvent(DockingRequestedEvent arg) => DockingRequestedEvent?.Invoke(this, arg);
        
		// DockingGranted
        public event EventHandler<DockingGrantedEvent> DockingGrantedEvent;
        internal void InvokeDockingGrantedEvent(DockingGrantedEvent arg) => DockingGrantedEvent?.Invoke(this, arg);
        
		// Undocked
        public event EventHandler<UndockedEvent> UndockedEvent;
        internal void InvokeUndockedEvent(UndockedEvent arg) => UndockedEvent?.Invoke(this, arg);
        
		// CrewHire
        public event EventHandler<CrewHireEvent> CrewHireEvent;
        internal void InvokeCrewHireEvent(CrewHireEvent arg) => CrewHireEvent?.Invoke(this, arg);
        
		// Screenshot
        public event EventHandler<ScreenshotEvent> ScreenshotEvent;
        internal void InvokeScreenshotEvent(ScreenshotEvent arg) => ScreenshotEvent?.Invoke(this, arg);
        
		// Synthesis
        public event EventHandler<SynthesisEvent> SynthesisEvent;
        internal void InvokeSynthesisEvent(SynthesisEvent arg) => SynthesisEvent?.Invoke(this, arg);
        
		// FighterRebuilt
        public event EventHandler<FighterRebuiltEvent> FighterRebuiltEvent;
        internal void InvokeFighterRebuiltEvent(FighterRebuiltEvent arg) => FighterRebuiltEvent?.Invoke(this, arg);
        
		// SellExplorationData
        public event EventHandler<SellExplorationDataEvent> SellExplorationDataEvent;
        internal void InvokeSellExplorationDataEvent(SellExplorationDataEvent arg) => SellExplorationDataEvent?.Invoke(this, arg);
        
		// RebootRepair
        public event EventHandler<RebootRepairEvent> RebootRepairEvent;
        internal void InvokeRebootRepairEvent(RebootRepairEvent arg) => RebootRepairEvent?.Invoke(this, arg);
        
		// Scan
        public event EventHandler<ScanEvent> ScanEvent;
        internal void InvokeScanEvent(ScanEvent arg) => ScanEvent?.Invoke(this, arg);
        
		// WingInvite
        public event EventHandler<WingInviteEvent> WingInviteEvent;
        internal void InvokeWingInviteEvent(WingInviteEvent arg) => WingInviteEvent?.Invoke(this, arg);
        
		// StartJump
        public event EventHandler<StartJumpEvent> StartJumpEvent;
        internal void InvokeStartJumpEvent(StartJumpEvent arg) => StartJumpEvent?.Invoke(this, arg);
        
		// SupercruiseExit
        public event EventHandler<SupercruiseExitEvent> SupercruiseExitEvent;
        internal void InvokeSupercruiseExitEvent(SupercruiseExitEvent arg) => SupercruiseExitEvent?.Invoke(this, arg);
        
		// PayBounties
        public event EventHandler<PayBountiesEvent> PayBountiesEvent;
        internal void InvokePayBountiesEvent(PayBountiesEvent arg) => PayBountiesEvent?.Invoke(this, arg);
        
		// PowerplaySalary
        public event EventHandler<PowerplaySalaryEvent> PowerplaySalaryEvent;
        internal void InvokePowerplaySalaryEvent(PowerplaySalaryEvent arg) => PowerplaySalaryEvent?.Invoke(this, arg);
        
		// ShipyardTransfer
        public event EventHandler<ShipyardTransferEvent> ShipyardTransferEvent;
        internal void InvokeShipyardTransferEvent(ShipyardTransferEvent arg) => ShipyardTransferEvent?.Invoke(this, arg);
        
		// TechnologyBroker
        public event EventHandler<TechnologyBrokerEvent> TechnologyBrokerEvent;
        internal void InvokeTechnologyBrokerEvent(TechnologyBrokerEvent arg) => TechnologyBrokerEvent?.Invoke(this, arg);
        
		// PayFines
        public event EventHandler<PayFinesEvent> PayFinesEvent;
        internal void InvokePayFinesEvent(PayFinesEvent arg) => PayFinesEvent?.Invoke(this, arg);
        
		// Bounty
        public event EventHandler<BountyEvent> BountyEvent;
        internal void InvokeBountyEvent(BountyEvent arg) => BountyEvent?.Invoke(this, arg);
        
		// MaterialTrade
        public event EventHandler<MaterialTradeEvent> MaterialTradeEvent;
        internal void InvokeMaterialTradeEvent(MaterialTradeEvent arg) => MaterialTradeEvent?.Invoke(this, arg);
        
		// ReceiveText
        public event EventHandler<ReceiveTextEvent> ReceiveTextEvent;
        internal void InvokeReceiveTextEvent(ReceiveTextEvent arg) => ReceiveTextEvent?.Invoke(this, arg);
        
		// ModuleSellRemote
        public event EventHandler<ModuleSellRemoteEvent> ModuleSellRemoteEvent;
        internal void InvokeModuleSellRemoteEvent(ModuleSellRemoteEvent arg) => ModuleSellRemoteEvent?.Invoke(this, arg);
        
		// ShipyardSwap
        public event EventHandler<ShipyardSwapEvent> ShipyardSwapEvent;
        internal void InvokeShipyardSwapEvent(ShipyardSwapEvent arg) => ShipyardSwapEvent?.Invoke(this, arg);
        
		// MarketBuy
        public event EventHandler<MarketBuyEvent> MarketBuyEvent;
        internal void InvokeMarketBuyEvent(MarketBuyEvent arg) => MarketBuyEvent?.Invoke(this, arg);
        
		// CargoDepot
        public event EventHandler<CargoDepotEvent> CargoDepotEvent;
        internal void InvokeCargoDepotEvent(CargoDepotEvent arg) => CargoDepotEvent?.Invoke(this, arg);
        
		// KillBond
        public event EventHandler<FactionKillBondEvent> FactionKillBondEvent;
        internal void InvokeFactionKillBondEvent(FactionKillBondEvent arg) => FactionKillBondEvent?.Invoke(this, arg);
        
		// StoredModules
        public event EventHandler<StoredModulesEvent> StoredModulesEvent;
        internal void InvokeStoredModulesEvent(StoredModulesEvent arg) => StoredModulesEvent?.Invoke(this, arg);
        
		// WingJoin
        public event EventHandler<WingJoinEvent> WingJoinEvent;
        internal void InvokeWingJoinEvent(WingJoinEvent arg) => WingJoinEvent?.Invoke(this, arg);
        
		// ApproachBody
        public event EventHandler<ApproachBodyEvent> ApproachBodyEvent;
        internal void InvokeApproachBodyEvent(ApproachBodyEvent arg) => ApproachBodyEvent?.Invoke(this, arg);
        
		// EngineerProgress
        public event EventHandler<EngineerProgressEvent> EngineerProgressEvent;
        internal void InvokeEngineerProgressEvent(EngineerProgressEvent arg) => EngineerProgressEvent?.Invoke(this, arg);
        
		// FSSDiscoveryScan
        public event EventHandler<FSSDiscoveryScanEvent> FSSDiscoveryScanEvent;
        internal void InvokeFSSDiscoveryScanEvent(FSSDiscoveryScanEvent arg) => FSSDiscoveryScanEvent?.Invoke(this, arg);
        
		// SquadronCreated
        public event EventHandler<SquadronCreatedEvent> SquadronCreatedEvent;
        internal void InvokeSquadronCreatedEvent(SquadronCreatedEvent arg) => SquadronCreatedEvent?.Invoke(this, arg);
        
		// Commander
        public event EventHandler<CommanderEvent> CommanderEvent;
        internal void InvokeCommanderEvent(CommanderEvent arg) => CommanderEvent?.Invoke(this, arg);
        
		// JoinedSquadron
        public event EventHandler<JoinedSquadronEvent> JoinedSquadronEvent;
        internal void InvokeJoinedSquadronEvent(JoinedSquadronEvent arg) => JoinedSquadronEvent?.Invoke(this, arg);
        
		// EjectCargo
        public event EventHandler<EjectCargoEvent> EjectCargoEvent;
        internal void InvokeEjectCargoEvent(EjectCargoEvent arg) => EjectCargoEvent?.Invoke(this, arg);
        
		// NpcCrewPaidWage
        public event EventHandler<NpcCrewPaidWageEvent> NpcCrewPaidWageEvent;
        internal void InvokeNpcCrewPaidWageEvent(NpcCrewPaidWageEvent arg) => NpcCrewPaidWageEvent?.Invoke(this, arg);
        
		// Materials
        public event EventHandler<MaterialsEvent> MaterialsEvent;
        internal void InvokeMaterialsEvent(MaterialsEvent arg) => MaterialsEvent?.Invoke(this, arg);
        
		// LoadGame
        public event EventHandler<LoadGameEvent> LoadGameEvent;
        internal void InvokeLoadGameEvent(LoadGameEvent arg) => LoadGameEvent?.Invoke(this, arg);
        
		// SupercruiseEntry
        public event EventHandler<SupercruiseEntryEvent> SupercruiseEntryEvent;
        internal void InvokeSupercruiseEntryEvent(SupercruiseEntryEvent arg) => SupercruiseEntryEvent?.Invoke(this, arg);
        
		// FSDTarget
        public event EventHandler<FSDTargetEvent> FSDTargetEvent;
        internal void InvokeFSDTargetEvent(FSDTargetEvent arg) => FSDTargetEvent?.Invoke(this, arg);
        
		// FSSAllBodiesFound
        public event EventHandler<FSSAllBodiesFoundEvent> FSSAllBodiesFoundEvent;
        internal void InvokeFSSAllBodiesFoundEvent(FSSAllBodiesFoundEvent arg) => FSSAllBodiesFoundEvent?.Invoke(this, arg);
        
		// SAAScanComplete
        public event EventHandler<SAAScanCompleteEvent> SAAScanCompleteEvent;
        internal void InvokeSAAScanCompleteEvent(SAAScanCompleteEvent arg) => SAAScanCompleteEvent?.Invoke(this, arg);
        
		// CodexEntry
        public event EventHandler<CodexEntryEvent> CodexEntryEvent;
        internal void InvokeCodexEntryEvent(CodexEntryEvent arg) => CodexEntryEvent?.Invoke(this, arg);
        
		// CrimeVictim
        public event EventHandler<CrimeVictimEvent> CrimeVictimEvent;
        internal void InvokeCrimeVictimEvent(CrimeVictimEvent arg) => CrimeVictimEvent?.Invoke(this, arg);
        
		// Loadout
        public event EventHandler<LoadoutEvent> LoadoutEvent;
        internal void InvokeLoadoutEvent(LoadoutEvent arg) => LoadoutEvent?.Invoke(this, arg);
        
		// MissionCompleted
        public event EventHandler<MissionCompletedEvent> MissionCompletedEvent;
        internal void InvokeMissionCompletedEvent(MissionCompletedEvent arg) => MissionCompletedEvent?.Invoke(this, arg);
        
		// BuyTradeData
        public event EventHandler<BuyTradeDataEvent> BuyTradeDataEvent;
        internal void InvokeBuyTradeDataEvent(BuyTradeDataEvent arg) => BuyTradeDataEvent?.Invoke(this, arg);
        
		// CrewAssign
        public event EventHandler<CrewAssignEvent> CrewAssignEvent;
        internal void InvokeCrewAssignEvent(CrewAssignEvent arg) => CrewAssignEvent?.Invoke(this, arg);
        
		// CrewFire
        public event EventHandler<CrewFireEvent> CrewFireEvent;
        internal void InvokeCrewFireEvent(CrewFireEvent arg) => CrewFireEvent?.Invoke(this, arg);
        
		// MultiSellExplorationData
        public event EventHandler<MultiSellExplorationDataEvent> MultiSellExplorationDataEvent;
        internal void InvokeMultiSellExplorationDataEvent(MultiSellExplorationDataEvent arg) => MultiSellExplorationDataEvent?.Invoke(this, arg);
        
		// Location
        public event EventHandler<LocationEvent> LocationEvent;
        internal void InvokeLocationEvent(LocationEvent arg) => LocationEvent?.Invoke(this, arg);
        
		// AsteroidCracked
        public event EventHandler<AsteroidCrackedEvent> AsteroidCrackedEvent;
        internal void InvokeAsteroidCrackedEvent(AsteroidCrackedEvent arg) => AsteroidCrackedEvent?.Invoke(this, arg);
        
		// ModuleSwap
        public event EventHandler<ModuleSwapEvent> ModuleSwapEvent;
        internal void InvokeModuleSwapEvent(ModuleSwapEvent arg) => ModuleSwapEvent?.Invoke(this, arg);
        
		// DataScanned
        public event EventHandler<DataScannedEvent> DataScannedEvent;
        internal void InvokeDataScannedEvent(DataScannedEvent arg) => DataScannedEvent?.Invoke(this, arg);
        
		// DisbandedSquadron
        public event EventHandler<DisbandedSquadronEvent> DisbandedSquadronEvent;
        internal void InvokeDisbandedSquadronEvent(DisbandedSquadronEvent arg) => DisbandedSquadronEvent?.Invoke(this, arg);
        
		// AppliedToSquadron
        public event EventHandler<AppliedToSquadronEvent> AppliedToSquadronEvent;
        internal void InvokeAppliedToSquadronEvent(AppliedToSquadronEvent arg) => AppliedToSquadronEvent?.Invoke(this, arg);
        
		// Docked
        public event EventHandler<DockedEvent> DockedEvent;
        internal void InvokeDockedEvent(DockedEvent arg) => DockedEvent?.Invoke(this, arg);
        
		// Statistics
        public event EventHandler<StatisticsEvent> StatisticsEvent;
        internal void InvokeStatisticsEvent(StatisticsEvent arg) => StatisticsEvent?.Invoke(this, arg);
        
		// SetUserShipName
        public event EventHandler<SetUserShipNameEvent> SetUserShipNameEvent;
        internal void InvokeSetUserShipNameEvent(SetUserShipNameEvent arg) => SetUserShipNameEvent?.Invoke(this, arg);
        
		// FSDJump
        public event EventHandler<FSDJumpEvent> FSDJumpEvent;
        internal void InvokeFSDJumpEvent(FSDJumpEvent arg) => FSDJumpEvent?.Invoke(this, arg);
        
		// ClearSavedGame
        public event EventHandler<ClearSavedGameEvent> ClearSavedGameEvent;
        internal void InvokeClearSavedGameEvent(ClearSavedGameEvent arg) => ClearSavedGameEvent?.Invoke(this, arg);
        
		// Cargo
        public event EventHandler<CargoEvent> CargoEvent;
        internal void InvokeCargoEvent(CargoEvent arg) => CargoEvent?.Invoke(this, arg);
        
		// EngineerCraft
        public event EventHandler<EngineerCraftEvent> EngineerCraftEvent;
        internal void InvokeEngineerCraftEvent(EngineerCraftEvent arg) => EngineerCraftEvent?.Invoke(this, arg);
        
		// ApproachSettlement
        public event EventHandler<ApproachSettlementEvent> ApproachSettlementEvent;
        internal void InvokeApproachSettlementEvent(ApproachSettlementEvent arg) => ApproachSettlementEvent?.Invoke(this, arg); 
        
        // StoredShips
        public event EventHandler<StoredShipsEvent> StoredShipsEvent;
        internal void InvokeStoredShipsEvent(StoredShipsEvent arg) => StoredShipsEvent?.Invoke(this, arg);
        
		// FSSSignalDiscovered
        public event EventHandler<FSSSignalDiscoveredEvent> FSSSignalDiscoveredEvent;
        internal void InvokeFSSSignalDiscoveredEvent(FSSSignalDiscoveredEvent arg) => FSSSignalDiscoveredEvent?.Invoke(this, arg);
        
		// SquadronStartup
        public event EventHandler<SquadronStartupEvent> SquadronStartupEvent;
        internal void InvokeSquadronStartupEvent(SquadronStartupEvent arg) => SquadronStartupEvent?.Invoke(this, arg);
    }
}