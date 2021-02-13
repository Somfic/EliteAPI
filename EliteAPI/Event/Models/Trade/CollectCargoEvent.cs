using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class CollectCargoEvent : EventBase
    {
        internal CollectCargoEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Stolen")]
        public bool Stolen { get; private set; }
    }

    public partial class CollectCargoEvent
    {
        public static CollectCargoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CollectCargoEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CollectCargoEvent> CollectCargoEvent;

        internal void InvokeCollectCargoEvent(CollectCargoEvent arg)
        {
            CollectCargoEvent?.Invoke(this, arg);
        }
    }
}