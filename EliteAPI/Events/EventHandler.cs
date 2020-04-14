using System;
using EliteAPI.Events.Exploration;
using EliteAPI.Events.Startup;
using EliteAPI.Events.Travel;

namespace EliteAPI.Events
{
    public class EventHandler
    {
        public event EventHandler<StatusEvent> StatusInMainMenu;

        internal StatusEvent InvokeStatusInMainMenu(StatusEvent e)
        {
            StatusInMainMenu?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusIsRunning;

        internal StatusEvent InvokeStatusIsRunning(StatusEvent e)
        {
            StatusIsRunning?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusInNoFireZoneEvent;

        internal StatusEvent InvokeStatusInNoFireZone(StatusEvent e)
        {
            StatusInNoFireZoneEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusDockedEvent;

        internal StatusEvent InvokeStatusDocked(StatusEvent e)
        {
            StatusDockedEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusLandedEvent;

        internal StatusEvent InvokeStatusLanded(StatusEvent e)
        {
            StatusLandedEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusFsdCooldownEvent;

        internal StatusEvent InvokeStatusFsdCooldown(StatusEvent e)
        {
            StatusFsdCooldownEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusGearEvent;

        internal StatusEvent InvokeStatusGear(StatusEvent e)
        {
            StatusGearEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusShieldsEvent;

        internal StatusEvent InvokeStatusShields(StatusEvent e)
        {
            StatusShieldsEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusSupercruiseEvent;

        internal StatusEvent InvokeStatusSupercruise(StatusEvent e)
        {
            StatusSupercruiseEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusFlightAssistEvent;

        internal StatusEvent InvokeStatusFlightAssist(StatusEvent e)
        {
            StatusFlightAssistEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusHardpointsEvent;

        internal StatusEvent InvokeStatusHardpoints(StatusEvent e)
        {
            StatusHardpointsEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusWingingEvent;

        internal StatusEvent InvokeStatusWinging(StatusEvent e)
        {
            StatusWingingEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusLightsEvent;

        internal StatusEvent InvokeStatusLights(StatusEvent e)
        {
            StatusLightsEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusCargoScoopEvent;

        internal StatusEvent InvokeStatusCargoScoop(StatusEvent e)
        {
            StatusCargoScoopEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusSilentRunningEvent;

        internal StatusEvent InvokeStatusSilentRunning(StatusEvent e)
        {
            StatusSilentRunningEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusScoopingEvent;

        internal StatusEvent InvokeStatusScooping(StatusEvent e)
        {
            StatusScoopingEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusSrvHandbreakEvent;

        internal StatusEvent InvokeStatusSrvHandbreak(StatusEvent e)
        {
            StatusSrvHandbreakEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusSrvTurrentEvent;

        internal StatusEvent InvokeStatusSrvTurrent(StatusEvent e)
        {
            StatusSrvTurrentEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusSrvNearShipEvent;

        internal StatusEvent InvokeStatusSrvNearShip(StatusEvent e)
        {
            StatusSrvNearShipEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusSrvDriveAssistEvent;

        internal StatusEvent InvokeStatusSrvDriveAssist(StatusEvent e)
        {
            StatusSrvDriveAssistEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusMassLockedEvent;

        internal StatusEvent InvokeStatusMassLocked(StatusEvent e)
        {
            StatusMassLockedEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusFsdChargingEvent;

        internal StatusEvent InvokeStatusFsdCharging(StatusEvent e)
        {
            StatusFsdChargingEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusFsdCooldowEvent;

        internal StatusEvent InvokeStatusFsdCooldow(StatusEvent e)
        {
            StatusFsdCooldowEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusLowFuelEvent;

        internal StatusEvent InvokeStatusLowFuel(StatusEvent e)
        {
            StatusLowFuelEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusOverheatingEvent;

        internal StatusEvent InvokeStatusOverheating(StatusEvent e)
        {
            StatusOverheatingEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusHasLatLongEvent;

        internal StatusEvent InvokeStatusHasLatLong(StatusEvent e)
        {
            StatusHasLatLongEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusInDangerEvent;

        internal StatusEvent InvokeStatusInDanger(StatusEvent e)
        {
            StatusInDangerEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusInInterdictionEvent;

        internal StatusEvent InvokeStatusInInterdiction(StatusEvent e)
        {
            StatusInInterdictionEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusInMothershipEvent;

        internal StatusEvent InvokeStatusInMothership(StatusEvent e)
        {
            StatusInMothershipEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusInFighterEvent;

        internal StatusEvent InvokeStatusInFighter(StatusEvent e)
        {
            StatusInFighterEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusInSRVEvent;

        internal StatusEvent InvokeStatusInSRV(StatusEvent e)
        {
            StatusInSRVEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusAnalysisModeEvent;

        internal StatusEvent InvokeStatusAnalysisMode(StatusEvent e)
        {
            StatusAnalysisModeEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusNightVisionEvent;

        internal StatusEvent InvokeStatusNightVision(StatusEvent e)
        {
            StatusNightVisionEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusAltitudeFromRadiusEvent;

        internal StatusEvent InvokeStatusAltitudeFromRadius(StatusEvent e)
        {
            StatusAltitudeFromRadiusEvent?.Invoke(this, e);

            return e;
        }

        public event EventHandler<StatusEvent> StatusFsdJumpEvent;

        internal StatusEvent InvokeStatusFsdJump(StatusEvent e)
        {
            StatusFsdJumpEvent?.Invoke(this, e);

            return e;
        } 
        
        public event EventHandler<StatusEvent> StatusSrvHighBeamEvent;

        internal StatusEvent InvokeStatusSrvHighBeam(StatusEvent e)
        {
            StatusSrvHighBeamEvent?.Invoke(this, e);

            return e;
        }   

        //AllEvents
        public event EventHandler<EventBase> AllEvent;

        internal EventBase InvokeAllEvent(EventBase arg)
        {
            AllEvent?.Invoke(null, arg);

            return arg;
        }

        //AllEvents
        public event EventHandler<object> MissingEvent;

        internal object InvokeMissingEvent(object arg)
        {
            MissingEvent?.Invoke(null, arg);

            return arg;
        }

        //ReservoirReplenished
        public event EventHandler<ReservoirReplenishedInfo> ReservoirReplenishedEvent;

        internal ReservoirReplenishedInfo InvokeReservoirReplenishedEvent(ReservoirReplenishedInfo arg)
        {
            ReservoirReplenishedEvent?.Invoke(null, arg);

            return arg;
        }

        //ProspectedAsteroid
        public event EventHandler<ProspectedAsteroidInfo> ProspectedAsteroidEvent;

        internal ProspectedAsteroidInfo InvokeProspectedAsteroidEvent(ProspectedAsteroidInfo arg)
        {
            ProspectedAsteroidEvent?.Invoke(null, arg);

            return arg;
        }

        //LeftSquadron
        public event EventHandler<LeftSquadronInfo> LeftSquadronEvent;

        internal LeftSquadronInfo InvokeLeftSquadronEvent(LeftSquadronInfo arg)
        {
            LeftSquadronEvent?.Invoke(null, arg);

            return arg;
        }

        //HeatWarning
        public event EventHandler<HeatWarningInfo> HeatWarningEvent;

        internal HeatWarningInfo InvokeHeatWarningEvent(HeatWarningInfo arg)
        {
            HeatWarningEvent?.Invoke(null, arg);

            return arg;
        }

        //ShieldState
        public event EventHandler<ShieldStateInfo> ShieldStateEvent;

        internal ShieldStateInfo InvokeShieldStateEvent(ShieldStateInfo arg)
        {
            ShieldStateEvent?.Invoke(null, arg);

            return arg;
        }

        //VehicleSwitch
        public event EventHandler<VehicleSwitchInfo> VehicleSwitchEvent;

        internal VehicleSwitchInfo InvokeVehicleSwitchEvent(VehicleSwitchInfo arg)
        {
            VehicleSwitchEvent?.Invoke(null, arg);

            return arg;
        }

        //DockFighter
        public event EventHandler<DockFighterInfo> DockFighterEvent;

        internal DockFighterInfo InvokeDockFighterEvent(DockFighterInfo arg)
        {
            DockFighterEvent?.Invoke(null, arg);

            return arg;
        }

        //LaunchSRV
        public event EventHandler<LaunchSRVInfo> LaunchSRVEvent;

        internal LaunchSRVInfo InvokeLaunchSRVEvent(LaunchSRVInfo arg)
        {
            LaunchSRVEvent?.Invoke(null, arg);

            return arg;
        }

        //SelfDestruct
        public event EventHandler<SelfDestructInfo> SelfDestructEvent;

        internal SelfDestructInfo InvokeSelfDestructEvent(SelfDestructInfo arg)
        {
            SelfDestructEvent?.Invoke(null, arg);

            return arg;
        }

        //DockSRV
        public event EventHandler<DockSRVInfo> DockSRVEvent;

        internal DockSRVInfo InvokeDockSRVEvent(DockSRVInfo arg)
        {
            DockSRVEvent?.Invoke(null, arg);

            return arg;
        }

        //HeatDamage
        public event EventHandler<HeatDamageInfo> HeatDamageEvent;

        internal HeatDamageInfo InvokeHeatDamageEvent(HeatDamageInfo arg)
        {
            HeatDamageEvent?.Invoke(null, arg);

            return arg;
        }

        //LaunchFighter
        public event EventHandler<LaunchFighterInfo> LaunchFighterEvent;

        internal LaunchFighterInfo InvokeLaunchFighterEvent(LaunchFighterInfo arg)
        {
            LaunchFighterEvent?.Invoke(null, arg);

            return arg;
        }

        //DatalinkScan
        public event EventHandler<DatalinkScanInfo> DatalinkScanEvent;

        internal DatalinkScanInfo InvokeDatalinkScanEvent(DatalinkScanInfo arg)
        {
            DatalinkScanEvent?.Invoke(null, arg);

            return arg;
        }

        //CockpitBreached
        public event EventHandler<CockpitBreachedInfo> CockpitBreachedEvent;

        internal CockpitBreachedInfo InvokeCockpitBreachedEvent(CockpitBreachedInfo arg)
        {
            CockpitBreachedEvent?.Invoke(null, arg);

            return arg;
        }

        //JetConeBoost
        public event EventHandler<JetConeBoostInfo> JetConeBoostEvent;

        internal JetConeBoostInfo InvokeJetConeBoostEvent(JetConeBoostInfo arg)
        {
            JetConeBoostEvent?.Invoke(null, arg);

            return arg;
        }

        //PowerplayLeave
        public event EventHandler<PowerplayLeaveInfo> PowerplayLeaveEvent;

        internal PowerplayLeaveInfo InvokePowerplayLeaveEvent(PowerplayLeaveInfo arg)
        {
            PowerplayLeaveEvent?.Invoke(null, arg);

            return arg;
        }

        //Interdiction
        public event EventHandler<InterdictionInfo> InterdictionEvent;

        internal InterdictionInfo InvokeInterdictionEvent(InterdictionInfo arg)
        {
            InterdictionEvent?.Invoke(null, arg);

            return arg;
        }

        //USSDrop
        public event EventHandler<USSDropInfo> USSDropEvent;

        internal USSDropInfo InvokeUSSDropEvent(USSDropInfo arg)
        {
            USSDropEvent?.Invoke(null, arg);

            return arg;
        }

        //PowerplayCollect
        public event EventHandler<PowerplayCollectInfo> PowerplayCollectEvent;

        internal PowerplayCollectInfo InvokePowerplayCollectEvent(PowerplayCollectInfo arg)
        {
            PowerplayCollectEvent?.Invoke(null, arg);

            return arg;
        }

        //PowerplayDeliver
        public event EventHandler<PowerplayDeliverInfo> PowerplayDeliverEvent;

        internal PowerplayDeliverInfo InvokePowerplayDeliverEvent(PowerplayDeliverInfo arg)
        {
            PowerplayDeliverEvent?.Invoke(null, arg);

            return arg;
        }

        //PayLegacyFines
        public event EventHandler<PayLegacyFinesInfo> PayLegacyFinesEvent;

        internal PayLegacyFinesInfo InvokePayLegacyFinesEvent(PayLegacyFinesInfo arg)
        {
            PayLegacyFinesEvent?.Invoke(null, arg);

            return arg;
        }

        //EngineerApply
        public event EventHandler<EngineerApplyInfo> EngineerApplyEvent;

        internal EngineerApplyInfo InvokeEngineerApplyEvent(EngineerApplyInfo arg)
        {
            EngineerApplyEvent?.Invoke(null, arg);

            return arg;
        }

        //WingLeave
        public event EventHandler<WingLeaveInfo> WingLeaveEvent;

        internal WingLeaveInfo InvokeWingLeaveEvent(WingLeaveInfo arg)
        {
            WingLeaveEvent?.Invoke(null, arg);

            return arg;
        }

        //SystemsShutdown
        public event EventHandler<SystemsShutdownInfo> SystemsShutdownEvent;

        internal SystemsShutdownInfo InvokeSystemsShutdownEvent(SystemsShutdownInfo arg)
        {
            SystemsShutdownEvent?.Invoke(null, arg);

            return arg;
        }

        //HullDamage
        public event EventHandler<HullDamageInfo> HullDamageEvent;

        internal HullDamageInfo InvokeHullDamageEvent(HullDamageInfo arg)
        {
            HullDamageEvent?.Invoke(null, arg);

            return arg;
        }

        //BuyDrones
        public event EventHandler<BuyDronesInfo> BuyDronesEvent;

        internal BuyDronesInfo InvokeBuyDronesEvent(BuyDronesInfo arg)
        {
            BuyDronesEvent?.Invoke(null, arg);

            return arg;
        }

        //RestockVehicle
        public event EventHandler<RestockVehicleInfo> RestockVehicleEvent;

        internal RestockVehicleInfo InvokeRestockVehicleEvent(RestockVehicleInfo arg)
        {
            RestockVehicleEvent?.Invoke(null, arg);

            return arg;
        }

        //BuyAmmo
        public event EventHandler<BuyAmmoInfo> BuyAmmoEvent;

        internal BuyAmmoInfo InvokeBuyAmmoEvent(BuyAmmoInfo arg)
        {
            BuyAmmoEvent?.Invoke(null, arg);

            return arg;
        }

        //MiningRefined
        public event EventHandler<MiningRefinedInfo> MiningRefinedEvent;

        internal MiningRefinedInfo InvokeMiningRefinedEvent(MiningRefinedInfo arg)
        {
            MiningRefinedEvent?.Invoke(null, arg);

            return arg;
        }

        //DatalinkVoucher
        public event EventHandler<DatalinkVoucherInfo> DatalinkVoucherEvent;

        internal DatalinkVoucherInfo InvokeDatalinkVoucherEvent(DatalinkVoucherInfo arg)
        {
            DatalinkVoucherEvent?.Invoke(null, arg);

            return arg;
        }

        //Scanned
        public event EventHandler<ScannedInfo> ScannedEvent;

        internal ScannedInfo InvokeScannedEvent(ScannedInfo arg)
        {
            ScannedEvent?.Invoke(null, arg);

            return arg;
        }

        //ChangeCrewRole
        public event EventHandler<ChangeCrewRoleInfo> ChangeCrewRoleEvent;

        internal ChangeCrewRoleInfo InvokeChangeCrewRoleEvent(ChangeCrewRoleInfo arg)
        {
            ChangeCrewRoleEvent?.Invoke(null, arg);

            return arg;
        }

        //Touchdown
        public event EventHandler<TouchdownInfo> TouchdownEvent;

        internal TouchdownInfo InvokeTouchdownEvent(TouchdownInfo arg)
        {
            TouchdownEvent?.Invoke(null, arg);

            return arg;
        }

        //SendText
        public event EventHandler<SendTextInfo> SendTextEvent;

        internal SendTextInfo InvokeSendTextEvent(SendTextInfo arg)
        {
            SendTextEvent?.Invoke(null, arg);

            return arg;
        }

        //RefuelAll
        public event EventHandler<RefuelAllInfo> RefuelAllEvent;

        internal RefuelAllInfo InvokeRefuelAllEvent(RefuelAllInfo arg)
        {
            RefuelAllEvent?.Invoke(null, arg);

            return arg;
        }

        //EndCrewSession
        public event EventHandler<EndCrewSessionInfo> EndCrewSessionEvent;

        internal EndCrewSessionInfo InvokeEndCrewSessionEvent(EndCrewSessionInfo arg)
        {
            EndCrewSessionEvent?.Invoke(null, arg);

            return arg;
        }

        //Liftoff
        public event EventHandler<LiftoffInfo> LiftoffEvent;

        internal LiftoffInfo InvokeLiftoffEvent(LiftoffInfo arg)
        {
            LiftoffEvent?.Invoke(null, arg);

            return arg;
        }

        //EscapeInterdiction
        public event EventHandler<EscapeInterdictionInfo> EscapeInterdictionEvent;

        internal EscapeInterdictionInfo InvokeEscapeInterdictionEvent(EscapeInterdictionInfo arg)
        {
            EscapeInterdictionEvent?.Invoke(null, arg);

            return arg;
        }

        //WingAdd
        public event EventHandler<WingAddInfo> WingAddEvent;

        internal WingAddInfo InvokeWingAddEvent(WingAddInfo arg)
        {
            WingAddEvent?.Invoke(null, arg);

            return arg;
        }

        //SellDrones
        public event EventHandler<SellDronesInfo> SellDronesEvent;

        internal SellDronesInfo InvokeSellDronesEvent(SellDronesInfo arg)
        {
            SellDronesEvent?.Invoke(null, arg);

            return arg;
        }

        //Fileheader
        public event EventHandler<FileheaderInfo> FileheaderEvent;

        internal FileheaderInfo InvokeFileheaderEvent(FileheaderInfo arg)
        {
            FileheaderEvent?.Invoke(null, arg);

            return arg;
        }

        //Interdicted
        public event EventHandler<InterdictedInfo> InterdictedEvent;

        internal InterdictedInfo InvokeInterdictedEvent(InterdictedInfo arg)
        {
            InterdictedEvent?.Invoke(null, arg);

            return arg;
        }

        //CrewMemberJoins
        public event EventHandler<CrewMemberJoinsInfo> CrewMemberJoinsEvent;

        internal CrewMemberJoinsInfo InvokeCrewMemberJoinsEvent(CrewMemberJoinsInfo arg)
        {
            CrewMemberJoinsEvent?.Invoke(null, arg);

            return arg;
        }

        //CrewMemberQuits
        public event EventHandler<CrewMemberQuitsInfo> CrewMemberQuitsEvent;

        internal CrewMemberQuitsInfo InvokeCrewMemberQuitsEvent(CrewMemberQuitsInfo arg)
        {
            CrewMemberQuitsEvent?.Invoke(null, arg);

            return arg;
        }

        //CrewMemberRoleChange
        public event EventHandler<CrewMemberRoleChangeInfo> CrewMemberRoleChangeEvent;

        internal CrewMemberRoleChangeInfo InvokeCrewMemberRoleChangeEvent(CrewMemberRoleChangeInfo arg)
        {
            CrewMemberRoleChangeEvent?.Invoke(null, arg);

            return arg;
        }

        //PVPKill
        public event EventHandler<PVPKillInfo> PVPKillEvent;

        internal PVPKillInfo InvokePVPKillEvent(PVPKillInfo arg)
        {
            PVPKillEvent?.Invoke(null, arg);

            return arg;
        }

        //JoinACrew
        public event EventHandler<JoinACrewInfo> JoinACrewEvent;

        internal JoinACrewInfo InvokeJoinACrewEvent(JoinACrewInfo arg)
        {
            JoinACrewEvent?.Invoke(null, arg);

            return arg;
        }

        //QuitACrew
        public event EventHandler<QuitACrewInfo> QuitACrewEvent;

        internal QuitACrewInfo InvokeQuitACrewEvent(QuitACrewInfo arg)
        {
            QuitACrewEvent?.Invoke(null, arg);

            return arg;
        }

        //Progress
        public event EventHandler<ProgressInfo> ProgressEvent;

        internal ProgressInfo InvokeProgressEvent(ProgressInfo arg)
        {
            ProgressEvent?.Invoke(null, arg);

            return arg;
        }

        //Promotion
        public event EventHandler<PromotionInfo> PromotionEvent;

        internal PromotionInfo InvokePromotionEvent(PromotionInfo arg)
        {
            PromotionEvent?.Invoke(null, arg);

            return arg;
        }

        //Rank
        public event EventHandler<RankInfo> RankEvent;

        internal RankInfo InvokeRankEvent(RankInfo arg)
        {
            RankEvent?.Invoke(null, arg);

            return arg;
        }

        //CommitCrime
        public event EventHandler<CommitCrimeInfo> CommitCrimeEvent;

        internal CommitCrimeInfo InvokeCommitCrimeEvent(CommitCrimeInfo arg)
        {
            CommitCrimeEvent?.Invoke(null, arg);

            return arg;
        }

        //EngineerContribution
        public event EventHandler<EngineerContributionInfo> EngineerContributionEvent;

        internal EngineerContributionInfo InvokeEngineerContributionEvent(EngineerContributionInfo arg)
        {
            EngineerContributionEvent?.Invoke(null, arg);

            return arg;
        }

        //Music
        public event EventHandler<MusicInfo> MusicEvent;

        internal MusicInfo InvokeMusicEvent(MusicInfo arg)
        {
            MusicEvent?.Invoke(null, arg);

            return arg;
        }

        //Died
        public event EventHandler<DiedInfo> DiedEvent;

        internal DiedInfo InvokeDiedEvent(DiedInfo arg)
        {
            DiedEvent?.Invoke(null, arg);

            return arg;
        }

        //Passengers
        public event EventHandler<PassengersInfo> PassengersEvent;

        internal PassengersInfo InvokePassengersEvent(PassengersInfo arg)
        {
            PassengersEvent?.Invoke(null, arg);

            return arg;
        }

        //SearchAndRescue
        public event EventHandler<SearchAndRescueInfo> SearchAndRescueEvent;

        internal SearchAndRescueInfo InvokeSearchAndRescueEvent(SearchAndRescueInfo arg)
        {
            SearchAndRescueEvent?.Invoke(null, arg);

            return arg;
        }

        //KickCrewMember
        public event EventHandler<KickCrewMemberInfo> KickCrewMemberEvent;

        internal KickCrewMemberInfo InvokeKickCrewMemberEvent(KickCrewMemberInfo arg)
        {
            KickCrewMemberEvent?.Invoke(null, arg);

            return arg;
        }

        //RedeemVoucher
        public event EventHandler<RedeemVoucherInfo> RedeemVoucherEvent;

        internal RedeemVoucherInfo InvokeRedeemVoucherEvent(RedeemVoucherInfo arg)
        {
            RedeemVoucherEvent?.Invoke(null, arg);

            return arg;
        }

        //Resurrect
        public event EventHandler<ResurrectInfo> ResurrectEvent;

        internal ResurrectInfo InvokeResurrectEvent(ResurrectInfo arg)
        {
            ResurrectEvent?.Invoke(null, arg);

            return arg;
        }

        //CommunityGoalJoin
        public event EventHandler<CommunityGoalJoinInfo> CommunityGoalJoinEvent;

        internal CommunityGoalJoinInfo InvokeCommunityGoalJoinEvent(CommunityGoalJoinInfo arg)
        {
            CommunityGoalJoinEvent?.Invoke(null, arg);

            return arg;
        }

        //CommunityGoal
        public event EventHandler<CommunityGoalInfo> CommunityGoalEvent;

        internal CommunityGoalInfo InvokeCommunityGoalEvent(CommunityGoalInfo arg)
        {
            CommunityGoalEvent?.Invoke(null, arg);

            return arg;
        }

        //RepairDrone
        public event EventHandler<RepairDroneInfo> RepairDroneEvent;

        internal RepairDroneInfo InvokeRepairDroneEvent(RepairDroneInfo arg)
        {
            RepairDroneEvent?.Invoke(null, arg);

            return arg;
        }

        //Repair
        public event EventHandler<RepairInfo> RepairEvent;

        internal RepairInfo InvokeRepairEvent(RepairInfo arg)
        {
            RepairEvent?.Invoke(null, arg);

            return arg;
        }

        //JetConeDamage
        public event EventHandler<JetConeDamageInfo> JetConeDamageEvent;

        internal JetConeDamageInfo InvokeJetConeDamageEvent(JetConeDamageInfo arg)
        {
            JetConeDamageEvent?.Invoke(null, arg);

            return arg;
        }

        //CommunityGoalDiscard
        public event EventHandler<CommunityGoalDiscardInfo> CommunityGoalDiscardEvent;

        internal CommunityGoalDiscardInfo InvokeCommunityGoalDiscardEvent(CommunityGoalDiscardInfo arg)
        {
            CommunityGoalDiscardEvent?.Invoke(null, arg);

            return arg;
        }

        //MissionAccepted
        public event EventHandler<MissionAcceptedInfo> MissionAcceptedEvent;

        internal MissionAcceptedInfo InvokeMissionAcceptedEvent(MissionAcceptedInfo arg)
        {
            MissionAcceptedEvent?.Invoke(null, arg);

            return arg;
        }

        //BuyExplorationData
        public event EventHandler<BuyExplorationDataInfo> BuyExplorationDataEvent;

        internal BuyExplorationDataInfo InvokeBuyExplorationDataEvent(BuyExplorationDataInfo arg)
        {
            BuyExplorationDataEvent?.Invoke(null, arg);

            return arg;
        }

        //RepairAll
        public event EventHandler<RepairAllInfo> RepairAllEvent;

        internal RepairAllInfo InvokeRepairAllEvent(RepairAllInfo arg)
        {
            RepairAllEvent?.Invoke(null, arg);

            return arg;
        }

        //CrewLaunchFighter
        public event EventHandler<CrewLaunchFighterInfo> CrewLaunchFighterEvent;

        internal CrewLaunchFighterInfo InvokeCrewLaunchFighterEvent(CrewLaunchFighterInfo arg)
        {
            CrewLaunchFighterEvent?.Invoke(null, arg);

            return arg;
        }

        //MaterialDiscarded
        public event EventHandler<MaterialDiscardedInfo> MaterialDiscardedEvent;

        internal MaterialDiscardedInfo InvokeMaterialDiscardedEvent(MaterialDiscardedInfo arg)
        {
            MaterialDiscardedEvent?.Invoke(null, arg);

            return arg;
        }

        //NewCommander
        public event EventHandler<NewCommanderInfo> NewCommanderEvent;

        internal NewCommanderInfo InvokeNewCommanderEvent(NewCommanderInfo arg)
        {
            NewCommanderEvent?.Invoke(null, arg);

            return arg;
        }

        //CommunityGoalReward
        public event EventHandler<CommunityGoalRewardInfo> CommunityGoalRewardEvent;

        internal CommunityGoalRewardInfo InvokeCommunityGoalRewardEvent(CommunityGoalRewardInfo arg)
        {
            CommunityGoalRewardEvent?.Invoke(null, arg);

            return arg;
        }

        //PowerplayVote
        public event EventHandler<PowerplayVoteInfo> PowerplayVoteEvent;

        internal PowerplayVoteInfo InvokePowerplayVoteEvent(PowerplayVoteInfo arg)
        {
            PowerplayVoteEvent?.Invoke(null, arg);

            return arg;
        }

        //PowerplayJoin
        public event EventHandler<PowerplayJoinInfo> PowerplayJoinEvent;

        internal PowerplayJoinInfo InvokePowerplayJoinEvent(PowerplayJoinInfo arg)
        {
            PowerplayJoinEvent?.Invoke(null, arg);

            return arg;
        }

        //PowerplayDefect
        public event EventHandler<PowerplayDefectInfo> PowerplayDefectEvent;

        internal PowerplayDefectInfo InvokePowerplayDefectEvent(PowerplayDefectInfo arg)
        {
            PowerplayDefectEvent?.Invoke(null, arg);

            return arg;
        }

        //MissionFailed
        public event EventHandler<MissionFailedInfo> MissionFailedEvent;

        internal MissionFailedInfo InvokeMissionFailedEvent(MissionFailedInfo arg)
        {
            MissionFailedEvent?.Invoke(null, arg);

            return arg;
        }

        //MissionRedirected
        public event EventHandler<MissionRedirectedInfo> MissionRedirectedEvent;

        internal MissionRedirectedInfo InvokeMissionRedirectedEvent(MissionRedirectedInfo arg)
        {
            MissionRedirectedEvent?.Invoke(null, arg);

            return arg;
        }

        //Shutdown
        public event EventHandler<ShutdownInfo> ShutdownEvent;

        internal ShutdownInfo InvokeShutdownEvent(ShutdownInfo arg)
        {
            ShutdownEvent?.Invoke(null, arg);

            return arg;
        }

        //ModuleInfo
        public event EventHandler<ModuleInfoInfo> ModuleInfoEvent;

        internal ModuleInfoInfo InvokeModuleInfoEvent(ModuleInfoInfo arg)
        {
            ModuleInfoEvent?.Invoke(null, arg);

            return arg;
        }

        //Market
        public event EventHandler<MarketInfo> MarketEvent;

        internal MarketInfo InvokeMarketEvent(MarketInfo arg)
        {
            MarketEvent?.Invoke(null, arg);

            return arg;
        }

        //MassModuleStore
        public event EventHandler<MassModuleStoreInfo> MassModuleStoreEvent;

        internal MassModuleStoreInfo InvokeMassModuleStoreEvent(MassModuleStoreInfo arg)
        {
            MassModuleStoreEvent?.Invoke(null, arg);

            return arg;
        }

        //MaterialDiscovered
        public event EventHandler<MaterialDiscoveredInfo> MaterialDiscoveredEvent;

        internal MaterialDiscoveredInfo InvokeMaterialDiscoveredEvent(MaterialDiscoveredInfo arg)
        {
            MaterialDiscoveredEvent?.Invoke(null, arg);

            return arg;
        }

        //MaterialCollected
        public event EventHandler<MaterialCollectedInfo> MaterialCollectedEvent;

        internal MaterialCollectedInfo InvokeMaterialCollectedEvent(MaterialCollectedInfo arg)
        {
            MaterialCollectedEvent?.Invoke(null, arg);

            return arg;
        }

        //SRVDestroyed
        public event EventHandler<SRVDestroyedInfo> SRVDestroyedEvent;

        internal SRVDestroyedInfo InvokeSRVDestroyedEvent(SRVDestroyedInfo arg)
        {
            SRVDestroyedEvent?.Invoke(null, arg);

            return arg;
        }

        //DockingDenied
        public event EventHandler<DockingDeniedInfo> DockingDeniedEvent;

        internal DockingDeniedInfo InvokeDockingDeniedEvent(DockingDeniedInfo arg)
        {
            DockingDeniedEvent?.Invoke(null, arg);

            return arg;
        }

        //UnderAttack
        public event EventHandler<UnderAttackInfo> UnderAttackEvent;

        internal UnderAttackInfo InvokeUnderAttackEvent(UnderAttackInfo arg)
        {
            UnderAttackEvent?.Invoke(null, arg);

            return arg;
        }

        //ShipTargeted
        public event EventHandler<ShipTargetedInfo> ShipTargetedEvent;

        internal ShipTargetedInfo InvokeShipTargetedEvent(ShipTargetedInfo arg)
        {
            ShipTargetedEvent?.Invoke(null, arg);

            return arg;
        }

        //Shipyard
        public event EventHandler<ShipyardInfo> ShipyardEvent;

        internal ShipyardInfo InvokeShipyardEvent(ShipyardInfo arg)
        {
            ShipyardEvent?.Invoke(null, arg);

            return arg;
        }

        //Outfitting
        public event EventHandler<OutfittingInfo> OutfittingEvent;

        internal OutfittingInfo InvokeOutfittingEvent(OutfittingInfo arg)
        {
            OutfittingEvent?.Invoke(null, arg);

            return arg;
        }

        //PowerplayFastTrack
        public event EventHandler<PowerplayFastTrackInfo> PowerplayFastTrackEvent;

        internal PowerplayFastTrackInfo InvokePowerplayFastTrackEvent(PowerplayFastTrackInfo arg)
        {
            PowerplayFastTrackEvent?.Invoke(null, arg);

            return arg;
        }

        //Powerplay
        public event EventHandler<PowerplayInfo> PowerplayEvent;

        internal PowerplayInfo InvokePowerplayEvent(PowerplayInfo arg)
        {
            PowerplayEvent?.Invoke(null, arg);

            return arg;
        }

        //CollectCargo
        public event EventHandler<CollectCargoInfo> CollectCargoEvent;

        internal CollectCargoInfo InvokeCollectCargoEvent(CollectCargoInfo arg)
        {
            CollectCargoEvent?.Invoke(null, arg);

            return arg;
        }

        //FetchRemoteModule
        public event EventHandler<FetchRemoteModuleInfo> FetchRemoteModuleEvent;

        internal FetchRemoteModuleInfo InvokeFetchRemoteModuleEvent(FetchRemoteModuleInfo arg)
        {
            FetchRemoteModuleEvent?.Invoke(null, arg);

            return arg;
        }

        //ModuleStore
        public event EventHandler<ModuleStoreInfo> ModuleStoreEvent;

        internal ModuleStoreInfo InvokeModuleStoreEvent(ModuleStoreInfo arg)
        {
            ModuleStoreEvent?.Invoke(null, arg);

            return arg;
        }

        //ShipyardBuy
        public event EventHandler<ShipyardBuyInfo> ShipyardBuyEvent;

        internal ShipyardBuyInfo InvokeShipyardBuyEvent(ShipyardBuyInfo arg)
        {
            ShipyardBuyEvent?.Invoke(null, arg);

            return arg;
        }

        //ShipyardNew
        public event EventHandler<ShipyardNewInfo> ShipyardNewEvent;

        internal ShipyardNewInfo InvokeShipyardNewEvent(ShipyardNewInfo arg)
        {
            ShipyardNewEvent?.Invoke(null, arg);

            return arg;
        }

        //ModuleBuy
        public event EventHandler<ModuleBuyInfo> ModuleBuyEvent;

        internal ModuleBuyInfo InvokeModuleBuyEvent(ModuleBuyInfo arg)
        {
            ModuleBuyEvent?.Invoke(null, arg);

            return arg;
        }

        //ModuleRetrieve
        public event EventHandler<ModuleRetrieveInfo> ModuleRetrieveEvent;

        internal ModuleRetrieveInfo InvokeModuleRetrieveEvent(ModuleRetrieveInfo arg)
        {
            ModuleRetrieveEvent?.Invoke(null, arg);

            return arg;
        }

        //AfmuRepairs
        public event EventHandler<AfmuRepairsInfo> AfmuRepairsEvent;

        internal AfmuRepairsInfo InvokeAfmuRepairsEvent(AfmuRepairsInfo arg)
        {
            AfmuRepairsEvent?.Invoke(null, arg);

            return arg;
        }

        //LaunchDrone
        public event EventHandler<LaunchDroneInfo> LaunchDroneEvent;

        internal LaunchDroneInfo InvokeLaunchDroneEvent(LaunchDroneInfo arg)
        {
            LaunchDroneEvent?.Invoke(null, arg);

            return arg;
        }

        //MarketSell
        public event EventHandler<MarketSellInfo> MarketSellEvent;

        internal MarketSellInfo InvokeMarketSellEvent(MarketSellInfo arg)
        {
            MarketSellEvent?.Invoke(null, arg);

            return arg;
        }

        //ModuleSell
        public event EventHandler<ModuleSellInfo> ModuleSellEvent;

        internal ModuleSellInfo InvokeModuleSellEvent(ModuleSellInfo arg)
        {
            ModuleSellEvent?.Invoke(null, arg);

            return arg;
        }

        //FuelScoop
        public event EventHandler<FuelScoopInfo> FuelScoopEvent;

        internal FuelScoopInfo InvokeFuelScoopEvent(FuelScoopInfo arg)
        {
            FuelScoopEvent?.Invoke(null, arg);

            return arg;
        }

        //FighterDestroyed
        public event EventHandler<FighterDestroyedInfo> FighterDestroyedEvent;

        internal FighterDestroyedInfo InvokeFighterDestroyedEvent(FighterDestroyedInfo arg)
        {
            FighterDestroyedEvent?.Invoke(null, arg);

            return arg;
        }

        //DiscoveryScan
        public event EventHandler<DiscoveryScanInfo> DiscoveryScanEvent;

        internal DiscoveryScanInfo InvokeDiscoveryScanEvent(DiscoveryScanInfo arg)
        {
            DiscoveryScanEvent?.Invoke(null, arg);

            return arg;
        }

        //LeaveBody
        public event EventHandler<LeaveBodyInfo> LeaveBodyEvent;

        internal LeaveBodyInfo InvokeLeaveBodyEvent(LeaveBodyInfo arg)
        {
            LeaveBodyEvent?.Invoke(null, arg);

            return arg;
        }

        //PowerplayVoucher
        public event EventHandler<PowerplayVoucherInfo> PowerplayVoucherEvent;

        internal PowerplayVoucherInfo InvokePowerplayVoucherEvent(PowerplayVoucherInfo arg)
        {
            PowerplayVoucherEvent?.Invoke(null, arg);

            return arg;
        }

        //Reputation
        public event EventHandler<ReputationInfo> ReputationEvent;

        internal ReputationInfo InvokeReputationEvent(ReputationInfo arg)
        {
            ReputationEvent?.Invoke(null, arg);

            return arg;
        }

        //NavBeaconScan
        public event EventHandler<NavBeaconScanInfo> NavBeaconScanEvent;

        internal NavBeaconScanInfo InvokeNavBeaconScanEvent(NavBeaconScanInfo arg)
        {
            NavBeaconScanEvent?.Invoke(null, arg);

            return arg;
        }

        //Missions
        public event EventHandler<MissionsInfo> MissionsEvent;

        internal MissionsInfo InvokeMissionsEvent(MissionsInfo arg)
        {
            MissionsEvent?.Invoke(null, arg);

            return arg;
        }

        //Friends
        public event EventHandler<FriendsInfo> FriendsEvent;

        internal FriendsInfo InvokeFriendsEvent(FriendsInfo arg)
        {
            FriendsEvent?.Invoke(null, arg);

            return arg;
        }

        //ShipyardSell
        public event EventHandler<ShipyardSellInfo> ShipyardSellEvent;

        internal ShipyardSellInfo InvokeShipyardSellEvent(ShipyardSellInfo arg)
        {
            ShipyardSellEvent?.Invoke(null, arg);

            return arg;
        }

        //MissionAbandoned
        public event EventHandler<MissionAbandonedInfo> MissionAbandonedEvent;

        internal MissionAbandonedInfo InvokeMissionAbandonedEvent(MissionAbandonedInfo arg)
        {
            MissionAbandonedEvent?.Invoke(null, arg);

            return arg;
        }

        //ScientificResearch
        public event EventHandler<ScientificResearchInfo> ScientificResearchEvent;

        internal ScientificResearchInfo InvokeScientificResearchEvent(ScientificResearchInfo arg)
        {
            ScientificResearchEvent?.Invoke(null, arg);

            return arg;
        }

        //DockingTimeout
        public event EventHandler<DockingTimeoutInfo> DockingTimeoutEvent;

        internal DockingTimeoutInfo InvokeDockingTimeoutEvent(DockingTimeoutInfo arg)
        {
            DockingTimeoutEvent?.Invoke(null, arg);

            return arg;
        }

        //DockingCancelled
        public event EventHandler<DockingCancelledInfo> DockingCancelledEvent;

        internal DockingCancelledInfo InvokeDockingCancelledEvent(DockingCancelledInfo arg)
        {
            DockingCancelledEvent?.Invoke(null, arg);

            return arg;
        }

        //DockingRequested
        public event EventHandler<DockingRequestedInfo> DockingRequestedEvent;

        internal DockingRequestedInfo InvokeDockingRequestedEvent(DockingRequestedInfo arg)
        {
            DockingRequestedEvent?.Invoke(null, arg);

            return arg;
        }

        //DockingGranted
        public event EventHandler<DockingGrantedInfo> DockingGrantedEvent;

        internal DockingGrantedInfo InvokeDockingGrantedEvent(DockingGrantedInfo arg)
        {
            DockingGrantedEvent?.Invoke(null, arg);

            return arg;
        }

        //Undocked
        public event EventHandler<UndockedInfo> UndockedEvent;

        internal UndockedInfo InvokeUndockedEvent(UndockedInfo arg)
        {
            UndockedEvent?.Invoke(null, arg);

            return arg;
        }

        //CrewHire
        public event EventHandler<CrewHireInfo> CrewHireEvent;

        internal CrewHireInfo InvokeCrewHireEvent(CrewHireInfo arg)
        {
            CrewHireEvent?.Invoke(null, arg);

            return arg;
        }

        //Screenshot
        public event EventHandler<ScreenshotInfo> ScreenshotEvent;

        internal ScreenshotInfo InvokeScreenshotEvent(ScreenshotInfo arg)
        {
            ScreenshotEvent?.Invoke(null, arg);

            return arg;
        }

        //Synthesis
        public event EventHandler<SynthesisInfo> SynthesisEvent;

        internal SynthesisInfo InvokeSynthesisEvent(SynthesisInfo arg)
        {
            SynthesisEvent?.Invoke(null, arg);

            return arg;
        }

        //FighterRebuilt
        public event EventHandler<FighterRebuiltInfo> FighterRebuiltEvent;

        internal FighterRebuiltInfo InvokeFighterRebuiltEvent(FighterRebuiltInfo arg)
        {
            FighterRebuiltEvent?.Invoke(null, arg);

            return arg;
        }

        //SellExplorationData
        public event EventHandler<SellExplorationDataInfo> SellExplorationDataEvent;

        internal SellExplorationDataInfo InvokeSellExplorationDataEvent(SellExplorationDataInfo arg)
        {
            SellExplorationDataEvent?.Invoke(null, arg);

            return arg;
        }

        //RebootRepair
        public event EventHandler<RebootRepairInfo> RebootRepairEvent;

        internal RebootRepairInfo InvokeRebootRepairEvent(RebootRepairInfo arg)
        {
            RebootRepairEvent?.Invoke(null, arg);

            return arg;
        }

        //Scan
        public event EventHandler<ScanInfo> ScanEvent;

        internal ScanInfo InvokeScanEvent(ScanInfo arg)
        {
            ScanEvent?.Invoke(null, arg);

            return arg;
        }

        //WingInvite
        public event EventHandler<WingInviteInfo> WingInviteEvent;

        internal WingInviteInfo InvokeWingInviteEvent(WingInviteInfo arg)
        {
            WingInviteEvent?.Invoke(null, arg);

            return arg;
        }

        //StartJump
        public event EventHandler<StartJumpInfo> StartJumpEvent;

        internal StartJumpInfo InvokeStartJumpEvent(StartJumpInfo arg)
        {
            StartJumpEvent?.Invoke(null, arg);

            return arg;
        }

        //SupercruiseExit
        public event EventHandler<SupercruiseExitInfo> SupercruiseExitEvent;

        internal SupercruiseExitInfo InvokeSupercruiseExitEvent(SupercruiseExitInfo arg)
        {
            SupercruiseExitEvent?.Invoke(null, arg);

            return arg;
        }

        //PayBounties
        public event EventHandler<PayBountiesInfo> PayBountiesEvent;

        internal PayBountiesInfo InvokePayBountiesEvent(PayBountiesInfo arg)
        {
            PayBountiesEvent?.Invoke(null, arg);

            return arg;
        }

        //PowerplaySalary
        public event EventHandler<PowerplaySalaryInfo> PowerplaySalaryEvent;

        internal PowerplaySalaryInfo InvokePowerplaySalaryEvent(PowerplaySalaryInfo arg)
        {
            PowerplaySalaryEvent?.Invoke(null, arg);

            return arg;
        }

        //ShipyardTransfer
        public event EventHandler<ShipyardTransferInfo> ShipyardTransferEvent;

        internal ShipyardTransferInfo InvokeShipyardTransferEvent(ShipyardTransferInfo arg)
        {
            ShipyardTransferEvent?.Invoke(null, arg);

            return arg;
        }

        //TechnologyBroker
        public event EventHandler<TechnologyBrokerInfo> TechnologyBrokerEvent;

        internal TechnologyBrokerInfo InvokeTechnologyBrokerEvent(TechnologyBrokerInfo arg)
        {
            TechnologyBrokerEvent?.Invoke(null, arg);

            return arg;
        }

        //PayFines
        public event EventHandler<PayFinesInfo> PayFinesEvent;

        internal PayFinesInfo InvokePayFinesEvent(PayFinesInfo arg)
        {
            PayFinesEvent?.Invoke(null, arg);

            return arg;
        }

        //Bounty
        public event EventHandler<BountyInfo> BountyEvent;

        internal BountyInfo InvokeBountyEvent(BountyInfo arg)
        {
            BountyEvent?.Invoke(null, arg);

            return arg;
        }

        //MaterialTrade
        public event EventHandler<MaterialTradeInfo> MaterialTradeEvent;

        internal MaterialTradeInfo InvokeMaterialTradeEvent(MaterialTradeInfo arg)
        {
            MaterialTradeEvent?.Invoke(null, arg);

            return arg;
        }

        //ReceiveText
        public event EventHandler<ReceiveTextInfo> ReceiveTextEvent;

        internal ReceiveTextInfo InvokeReceiveTextEvent(ReceiveTextInfo arg)
        {
            ReceiveTextEvent?.Invoke(null, arg);

            return arg;
        }

        //ModuleSellRemote
        public event EventHandler<ModuleSellRemoteInfo> ModuleSellRemoteEvent;

        internal ModuleSellRemoteInfo InvokeModuleSellRemoteEvent(ModuleSellRemoteInfo arg)
        {
            ModuleSellRemoteEvent?.Invoke(null, arg);

            return arg;
        }

        //ShipyardSwap
        public event EventHandler<ShipyardSwapInfo> ShipyardSwapEvent;

        internal ShipyardSwapInfo InvokeShipyardSwapEvent(ShipyardSwapInfo arg)
        {
            ShipyardSwapEvent?.Invoke(null, arg);

            return arg;
        }

        //MarketBuy
        public event EventHandler<MarketBuyInfo> MarketBuyEvent;

        internal MarketBuyInfo InvokeMarketBuyEvent(MarketBuyInfo arg)
        {
            MarketBuyEvent?.Invoke(null, arg);

            return arg;
        }

        //CargoDepot
        public event EventHandler<CargoDepotInfo> CargoDepotEvent;

        internal CargoDepotInfo InvokeCargoDepotEvent(CargoDepotInfo arg)
        {
            CargoDepotEvent?.Invoke(null, arg);

            return arg;
        }

        //KillBond
        public event EventHandler<FactionKillBondInfo> FactionKillBondEvent;

        internal FactionKillBondInfo InvokeFactionKillBondEvent(FactionKillBondInfo arg)
        {
            FactionKillBondEvent?.Invoke(null, arg);

            return arg;
        }

        //StoredModules
        public event EventHandler<StoredModulesInfo> StoredModulesEvent;

        internal StoredModulesInfo InvokeStoredModulesEvent(StoredModulesInfo arg)
        {
            StoredModulesEvent?.Invoke(null, arg);

            return arg;
        }

        //WingJoin
        public event EventHandler<WingJoinInfo> WingJoinEvent;

        internal WingJoinInfo InvokeWingJoinEvent(WingJoinInfo arg)
        {
            WingJoinEvent?.Invoke(null, arg);

            return arg;
        }

        //ApproachBody
        public event EventHandler<ApproachBodyInfo> ApproachBodyEvent;

        internal ApproachBodyInfo InvokeApproachBodyEvent(ApproachBodyInfo arg)
        {
            ApproachBodyEvent?.Invoke(null, arg);

            return arg;
        }

        //EngineerProgress
        public event EventHandler<EngineerProgressInfo> EngineerProgressEvent;

        internal EngineerProgressInfo InvokeEngineerProgressEvent(EngineerProgressInfo arg)
        {
            EngineerProgressEvent?.Invoke(null, arg);

            return arg;
        }

        //FSSDiscoveryScan
        public event EventHandler<FSSDiscoveryScanInfo> FSSDiscoveryScanEvent;

        internal FSSDiscoveryScanInfo InvokeFSSDiscoveryScanEvent(FSSDiscoveryScanInfo arg)
        {
            FSSDiscoveryScanEvent?.Invoke(null, arg);

            return arg;
        }

        //SquadronCreated
        public event EventHandler<SquadronCreatedInfo> SquadronCreatedEvent;

        internal SquadronCreatedInfo InvokeSquadronCreatedEvent(SquadronCreatedInfo arg)
        {
            SquadronCreatedEvent?.Invoke(null, arg);

            return arg;
        }

        //Commander
        public event EventHandler<CommanderInfo> CommanderEvent;

        internal CommanderInfo InvokeCommanderEvent(CommanderInfo arg)
        {
            CommanderEvent?.Invoke(null, arg);

            return arg;
        }

        //JoinedSquadron
        public event EventHandler<JoinedSquadronInfo> JoinedSquadronEvent;

        internal JoinedSquadronInfo InvokeJoinedSquadronEvent(JoinedSquadronInfo arg)
        {
            JoinedSquadronEvent?.Invoke(null, arg);

            return arg;
        }

        //EjectCargo
        public event EventHandler<EjectCargoInfo> EjectCargoEvent;

        internal EjectCargoInfo InvokeEjectCargoEvent(EjectCargoInfo arg)
        {
            EjectCargoEvent?.Invoke(null, arg);

            return arg;
        }

        //NpcCrewPaidWage
        public event EventHandler<NpcCrewPaidWageInfo> NpcCrewPaidWageEvent;

        internal NpcCrewPaidWageInfo InvokeNpcCrewPaidWageEvent(NpcCrewPaidWageInfo arg)
        {
            NpcCrewPaidWageEvent?.Invoke(null, arg);

            return arg;
        }

        //Materials
        public event EventHandler<MaterialsInfo> MaterialsEvent;

        internal MaterialsInfo InvokeMaterialsEvent(MaterialsInfo arg)
        {
            MaterialsEvent?.Invoke(null, arg);

            return arg;
        }

        //LoadGame
        public event EventHandler<LoadGameInfo> LoadGameEvent;

        internal LoadGameInfo InvokeLoadGameEvent(LoadGameInfo arg)
        {
            LoadGameEvent?.Invoke(null, arg);

            return arg;
        }

        //SupercruiseEntry
        public event EventHandler<SupercruiseEntryInfo> SupercruiseEntryEvent;

        internal SupercruiseEntryInfo InvokeSupercruiseEntryEvent(SupercruiseEntryInfo arg)
        {
            SupercruiseEntryEvent?.Invoke(null, arg);

            return arg;
        }

        //FSDTarget
        public event EventHandler<FSDTargetInfo> FSDTargetEvent;

        internal FSDTargetInfo InvokeFSDTargetEvent(FSDTargetInfo arg)
        {
            FSDTargetEvent?.Invoke(null, arg);

            return arg;
        }

        //FSSAllBodiesFound
        public event EventHandler<FSSAllBodiesFoundInfo> FSSAllBodiesFoundEvent;

        internal FSSAllBodiesFoundInfo InvokeFSSAllBodiesFoundEvent(FSSAllBodiesFoundInfo arg)
        {
            FSSAllBodiesFoundEvent?.Invoke(null, arg);

            return arg;
        }

        //SAAScanComplete
        public event EventHandler<SAAScanCompleteInfo> SAAScanCompleteEvent;

        internal SAAScanCompleteInfo InvokeSAAScanCompleteEvent(SAAScanCompleteInfo arg)
        {
            SAAScanCompleteEvent?.Invoke(null, arg);

            return arg;
        }

        //CodexEntry
        public event EventHandler<CodexEntryInfo> CodexEntryEvent;

        internal CodexEntryInfo InvokeCodexEntryEvent(CodexEntryInfo arg)
        {
            CodexEntryEvent?.Invoke(null, arg);

            return arg;
        }

        //CrimeVictim
        public event EventHandler<CrimeVictimInfo> CrimeVictimEvent;

        internal CrimeVictimInfo InvokeCrimeVictimEvent(CrimeVictimInfo arg)
        {
            CrimeVictimEvent?.Invoke(null, arg);

            return arg;
        }

        //Loadout
        public event EventHandler<LoadoutInfo> LoadoutEvent;

        internal LoadoutInfo InvokeLoadoutEvent(LoadoutInfo arg)
        {
            LoadoutEvent?.Invoke(null, arg);

            return arg;
        }

        //MissionCompleted
        public event EventHandler<MissionCompletedInfo> MissionCompletedEvent;

        internal MissionCompletedInfo InvokeMissionCompletedEvent(MissionCompletedInfo arg)
        {
            MissionCompletedEvent?.Invoke(null, arg);

            return arg;
        }

        //BuyTradeData
        public event EventHandler<BuyTradeDataInfo> BuyTradeDataEvent;

        internal BuyTradeDataInfo InvokeBuyTradeDataEvent(BuyTradeDataInfo arg)
        {
            BuyTradeDataEvent?.Invoke(null, arg);

            return arg;
        }

        //CrewAssign
        public event EventHandler<CrewAssignInfo> CrewAssignEvent;

        internal CrewAssignInfo InvokeCrewAssignEvent(CrewAssignInfo arg)
        {
            CrewAssignEvent?.Invoke(null, arg);

            return arg;
        }

        //CrewFire
        public event EventHandler<CrewFireInfo> CrewFireEvent;

        internal CrewFireInfo InvokeCrewFireEvent(CrewFireInfo arg)
        {
            CrewFireEvent?.Invoke(null, arg);

            return arg;
        }

        //MultiSellExplorationData
        public event EventHandler<MultiSellExplorationDataInfo> MultiSellExplorationDataEvent;

        internal MultiSellExplorationDataInfo InvokeMultiSellExplorationDataEvent(MultiSellExplorationDataInfo arg)
        {
            MultiSellExplorationDataEvent?.Invoke(null, arg);

            return arg;
        }

        //Location
        public event EventHandler<LocationInfo> LocationEvent;

        internal LocationInfo InvokeLocationEvent(LocationInfo arg)
        {
            LocationEvent?.Invoke(null, arg);

            return arg;
        }

        //AsteroidCracked
        public event EventHandler<AsteroidCrackedInfo> AsteroidCrackedEvent;

        internal AsteroidCrackedInfo InvokeAsteroidCrackedEvent(AsteroidCrackedInfo arg)
        {
            AsteroidCrackedEvent?.Invoke(null, arg);

            return arg;
        }

        //ModuleSwap
        public event EventHandler<ModuleSwapInfo> ModuleSwapEvent;

        internal ModuleSwapInfo InvokeModuleSwapEvent(ModuleSwapInfo arg)
        {
            ModuleSwapEvent?.Invoke(null, arg);

            return arg;
        }

        //DataScanned
        public event EventHandler<DataScannedInfo> DataScannedEvent;

        internal DataScannedInfo InvokeDataScannedEvent(DataScannedInfo arg)
        {
            DataScannedEvent?.Invoke(null, arg);

            return arg;
        }

        //DisbandedSquadron
        public event EventHandler<DisbandedSquadronInfo> DisbandedSquadronEvent;

        internal DisbandedSquadronInfo InvokeDisbandedSquadronEvent(DisbandedSquadronInfo arg)
        {
            DisbandedSquadronEvent?.Invoke(null, arg);

            return arg;
        }

        //AppliedToSquadron
        public event EventHandler<AppliedToSquadronInfo> AppliedToSquadronEvent;

        internal AppliedToSquadronInfo InvokeAppliedToSquadronEvent(AppliedToSquadronInfo arg)
        {
            AppliedToSquadronEvent?.Invoke(null, arg);

            return arg;
        }

        //Docked
        public event EventHandler<DockedInfo> DockedEvent;

        internal DockedInfo InvokeDockedEvent(DockedInfo arg)
        {
            DockedEvent?.Invoke(null, arg);

            return arg;
        }

        //Statistics
        public event EventHandler<StatisticsInfo> StatisticsEvent;

        internal StatisticsInfo InvokeStatisticsEvent(StatisticsInfo arg)
        {
            StatisticsEvent?.Invoke(null, arg);

            return arg;
        }

        //SetUserShipName
        public event EventHandler<SetUserShipNameInfo> SetUserShipNameEvent;

        internal SetUserShipNameInfo InvokeSetUserShipNameEvent(SetUserShipNameInfo arg)
        {
            SetUserShipNameEvent?.Invoke(null, arg);

            return arg;
        }

        //FSDJump
        public event EventHandler<FSDJumpInfo> FSDJumpEvent;

        internal FSDJumpInfo InvokeFSDJumpEvent(FSDJumpInfo arg)
        {
            FSDJumpEvent?.Invoke(null, arg);

            return arg;
        }

        //ClearSavedGame
        public event EventHandler<ClearSavedGameInfo> ClearSavedGameEvent;

        internal ClearSavedGameInfo InvokeClearSavedGameEvent(ClearSavedGameInfo arg)
        {
            ClearSavedGameEvent?.Invoke(null, arg);

            return arg;
        }

        //Cargo
        public event EventHandler<CargoInfo> CargoEvent;

        internal CargoInfo InvokeCargoEvent(CargoInfo arg)
        {
            CargoEvent?.Invoke(null, arg);

            return arg;
        }

        //EngineerCraft
        public event EventHandler<EngineerCraftInfo> EngineerCraftEvent;

        internal EngineerCraftInfo InvokeEngineerCraftEvent(EngineerCraftInfo arg)
        {
            EngineerCraftEvent?.Invoke(null, arg);

            return arg;
        }

        //ApproachSettlement
        public event EventHandler<ApproachSettlementInfo> ApproachSettlementEvent;

        internal ApproachSettlementInfo InvokeApproachSettlementEvent(ApproachSettlementInfo arg)
        {
            ApproachSettlementEvent?.Invoke(null, arg);

            return arg;
        }

        //StoredShips
        public event EventHandler<StoredShipsInfo> StoredShipsEvent;

        internal StoredShipsInfo InvokeStoredShipsEvent(StoredShipsInfo arg)
        {
            StoredShipsEvent?.Invoke(null, arg);

            return arg;
        }

        //FSSSignalDiscovered
        public event EventHandler<FSSSignalDiscoveredInfo> FSSSignalDiscoveredEvent;

        internal FSSSignalDiscoveredInfo InvokeFSSSignalDiscoveredEvent(FSSSignalDiscoveredInfo arg)
        {
            FSSSignalDiscoveredEvent?.Invoke(null, arg);

            return arg;
        }

        //SquadronStartup
        public event EventHandler<SquadronStartupInfo> SquadronStartupEvent;

        internal SquadronStartupInfo InvokeSquadronStartupEvent(SquadronStartupInfo arg)
        {
            SquadronStartupEvent?.Invoke(null, arg);

            return arg;
        }
    }
}