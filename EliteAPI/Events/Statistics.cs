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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Bank_Account")]
        public Dictionary<string, long> BankAccount { get; internal set; }

        [JsonProperty("Combat")]
        public Combat Combat { get; internal set; }

        [JsonProperty("Crime")]
        public Crime Crime { get; internal set; }

        [JsonProperty("Smuggling")]
        public Smuggling Smuggling { get; internal set; }

        [JsonProperty("Trading")]
        public Trading Trading { get; internal set; }

        [JsonProperty("Mining")]
        public Mining Mining { get; internal set; }

        [JsonProperty("Exploration")]
        public Dictionary<string, double> Exploration { get; internal set; }

        [JsonProperty("Passengers")]
        public Passengers Passengers { get; internal set; }

        [JsonProperty("Search_And_Rescue")]
        public SearchAndRescue SearchAndRescue { get; internal set; }

        [JsonProperty("TG_ENCOUNTERS")]
        public TgEncounters TgEncounters { get; internal set; }

        [JsonProperty("Crafting")]
        public Crafting Crafting { get; internal set; }

        [JsonProperty("Crew")]
        public Crew Crew { get; internal set; }

        [JsonProperty("Multicrew")]
        public Multicrew Multicrew { get; internal set; }

        [JsonProperty("Material_Trader_Stats")]
        public MaterialTraderStats MaterialTraderStats { get; internal set; }

        [JsonProperty("CQC")]
        public Dictionary<string, double> Cqc { get; internal set; }
    }

    public class Combat
    {
        [JsonProperty("Bounties_Claimed")]
        public long BountiesClaimed { get; internal set; }

        [JsonProperty("Bounty_Hunting_Profit")]
        public double BountyHuntingProfit { get; internal set; }

        [JsonProperty("Combat_Bonds")]
        public long CombatBonds { get; internal set; }

        [JsonProperty("Combat_Bond_Profits")]
        public long CombatBondProfits { get; internal set; }

        [JsonProperty("Assassinations")]
        public long Assassinations { get; internal set; }

        [JsonProperty("Assassination_Profits")]
        public long AssassinationProfits { get; internal set; }

        [JsonProperty("Highest_Single_Reward")]
        public long HighestSingleReward { get; internal set; }

        [JsonProperty("Skimmers_Killed")]
        public long SkimmersKilled { get; internal set; }
    }

    public class Crafting
    {
        [JsonProperty("Count_Of_Used_Engineers")]
        public long CountOfUsedEngineers { get; internal set; }

        [JsonProperty("Recipes_Generated")]
        public long RecipesGenerated { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_1")]
        public long RecipesGeneratedRank1 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_2")]
        public long RecipesGeneratedRank2 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_3")]
        public long RecipesGeneratedRank3 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_4")]
        public long RecipesGeneratedRank4 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_5")]
        public long RecipesGeneratedRank5 { get; internal set; }
    }

    public class Crew
    {
        [JsonProperty("NpcCrew_TotalWages")]
        public long NpcCrewTotalWages { get; internal set; }

        [JsonProperty("NpcCrew_Hired")]
        public long NpcCrewHired { get; internal set; }

        [JsonProperty("NpcCrew_Fired")]
        public long NpcCrewFired { get; internal set; }

        [JsonProperty("NpcCrew_Died")]
        public long NpcCrewDied { get; internal set; }
    }

    public class Crime
    {
        [JsonProperty("Notoriety")]
        public long Notoriety { get; internal set; }

        [JsonProperty("Fines")]
        public long Fines { get; internal set; }

        [JsonProperty("Total_Fines")]
        public long TotalFines { get; internal set; }

        [JsonProperty("Bounties_Received")]
        public long BountiesReceived { get; internal set; }

        [JsonProperty("Total_Bounties")]
        public long TotalBounties { get; internal set; }

        [JsonProperty("Highest_Bounty")]
        public long HighestBounty { get; internal set; }
    }

    public class MaterialTraderStats
    {
        [JsonProperty("Trades_Completed")]
        public long TradesCompleted { get; internal set; }

        [JsonProperty("Materials_Traded")]
        public long MaterialsTraded { get; internal set; }

        [JsonProperty("Encoded_Materials_Traded")]
        public long EncodedMaterialsTraded { get; internal set; }

        [JsonProperty("Raw_Materials_Traded")]
        public long RawMaterialsTraded { get; internal set; }

        [JsonProperty("Grade_1_Materials_Traded")]
        public long Grade1_MaterialsTraded { get; internal set; }

        [JsonProperty("Grade_2_Materials_Traded")]
        public long Grade2_MaterialsTraded { get; internal set; }

        [JsonProperty("Grade_3_Materials_Traded")]
        public long Grade3_MaterialsTraded { get; internal set; }

        [JsonProperty("Grade_4_Materials_Traded")]
        public long Grade4_MaterialsTraded { get; internal set; }

        [JsonProperty("Grade_5_Materials_Traded")]
        public long Grade5_MaterialsTraded { get; internal set; }
    }

    public class Mining
    {
        [JsonProperty("Mining_Profits")]
        public long MiningProfits { get; internal set; }

        [JsonProperty("Quantity_Mined")]
        public long QuantityMined { get; internal set; }

        [JsonProperty("Materials_Collected")]
        public long MaterialsCollected { get; internal set; }
    }

    public class Multicrew
    {
        [JsonProperty("Multicrew_Time_Total")]
        public long MulticrewTimeTotal { get; internal set; }

        [JsonProperty("Multicrew_Gunner_Time_Total")]
        public long MulticrewGunnerTimeTotal { get; internal set; }

        [JsonProperty("Multicrew_Fighter_Time_Total")]
        public long MulticrewFighterTimeTotal { get; internal set; }

        [JsonProperty("Multicrew_Credits_Total")]
        public long MulticrewCreditsTotal { get; internal set; }

        [JsonProperty("Multicrew_Fines_Total")]
        public long MulticrewFinesTotal { get; internal set; }
    }

    public class Passengers
    {
        [JsonProperty("Passengers_Missions_Accepted")]
        public long PassengersMissionsAccepted { get; internal set; }

        [JsonProperty("Passengers_Missions_Disgruntled")]
        public long PassengersMissionsDisgruntled { get; internal set; }

        [JsonProperty("Passengers_Missions_Bulk")]
        public long PassengersMissionsBulk { get; internal set; }

        [JsonProperty("Passengers_Missions_VIP")]
        public long PassengersMissionsVip { get; internal set; }

        [JsonProperty("Passengers_Missions_Delivered")]
        public long PassengersMissionsDelivered { get; internal set; }

        [JsonProperty("Passengers_Missions_Ejected")]
        public long PassengersMissionsEjected { get; internal set; }
    }

    public class SearchAndRescue
    {
        [JsonProperty("SearchRescue_Traded")]
        public long SearchRescueTraded { get; internal set; }

        [JsonProperty("SearchRescue_Profit")]
        public long SearchRescueProfit { get; internal set; }

        [JsonProperty("SearchRescue_Count")]
        public long SearchRescueCount { get; internal set; }
    }

    public class Smuggling
    {
        [JsonProperty("Black_Markets_Traded_With")]
        public long BlackMarketsTradedWith { get; internal set; }

        [JsonProperty("Black_Markets_Profits")]
        public long BlackMarketsProfits { get; internal set; }

        [JsonProperty("Resources_Smuggled")]
        public long ResourcesSmuggled { get; internal set; }

        [JsonProperty("Average_Profit")]
        public double AverageProfit { get; internal set; }

        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; internal set; }
    }

    public class TgEncounters
    {
        [JsonProperty("TG_ENCOUNTER_TOTAL")]
        public long TgEncounterTotal { get; internal set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SYSTEM")]
        public string TgEncounterTotalLastSystem { get; internal set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP")]
        public string TgEncounterTotalLastTimestamp { get; internal set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SHIP")]
        public string TgEncounterTotalLastShip { get; internal set; }

        [JsonProperty("TG_SCOUT_COUNT")]
        public long TgScoutCount { get; internal set; }
    }

    public class Trading
    {
        [JsonProperty("Markets_Traded_With")]
        public long MarketsTradedWith { get; internal set; }

        [JsonProperty("Market_Profits")]
        public long MarketProfits { get; internal set; }

        [JsonProperty("Resources_Traded")]
        public long ResourcesTraded { get; internal set; }

        [JsonProperty("Average_Profit")]
        public double AverageProfit { get; internal set; }

        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; internal set; }
    }

    public partial class StatisticsInfo
    {
        public static StatisticsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStatisticsEvent(JsonConvert.DeserializeObject<StatisticsInfo>(json, EliteAPI.Events.StatisticsConverter.Settings));
    }

    public static class StatisticsSerializer
    {
        public static string ToJson(this StatisticsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.StatisticsConverter.Settings);
    }

    internal static class StatisticsConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
