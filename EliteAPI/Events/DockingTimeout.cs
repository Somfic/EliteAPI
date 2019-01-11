namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DockingTimeoutInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StationType")]
        public string StationType { get; set; }
    }

    public partial class DockingTimeoutInfo
    {
        public static DockingTimeoutInfo Process(string json) => EventHandler.InvokeDockingTimeoutEvent(JsonConvert.DeserializeObject<DockingTimeoutInfo>(json, EliteAPI.Events.DockingTimeoutConverter.Settings));
    }

    public static class DockingTimeoutSerializer
    {
        public static string ToJson(this DockingTimeoutInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DockingTimeoutConverter.Settings);
    }

    internal static class DockingTimeoutConverter
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
