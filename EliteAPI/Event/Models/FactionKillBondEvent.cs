
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FactionKillBondEvent : EventBase
    {
        internal FactionKillBondEvent() { }

        [JsonProperty("Reward")]
        public long Reward { get; private set; }

        [JsonProperty("AwardingFaction")]
        public string AwardingFaction { get; private set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; private set; }
    }

    public partial class FactionKillBondEvent
    {
        public static FactionKillBondEvent FromJson(string json) => JsonConvert.DeserializeObject<FactionKillBondEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FactionKillBondEvent> FactionKillBondEvent;
        internal void InvokeFactionKillBondEvent(FactionKillBondEvent arg) => FactionKillBondEvent?.Invoke(this, arg);
    }
}
