using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class BuyAmmoEvent : EventBase
    {
        internal BuyAmmoEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

    public partial class BuyAmmoEvent
    {
        public static BuyAmmoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BuyAmmoEvent>(json);
        }
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