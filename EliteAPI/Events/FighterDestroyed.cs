namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FighterDestroyedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }

    public partial class FighterDestroyedInfo
    {
        public static FighterDestroyedInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeFighterDestroyedEvent(JsonConvert.DeserializeObject<FighterDestroyedInfo>(json, EliteAPI.Events.FighterDestroyedConverter.Settings));
    }

    public static class FighterDestroyedSerializer
    {
        public static string ToJson(this FighterDestroyedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FighterDestroyedConverter.Settings);
    }

    internal static class FighterDestroyedConverter
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
