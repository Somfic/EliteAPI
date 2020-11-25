
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CrimeVictimEvent : EventBase
    {
        internal CrimeVictimEvent() { }

        [JsonProperty("Offender")]
        public string Offender { get; private set; }

        [JsonProperty("CrimeType")]
        public string CrimeType { get; private set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; private set; }
    }

    public partial class CrimeVictimEvent
    {
        public static CrimeVictimEvent FromJson(string json) => JsonConvert.DeserializeObject<CrimeVictimEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CrimeVictimEvent> CrimeVictimEvent;
        internal void InvokeCrimeVictimEvent(CrimeVictimEvent arg) => CrimeVictimEvent?.Invoke(this, arg);
    }
}
