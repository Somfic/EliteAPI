using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class MissionRedirectedEvent : EventBase
    {
        internal MissionRedirectedEvent() { }

        [JsonProperty("MissionID")]
        public string MissionId { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; private set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; private set; }

        [JsonProperty("OldDestinationStation")]
        public string OldDestinationStation { get; private set; }

        [JsonProperty("OldDestinationSystem")]
        public string OldDestinationSystem { get; private set; }
    }

    public partial class MissionRedirectedEvent
    {
        public static MissionRedirectedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionRedirectedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MissionRedirectedEvent> MissionRedirectedEvent;

        internal void InvokeMissionRedirectedEvent(MissionRedirectedEvent arg)
        {
            MissionRedirectedEvent?.Invoke(this, arg);
        }
    }
}