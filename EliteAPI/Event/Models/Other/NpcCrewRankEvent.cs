using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class NpcCrewRankEvent : EventBase
    {
        internal NpcCrewRankEvent() { }

        [JsonProperty("NpcCrewId")]
        public string CrewId { get; private set; }

        [JsonProperty("NpcCrewName")]
        public string CrewName { get; private set; }

        [JsonProperty("RankCombat")]
        public int RankCombat { get; private set; }
    }

    public partial class NpcCrewRankEvent
    {
        public static NpcCrewRankEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<NpcCrewRankEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<NpcCrewRankEvent> NpcCrewRankEvent;

        internal void InvokeNpcCrewRankEvent(NpcCrewRankEvent arg)
        {
            NpcCrewRankEvent?.Invoke(this, arg);
        }
    }
}