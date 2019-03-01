namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CommunityGoalInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("CurrentGoals")]
        public List<CurrentGoal> CurrentGoals { get; internal set; }
    }

    public partial class CurrentGoal
    {
        [JsonProperty("CGID")]
        public long Cgid { get; internal set; }

        [JsonProperty("Title")]
        public string Title { get; internal set; }

        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }

        [JsonProperty("MarketName")]
        public string MarketName { get; internal set; }

        [JsonProperty("Expiry")]
        public DateTime Expiry { get; internal set; }

        [JsonProperty("IsComplete")]
        public bool IsComplete { get; internal set; }

        [JsonProperty("CurrentTotal")]
        public long CurrentTotal { get; internal set; }

        [JsonProperty("PlayerContribution")]
        public long PlayerContribution { get; internal set; }

        [JsonProperty("NumContributors")]
        public long NumContributors { get; internal set; }

        [JsonProperty("TopRankSize")]
        public long TopRankSize { get; internal set; }

        [JsonProperty("PlayerInTopRank")]
        public bool PlayerInTopRank { get; internal set; }

        [JsonProperty("TierReached")]
        public string TierReached { get; internal set; }

        [JsonProperty("PlayerPercentileBand")]
        public long PlayerPercentileBand { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }
    }

    public partial class CommunityGoalInfo
    {
        public static CommunityGoalInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommunityGoalEvent(JsonConvert.DeserializeObject<CommunityGoalInfo>(json, EliteAPI.Events.CommunityGoalConverter.Settings));
    }

    public static class CommunityGoalSerializer
    {
        public static string ToJson(this CommunityGoalInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CommunityGoalConverter.Settings);
    }

    internal static class CommunityGoalConverter
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
