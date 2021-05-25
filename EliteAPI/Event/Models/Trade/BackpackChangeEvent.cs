using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Status.Backpack;
using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class BackpackChangeEvent : EventBase<BackpackChangeEvent>
    {
        internal BackpackChangeEvent() { }

        [JsonProperty("Added")]
        public IReadOnlyList<BackpackItem> Added { get; private set; }

        [JsonProperty("Removed")]
        public IReadOnlyList<BackpackItem> Removed { get; private set; }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<BackpackChangeEvent> BackpackChangeEvent;

        internal void InvokeBackpackChangeEvent(BackpackChangeEvent arg)
        {
            BackpackChangeEvent?.Invoke(this, arg);
        }
    }
}