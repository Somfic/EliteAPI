using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
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
        public static CrewHireEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewHireEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrewHireEvent> CrewHireEvent;

        internal void InvokeCrewHireEvent(CrewHireEvent arg)
        {
            CrewHireEvent?.Invoke(this, arg);
        }
    }
}