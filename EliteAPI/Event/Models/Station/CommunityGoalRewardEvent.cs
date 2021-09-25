using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CommunityGoalRewardEvent : EventBase<CommunityGoalRewardEvent>
    {
        internal CommunityGoalRewardEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }

        [JsonProperty("Reward")]
        public long Reward { get; private set; }
        
        [JsonProperty("CGID")]
        public string Id { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CommunityGoalRewardEvent> CommunityGoalRewardEvent;

        internal void InvokeCommunityGoalRewardEvent(CommunityGoalRewardEvent arg)
        {
            CommunityGoalRewardEvent?.Invoke(this, arg);
        }
    }
}