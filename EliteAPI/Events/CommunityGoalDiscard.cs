namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CommunityGoalDiscardInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("System")]
        public string System { get; set; }
    }

    public partial class CommunityGoalDiscardInfo
    {
        public static CommunityGoalDiscardInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalDiscardEvent(JsonConvert.DeserializeObject<CommunityGoalDiscardInfo>(json, EliteAPI.Events.CommunityGoalDiscardConverter.Settings));
    }

    public static class CommunityGoalDiscardSerializer
    {
        public static string ToJson(this CommunityGoalDiscardInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CommunityGoalDiscardConverter.Settings);
    }

    internal static class CommunityGoalDiscardConverter
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
