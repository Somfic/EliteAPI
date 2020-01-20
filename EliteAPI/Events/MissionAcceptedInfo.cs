using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MissionAcceptedInfo : IEvent
    {
        internal static MissionAcceptedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionAcceptedEvent(JsonConvert.DeserializeObject<MissionAcceptedInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("LocalisedName")]
        public string LocalisedName { get; internal set; }
        [JsonProperty("Commodity")]
        public string Commodity { get; internal set; }
        [JsonProperty("Commodity_Localised")]
        public string CommodityLocalised { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; internal set; }
        [JsonProperty("Expiry")]
        public DateTime Expiry { get; internal set; }
        [JsonProperty("Influence")]
        public string Influence { get; internal set; }
        [JsonProperty("Reputation")]
        public string Reputation { get; internal set; }
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }
        [JsonProperty("PassengerCount")]
        public long PassengerCount { get; internal set; }
        [JsonProperty("PassengerVIPs")]
        public bool PassengerViPs { get; internal set; }
        [JsonProperty("PassengerWanted")]
        public bool PassengerWanted { get; internal set; }
        [JsonProperty("PassengerType")]
        public string PassengerType { get; internal set; }
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
    }
}
