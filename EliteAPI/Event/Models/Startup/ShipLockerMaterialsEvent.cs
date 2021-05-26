using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ShipLockerMaterialsEvent : EventBase<ShipLockerMaterialsEvent>
    {
        internal ShipLockerMaterialsEvent() { }

        [JsonProperty("Items")]
        public IReadOnlyList<ShipLockerMaterials> Items { get; private set; }


        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class ShipLockerMaterials
        {
            internal ShipLockerMaterials() { }

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
        public event EventHandler<ShipLockerMaterialsEvent> ShipLockerMaterialsEvent;

        internal void InvokeShipLockerMaterialsEvent(ShipLockerMaterialsEvent arg)
        {
            ShipLockerMaterialsEvent?.Invoke(this, arg);
        }
    }
}