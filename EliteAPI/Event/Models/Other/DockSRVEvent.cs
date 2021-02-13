using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class DockSrvEvent : EventBase
    {
        internal DockSrvEvent() { }

        [JsonProperty("ID")]
        public string Id { get; private set; }
    }

    public partial class DockSrvEvent
    {
        public static DockSrvEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockSrvEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DockSrvEvent> DockSrvEvent;

        internal void InvokeDockSrvEvent(DockSrvEvent arg)
        {
            DockSrvEvent?.Invoke(this, arg);
        }
    }
}