using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SetUserShipNameEvent : EventBase<SetUserShipNameEvent>
    {
        internal SetUserShipNameEvent() { }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; private set; }

        [JsonProperty("UserShipName")]
        public string UserShipName { get; private set; }

        [JsonProperty("UserShipId")]
        public string UserShipId { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SetUserShipNameEvent> SetUserShipNameEvent;

    }
}