
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SaaScanCompleteEvent : EventBase
    {
        internal SaaScanCompleteEvent() { }

        [JsonProperty("BodyName")]
        public string BodyName { get; private set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; private set; }

        [JsonProperty("ProbesUsed")]
        public long ProbesUsed { get; private set; }

        [JsonProperty("EfficiencyTarget")]
        public long EfficiencyTarget { get; private set; }
    }

    public partial class SaaScanCompleteEvent
    {
        public static SaaScanCompleteEvent FromJson(string json) => JsonConvert.DeserializeObject<SaaScanCompleteEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SaaScanCompleteEvent> SaaScanCompleteEvent;
        internal void InvokeSaaScanCompleteEvent(SaaScanCompleteEvent arg) => SaaScanCompleteEvent?.Invoke(this, arg);
    }
}
