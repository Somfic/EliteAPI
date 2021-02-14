using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ApproachSettlementEvent : EventBase<ApproachSettlementEvent>
    {
        internal ApproachSettlementEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("MarketID")]
        public string MarketId { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("BodyID")]
        public string BodyId { get; private set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; private set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; private set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ApproachSettlementEvent> ApproachSettlementEvent;

    }
}