using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CargoEvent : EventBase<CargoEvent>
    {
        internal CargoEvent() { }

        [JsonProperty("Vessel")]
        public string Vessel { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Inventory")]
        public IReadOnlyList<CargoInfo> Inventory { get; private set; }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class CargoInfo
        {
            internal CargoInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("Name_Localised")]
            public string NameLocalised { get; private set; }

            [JsonProperty("Count")]
            public int Count { get; private set; }

            [JsonProperty("Stolen")]
            public bool IsStolen { get; private set; }

            [JsonProperty("MissionID", NullValueHandling = NullValueHandling.Ignore)]
            public string MissionId { get; private set; }
        }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CargoEvent> CargoEvent;

        internal void InvokeCargoEvent(CargoEvent arg)
        {
            CargoEvent?.Invoke(this, arg);
        }
    }
}