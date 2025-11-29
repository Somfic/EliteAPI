using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CommunityGoalEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CurrentGoals")]
    public IReadOnlyCollection<CurrentGoalInfo> CurrentGoals { get; init; }

    public readonly struct CurrentGoalInfo
    {
        [JsonProperty("CGID")]
        public string Id { get; init; }

        [JsonProperty("Title")]
        public string Title { get; init; }

        [JsonProperty("SystemName")]
        public string SystemName { get; init; }

        [JsonProperty("MarketName")]
        public string MarketName { get; init; }

        [JsonProperty("Expiry")]
        public DateTime Expiry { get; init; }

        [JsonProperty("IsComplete")]
        public bool IsComplete { get; init; }

        [JsonProperty("CurrentTotal")]
        public long CurrentTotal { get; init; }

        [JsonProperty("PlayerContribution")]
        public long PlayerContribution { get; init; }

        [JsonProperty("NumContributors")]
        public long NumContributors { get; init; }

        [JsonProperty("TopTier")]
        public TopTierInfo TopTier { get; init; }

        [JsonProperty("TierReached")]
        public string TierReached { get; init; }

        [JsonProperty("TopRankSize")]
        public long TopRankSize { get; init; }

        [JsonProperty("PlayerInTopRank")]
        public bool IsInTopRank { get; init; }

        [JsonProperty("PlayerPercentileBand")]
        public long PlayerPercentileBand { get; init; }

        [JsonProperty("Bonus")]
        public long Bonus { get; init; }
    }


    public readonly struct TopTierInfo
    {
        [JsonProperty("Name")]
        public string Name { get; init; }

        [JsonProperty("Bonus")]
        public string Bonus { get; init; }
    }
}
