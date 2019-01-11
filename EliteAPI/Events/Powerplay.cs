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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Power")]
        public string Power { get; set; }

        [JsonProperty("Rank")]
        public long Rank { get; set; }

        [JsonProperty("Merits")]
        public long Merits { get; set; }

        [JsonProperty("Votes")]
        public long Votes { get; set; }

        [JsonProperty("TimePledged")]
        public long TimePledged { get; set; }
    }

    public partial class PowerplayInfo
    {
        public static PowerplayInfo Process(string json) => EventHandler.InvokePowerplayEvent(JsonConvert.DeserializeObject<PowerplayInfo>(json, EliteAPI.Events.PowerplayConverter.Settings));
    }

    public static class PowerplaySerializer
    {
        public static string ToJson(this PowerplayInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayConverter.Settings);
    }

    internal static class PowerplayConverter
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
