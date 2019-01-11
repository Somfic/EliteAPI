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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("CurrentGoals")]
        public List<CurrentGoal> CurrentGoals { get; set; }
    }

    public partial class CurrentGoal
    {
        [JsonProperty("CGID")]
        public long Cgid { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("SystemName")]
        public string SystemName { get; set; }

        [JsonProperty("MarketName")]
        public string MarketName { get; set; }

        [JsonProperty("Expiry")]
        public DateTime Expiry { get; set; }

        [JsonProperty("IsComplete")]
        public bool IsComplete { get; set; }

        [JsonProperty("CurrentTotal")]
        public long CurrentTotal { get; set; }

        [JsonProperty("PlayerContribution")]
        public long PlayerContribution { get; set; }

        [JsonProperty("NumContributors")]
        public long NumContributors { get; set; }

        [JsonProperty("TopRankSize")]
        public long TopRankSize { get; set; }

        [JsonProperty("PlayerInTopRank")]
        public bool PlayerInTopRank { get; set; }

        [JsonProperty("TierReached")]
        public string TierReached { get; set; }

        [JsonProperty("PlayerPercentileBand")]
        public long PlayerPercentileBand { get; set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; set; }
    }

    public partial class CommunityGoalInfo
    {
        public static CommunityGoalInfo Process(string json) => EventHandler.InvokeCommunityGoalEvent(JsonConvert.DeserializeObject<CommunityGoalInfo>(json, EliteAPI.Events.CommunityGoalConverter.Settings));
    }

    public static class CommunityGoalSerializer
    {
        public static string ToJson(this CommunityGoalInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CommunityGoalConverter.Settings);
    }

    internal static class CommunityGoalConverter
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
