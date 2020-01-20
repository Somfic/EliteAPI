using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class StatisticsInfo : IEvent
    {
        internal static StatisticsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStatisticsEvent(JsonConvert.DeserializeObject<StatisticsInfo>(json, JsonSettings.Settings));

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
        public PassengersStatistics Passengers { get; internal set; }
        [JsonProperty("Search_And_Rescue")]
        public SearchAndRescueStatistics SearchAndRescue { get; internal set; }
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
}