using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SearchAndRescueEvent : EventBase<SearchAndRescueEvent>
    {
        internal SearchAndRescueEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Reward")]
        public long Reward { get; private set; }
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