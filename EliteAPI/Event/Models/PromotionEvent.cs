
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PromotionEvent : EventBase
    {
        internal PromotionEvent() { }

        [JsonProperty("Empire")]
        public long Empire { get; private set; }
    }

    public partial class PromotionEvent
    {
        public static PromotionEvent FromJson(string json) => JsonConvert.DeserializeObject<PromotionEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PromotionEvent> PromotionEvent;
        internal void InvokePromotionEvent(PromotionEvent arg) => PromotionEvent?.Invoke(this, arg);
    }
}
