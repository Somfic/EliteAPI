using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ShipyardNewEvent : EventBase<ShipyardNewEvent>
    {
        internal ShipyardNewEvent() { }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; private set; }

        [JsonProperty("NewShipID")]
        public string NewShipId { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShipyardNewEvent> ShipyardNewEvent;

    }
}