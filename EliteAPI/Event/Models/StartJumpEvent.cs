using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class StartJumpEvent : EventBase
    {
        internal StartJumpEvent()
        {
        }

        [JsonProperty("JumpType")] public string JumpType { get; private set; }
    }

    public partial class StartJumpEvent
    {
        public static StartJumpEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<StartJumpEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<StartJumpEvent> StartJumpEvent;

        internal void InvokeStartJumpEvent(StartJumpEvent arg)
        {
            StartJumpEvent?.Invoke(this, arg);
        }
    }
}