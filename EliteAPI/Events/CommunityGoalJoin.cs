namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CommunityGoalJoinInfo
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

    public partial class CommunityGoalJoinInfo
    {
        public static CommunityGoalJoinInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalJoinEvent(JsonConvert.DeserializeObject<CommunityGoalJoinInfo>(json, EliteAPI.Events.CommunityGoalJoinConverter.Settings));
    }

    public static class CommunityGoalJoinSerializer
    {
        public static string ToJson(this CommunityGoalJoinInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CommunityGoalJoinConverter.Settings);
    }

    internal static class CommunityGoalJoinConverter
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
