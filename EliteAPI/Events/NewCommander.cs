namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class NewCommanderInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Package")]
        public string Package { get; internal set; }
    }

    public partial class NewCommanderInfo
    {
        public static NewCommanderInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeNewCommanderEvent(JsonConvert.DeserializeObject<NewCommanderInfo>(json, EliteAPI.Events.NewCommanderConverter.Settings));
    }

    public static class NewCommanderSerializer
    {
        public static string ToJson(this NewCommanderInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.NewCommanderConverter.Settings);
    }

    internal static class NewCommanderConverter
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
