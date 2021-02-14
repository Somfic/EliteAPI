using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class OutfittingEvent : EventBase<OutfittingEvent>
    {
        internal OutfittingEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<OutfittingEvent> OutfittingEvent;

    }
}