using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class BuyAmmoEvent : EventBase<BuyAmmoEvent>
    {
        internal BuyAmmoEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<BuyAmmoEvent> BuyAmmoEvent;

        internal void InvokeBuyAmmoEvent(BuyAmmoEvent arg)
        {
            BuyAmmoEvent?.Invoke(this, arg);
        }
    }
}