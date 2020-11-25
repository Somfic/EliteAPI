
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class EngineerApplyEvent : EventBase
    {
        internal EngineerApplyEvent() { }

        [JsonProperty("Engineer")]
        public string Engineer { get; private set; }

        [JsonProperty("Blueprint")]
        public string Blueprint { get; private set; }

        [JsonProperty("Level")]
        public long Level { get; private set; }
    }

    public partial class EngineerApplyEvent
    {
        public static EngineerApplyEvent FromJson(string json) => JsonConvert.DeserializeObject<EngineerApplyEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<EngineerApplyEvent> EngineerApplyEvent;
        internal void InvokeEngineerApplyEvent(EngineerApplyEvent arg) => EngineerApplyEvent?.Invoke(this, arg);
    }
}
