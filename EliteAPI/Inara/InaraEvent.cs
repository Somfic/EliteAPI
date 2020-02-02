using System;
using Newtonsoft.Json;

namespace EliteAPI.Inara
{
    public class InaraEvent
    {
        public InaraEvent(IInaraEventData eventData)
        {
            EventData = eventData;
        }
        [JsonProperty("eventName")]
        string EventName { get => EventData.GetType().Name; }
        [JsonProperty("eventTimestamp")]
        string EventTimestamp { get => DateTime.UtcNow.ToString("o"); }
        [JsonProperty("eventData")]
        IInaraEventData EventData { get; set; }
    }
}