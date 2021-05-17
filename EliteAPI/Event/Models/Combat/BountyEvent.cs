using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class BountyEvent : EventBase<BountyEvent>
    {
        internal BountyEvent() { }

        [JsonProperty("Rewards")]
        public IReadOnlyList<BountryRewardInfo> Rewards { get; private set; }

        [JsonProperty("Target")]
        public string Target { get; private set; }

        [JsonProperty("Target_Localised")]
        public string TargetLocalised { get; private set; }

        [JsonProperty("TotalReward")]
        public long TotalReward { get; private set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; private set; }

        [JsonProperty("SharedWithOthers")]
        public long SharedWithOthers { get; private set; }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class BountryRewardInfo
        {
            internal BountryRewardInfo() { }

            [JsonProperty("Faction")]
            public string Faction { get; private set; }

            [JsonProperty("Reward")]
            public long Reward { get; private set; }
        }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<BountyEvent> BountyEvent;

        internal void InvokeBountyEvent(BountyEvent arg)
        {
            BountyEvent?.Invoke(this, arg);
        }
    }
}