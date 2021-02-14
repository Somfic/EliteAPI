using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CrimeVictimEvent : EventBase<CrimeVictimEvent>
    {
        internal CrimeVictimEvent() { }

        [JsonProperty("Offender")]
        public string Offender { get; private set; }

        [JsonProperty("CrimeType")]
        public string CrimeType { get; private set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrimeVictimEvent> CrimeVictimEvent;

    }
}