
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CrewAssignEvent : EventBase
    {
        internal CrewAssignEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; private set; }

        [JsonProperty("Role")]
        public string Role { get; private set; }
    }

    public partial class CrewAssignEvent
    {
        public static CrewAssignEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewAssignEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CrewAssignEvent> CrewAssignEvent;
        internal void InvokeCrewAssignEvent(CrewAssignEvent arg) => CrewAssignEvent?.Invoke(this, arg);
    }
}
