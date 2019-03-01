namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Rank")]
        public long Rank { get; internal set; }

        [JsonProperty("Merits")]
        public long Merits { get; internal set; }

        [JsonProperty("Votes")]
        public long Votes { get; internal set; }

        [JsonProperty("TimePledged")]
        public long TimePledged { get; internal set; }
    }

    public partial class PowerplayInfo
    {
        public static PowerplayInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayEvent(JsonConvert.DeserializeObject<PowerplayInfo>(json, EliteAPI.Events.PowerplayConverter.Settings));
    }

    public static class PowerplaySerializer
    {
        public static string ToJson(this PowerplayInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayConverter.Settings);
    }

    internal static class PowerplayConverter
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
