namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PassengersInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Manifest")]
        public List<Manifest> Manifest { get; set; }
    }

    public partial class Manifest
    {
        [JsonProperty("MissionID")]
        public long MissionId { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("VIP")]
        public bool Vip { get; set; }

        [JsonProperty("Wanted")]
        public bool Wanted { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }

    public partial class PassengersInfo
    {
        public static PassengersInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePassengersEvent(JsonConvert.DeserializeObject<PassengersInfo>(json, EliteAPI.Events.PassengersConverter.Settings));
    }

    public static class PassengersSerializer
    {
        public static string ToJson(this PassengersInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PassengersConverter.Settings);
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
