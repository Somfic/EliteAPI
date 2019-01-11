namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class HullDamageInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Health")]
        public double Health { get; set; }

        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; set; }

        [JsonProperty("Fighter")]
        public bool Fighter { get; set; }
    }

    public partial class HullDamageInfo
    {
        public static HullDamageInfo Process(string json) => EventHandler.InvokeHullDamageEvent(JsonConvert.DeserializeObject<HullDamageInfo>(json, EliteAPI.Events.HullDamageConverter.Settings));
    }

    public static class HullDamageSerializer
    {
        public static string ToJson(this HullDamageInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.HullDamageConverter.Settings);
    }

    internal static class HullDamageConverter
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
