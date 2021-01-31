using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class ScientificResearchEvent : EventBase
    {
        internal ScientificResearchEvent() { }

        [JsonProperty("MarketID")]
        public string MarketId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }

    public partial class ScientificResearchEvent
    {
        public static ScientificResearchEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ScientificResearchEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ScientificResearchEvent> ScientificResearchEvent;

        internal void InvokeScientificResearchEvent(ScientificResearchEvent arg)
        {
            ScientificResearchEvent?.Invoke(this, arg);
        }
    }
}