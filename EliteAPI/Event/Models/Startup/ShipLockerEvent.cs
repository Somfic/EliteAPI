using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ShipLockerEvent : EventBase<ShipLockerEvent>
    {
        internal ShipLockerEvent() { }

        [JsonProperty("Items")]
        public IReadOnlyList<ShipLockerMaterialInfo> Items { get; private set; }

        [JsonProperty("Components")]
        public IReadOnlyList<ShipLockerMaterialInfo> Components { get; private set; }
        
        [JsonProperty("Consumables")]
        public IReadOnlyList<ShipLockerMaterialInfo> Consumables { get; private set; }
        
        [JsonProperty("Data")]
        public IReadOnlyList<ShipLockerMaterialInfo> Data { get; private set; }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class ShipLockerMaterialInfo
        {
            internal ShipLockerMaterialInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("Name_Localised")]
            public string NameLocalised { get; private set; }

            [JsonProperty("OwnerID")]
            public string OwnerId { get; private set; }

            [JsonProperty("Count")]
            public long Count { get; private set; }
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShipLockerEvent> ShipLockerEvent;

        internal void InvokeShipLockerEvent(ShipLockerEvent arg)
        {
            ShipLockerEvent?.Invoke(this, arg);
        }
    }
}