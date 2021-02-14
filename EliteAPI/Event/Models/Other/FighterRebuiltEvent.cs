using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class FighterRebuiltEvent : EventBase<FighterRebuiltEvent>
    {
        internal FighterRebuiltEvent() { }

        [JsonProperty("Loadout")]
        public string Loadout { get; private set; }

        [JsonProperty("ID")]
        public string Id { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FighterRebuiltEvent> FighterRebuiltEvent;

    }
}