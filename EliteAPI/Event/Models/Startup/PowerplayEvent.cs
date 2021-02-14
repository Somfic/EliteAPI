using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PowerplayEvent : EventBase<PowerplayEvent>
    {
        internal PowerplayEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Rank")]
        public long Rank { get; private set; }

        [JsonProperty("Merits")]
        public long Merits { get; private set; }

        [JsonProperty("Votes")]
        public long Votes { get; private set; }

        [JsonProperty("TimePledged")]
        public long TimePledged { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayEvent> PowerplayEvent;

    }
}