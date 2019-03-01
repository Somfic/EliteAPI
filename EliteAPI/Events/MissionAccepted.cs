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
