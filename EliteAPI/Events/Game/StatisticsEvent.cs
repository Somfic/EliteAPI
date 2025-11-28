using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct StatisticsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Bank_Account")]
    public BankAccountInfo BankAccount { get; init; }

    [JsonProperty("Combat")]
    public CombatInfo Combat { get; init; }

    [JsonProperty("Crime")]
    public CrimeInfo Crime { get; init; }

    [JsonProperty("Smuggling")]
    public SmugglingInfo Smuggling { get; init; }

    [JsonProperty("Trading")]
    public TradingInfo Trading { get; init; }

    [JsonProperty("Mining")]
    public MiningInfo Mining { get; init; }

    [JsonProperty("Exploration")]
    public ExplorationInfo Exploration { get; init; }

    [JsonProperty("Passengers")]
    public PassengersInfo Passengers { get; init; }

    [JsonProperty("Search_And_Rescue")]
    public SearchAndRescueInfo SearchAndRescue { get; init; }

    [JsonProperty("Crafting")]
    public CraftingInfo Crafting { get; init; }

    [JsonProperty("Crew")]
    public CrewInfo Crew { get; init; }

    [JsonProperty("Multicrew")]
    public MulticrewInfo Multicrew { get; init; }

    [JsonProperty("Material_Trader_Stats")]
    public MaterialTraderStatsInfo MaterialTraderStats { get; init; }

    [JsonProperty("CQC")]
    public CqcInfo Cqc { get; init; }

    [JsonProperty("FLEETCARRIER")]
    public FleetCarrierInfo FleetCarrier { get; init; }

    [JsonProperty("TG_ENCOUNTERS")]
    public TgEncountersInfo TgEncounters { get; init; }

    [JsonProperty("Exobiology")]
    public ExobiologyInfo Exobiology { get; init; }


    public readonly struct BankAccountInfo
    {
        [JsonProperty("Current_Wealth")]
        public long CurrentWealth { get; init; }

        [JsonProperty("Spent_On_Ships")]
        public long SpentOnShips { get; init; }

        [JsonProperty("Spent_On_Outfitting")]
        public long SpentOnOutfitting { get; init; }

        [JsonProperty("Spent_On_Repairs")]
        public long SpentOnRepairs { get; init; }

        [JsonProperty("Spent_On_Fuel")]
        public long SpentOnFuel { get; init; }

        [JsonProperty("Spent_On_Suits")]
        public long SpentOnSuits { get; init; }

        [JsonProperty("Spent_On_Weapons")]
        public long SpentOnWeapons { get; init; }

        [JsonProperty("Spent_On_Suit_Consumables")]
        public long SpentOnSuitConsumables { get; init; }

        [JsonProperty("Suits_Owned")]
        public long SuitsOwned { get; init; }

        [JsonProperty("Weapons_Owned")]
        public long WeaponsOwned { get; init; }

        [JsonProperty("Spent_On_Premium_Stock")]
        public long SpentOnPremiumStock { get; init; }

        [JsonProperty("Premium_Stock_Bought")]
        public long PremiumStockBought { get; init; }

        [JsonProperty("Spent_On_Ammo_Consumables")]
        public long SpentOnAmmoConsumables { get; init; }

        [JsonProperty("Insurance_Claims")]
        public long InsuranceClaims { get; init; }

        [JsonProperty("Spent_On_Insurance")]
        public long SpentOnInsurance { get; init; }

        [JsonProperty("Owned_Ship_Count")]
        public long OwnedShipCount { get; init; }
    }


    public readonly struct CombatInfo
    {
        [JsonProperty("Bounties_Claimed")]
        public long BountiesClaimed { get; init; }

        [JsonProperty("Bounty_Hunting_Profit")]
        public long BountyHuntingProfit { get; init; }

        [JsonProperty("Combat_Bonds")]
        public long CombatBonds { get; init; }

        [JsonProperty("Combat_Bond_Profits")]
        public long CombatBondProfits { get; init; }

        [JsonProperty("Assassinations")]
        public long Assassinations { get; init; }

        [JsonProperty("Assassination_Profits")]
        public long AssassinationProfits { get; init; }

        [JsonProperty("Highest_Single_Reward")]
        public long HighestSingleReward { get; init; }

        [JsonProperty("Skimmers_Killed")]
        public long SkimmersKilled { get; init; }

        [JsonProperty("OnFoot_Combat_Bonds")]
        public long OnFootCombatBonds { get; init; }

        [JsonProperty("OnFoot_Combat_Bonds_Profits")]
        public long OnFootCombatBondsProfits { get; init; }

        [JsonProperty("OnFoot_Vehicles_Destroyed")]
        public long OnFootVehiclesDestroyed { get; init; }

        [JsonProperty("OnFoot_Ships_Destroyed")]
        public long OnFootShipsDestroyed { get; init; }

        [JsonProperty("Dropships_Taken")]
        public long DropshipsTaken { get; init; }

        [JsonProperty("Dropships_Booked")]
        public long DropshipsBooked { get; init; }

        [JsonProperty("Dropships_Cancelled")]
        public long DropshipsCancelled { get; init; }

        [JsonProperty("ConflictZone_High")]
        public long ConflictZoneHigh { get; init; }

        [JsonProperty("ConflictZone_Medium")]
        public long ConflictZoneMedium { get; init; }

        [JsonProperty("ConflictZone_Low")]
        public long ConflictZoneLow { get; init; }

        [JsonProperty("ConflictZone_Total")]
        public long ConflictZoneTotal { get; init; }

        [JsonProperty("ConflictZone_High_Wins")]
        public long ConflictZoneHighWins { get; init; }

        [JsonProperty("ConflictZone_Medium_Wins")]
        public long ConflictZoneMediumWins { get; init; }

        [JsonProperty("ConflictZone_Low_Wins")]
        public long ConflictZoneLowWins { get; init; }

        [JsonProperty("ConflictZone_Total_Wins")]
        public long ConflictZoneTotalWins { get; init; }

        [JsonProperty("Settlement_Defended")]
        public long SettlementsDefended { get; init; }

        [JsonProperty("Settlement_Conquered")]
        public long SettlementsConquered { get; init; }

        [JsonProperty("OnFoot_Skimmers_Killed")]
        public long OnFootSkimmersKilled { get; init; }

        [JsonProperty("OnFoot_Scavs_Killed")]
        public long OnFootScavsKilled { get; init; }
    }


    public readonly struct CqcInfo
    {
        [JsonProperty("CQC_Credits_Earned")]
        public long CqcCreditsEarned { get; init; }

        [JsonProperty("CQC_Time_Played")]
        public long CqcTimePlayed { get; init; }

        [JsonProperty("CQC_KD")]
        public double CqcKd { get; init; }

        [JsonProperty("CQC_Kills")]
        public long CqcKills { get; init; }

        [JsonProperty("CQC_WL")]
        public double CqcWl { get; init; }
    }


    public readonly struct TgEncountersInfo
    {
        [JsonProperty("TG_ENCOUNTER_TOTAL")]
        public long TgEncounterTotal { get; init; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SYSTEM")]
        public string TgEncounterTotalLastSystem { get; init; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP")]
        public string TgEncounterTotalLastTimestamp { get; init; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SHIP")]
        public string TgEncounterTotalLastShip { get; init; }

        [JsonProperty("TG_SCOUT_COUNT")]
        public long TgScoutCount { get; init; }
    }


    public readonly struct CraftingInfo
    {
        [JsonProperty("Count_Of_Used_Engineers")]
        public long CountOfUsedEngineers { get; init; }

        [JsonProperty("Recipes_Generated")]
        public long RecipesGenerated { get; init; }

        [JsonProperty("Recipes_Generated_Rank_1")]
        public long RecipesGeneratedRank1 { get; init; }

        [JsonProperty("Recipes_Generated_Rank_2")]
        public long RecipesGeneratedRank2 { get; init; }

        [JsonProperty("Recipes_Generated_Rank_3")]
        public long RecipesGeneratedRank3 { get; init; }

        [JsonProperty("Recipes_Generated_Rank_4")]
        public long RecipesGeneratedRank4 { get; init; }

        [JsonProperty("Recipes_Generated_Rank_5")]
        public long RecipesGeneratedRank5 { get; init; }

        [JsonProperty("Suit_Mods_Applied")]
        public long SuitModsApplied { get; init; }

        [JsonProperty("Weapon_Mods_Applied")]
        public long WeaponModsApplied { get; init; }

        [JsonProperty("Suits_Upgraded")]
        public long SuitsUpgraded { get; init; }

        [JsonProperty("Weapons_Upgraded")]
        public long WeaponsUpgraded { get; init; }

        [JsonProperty("Suits_Upgraded_Full")]
        public long SuitsFullyUpgraded { get; init; }

        [JsonProperty("Weapons_Upgraded_Full")]
        public long WeaponsFullyUpgraded { get; init; }

        [JsonProperty("Suit_Mods_Applied_Full")]
        public long SuitModsFullyApplied { get; init; }

        [JsonProperty("Weapon_Mods_Applied_Full")]
        public long WeaponModsFullyApplied { get; init; }
    }


    public readonly struct CrewInfo
    {
        [JsonProperty("NpcCrew_TotalWages")]
        public long NpcCrewTotalWages { get; init; }

        [JsonProperty("NpcCrew_Hired")]
        public long NpcCrewHired { get; init; }

        [JsonProperty("NpcCrew_Fired")]
        public long NpcCrewFired { get; init; }

        [JsonProperty("NpcCrew_Died")]
        public long NpcCrewDied { get; init; }
    }


    public readonly struct CrimeInfo
    {
        [JsonProperty("Notoriety")]
        public long Notoriety { get; init; }

        [JsonProperty("Fines")]
        public long Fines { get; init; }

        [JsonProperty("Total_Fines")]
        public long TotalFines { get; init; }

        [JsonProperty("Bounties_Received")]
        public long BountiesReceived { get; init; }

        [JsonProperty("Total_Bounties")]
        public long TotalBounties { get; init; }

        [JsonProperty("Highest_Bounty")]
        public long HighestBounty { get; init; }

        [JsonProperty("Malware_Uploaded")]
        public long MalwareUploaded { get; init; }

        [JsonProperty("Settlements_State_Shutdown")]
        public long SettlementsStateShutdown { get; init; }

        [JsonProperty("Production_Sabotage")]
        public long ProductionSabotage { get; init; }

        [JsonProperty("Production_Theft")]
        public long ProductionTheft { get; init; }

        [JsonProperty("Total_Murders")]
        public long TotalMurders { get; init; }

        [JsonProperty("Citizens_Murdered")]
        public long CitizensMurdered { get; init; }

        [JsonProperty("Omnipol_Murdered")]
        public long OmnipolMurdered { get; init; }

        [JsonProperty("Guards_Murdered")]
        public long GuardsMurdered { get; init; }

        [JsonProperty("Data_Stolen")]
        public long DataStolen { get; init; }

        [JsonProperty("Goods_Stolen")]
        public long GoodsStolen { get; init; }

        [JsonProperty("Sample_Stolen")]
        public long SamplesStolen { get; init; }

        [JsonProperty("Total_Stolen")]
        public long TotalStolen { get; init; }

        [JsonProperty("Turrets_Destroyed")]
        public long TurretsDestroyed { get; init; }

        [JsonProperty("Turrets_Overloaded")]
        public long TurretsOverloaded { get; init; }

        [JsonProperty("Turrets_Total")]
        public long TurrentsTotal { get; init; }

        [JsonProperty("Value_Stolen_StateChange")]
        public long ValueStolenStateChange { get; init; }

        [JsonProperty("Profiles_Cloned")]
        public long ProfilesCloned { get; init; }
    }


    public readonly struct ExplorationInfo
    {
        [JsonProperty("Systems_Visited")]
        public long SystemsVisited { get; init; }

        [JsonProperty("Exploration_Profits")]
        public long ExplorationProfits { get; init; }

        [JsonProperty("Planets_Scanned_To_Level_2")]
        public long PlanetsScannedToLevel2 { get; init; }

        [JsonProperty("Planets_Scanned_To_Level_3")]
        public long PlanetsScannedToLevel3 { get; init; }

        [JsonProperty("Efficient_Scans")]
        public long EfficientScans { get; init; }

        [JsonProperty("Highest_Payout")]
        public long HighestPayout { get; init; }

        [JsonProperty("Total_Hyperspace_Distance")]
        public long TotalHyperspaceDistance { get; init; }

        [JsonProperty("Total_Hyperspace_Jumps")]
        public long TotalHyperspaceJumps { get; init; }

        [JsonProperty("Greatest_Distance_From_Start")]
        public double GreatestDistanceFromStart { get; init; }

        [JsonProperty("Time_Played")]
        public long TimePlayed { get; init; }

        [JsonProperty("Shuttle_Journeys")]
        public long ShuttleJourneys { get; init; }

        [JsonProperty("Shuttle_Distance_Travelled")]
        public long ShuttleDistanceTravelled { get; init; }

        [JsonProperty("Spent_On_Shuttles")]
        public long SpentOnShuttles { get; init; }

        [JsonProperty("First_Footfalls")]
        public long FirstFootfalls { get; init; }

        [JsonProperty("Planet_Footfalls")]
        public long PlanetFootfalls { get; init; }

        [JsonProperty("Settlements_Visited")]
        public long SettlementsVisited { get; init; }

        [JsonProperty("OnFoot_Distance_Travelled")]
        public long DistanceTravelledOnFoot { get; init; }
    }


    public readonly struct FleetCarrierInfo
    {
        [JsonProperty("FLEETCARRIER_EXPORT_TOTAL")]
        public long ExportTotal { get; init; }

        [JsonProperty("FLEETCARRIER_IMPORT_TOTAL")]
        public long ImportTotal { get; init; }

        [JsonProperty("FLEETCARRIER_TRADEPROFIT_TOTAL")]
        public long TradeProfitTotal { get; init; }

        [JsonProperty("FLEETCARRIER_TRADESPEND_TOTAL")]
        public long TradeSpendTotal { get; init; }

        [JsonProperty("FLEETCARRIER_STOLENPROFIT_TOTAL")]
        public long StolenProfitTotal { get; init; }

        [JsonProperty("FLEETCARRIER_STOLENSPEND_TOTAL")]
        public long StolenSpendTotal { get; init; }

        [JsonProperty("FLEETCARRIER_DISTANCE_TRAVELLED")]
        public string DistanceTravelled { get; init; }

        [JsonProperty("FLEETCARRIER_TOTAL_JUMPS")]
        public long TotalJumps { get; init; }

        [JsonProperty("FLEETCARRIER_SHIPYARD_SOLD")]
        public long ShipyardSold { get; init; }

        [JsonProperty("FLEETCARRIER_SHIPYARD_PROFIT")]
        public long ShipyardProfit { get; init; }

        [JsonProperty("FLEETCARRIER_OUTFITTING_SOLD")]
        public long OutfittingSold { get; init; }

        [JsonProperty("FLEETCARRIER_OUTFITTING_PROFIT")]
        public long OutfittingProfit { get; init; }

        [JsonProperty("FLEETCARRIER_REARM_TOTAL")]
        public long RearmTotal { get; init; }

        [JsonProperty("FLEETCARRIER_REFUEL_TOTAL")]
        public long RefuelTotal { get; init; }

        [JsonProperty("FLEETCARRIER_REFUEL_PROFIT")]
        public long RefuelProfit { get; init; }

        [JsonProperty("FLEETCARRIER_REPAIRS_TOTAL")]
        public long RepairsTotal { get; init; }

        [JsonProperty("FLEETCARRIER_VOUCHERS_REDEEMED")]
        public long VouchersRedeemed { get; init; }

        [JsonProperty("FLEETCARRIER_VOUCHERS_PROFIT")]
        public long VouchersProfit { get; init; }
    }


    public readonly struct MaterialTraderStatsInfo
    {
        [JsonProperty("Trades_Completed")]
        public long TradesCompleted { get; init; }

        [JsonProperty("Materials_Traded")]
        public long MaterialsTraded { get; init; }

        [JsonProperty("Encoded_Materials_Traded")]
        public long EncodedMaterialsTraded { get; init; }

        [JsonProperty("Raw_Materials_Traded")]
        public long RawMaterialsTraded { get; init; }

        [JsonProperty("Grade_1_Materials_Traded")]
        public long Grade1Traded { get; init; }

        [JsonProperty("Grade_2_Materials_Traded")]
        public long Grade2Traded { get; init; }

        [JsonProperty("Grade_3_Materials_Traded")]
        public long Grade3Traded { get; init; }

        [JsonProperty("Grade_4_Materials_Traded")]
        public long Grade4Traded { get; init; }

        [JsonProperty("Grade_5_Materials_Traded")]
        public long Grade5Traded { get; init; }

        [JsonProperty("Assets_Traded_In")]
        public long AssetsTradedIn { get; init; }

        [JsonProperty("Assets_Traded_Out")]
        public long AssetsTradedOut { get; init; }
    }


    public readonly struct MiningInfo
    {
        [JsonProperty("Mining_Profits")]
        public long Profits { get; init; }

        [JsonProperty("Quantity_Mined")]
        public long QuantityMined { get; init; }

        [JsonProperty("Materials_Collected")]
        public long MaterialsCollected { get; init; }
    }


    public readonly struct MulticrewInfo
    {
        [JsonProperty("Multicrew_Time_Total")]
        public long TimeTotal { get; init; }

        [JsonProperty("Multicrew_Gunner_Time_Total")]
        public long GunnerTimeTotal { get; init; }

        [JsonProperty("Multicrew_Fighter_Time_Total")]
        public long FighterTimeTotal { get; init; }

        [JsonProperty("Multicrew_Credits_Total")]
        public long CreditsTotal { get; init; }

        [JsonProperty("Multicrew_Fines_Total")]
        public long FinesTotal { get; init; }
    }


    public readonly struct PassengersInfo
    {
        [JsonProperty("Passengers_Missions_Accepted")]
        public long Accepted { get; init; }

        [JsonProperty("Passengers_Missions_Disgruntled")]
        public long Disgruntled { get; init; }

        [JsonProperty("Passengers_Missions_Bulk")]
        public long Bulk { get; init; }

        [JsonProperty("Passengers_Missions_VIP")]
        public long Vip { get; init; }

        [JsonProperty("Passengers_Missions_Delivered")]
        public long Delivered { get; init; }

        [JsonProperty("Passengers_Missions_Ejected")]
        public long Ejected { get; init; }
    }


    public readonly struct SearchAndRescueInfo
    {
        [JsonProperty("SearchRescue_Traded")]
        public long SearchRescueTraded { get; init; }

        [JsonProperty("SearchRescue_Profit")]
        public long SearchRescueProfit { get; init; }

        [JsonProperty("SearchRescue_Count")]
        public long SearchRescueCount { get; init; }

        [JsonProperty("Salvage_Legal_POI")]
        public long SalvagedLegalPointOfInterest { get; init; }

        [JsonProperty("Salvage_Legal_Settlements")]
        public long SalvagedLegalSettlements { get; init; }

        [JsonProperty("Salvage_Illegal_POI")]
        public long SalvagedIllegalPointOfInterest { get; init; }

        [JsonProperty("Salvage_Illegal_Settlements")]
        public long SalvagedIllegalSettlements { get; init; }

        [JsonProperty("Maglocks_Opened")]
        public long MagneticLocksOpened { get; init; }

        [JsonProperty("Panels_Opened")]
        public long PanelsOpened { get; init; }

        [JsonProperty("Settlements_State_FireOut")]
        public long SettlementsStateFireOut { get; init; }

        [JsonProperty("Settlements_State_Reboot")]
        public long SettlementsStateReboot { get; init; }
    }


    public readonly struct SmugglingInfo
    {
        [JsonProperty("Black_Markets_Traded_With")]
        public long BlackMarketsTradedWith { get; init; }

        [JsonProperty("Black_Markets_Profits")]
        public long BlackMarketsProfits { get; init; }

        [JsonProperty("Resources_Smuggled")]
        public long ResourcesSmuggled { get; init; }

        [JsonProperty("Average_Profit")]
        public double AverageProfit { get; init; }

        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; init; }
    }


    public readonly struct TradingInfo
    {
        [JsonProperty("Markets_Traded_With")]
        public long MarketsTradedWith { get; init; }

        [JsonProperty("Market_Profits")]
        public long MarketProfits { get; init; }

        [JsonProperty("Resources_Traded")]
        public long ResourcesTraded { get; init; }

        [JsonProperty("Average_Profit")]
        public double AverageProfit { get; init; }

        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; init; }

        [JsonProperty("Data_Sold")]
        public long DataSold { get; init; }

        [JsonProperty("Goods_Sold")]
        public long GoodsSold { get; init; }

        [JsonProperty("Assets_Sold")]
        public long AssetsSold { get; init; }
    }


    public readonly struct ExobiologyInfo
    {
        [JsonProperty("AssOrganic_Genus_Encountered")]
        public long AssOrganicGenusEncountered { get; init; }

        [JsonProperty("Organic_Genus_Encountered")]
        public long OrganicGenusEncountered { get; init; }

        [JsonProperty("Organic_Species_Encountered")]
        public long OrganicSpeciesEncountered { get; init; }

        [JsonProperty("Organic_Variant_Encountered")]
        public long OrganicVariantsEncountered { get; init; }

        [JsonProperty("Organic_Data_Profits")]
        public long OrganicDataProfits { get; init; }

        [JsonProperty("Organic_Data")]
        public long OrganicData { get; init; }

        [JsonProperty("First_Logged_Profits")]
        public long FirstLoggedProfits { get; init; }

        [JsonProperty("First_Logged")]
        public long FirstLogged { get; init; }

        [JsonProperty("Organic_Systems")]
        public long OrganicSystems { get; init; }

        [JsonProperty("Organic_Planets")]
        public long OrganicPlanets { get; init; }

        [JsonProperty("Organic_Genus")]
        public long OrganicGenus { get; init; }

        [JsonProperty("Organic_Species")]
        public long OrganicSpecies { get; init; }
    }
}
