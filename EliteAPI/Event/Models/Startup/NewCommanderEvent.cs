using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class NewCommanderEvent : EventBase
    {
        internal NewCommanderEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("FID")]
        public string FrontierId { get; private set; }

        [JsonProperty("Package")]
        public string StarterPackage { get; private set; }
    }

    public partial class NewCommanderEvent
    {
        public static NewCommanderEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<NewCommanderEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<NewCommanderEvent> NewCommanderEvent;

        internal void InvokeNewCommanderEvent(NewCommanderEvent arg)
        {
            NewCommanderEvent?.Invoke(this, arg);
        }
    }
}