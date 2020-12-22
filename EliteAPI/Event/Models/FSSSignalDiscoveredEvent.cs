using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class FssSignalDiscoveredEvent : EventBase
    {
        internal FssSignalDiscoveredEvent()
        {
        }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("SignalName")] public string SignalName { get; private set; }
    }

    public partial class FssSignalDiscoveredEvent
    {
        public static FssSignalDiscoveredEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FssSignalDiscoveredEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FssSignalDiscoveredEvent> FssSignalDiscoveredEvent;

        internal void InvokeFssSignalDiscoveredEvent(FssSignalDiscoveredEvent arg)
        {
            FssSignalDiscoveredEvent?.Invoke(this, arg);
        }
    }
}