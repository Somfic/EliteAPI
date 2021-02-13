using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class MissionFailedEvent : EventBase
    {
        internal MissionFailedEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("MissionID")]
        public string MissionId { get; private set; }
    }

    public partial class MissionFailedEvent
    {
        public static MissionFailedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionFailedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MissionFailedEvent> MissionFailedEvent;

        internal void InvokeMissionFailedEvent(MissionFailedEvent arg)
        {
            MissionFailedEvent?.Invoke(this, arg);
        }
    }
}