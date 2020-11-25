
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CrewLaunchFighterEvent : EventBase
    {
        internal CrewLaunchFighterEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }
    }

    public partial class CrewLaunchFighterEvent
    {
        public static CrewLaunchFighterEvent FromJson(string json) => JsonConvert.DeserializeObject<CrewLaunchFighterEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CrewLaunchFighterEvent> CrewLaunchFighterEvent;
        internal void InvokeCrewLaunchFighterEvent(CrewLaunchFighterEvent arg) => CrewLaunchFighterEvent?.Invoke(this, arg);
    }
}
