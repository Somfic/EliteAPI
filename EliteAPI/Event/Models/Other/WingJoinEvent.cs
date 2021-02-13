using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class WingJoinEvent : EventBase
    {
        internal WingJoinEvent() { }

        [JsonProperty("Others")]
        public IReadOnlyList<string> Others { get; private set; }
    }

    public partial class WingJoinEvent
    {
        public static WingJoinEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WingJoinEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<WingJoinEvent> WingJoinEvent;

        internal void InvokeWingJoinEvent(WingJoinEvent arg)
        {
            WingJoinEvent?.Invoke(this, arg);
        }
    }
}