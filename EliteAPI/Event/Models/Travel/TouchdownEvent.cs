using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class TouchdownEvent : EventBase
    {
        internal TouchdownEvent() { }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; private set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; private set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; private set; }
    }

    public partial class TouchdownEvent
    {
        public static TouchdownEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<TouchdownEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<TouchdownEvent> TouchdownEvent;

        internal void InvokeTouchdownEvent(TouchdownEvent arg)
        {
            TouchdownEvent?.Invoke(this, arg);
        }
    }
}