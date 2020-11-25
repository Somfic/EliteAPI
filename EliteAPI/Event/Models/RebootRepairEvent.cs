
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class RebootRepairEvent : EventBase
    {
        internal RebootRepairEvent() { }

        [JsonProperty("Modules")]
        public IReadOnlyList<object> Modules { get; private set; }
    }

    public partial class RebootRepairEvent
    {
        public static RebootRepairEvent FromJson(string json) => JsonConvert.DeserializeObject<RebootRepairEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<RebootRepairEvent> RebootRepairEvent;
        internal void InvokeRebootRepairEvent(RebootRepairEvent arg) => RebootRepairEvent?.Invoke(this, arg);
    }
}
