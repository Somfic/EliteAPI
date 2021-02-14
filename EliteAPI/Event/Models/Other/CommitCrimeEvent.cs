using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CommitCrimeEvent : EventBase<CommitCrimeEvent>
    {
        internal CommitCrimeEvent() { }

        [JsonProperty("CrimeType")]
        public string CrimeType { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("Fine")]
        public long Fine { get; private set; }

        [JsonProperty("Victim")]
        public string Victim { get; private set; }

        [JsonProperty("Victim_Localised")]
        public string VictimLocalised { get; private set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CommitCrimeEvent> CommitCrimeEvent;

    }
}