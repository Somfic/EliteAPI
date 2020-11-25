
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MissionRedirectedEvent : EventBase
    {
        internal MissionRedirectedEvent() { }

        [JsonProperty("MissionID")]
        public long MissionId { get; private set; }

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
        public static MissionRedirectedEvent FromJson(string json) => JsonConvert.DeserializeObject<MissionRedirectedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MissionRedirectedEvent> MissionRedirectedEvent;
        internal void InvokeMissionRedirectedEvent(MissionRedirectedEvent arg) => MissionRedirectedEvent?.Invoke(this, arg);
    }
}
