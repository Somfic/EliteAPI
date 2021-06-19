using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CommunityGoalEvent : EventBase<CommunityGoalEvent>
    {
        internal CommunityGoalEvent() { }

        [JsonProperty("CurrentGoals")]
        public IReadOnlyList<CurrentGoalInfo> CurrentGoals { get; private set; }


        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class CurrentGoalInfo
        {
            internal CurrentGoalInfo() { }

            [JsonProperty("CGID")]
            public string CgId { get; private set; }

            [JsonProperty("Title")]
            public string Title { get; private set; }

            [JsonProperty("SystemName")]
            public string SystemName { get; private set; }

            [JsonProperty("MarketName")]
            public string MarketName { get; private set; }

            [JsonProperty("Expiry")]
            public DateTime Expiry { get; private set; }

            [JsonProperty("IsComplete")]
            public bool IsComplete { get; private set; }

            [JsonProperty("CurrentTotal")]
            public long CurrentTotal { get; private set; }

            [JsonProperty("PlayerContribution")]
            public long PlayerContribution { get; private set; }

            [JsonProperty("NumContributors")]
            public long NumContributors { get; private set; }

            [JsonProperty("TopTier")]
            public TopTierInfo TopTier { get; private set; }

            [JsonProperty("TierReached")]
            public string TierReached { get; private set; }
            
            [JsonProperty("TopRankSize")]
            public int TopRankSize { get; private set; }

            [JsonProperty("PlayerInTopRank")]
            public bool IsInTopRank { get; private set; }
            
            [JsonProperty("PlayerPercentileBand")]
            public long PlayerPercentileBand { get; private set; }

            [JsonProperty("Bonus")]
            public long Bonus { get; private set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class TopTierInfo
        {
            internal TopTierInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("Bonus")]
            public string Bonus { get; private set; }
        }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CommunityGoalEvent> CommunityGoalEvent;

        internal void InvokeCommunityGoalEvent(CommunityGoalEvent arg)
        {
            CommunityGoalEvent?.Invoke(this, arg);
        }
    }
}