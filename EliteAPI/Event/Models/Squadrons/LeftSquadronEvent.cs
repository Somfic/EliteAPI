using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class LeftSquadronEvent : EventBase
    {
        internal LeftSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; internal set; }
    }

    public partial class LeftSquadronEvent
    {
        public static LeftSquadronEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LeftSquadronEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<LeftSquadronEvent> LeftSquadronEvent;

        internal void InvokeLeftSquadronEvent(LeftSquadronEvent arg)
        {
            LeftSquadronEvent?.Invoke(this, arg);
        }
    }
}