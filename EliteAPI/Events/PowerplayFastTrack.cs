namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayFastTrackInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
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
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
