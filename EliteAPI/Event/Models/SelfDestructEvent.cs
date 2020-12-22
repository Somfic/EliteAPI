using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class SelfDestructEvent : EventBase
    {
        internal SelfDestructEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class SelfDestructEvent
    {
        public static SelfDestructEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SelfDestructEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SelfDestructEvent> SelfDestructEvent;

        internal void InvokeSelfDestructEvent(SelfDestructEvent arg)
        {
            SelfDestructEvent?.Invoke(this, arg);
        }
    }
}