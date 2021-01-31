using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class SquadronDisbandedEvent : EventBase
    {
        internal SquadronDisbandedEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; internal set; }
    }

    public partial class SquadronDisbandedEvent
    {
        public static SquadronDisbandedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SquadronDisbandedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SquadronDisbandedEvent> SquadronDisbandedEvent;

        internal void InvokeSquadronDisbandedEvent(SquadronDisbandedEvent arg)
        {
            SquadronDisbandedEvent?.Invoke(this, arg);
        }
    }
}