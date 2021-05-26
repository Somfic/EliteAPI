using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CollectItemsEvent : EventBase<CollectItemsEvent>
    {
        internal CollectItemsEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("OwnerID")]
        public string OwnerId { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Stolen")]
        public bool IsStolen { get; private set; }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CollectItemsEvent> CollectItemsEvent;

        internal void InvokeCollectItemsEvent(CollectItemsEvent arg)
        {
            CollectItemsEvent?.Invoke(this, arg);
        }
    }
}