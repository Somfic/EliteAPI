using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PvpKillEvent : EventBase<PvpKillEvent>
    {
        internal PvpKillEvent() { }

        [JsonProperty("Victim")]
        public string Victim { get; private set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PvpKillEvent> PvpKillEvent;

    }
}