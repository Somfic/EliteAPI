namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayCollectInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }

    public partial class PowerplayCollectInfo
    {
        public static PowerplayCollectInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayCollectEvent(JsonConvert.DeserializeObject<PowerplayCollectInfo>(json, EliteAPI.Events.PowerplayCollectConverter.Settings));
    }

    public static class PowerplayCollectSerializer
    {
        public static string ToJson(this PowerplayCollectInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayCollectConverter.Settings);
    }

    internal static class PowerplayCollectConverter
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
