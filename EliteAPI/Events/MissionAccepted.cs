namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MissionAcceptedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Faction")]
        public string Faction { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("LocalisedName")]
        public string LocalisedName { get; set; }

        [JsonProperty("Commodity")]
        public string Commodity { get; set; }

        [JsonProperty("Commodity_Localised")]
        public string CommodityLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; set; }

        [JsonProperty("Expiry")]
        public DateTime Expiry { get; set; }

        [JsonProperty("Influence")]
        public string Influence { get; set; }

        [JsonProperty("Reputation")]
        public string Reputation { get; set; }

        [JsonProperty("Reward")]
        public long Reward { get; set; }

        [JsonProperty("PassengerCount")]
        public long PassengerCount { get; set; }

        [JsonProperty("PassengerVIPs")]
        public bool PassengerViPs { get; set; }

        [JsonProperty("PassengerWanted")]
        public bool PassengerWanted { get; set; }

        [JsonProperty("PassengerType")]
        public string PassengerType { get; set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; set; }
    }

    public partial class MissionAcceptedInfo
    {
        public static MissionAcceptedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionAcceptedEvent(JsonConvert.DeserializeObject<MissionAcceptedInfo>(json, EliteAPI.Events.MissionAcceptedConverter.Settings));
    }

    public static class MissionAcceptedSerializer
    {
        public static string ToJson(this MissionAcceptedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MissionAcceptedConverter.Settings);
    }

    internal static class MissionAcceptedConverter
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
