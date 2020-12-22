using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class FssDiscoveryScanEvent : EventBase
    {
        internal FssDiscoveryScanEvent()
        {
        }

        [JsonProperty("Progress")] public double Progress { get; private set; }

        [JsonProperty("BodyCount")] public long BodyCount { get; private set; }

        [JsonProperty("NonBodyCount")] public long NonBodyCount { get; private set; }
    }

    public partial class FssDiscoveryScanEvent
    {
        public static FssDiscoveryScanEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FssDiscoveryScanEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FssDiscoveryScanEvent> FssDiscoveryScanEvent;

        internal void InvokeFssDiscoveryScanEvent(FssDiscoveryScanEvent arg)
        {
            FssDiscoveryScanEvent?.Invoke(this, arg);
        }
    }
}