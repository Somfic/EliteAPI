namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class StatisticsInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Bank_Account")]
        public Dictionary<string, long> BankAccount { get; set; }

        [JsonProperty("Combat")]
        public Combat Combat { get; set; }

        [JsonProperty("Crime")]
        public Crime Crime { get; set; }

        [JsonProperty("Smuggling")]
        public Smuggling Smuggling { get; set; }

        [JsonProperty("Trading")]
        public Trading Trading { get; set; }

        [JsonProperty("Mining")]
        public Mining Mining { get; set; }

        [JsonProperty("Exploration")]
        public Dictionary<string, double> Exploration { get; set; }

        [JsonProperty("Passengers")]
        public Passengers Passengers { get; set; }

        [JsonProperty("Search_And_Rescue")]
        public SearchAndRescue SearchAndRescue { get; set; }

        [JsonProperty("TG_ENCOUNTERS")]
        public TgEncounters TgEncounters { get; set; }

        [JsonProperty("Crafting")]
        public Crafting Crafting { get; set; }

        [JsonProperty("Crew")]
        public Crew Crew { get; set; }

        [JsonProperty("Multicrew")]
        public Multicrew Multicrew { get; set; }

        [JsonProperty("Material_Trader_Stats")]
        public MaterialTraderStats MaterialTraderStats { get; set; }

        [JsonProperty("CQC")]
        public Dictionary<string, double> Cqc { get; set; }
    }

    public partial class Combat
    {
        [JsonProperty("Bounties_Claimed")]
        public long BountiesClaimed { get; set; }

        [JsonProperty("Bounty_Hunting_Profit")]
        public double BountyHuntingProfit { get; set; }

        [JsonProperty("Combat_Bonds")]
        public long CombatBonds { get; set; }

        [JsonProperty("Combat_Bond_Profits")]
        public long CombatBondProfits { get; set; }

        [JsonProperty("Assassinations")]
        public long Assassinations { get; set; }

        [JsonProperty("Assassination_Profits")]
        public long AssassinationProfits { get; set; }

        [JsonProperty("Highest_Single_Reward")]
        public long HighestSingleReward { get; set; }

        [JsonProperty("Skimmers_Killed")]
        public long SkimmersKilled { get; set; }
    }

    public partial class Crafting
    {
        [JsonProperty("Count_Of_Used_Engineers")]
        public long CountOfUsedEngineers { get; set; }

        [JsonProperty("Recipes_Generated")]
        public long RecipesGenerated { get; set; }

        [JsonProperty("Recipes_Generated_Rank_1")]
        public long RecipesGeneratedRank1 { get; set; }

        [JsonProperty("Recipes_Generated_Rank_2")]
        public long RecipesGeneratedRank2 { get; set; }

        [JsonProperty("Recipes_Generated_Rank_3")]
        public long RecipesGeneratedRank3 { get; set; }

        [JsonProperty("Recipes_Generated_Rank_4")]
        public long RecipesGeneratedRank4 { get; set; }

        [JsonProperty("Recipes_Generated_Rank_5")]
        public long RecipesGeneratedRank5 { get; set; }
    }

    public partial class Crew
    {
        [JsonProperty("NpcCrew_TotalWages")]
        public long NpcCrewTotalWages { get; set; }

        [JsonProperty("NpcCrew_Hired")]
        public long NpcCrewHired { get; set; }

        [JsonProperty("NpcCrew_Fired")]
        public long NpcCrewFired { get; set; }

        [JsonProperty("NpcCrew_Died")]
        public long NpcCrewDied { get; set; }
    }

    public partial class Crime
    {
        [JsonProperty("Notoriety")]
        public long Notoriety { get; set; }

        [JsonProperty("Fines")]
        public long Fines { get; set; }

        [JsonProperty("Total_Fines")]
        public long TotalFines { get; set; }

        [JsonProperty("Bounties_Received")]
        public long BountiesReceived { get; set; }

        [JsonProperty("Total_Bounties")]
        public long TotalBounties { get; set; }

        [JsonProperty("Highest_Bounty")]
        public long HighestBounty { get; set; }
    }

    public partial class MaterialTraderStats
    {
        [JsonProperty("Trades_Completed")]
        public long TradesCompleted { get; set; }

        [JsonProperty("Materials_Traded")]
        public long MaterialsTraded { get; set; }

        [JsonProperty("Encoded_Materials_Traded")]
        public long EncodedMaterialsTraded { get; set; }

        [JsonProperty("Raw_Materials_Traded")]
        public long RawMaterialsTraded { get; set; }

        [JsonProperty("Grade_1_Materials_Traded")]
        public long Grade1_MaterialsTraded { get; set; }

        [JsonProperty("Grade_2_Materials_Traded")]
        public long Grade2_MaterialsTraded { get; set; }

        [JsonProperty("Grade_3_Materials_Traded")]
        public long Grade3_MaterialsTraded { get; set; }

        [JsonProperty("Grade_4_Materials_Traded")]
        public long Grade4_MaterialsTraded { get; set; }

        [JsonProperty("Grade_5_Materials_Traded")]
        public long Grade5_MaterialsTraded { get; set; }
    }

    public partial class Mining
    {
        [JsonProperty("Mining_Profits")]
        public long MiningProfits { get; set; }

        [JsonProperty("Quantity_Mined")]
        public long QuantityMined { get; set; }

        [JsonProperty("Materials_Collected")]
        public long MaterialsCollected { get; set; }
    }

    public partial class Multicrew
    {
        [JsonProperty("Multicrew_Time_Total")]
        public long MulticrewTimeTotal { get; set; }

        [JsonProperty("Multicrew_Gunner_Time_Total")]
        public long MulticrewGunnerTimeTotal { get; set; }

        [JsonProperty("Multicrew_Fighter_Time_Total")]
        public long MulticrewFighterTimeTotal { get; set; }

        [JsonProperty("Multicrew_Credits_Total")]
        public long MulticrewCreditsTotal { get; set; }

        [JsonProperty("Multicrew_Fines_Total")]
        public long MulticrewFinesTotal { get; set; }
    }

    public partial class Passengers
    {
        [JsonProperty("Passengers_Missions_Accepted")]
        public long PassengersMissionsAccepted { get; set; }

        [JsonProperty("Passengers_Missions_Disgruntled")]
        public long PassengersMissionsDisgruntled { get; set; }

        [JsonProperty("Passengers_Missions_Bulk")]
        public long PassengersMissionsBulk { get; set; }

        [JsonProperty("Passengers_Missions_VIP")]
        public long PassengersMissionsVip { get; set; }

        [JsonProperty("Passengers_Missions_Delivered")]
        public long PassengersMissionsDelivered { get; set; }

        [JsonProperty("Passengers_Missions_Ejected")]
        public long PassengersMissionsEjected { get; set; }
    }

    public partial class SearchAndRescue
    {
        [JsonProperty("SearchRescue_Traded")]
        public long SearchRescueTraded { get; set; }

        [JsonProperty("SearchRescue_Profit")]
        public long SearchRescueProfit { get; set; }

        [JsonProperty("SearchRescue_Count")]
        public long SearchRescueCount { get; set; }
    }

    public partial class Smuggling
    {
        [JsonProperty("Black_Markets_Traded_With")]
        public long BlackMarketsTradedWith { get; set; }

        [JsonProperty("Black_Markets_Profits")]
        public long BlackMarketsProfits { get; set; }

        [JsonProperty("Resources_Smuggled")]
        public long ResourcesSmuggled { get; set; }

        [JsonProperty("Average_Profit")]
        public double AverageProfit { get; set; }

        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; set; }
    }

    public partial class TgEncounters
    {
        [JsonProperty("TG_ENCOUNTER_TOTAL")]
        public long TgEncounterTotal { get; set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SYSTEM")]
        public string TgEncounterTotalLastSystem { get; set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP")]
        public string TgEncounterTotalLastTimestamp { get; set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SHIP")]
        public string TgEncounterTotalLastShip { get; set; }

        [JsonProperty("TG_SCOUT_COUNT")]
        public long TgScoutCount { get; set; }
    }

    public partial class Trading
    {
        [JsonProperty("Markets_Traded_With")]
        public long MarketsTradedWith { get; set; }

        [JsonProperty("Market_Profits")]
        public long MarketProfits { get; set; }

        [JsonProperty("Resources_Traded")]
        public long ResourcesTraded { get; set; }

        [JsonProperty("Average_Profit")]
        public double AverageProfit { get; set; }

        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; set; }
    }

    public partial class StatisticsInfo
    {
        public static StatisticsInfo Process(string json) => EventHandler.InvokeStatisticsEvent(JsonConvert.DeserializeObject<StatisticsInfo>(json, EliteAPI.Events.StatisticsConverter.Settings));
    }

    public static class StatisticsSerializer
    {
        public static string ToJson(this StatisticsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.StatisticsConverter.Settings);
    }

    internal static class StatisticsConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
