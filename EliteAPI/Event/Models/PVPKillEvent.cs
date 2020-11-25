
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PvpKillEvent : EventBase
    {
        internal PvpKillEvent() { }

        [JsonProperty("Victim")]
        public string Victim { get; private set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; private set; }
    }

    public partial class PvpKillEvent
    {
        public static PvpKillEvent FromJson(string json) => JsonConvert.DeserializeObject<PvpKillEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PvpKillEvent> PvpKillEvent;
        internal void InvokePvpKillEvent(PvpKillEvent arg) => PvpKillEvent?.Invoke(this, arg);
    }
}
