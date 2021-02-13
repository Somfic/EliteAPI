using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class QuitACrewEvent : EventBase
    {
        internal QuitACrewEvent() { }

        [JsonProperty("Captain")]
        public string Captain { get; private set; }
    }

    public partial class QuitACrewEvent
    {
        public static QuitACrewEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<QuitACrewEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<QuitACrewEvent> QuitACrewEvent;

        internal void InvokeQuitACrewEvent(QuitACrewEvent arg)
        {
            QuitACrewEvent?.Invoke(this, arg);
        }
    }
}