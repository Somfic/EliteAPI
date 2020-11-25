
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class UnderAttackEvent : EventBase
    {
        internal UnderAttackEvent() { }

        [JsonProperty("Target")]
        public string Target { get; private set; }
    }

    public partial class UnderAttackEvent
    {
        public static UnderAttackEvent FromJson(string json) => JsonConvert.DeserializeObject<UnderAttackEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<UnderAttackEvent> UnderAttackEvent;
        internal void InvokeUnderAttackEvent(UnderAttackEvent arg) => UnderAttackEvent?.Invoke(this, arg);
    }
}
