using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class MarketEvent : EventBase
    {
        internal MarketEvent() { }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }
    }

    public partial class MarketEvent
    {
        public static MarketEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MarketEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MarketEvent> MarketEvent;

        internal void InvokeMarketEvent(MarketEvent arg)
        {
            MarketEvent?.Invoke(this, arg);
        }
    }
}