namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FighterRebuiltInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; set; }
    }

    public partial class FighterRebuiltInfo
    {
        public static FighterRebuiltInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFighterRebuiltEvent(JsonConvert.DeserializeObject<FighterRebuiltInfo>(json, EliteAPI.Events.FighterRebuiltConverter.Settings));
    }

    public static class FighterRebuiltSerializer
    {
        public static string ToJson(this FighterRebuiltInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FighterRebuiltConverter.Settings);
    }

    internal static class FighterRebuiltConverter
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
