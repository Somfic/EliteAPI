namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CommunityGoalRewardInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }
    }

    public partial class CommunityGoalRewardInfo
    {
        public static CommunityGoalRewardInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalRewardEvent(JsonConvert.DeserializeObject<CommunityGoalRewardInfo>(json, EliteAPI.Events.CommunityGoalRewardConverter.Settings));
    }

    public static class CommunityGoalRewardSerializer
    {
        public static string ToJson(this CommunityGoalRewardInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CommunityGoalRewardConverter.Settings);
    }

    internal static class CommunityGoalRewardConverter
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
