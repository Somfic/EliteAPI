namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayDeliverInfo : IEvent
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

    public partial class PowerplayDeliverInfo
    {
        public static PowerplayDeliverInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayDeliverEvent(JsonConvert.DeserializeObject<PowerplayDeliverInfo>(json, EliteAPI.Events.PowerplayDeliverConverter.Settings));
    }

    public static class PowerplayDeliverSerializer
    {
        public static string ToJson(this PowerplayDeliverInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayDeliverConverter.Settings);
    }

    internal static class PowerplayDeliverConverter
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
