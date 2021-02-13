using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class WingLeaveEvent : EventBase
    {
        internal WingLeaveEvent() { }

        [JsonProperty("event")]
        public string Event { get; private set; }
    }

    public partial class WingLeaveEvent
    {
        public static WingLeaveEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WingLeaveEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<WingLeaveEvent> WingLeaveEvent;

        internal void InvokeWingLeaveEvent(WingLeaveEvent arg)
        {
            WingLeaveEvent?.Invoke(this, arg);
        }
    }
}