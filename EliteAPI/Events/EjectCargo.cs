namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EjectCargoInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("Abandoned")]
        public bool Abandoned { get; set; }
    }

    public partial class EjectCargoInfo
    {
        public static EjectCargoInfo Process(string json) => EventHandler.InvokeEjectCargoEvent(JsonConvert.DeserializeObject<EjectCargoInfo>(json, EliteAPI.Events.EjectCargoConverter.Settings));
    }

    public static class EjectCargoSerializer
    {
        public static string ToJson(this EjectCargoInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.EjectCargoConverter.Settings);
    }

    internal static class EjectCargoConverter
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
