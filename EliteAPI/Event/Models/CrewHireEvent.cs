
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CrewHireEvent : EventBase
    {
        internal CrewHireEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; private set; }
    }

    public partial class CrewHireEvent
    {
        public static CrewHireEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewHireEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CrewHireEvent> CrewHireEvent;
        internal void InvokeCrewHireEvent(CrewHireEvent arg) => CrewHireEvent?.Invoke(this, arg);
    }
}
