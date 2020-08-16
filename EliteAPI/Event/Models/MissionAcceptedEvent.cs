using System;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class MissionAcceptedEvent : EventBase
    {
        internal MissionAcceptedEvent() { }

        public static MissionAcceptedEvent FromJson(string json) => JsonConvert.DeserializeObject<MissionAcceptedEvent>(json);


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