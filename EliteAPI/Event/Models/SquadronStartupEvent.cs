
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SquadronStartupEvent : EventBase
    {
        internal SquadronStartupEvent() { }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; private set; }

        [JsonProperty("CurrentRank")]
        public long CurrentRank { get; private set; }
    }

    public partial class SquadronStartupEvent
    {
        public static SquadronStartupEvent FromJson(string json) => JsonConvert.DeserializeObject<SquadronStartupEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SquadronStartupEvent> SquadronStartupEvent;
        internal void InvokeSquadronStartupEvent(SquadronStartupEvent arg) => SquadronStartupEvent?.Invoke(this, arg);
    }
}
