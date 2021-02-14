using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class NpcCrewRankEvent : EventBase<NpcCrewRankEvent>
    {
        internal NpcCrewRankEvent() { }

        [JsonProperty("NpcCrewId")]
        public string CrewId { get; private set; }

        [JsonProperty("NpcCrewName")]
        public string CrewName { get; private set; }

        [JsonProperty("RankCombat")]
        public int RankCombat { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<NpcCrewRankEvent> NpcCrewRankEvent;

    }
}