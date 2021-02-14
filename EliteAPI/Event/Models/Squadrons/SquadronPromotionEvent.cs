using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SquadronPromotionEvent : EventBase<SquadronPromotionEvent>
    {
        internal SquadronPromotionEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; private set; }

        [JsonProperty("OldRank")]
        public int OldRank { get; private set; }

        [JsonProperty("NewRank")]
        public int NewRank { get; private set; }
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