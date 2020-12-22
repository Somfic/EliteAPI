using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class CommunityGoalDiscardEvent : EventBase
    {
        internal CommunityGoalDiscardEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("System")] public string System { get; private set; }
    }

    public partial class CommunityGoalDiscardEvent
    {
        public static CommunityGoalDiscardEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommunityGoalDiscardEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CommunityGoalDiscardEvent> CommunityGoalDiscardEvent;

        internal void InvokeCommunityGoalDiscardEvent(CommunityGoalDiscardEvent arg)
        {
            CommunityGoalDiscardEvent?.Invoke(this, arg);
        }
    }
}