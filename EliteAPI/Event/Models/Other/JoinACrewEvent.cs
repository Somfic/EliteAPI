using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class JoinACrewEvent : EventBase
    {
        internal JoinACrewEvent() { }

        [JsonProperty("Captain")]
        public string Captain { get; private set; }
    }

    public partial class JoinACrewEvent
    {
        public static JoinACrewEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JoinACrewEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<JoinACrewEvent> JoinACrewEvent;

        internal void InvokeJoinACrewEvent(JoinACrewEvent arg)
        {
            JoinACrewEvent?.Invoke(this, arg);
        }
    }
}