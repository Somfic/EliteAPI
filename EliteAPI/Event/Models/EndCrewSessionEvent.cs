using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class EndCrewSessionEvent : EventBase
    {
        internal EndCrewSessionEvent()
        {
        }

        [JsonProperty("OnCrime")] public bool OnCrime { get; private set; }
    }

    public partial class EndCrewSessionEvent
    {
        public static EndCrewSessionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EndCrewSessionEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EndCrewSessionEvent> EndCrewSessionEvent;

        internal void InvokeEndCrewSessionEvent(EndCrewSessionEvent arg)
        {
            EndCrewSessionEvent?.Invoke(this, arg);
        }
    }
}