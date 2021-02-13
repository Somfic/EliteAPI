using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class PowerplayFastTrackEvent : EventBase
    {
        internal PowerplayFastTrackEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

    public partial class PowerplayFastTrackEvent
    {
        public static PowerplayFastTrackEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayFastTrackEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayFastTrackEvent> PowerplayFastTrackEvent;

        internal void InvokePowerplayFastTrackEvent(PowerplayFastTrackEvent arg)
        {
            PowerplayFastTrackEvent?.Invoke(this, arg);
        }
    }
}