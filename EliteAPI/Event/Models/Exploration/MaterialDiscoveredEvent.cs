using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class MaterialDiscoveredEvent : EventBase
    {
        internal MaterialDiscoveredEvent() { }

        [JsonProperty("Category")]
        public string Category { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("DiscoveryNumber")]
        public long DiscoveryNumber { get; private set; }
    }

    public partial class MaterialDiscoveredEvent
    {
        public static MaterialDiscoveredEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MaterialDiscoveredEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MaterialDiscoveredEvent> MaterialDiscoveredEvent;

        internal void InvokeMaterialDiscoveredEvent(MaterialDiscoveredEvent arg)
        {
            MaterialDiscoveredEvent?.Invoke(this, arg);
        }
    }
}