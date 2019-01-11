namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CollectCargoInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; set; }

        [JsonProperty("Stolen")]
        public bool Stolen { get; set; }
    }

    public partial class CollectCargoInfo
    {
        public static CollectCargoInfo Process(string json) => EventHandler.InvokeCollectCargoEvent(JsonConvert.DeserializeObject<CollectCargoInfo>(json, EliteAPI.Events.CollectCargoConverter.Settings));
    }

    public static class CollectCargoSerializer
    {
        public static string ToJson(this CollectCargoInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CollectCargoConverter.Settings);
    }

    internal static class CollectCargoConverter
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
