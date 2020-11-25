
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class BuyAmmoEvent : EventBase
    {
        internal BuyAmmoEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

    public partial class BuyAmmoEvent
    {
        public static BuyAmmoEvent FromJson(string json) => JsonConvert.DeserializeObject<BuyAmmoEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<BuyAmmoEvent> BuyAmmoEvent;
        internal void InvokeBuyAmmoEvent(BuyAmmoEvent arg) => BuyAmmoEvent?.Invoke(this, arg);
    }
}
