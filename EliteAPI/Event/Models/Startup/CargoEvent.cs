using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CargoEvent : EventBase
    {
        internal CargoEvent() { }

        [JsonProperty("Vessel")]
        public string Vessel { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Inventory")]
        public IReadOnlyList<CargoInfo> Inventory { get; private set; }

        public class CargoInfo
        {
            internal CargoInfo() {}

            [JsonProperty("Name")]
            public string Name { get; private set; }
            
            [JsonProperty("Name_Localised")]
            public string NameLocalised { get; private set; }

            [JsonProperty("Count")]
            public int Count { get; private set; }

            [JsonProperty("Stolen")]
            public bool Stolen { get; private set; }

            [JsonProperty("MissionID")]
            public string MissionId { get; private set; }
        }
    }

    public partial class CargoEvent
    {
        public static CargoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CargoEvent>(json);
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