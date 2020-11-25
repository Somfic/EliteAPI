
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class EngineerProgressEvent : EventBase
    {
        internal EngineerProgressEvent() { }

        [JsonProperty("Engineers")]
        public IReadOnlyList<Engineer> Engineers { get; private set; }
    }

    public partial class Engineer
    {
        internal Engineer() { }

        [JsonProperty("Engineer")]
        public string EngineerEngineer { get; private set; }

        [JsonProperty("EngineerID")]
        public long EngineerId { get; private set; }

        [JsonProperty("Progress")]
        public string Progress { get; private set; }

        [JsonProperty("RankProgress", NullValueHandling = NullValueHandling.Ignore)]
        public long? RankProgress { get; private set; }

        [JsonProperty("Rank", NullValueHandling = NullValueHandling.Ignore)]
        public long? Rank { get; private set; }
    }

    public partial class EngineerProgressEvent
    {
        public static EngineerProgressEvent FromJson(string json) => JsonConvert.DeserializeObject<EngineerProgressEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<EngineerProgressEvent> EngineerProgressEvent;
        internal void InvokeEngineerProgressEvent(EngineerProgressEvent arg) => EngineerProgressEvent?.Invoke(this, arg);
    }
}
