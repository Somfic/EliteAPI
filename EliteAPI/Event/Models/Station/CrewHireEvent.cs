using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CrewHireEvent : EventBase<CrewHireEvent>
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

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrewHireEvent> CrewHireEvent;

    }
}