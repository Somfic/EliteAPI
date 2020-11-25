using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class FactionKillBondEvent : EventBase
    {
        internal FactionKillBondEvent()
        {
        }

        [JsonProperty("Reward")] public long Reward { get; private set; }

        [JsonProperty("AwardingFaction")] public string AwardingFaction { get; private set; }

        [JsonProperty("VictimFaction")] public string VictimFaction { get; private set; }
    }

    public partial class FactionKillBondEvent
    {
        public static FactionKillBondEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FactionKillBondEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FactionKillBondEvent> FactionKillBondEvent;

        internal void InvokeFactionKillBondEvent(FactionKillBondEvent arg)
        {
            FactionKillBondEvent?.Invoke(this, arg);
        }
    }
}