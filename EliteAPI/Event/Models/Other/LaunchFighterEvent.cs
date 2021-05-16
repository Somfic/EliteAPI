using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class LaunchFighterEvent : EventBase<LaunchFighterEvent>
    {
        internal LaunchFighterEvent() { }

        [JsonProperty("Loadout")]
        public string Loadout { get; private set; }

        [JsonProperty("ID")]
        public string Id { get; private set; }

        [JsonProperty("PlayerControlled")]
        public bool IsPlayerControlled { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<LaunchFighterEvent> LaunchFighterEvent;

        internal void InvokeLaunchFighterEvent(LaunchFighterEvent arg)
        {
            LaunchFighterEvent?.Invoke(this, arg);
        }
    }
}