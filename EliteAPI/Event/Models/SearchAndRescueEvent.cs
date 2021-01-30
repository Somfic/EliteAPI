using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
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
        public static SearchAndRescueEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SearchAndRescueEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SearchAndRescueEvent> SearchAndRescueEvent;

        internal void InvokeSearchAndRescueEvent(SearchAndRescueEvent arg)
        {
            SearchAndRescueEvent?.Invoke(this, arg);
        }
    }
}