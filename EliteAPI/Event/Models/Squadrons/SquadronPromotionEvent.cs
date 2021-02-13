using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class SquadronPromotionEvent : EventBase
    {
        internal SquadronPromotionEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; private set; }

        [JsonProperty("OldRank")]
        public int OldRank { get; private set; }

        [JsonProperty("NewRank")]
        public int NewRank { get; private set; }
    }

    public partial class SquadronPromotionEvent
    {
        public static SquadronPromotionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SquadronPromotionEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SquadronPromotionEvent> SquadronPromotionEvent;

        internal void InvokeSquadronPromotionEvent(SquadronPromotionEvent arg)
        {
            SquadronPromotionEvent?.Invoke(this, arg);
        }
    }
}