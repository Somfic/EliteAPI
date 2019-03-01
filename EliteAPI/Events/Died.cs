namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DiedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("KillerName")]
        public string KillerName { get; internal set; }

        [JsonProperty("KillerName_Localised")]
        public string KillerNameLocalised { get; internal set; }

        [JsonProperty("KillerShip")]
        public string KillerShip { get; internal set; }

        [JsonProperty("KillerRank")]
        public string KillerRank { get; internal set; }
    }

    public partial class DiedInfo
    {
        public static DiedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDiedEvent(JsonConvert.DeserializeObject<DiedInfo>(json, EliteAPI.Events.DiedConverter.Settings));
    }

    public static class DiedSerializer
    {
        public static string ToJson(this DiedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DiedConverter.Settings);
    }

    internal static class DiedConverter
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
