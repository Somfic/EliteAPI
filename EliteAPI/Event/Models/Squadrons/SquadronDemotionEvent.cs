using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class SquadronDemotionEvent : EventBase
    {
        internal SquadronDemotionEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; private set; }

        [JsonProperty("OldRank")]
        public int OldRank { get; private set; }

        [JsonProperty("NewRank")]
        public int NewRank { get; private set; }
    }

    public partial class SquadronDemotionEvent
    {
        public static SquadronDemotionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SquadronDemotionEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SquadronDemotionEvent> SquadronDemotionEvent;

        internal void InvokeSquadronDemotionEvent(SquadronDemotionEvent arg)
        {
            SquadronDemotionEvent?.Invoke(this, arg);
        }
    }
}