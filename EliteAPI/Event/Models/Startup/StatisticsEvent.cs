using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class StatisticsEvent : EventBase<StatisticsEvent>
    {
        internal StatisticsEvent() { }

        [JsonProperty("Bank_Account")]
        public BankAccountInfo BankAccount { get; private set; }

        [JsonProperty("Combat")]
        public CombatInfo Combat { get; private set; }

        [JsonProperty("Crime")]
        public CrimeInfo Crime { get; private set; }

        [JsonProperty("Smuggling")]
        public SmugglingInfo Smuggling { get; private set; }

        [JsonProperty("Trading")]
        public TradingInfo Trading { get; private set; }

        [JsonProperty("Mining")]
        public MiningInfo Mining { get; private set; }

        [JsonProperty("Exploration")]
        public ExplorationInfo Exploration { get; private set; }

        [JsonProperty("Passengers")]
        public PassengersInfo Passengers { get; private set; }

        [JsonProperty("Search_And_Rescue")]
        public SearchAndRescueInfo SearchAndRescue { get; private set; }

        [JsonProperty("Crafting")]
        public CraftingInfo Crafting { get; private set; }

        [JsonProperty("Crew")]
        public CrewInfo Crew { get; private set; }

        [JsonProperty("Multicrew")]
        public MulticrewInfo Multicrew { get; private set; }

        [JsonProperty("Material_Trader_Stats")]
        public MaterialTraderStatsInfo MaterialTraderStats { get; private set; }

        [JsonProperty("CQC")]
        public CqcInfo Cqc { get; private set; }

        [JsonProperty("FLEETCARRIER")]
        public FleetCarrierInfo FleetCarrier { get; private set; }

        [JsonProperty("TG_ENCOUNTERS")]
        public TgEncountersInfo TgEncounters { get; private set; }
        
        [JsonProperty("Exobiology")]
        public ExobiologyInfo Exobiology { get; private set; }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class BankAccountInfo
        {
            internal BankAccountInfo() { }

            [JsonProperty("Current_Wealth")]
            public long CurrentWealth { get; private set; }

            [JsonProperty("Spent_On_Ships")]
            public long SpentOnShips { get; private set; }

            [JsonProperty("Spent_On_Outfitting")]
            public long SpentOnOutfitting { get; private set; }

            [JsonProperty("Spent_On_Repairs")]
            public long SpentOnRepairs { get; private set; }

            [JsonProperty("Spent_On_Fuel")]
            public long SpentOnFuel { get; private set; }

            [JsonProperty("Spent_On_Suits")]
            public long SpentOnSuits { get; private set; }
            
            [JsonProperty("Spent_On_Weapons")]
            public long SpentOnWeapons { get; private set; }     
            
            [JsonProperty("Spent_On_Suit_Consumables")]
            public long SpentOnSuitConsumables { get; private set; }
            
            [JsonProperty("Suits_Owned")]
            public long SuitsOwned { get; private set; }
            
            [JsonProperty("Weapons_Owned")]
            public long WeaponsOwned { get; private set; }

            [JsonProperty("Spent_On_Premium_Stock")]
            public long SpentOnPremiumStock { get; private set; }
            
            [JsonProperty("Premium_Stock_Bought")]
            public long PremiumStockBought { get; private set; }

            [JsonProperty("Spent_On_Ammo_Consumables")]
            public long SpentOnAmmoConsumables { get; private set; }

            [JsonProperty("Insurance_Claims")]
            public long InsuranceClaims { get; private set; }

            [JsonProperty("Spent_On_Insurance")]
            public long SpentOnInsurance { get; private set; }

            [JsonProperty("Owned_Ship_Count")]
            public long OwnedShipCount { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class CombatInfo
        {
            internal CombatInfo() { }

            [JsonProperty("Bounties_Claimed")]
            public long BountiesClaimed { get; private set; }

            [JsonProperty("Bounty_Hunting_Profit")]
            public long BountyHuntingProfit { get; private set; }

            [JsonProperty("Combat_Bonds")]
            public long CombatBonds { get; private set; }

            [JsonProperty("Combat_Bond_Profits")]
            public long CombatBondProfits { get; private set; }

            [JsonProperty("Assassinations")]
            public long Assassinations { get; private set; }

            [JsonProperty("Assassination_Profits")]
            public long AssassinationProfits { get; private set; }

            [JsonProperty("Highest_Single_Reward")]
            public long HighestSingleReward { get; private set; }

            [JsonProperty("Skimmers_Killed")]
            public long SkimmersKilled { get; private set; }
            
            [JsonProperty("OnFoot_Combat_Bonds")]
            public long OnFootCombatBonds { get; private set; }
            
            [JsonProperty("OnFoot_Combat_Bonds_Profits")]
            public long OnFootCombatBondsProfits { get; private set; }

            [JsonProperty("OnFoot_Vehicles_Destroyed")]
            public long OnFootVehiclesDestroyed { get; private set; }

            [JsonProperty("OnFoot_Ships_Destroyed")]
            public long OnFootShipsDestroyed { get; private set; }

            [JsonProperty("Dropships_Taken")]
            public long DropshipsTaken { get; private set; }

            [JsonProperty("Dropships_Booked")]
            public long DropshipsBooked { get; private set; }
            
            [JsonProperty("Dropships_Cancelled")]
            public long DropshipsCancelled { get; private set; }
            
            [JsonProperty("ConflictZone_High")]
            public long ConflictZoneHigh { get; private set; }
            
            [JsonProperty("ConflictZone_Medium")]
            public long ConflictZoneMedium { get; private set; }

            [JsonProperty("ConflictZone_Low")]
            public long ConflictZoneLow { get; private set; }
            
            [JsonProperty("ConflictZone_Total")]
            public long ConflictZoneTotal { get; private set; }

            [JsonProperty("ConflictZone_High_Wins")]
            public long ConflictZoneHighWins { get; private set; }

            [JsonProperty("ConflictZone_Medium_Wins")]
            public long ConflictZoneMediumWins { get; private set; }

            [JsonProperty("ConflictZone_Low_Wins")]
            public long ConflictZoneLowWins { get; private set; }
            
            [JsonProperty("ConflictZone_Total_Wins")]
            public long ConflictZoneTotalWins { get; private set; }
            
            [JsonProperty("Settlement_Defended")]
            public long SettlementsDefended { get; private set; }

            [JsonProperty("Settlement_Conquered")]
            public long SettlementsConquered { get; private set; }

            [JsonProperty("OnFoot_Skimmers_Killed")]
            public long OnFootSkimmersKilled  { get; private set; }
            
            [JsonProperty("OnFoot_Scavs_Killed")]
            public long OnFootScavsKilled  { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class CqcInfo
        {
            internal CqcInfo() { }

            [JsonProperty("CQC_Credits_Earned")]
            public long CqcCreditsEarned { get; private set; }

            [JsonProperty("CQC_Time_Played")]
            public long CqcTimePlayed { get; private set; }

            [JsonProperty("CQC_KD")]
            public double CqcKd { get; private set; }

            [JsonProperty("CQC_Kills")]
            public long CqcKills { get; private set; }

            [JsonProperty("CQC_WL")]
            public double CqcWl { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class TgEncountersInfo
        {
            internal TgEncountersInfo() { }

            [JsonProperty("TG_ENCOUNTER_TOTAL")]
            public long TgEncounterTotal { get; private set; }

            [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SYSTEM")]
            public string TgEncounterTotalLastSystem { get; private set; }

            [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP")]
            public string TgEncounterTotalLastTimestamp { get; private set; }

            [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SHIP")]
            public string TgEncounterTotalLastShip { get; private set; }

            [JsonProperty("TG_SCOUT_COUNT")]
            public long TgScoutCount { get; private set; }
        }


        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class CraftingInfo
        {
            internal CraftingInfo() { }

            [JsonProperty("Count_Of_Used_Engineers")]
            public long CountOfUsedEngineers { get; private set; }

            [JsonProperty("Recipes_Generated")]
            public long RecipesGenerated { get; private set; }

            [JsonProperty("Recipes_Generated_Rank_1")]
            public long RecipesGeneratedRank1 { get; private set; }

            [JsonProperty("Recipes_Generated_Rank_2")]
            public long RecipesGeneratedRank2 { get; private set; }

            [JsonProperty("Recipes_Generated_Rank_3")]
            public long RecipesGeneratedRank3 { get; private set; }

            [JsonProperty("Recipes_Generated_Rank_4")]
            public long RecipesGeneratedRank4 { get; private set; }

            [JsonProperty("Recipes_Generated_Rank_5")]
            public long RecipesGeneratedRank5 { get; private set; }
            
            [JsonProperty("Suit_Mods_Applied")]
            public long SuitModsApplied { get; private set; }
            
            [JsonProperty("Weapon_Mods_Applied")]
            public long WeaponModsApplied { get; private set; }
            
            [JsonProperty("Suits_Upgraded")]
            public long SuitsUpgraded { get; private set; }
            
            [JsonProperty("Weapons_Upgraded")]
            public long WeaponsUpgraded { get; private set; }
            
            [JsonProperty("Suits_Upgraded_Full")]
            public long SuitsFullyUpgraded { get; private set; }
            
            [JsonProperty("Weapons_Upgraded_Full")]
            public long WeaponsFullyUpgraded { get; private set; }
            
            [JsonProperty("Suit_Mods_Applied_Full")]
            public long SuitModsFullyApplied { get; private set; }
            
            [JsonProperty("Weapon_Mods_Applied_Full")]
            public long WeaponModsFullyApplied { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class CrewInfo
        {
            internal CrewInfo() { }

            [JsonProperty("NpcCrew_TotalWages")]
            public long NpcCrewTotalWages { get; private set; }

            [JsonProperty("NpcCrew_Hired")]
            public long NpcCrewHired { get; private set; }

            [JsonProperty("NpcCrew_Fired")]
            public long NpcCrewFired { get; private set; }

            [JsonProperty("NpcCrew_Died")]
            public long NpcCrewDied { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class CrimeInfo
        {
            internal CrimeInfo() { }

            [JsonProperty("Notoriety")]
            public long Notoriety { get; private set; }

            [JsonProperty("Fines")]
            public long Fines { get; private set; }

            [JsonProperty("Total_Fines")]
            public long TotalFines { get; private set; }

            [JsonProperty("Bounties_Received")]
            public long BountiesReceived { get; private set; }

            [JsonProperty("Total_Bounties")]
            public long TotalBounties { get; private set; }

            [JsonProperty("Highest_Bounty")]
            public long HighestBounty { get; private set; }

            [JsonProperty("Malware_Uploaded")]
            public long MalwareUploaded { get; private set; }

            [JsonProperty("Settlements_State_Shutdown")]
            public long SettlementsStateShutdown { get; private set; }
            
            [JsonProperty("Production_Sabotage")]
            public long ProductionSabotage { get; private set; }
            
            [JsonProperty("Production_Theft")]
            public long ProductionTheft { get; private set; }
            
            [JsonProperty("Total_Murders")]
            public long TotalMurders { get; private set; }
            
            [JsonProperty("Citizens_Murdered")]
            public long CitizensMurdered { get; private set; }
            
            [JsonProperty("Omnipol_Murdered")]
            public long OmnipolMurdered { get; private set; }
            
            [JsonProperty("Guards_Murdered")]
            public long GuardsMurdered { get; private set; }
            
            [JsonProperty("Data_Stolen")]
            public long DataStolen { get; private set; }
            
            [JsonProperty("Goods_Stolen")]
            public long GoodsStolen { get; private set; }
            
            [JsonProperty("Sample_Stolen")]
            public long SamplesStolen  { get; private set; }
            
            [JsonProperty("Total_Stolen")]
            public long TotalStolen { get; private set; }
              
            [JsonProperty("Turrets_Destroyed")]
            public long TurretsDestroyed  { get; private set; }
            
            [JsonProperty("Turrets_Overloaded")]
            public long TurretsOverloaded { get; private set; }
            
            [JsonProperty("Turrets_Total")]
            public long TurrentsTotal { get; private set; }
            
            [JsonProperty("Value_Stolen_StateChange")]
            public long ValueStolenStateChange { get; private set; }
            
            [JsonProperty("Profiles_Cloned")]
            public long ProfilesCloned { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class ExplorationInfo
        {
            internal ExplorationInfo() { }

            [JsonProperty("Systems_Visited")]
            public long SystemsVisited { get; private set; }

            [JsonProperty("Exploration_Profits")]
            public long ExplorationProfits { get; private set; }

            [JsonProperty("Planets_Scanned_To_Level_2")]
            public long PlanetsScannedToLevel2 { get; private set; }

            [JsonProperty("Planets_Scanned_To_Level_3")]
            public long PlanetsScannedToLevel3 { get; private set; }

            [JsonProperty("Efficient_Scans")]
            public long EfficientScans { get; private set; }

            [JsonProperty("Highest_Payout")]
            public long HighestPayout { get; private set; }

            [JsonProperty("Total_Hyperspace_Distance")]
            public long TotalHyperspaceDistance { get; private set; }

            [JsonProperty("Total_Hyperspace_Jumps")]
            public long TotalHyperspaceJumps { get; private set; }

            [JsonProperty("Greatest_Distance_From_Start")]
            public double GreatestDistanceFromStart { get; private set; }

            [JsonProperty("Time_Played")]
            public long TimePlayed { get; private set; }

            [JsonProperty("Shuttle_Journeys")]
            public long ShuttleJourneys { get; private set; }

            [JsonProperty("Shuttle_Distance_Travelled")]
            public long ShuttleDistanceTravelled { get; private set; }

            [JsonProperty("Spent_On_Shuttles")]
            public long SpentOnShuttles { get; private set; }

            [JsonProperty("First_Footfalls")]
            public long FirstFootfalls { get; private set; }

            [JsonProperty("Planet_Footfalls")]
            public long PlanetFootfalls { get; private set; }

            [JsonProperty("Settlements_Visited")]
            public long SettlementsVisited { get; private set; }
            
            [JsonProperty("OnFoot_Distance_Travelled")]
            public long DistanceTravelledOnFoot { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class FleetCarrierInfo
        {
            internal FleetCarrierInfo() { }

            [JsonProperty("FLEETCARRIER_EXPORT_TOTAL")]
            public long ExportTotal { get; private set; }

            [JsonProperty("FLEETCARRIER_IMPORT_TOTAL")]
            public long ImportTotal { get; private set; }

            [JsonProperty("FLEETCARRIER_TRADEPROFIT_TOTAL")]
            public long TradeProfitTotal { get; private set; }

            [JsonProperty("FLEETCARRIER_TRADESPEND_TOTAL")]
            public long TradeSpendTotal { get; private set; }

            [JsonProperty("FLEETCARRIER_STOLENPROFIT_TOTAL")]
            public long StolenProfitTotal { get; private set; }

            [JsonProperty("FLEETCARRIER_STOLENSPEND_TOTAL")]
            public long StolenSpendTotal { get; private set; }

            [JsonProperty("FLEETCARRIER_DISTANCE_TRAVELLED")]
            public string DistanceTravelled { get; private set; }

            [JsonProperty("FLEETCARRIER_TOTAL_JUMPS")]
            public long TotalJumps { get; private set; }

            [JsonProperty("FLEETCARRIER_SHIPYARD_SOLD")]
            public long ShipyardSold { get; private set; }

            [JsonProperty("FLEETCARRIER_SHIPYARD_PROFIT")]
            public long ShipyardProfit { get; private set; }

            [JsonProperty("FLEETCARRIER_OUTFITTING_SOLD")]
            public long OutfittingSold { get; private set; }

            [JsonProperty("FLEETCARRIER_OUTFITTING_PROFIT")]
            public long OutfittingProfit { get; private set; }

            [JsonProperty("FLEETCARRIER_REARM_TOTAL")]
            public long RearmTotal { get; private set; }

            [JsonProperty("FLEETCARRIER_REFUEL_TOTAL")]
            public long RefuelTotal { get; private set; }

            [JsonProperty("FLEETCARRIER_REFUEL_PROFIT")]
            public long RefuelProfit { get; private set; }

            [JsonProperty("FLEETCARRIER_REPAIRS_TOTAL")]
            public long RepairsTotal { get; private set; }

            [JsonProperty("FLEETCARRIER_VOUCHERS_REDEEMED")]
            public long VouchersRedeemed { get; private set; }

            [JsonProperty("FLEETCARRIER_VOUCHERS_PROFIT")]
            public long VouchersProfit { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class MaterialTraderStatsInfo
        {
            internal MaterialTraderStatsInfo() { }

            [JsonProperty("Trades_Completed")]
            public long TradesCompleted { get; private set; }

            [JsonProperty("Materials_Traded")]
            public long MaterialsTraded { get; private set; }

            [JsonProperty("Encoded_Materials_Traded")]
            public long EncodedMaterialsTraded { get; private set; }

            [JsonProperty("Raw_Materials_Traded")]
            public long RawMaterialsTraded { get; private set; }

            [JsonProperty("Grade_1_Materials_Traded")]
            public long Grade1Traded { get; private set; }

            [JsonProperty("Grade_2_Materials_Traded")]
            public long Grade2Traded { get; private set; }

            [JsonProperty("Grade_3_Materials_Traded")]
            public long Grade3Traded { get; private set; }

            [JsonProperty("Grade_4_Materials_Traded")]
            public long Grade4Traded { get; private set; }

            [JsonProperty("Grade_5_Materials_Traded")]
            public long Grade5Traded { get; private set; }
            
            [JsonProperty("Assets_Traded_In")]
            public long AssetsTradedIn { get; private set; }
            
            [JsonProperty("Assets_Traded_Out")]
            public long AssetsTradedOut { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class MiningInfo
        {
            internal MiningInfo() { }

            [JsonProperty("Mining_Profits")]
            public long Profits { get; private set; }

            [JsonProperty("Quantity_Mined")]
            public long QuantityMined { get; private set; }

            [JsonProperty("Materials_Collected")]
            public long MaterialsCollected { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class MulticrewInfo
        {
            internal MulticrewInfo() { }

            [JsonProperty("Multicrew_Time_Total")]
            public long TimeTotal { get; private set; }

            [JsonProperty("Multicrew_Gunner_Time_Total")]
            public long GunnerTimeTotal { get; private set; }

            [JsonProperty("Multicrew_Fighter_Time_Total")]
            public long FighterTimeTotal { get; private set; }

            [JsonProperty("Multicrew_Credits_Total")]
            public long CreditsTotal { get; private set; }

            [JsonProperty("Multicrew_Fines_Total")]
            public long FinesTotal { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class PassengersInfo
        {
            internal PassengersInfo() { }

            [JsonProperty("Passengers_Missions_Accepted")]
            public long Accepted { get; private set; }

            [JsonProperty("Passengers_Missions_Disgruntled")]
            public long Disgruntled { get; private set; }

            [JsonProperty("Passengers_Missions_Bulk")]
            public long Bulk { get; private set; }

            [JsonProperty("Passengers_Missions_VIP")]
            public long Vip { get; private set; }

            [JsonProperty("Passengers_Missions_Delivered")]
            public long Delivered { get; private set; }

            [JsonProperty("Passengers_Missions_Ejected")]
            public long Ejected { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class SearchAndRescueInfo
        {
            internal SearchAndRescueInfo() { }

            [JsonProperty("SearchRescue_Traded")]
            public long SearchRescueTraded { get; private set; }

            [JsonProperty("SearchRescue_Profit")]
            public long SearchRescueProfit { get; private set; }

            [JsonProperty("SearchRescue_Count")]
            public long SearchRescueCount { get; private set; }

            [JsonProperty("Salvage_Legal_POI")]
            public long SalvagedLegalPointOfInterest { get; private set; }

            [JsonProperty("Salvage_Legal_Settlements")]
            public long SalvagedLegalSettlements { get; private set; }

            [JsonProperty("Salvage_Illegal_POI")]
            public long SalvagedIllegalPointOfInterest { get; private set; }
            
            [JsonProperty("Salvage_Illegal_Settlements")]
            public long SalvagedIllegalSettlements { get; private set; }
            
            [JsonProperty("Maglocks_Opened")]
            public long MagneticLocksOpened { get; private set; }
            
            [JsonProperty("Panels_Opened")]
            public long PanelsOpened { get; private set; }
            
            [JsonProperty("Settlements_State_FireOut")]
            public long SettlementsStateFireOut { get; private set; }
            
            [JsonProperty("Settlements_State_Reboot")]
            public long SettlementsStateReboot { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class SmugglingInfo
        {
            internal SmugglingInfo() { }

            [JsonProperty("Black_Markets_Traded_With")]
            public long BlackMarketsTradedWith { get; private set; }

            [JsonProperty("Black_Markets_Profits")]
            public long BlackMarketsProfits { get; private set; }

            [JsonProperty("Resources_Smuggled")]
            public long ResourcesSmuggled { get; private set; }

            [JsonProperty("Average_Profit")]
            public double AverageProfit { get; private set; }

            [JsonProperty("Highest_Single_Transaction")]
            public long HighestSingleTransaction { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class TradingInfo
        {
            internal TradingInfo() { }

            [JsonProperty("Markets_Traded_With")]
            public long MarketsTradedWith { get; private set; }

            [JsonProperty("Market_Profits")]
            public long MarketProfits { get; private set; }

            [JsonProperty("Resources_Traded")]
            public long ResourcesTraded { get; private set; }

            [JsonProperty("Average_Profit")]
            public double AverageProfit { get; private set; }

            [JsonProperty("Highest_Single_Transaction")]
            public long HighestSingleTransaction { get; private set; }
            
            [JsonProperty("Data_Sold")]
            public long DataSold { get; private set; }
            
            [JsonProperty("Goods_Sold")]
            public long GoodsSold { get; private set; }
            
            [JsonProperty("Assets_Sold")]
            public long AssetsSold { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class ExobiologyInfo
        {
            internal ExobiologyInfo() { }
            
            [JsonProperty("AssOrganic_Genus_Encountered")]
            public long AssOrganicGenusEncountered { get; private set; }
            
            [JsonProperty("Organic_Genus_Encountered")]
            public long OrganicGenusEncountered { get; private set; }
            
            [JsonProperty("Organic_Species_Encountered")]
            public long OrganicSpeciesEncountered { get; private set; }
            
            [JsonProperty("Organic_Variant_Encountered")]
            public long OrganicVariantsEncountered { get; private set; }
            
            [JsonProperty("Organic_Data_Profits")]
            public long OrganicDataProfits { get; private set; }
            
            [JsonProperty("Organic_Data")]
            public long OrganicData { get; private set; }
            
            [JsonProperty("First_Logged_Profits")]
            public long FirstLoggedProfits { get; private set; }
            
            [JsonProperty("First_Logged")]
            public long FirstLogged { get; private set; }
            
            [JsonProperty("Organic_Systems")]
            public long OrganicSystems { get; private set; }
            
            [JsonProperty("Organic_Planets")]
            public long OrganicPlanets { get; private set; }
            
            [JsonProperty("Organic_Genus")]
            public long OrganicGenus { get; private set; }
              
            [JsonProperty("Organic_Species")]
            public long Organic_Species { get; private set; }
        }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<StatisticsEvent> StatisticsEvent;

        internal void InvokeStatisticsEvent(StatisticsEvent arg)
        {
            StatisticsEvent?.Invoke(this, arg);
        }
    }
}