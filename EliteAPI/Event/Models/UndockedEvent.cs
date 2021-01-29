using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class UndockedEvent : EventBase
    {
        internal UndockedEvent() { }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }
    }

    public partial class UndockedEvent
    {
        public static UndockedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UndockedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<UndockedEvent> UndockedEvent;

        internal void InvokeUndockedEvent(UndockedEvent arg)
        {
            UndockedEvent?.Invoke(this, arg);
        }
    }
}