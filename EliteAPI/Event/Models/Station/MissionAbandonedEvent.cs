using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class MissionAbandonedEvent : EventBase
    {
        internal MissionAbandonedEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("MissionID")]
        public string MissionId { get; private set; }
    }

    public partial class MissionAbandonedEvent
    {
        public static MissionAbandonedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionAbandonedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MissionAbandonedEvent> MissionAbandonedEvent;

        internal void InvokeMissionAbandonedEvent(MissionAbandonedEvent arg)
        {
            MissionAbandonedEvent?.Invoke(this, arg);
        }
    }
}