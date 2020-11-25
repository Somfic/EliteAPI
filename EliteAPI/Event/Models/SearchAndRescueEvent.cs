
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SearchAndRescueEvent : EventBase
    {
        internal SearchAndRescueEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Reward")]
        public long Reward { get; private set; }
    }

    public partial class SearchAndRescueEvent
    {
        public static SearchAndRescueEvent FromJson(string json) => JsonConvert.DeserializeObject<SearchAndRescueEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SearchAndRescueEvent> SearchAndRescueEvent;
        internal void InvokeSearchAndRescueEvent(SearchAndRescueEvent arg) => SearchAndRescueEvent?.Invoke(this, arg);
    }
}
