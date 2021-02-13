using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class HeatWarningEvent : EventBase
    {
        internal HeatWarningEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class HeatWarningEvent
    {
        public static HeatWarningEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<HeatWarningEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<HeatWarningEvent> HeatWarningEvent;

        internal void InvokeHeatWarningEvent(HeatWarningEvent arg)
        {
            HeatWarningEvent?.Invoke(this, arg);
        }
    }
}