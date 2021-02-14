using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PowerplayVoteEvent : EventBase<PowerplayVoteEvent>
    {
        internal PowerplayVoteEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Votes")]
        public long Votes { get; private set; }

        [JsonProperty("")]
        public long Empty { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayVoteEvent> PowerplayVoteEvent;

    }
}