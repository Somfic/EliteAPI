using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PowerplayFastTrackEvent : EventBase<PowerplayFastTrackEvent>
    {
        internal PowerplayFastTrackEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayFastTrackEvent> PowerplayFastTrackEvent;

    }
}