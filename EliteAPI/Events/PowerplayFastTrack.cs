namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayFastTrackInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Power")]
        public string Power { get; set; }

        [JsonProperty("Cost")]
        public long Cost { get; set; }
    }

    public partial class PowerplayFastTrackInfo
    {
        public static PowerplayFastTrackInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayFastTrackEvent(JsonConvert.DeserializeObject<PowerplayFastTrackInfo>(json, EliteAPI.Events.PowerplayFastTrackConverter.Settings));
    }

    public static class PowerplayFastTrackSerializer
    {
        public static string ToJson(this PowerplayFastTrackInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayFastTrackConverter.Settings);
    }

    internal static class PowerplayFastTrackConverter
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
