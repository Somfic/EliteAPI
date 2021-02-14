using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PromotionEvent : EventBase<PromotionEvent>
    {
        internal PromotionEvent() { }

        [JsonProperty("Empire")]
        public long Empire { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PromotionEvent> PromotionEvent;

        internal void InvokePromotionEvent(PromotionEvent arg)
        {
            PromotionEvent?.Invoke(this, arg);
        }
    }
}