using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class LeaveBodyEvent : EventBase
    {
        internal LeaveBodyEvent()
        {
        }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("Body")] public string Body { get; private set; }

        [JsonProperty("BodyID")] public long BodyId { get; private set; }
    }

    public partial class LeaveBodyEvent
    {
        public static LeaveBodyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LeaveBodyEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<LeaveBodyEvent> LeaveBodyEvent;

        internal void InvokeLeaveBodyEvent(LeaveBodyEvent arg)
        {
            LeaveBodyEvent?.Invoke(this, arg);
        }
    }
}