namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PassengersInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Manifest")]
        public List<Manifest> Manifest { get; internal set; }
    }

    public partial class Manifest
    {
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("VIP")]
        public bool Vip { get; internal set; }

        [JsonProperty("Wanted")]
        public bool Wanted { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }

    public partial class PassengersInfo
    {
        public static PassengersInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePassengersEvent(JsonConvert.DeserializeObject<PassengersInfo>(json, EliteAPI.Events.PassengersConverter.Settings));
    }

    

    internal static class PassengersConverter
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
