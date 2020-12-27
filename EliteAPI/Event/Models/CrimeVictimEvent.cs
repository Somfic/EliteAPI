using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CrimeVictimEvent : EventBase
    {
        internal CrimeVictimEvent()
        {
        }

        [JsonProperty("Offender")] public string Offender { get; private set; }

        [JsonProperty("CrimeType")] public string CrimeType { get; private set; }

        [JsonProperty("Bounty")] public long Bounty { get; private set; }
    }

    public partial class CrimeVictimEvent
    {
        public static CrimeVictimEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrimeVictimEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrimeVictimEvent> CrimeVictimEvent;

        internal void InvokeCrimeVictimEvent(CrimeVictimEvent arg)
        {
            CrimeVictimEvent?.Invoke(this, arg);
        }
    }
}