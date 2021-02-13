using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class MissionsEvent : EventBase
    {
        internal MissionsEvent() { }

        [JsonProperty("Active")]
        public IReadOnlyList<MissionInfo> Active { get; private set; }

        [JsonProperty("Failed")]
        public IReadOnlyList<MissionInfo> Failed { get; private set; }

        [JsonProperty("Complete")]
        public IReadOnlyList<MissionInfo> Complete { get; private set; }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class MissionInfo
        {
            internal MissionInfo()
            {
                
            }

            [JsonProperty("MissionID")]
            public string MissionId { get; private set; }
            
            [JsonProperty("Name")]
            public string Name { get; private set; }
            
            [JsonProperty("PassengerMission")]
            public bool IsPassengerMission { get; private set; }
            
            [JsonProperty("Expires")]
            public long Expires { get; private set; }
        }
    }

    public partial class MissionsEvent
    {
        public static MissionsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionsEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MissionsEvent> MissionsEvent;

        internal void InvokeMissionsEvent(MissionsEvent arg)
        {
            MissionsEvent?.Invoke(this, arg);
        }
    }
}