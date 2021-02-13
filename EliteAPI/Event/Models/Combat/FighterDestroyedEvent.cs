using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class FighterDestroyedEvent : EventBase
    {
        internal FighterDestroyedEvent() { }

        [JsonProperty("ID")]
        public string Id { get; private set; }
    }

    public partial class FighterDestroyedEvent
    {
        public static FighterDestroyedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FighterDestroyedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FighterDestroyedEvent> FighterDestroyedEvent;

        internal void InvokeFighterDestroyedEvent(FighterDestroyedEvent arg)
        {
            FighterDestroyedEvent?.Invoke(this, arg);
        }
    }
}