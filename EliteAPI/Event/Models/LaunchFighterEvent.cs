
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class LaunchFighterEvent : EventBase
    {
        internal LaunchFighterEvent() { }

        [JsonProperty("Loadout")]
        public string Loadout { get; private set; }

        [JsonProperty("ID")]
        public long Id { get; private set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; private set; }
    }

    public partial class LaunchFighterEvent
    {
        public static LaunchFighterEvent FromJson(string json) => JsonConvert.DeserializeObject<LaunchFighterEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<LaunchFighterEvent> LaunchFighterEvent;
        internal void InvokeLaunchFighterEvent(LaunchFighterEvent arg) => LaunchFighterEvent?.Invoke(this, arg);
    }
}
