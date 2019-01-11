namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayCollectInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Power")]
        public string Power { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }

    public partial class PowerplayCollectInfo
    {
        public static PowerplayCollectInfo Process(string json) => EventHandler.InvokePowerplayCollectEvent(JsonConvert.DeserializeObject<PowerplayCollectInfo>(json, EliteAPI.Events.PowerplayCollectConverter.Settings));
    }

    public static class PowerplayCollectSerializer
    {
        public static string ToJson(this PowerplayCollectInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayCollectConverter.Settings);
    }

    internal static class PowerplayCollectConverter
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
