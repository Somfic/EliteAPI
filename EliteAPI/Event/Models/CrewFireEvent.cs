
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CrewFireEvent : EventBase
    {
        internal CrewFireEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }
    }

    public partial class CrewFireEvent
    {
        public static CrewFireEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewFireEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CrewFireEvent> CrewFireEvent;
        internal void InvokeCrewFireEvent(CrewFireEvent arg) => CrewFireEvent?.Invoke(this, arg);
    }
}
