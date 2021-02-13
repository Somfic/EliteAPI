using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class SquadronStartupEvent : EventBase
    {
        internal SquadronStartupEvent() { }

        [JsonProperty("SquadronName")]
        public string SquadronName { get; private set; }

        [JsonProperty("CurrentRank")]
        public long CurrentRank { get; private set; }
    }

    public partial class SquadronStartupEvent
    {
        public static SquadronStartupEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SquadronStartupEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SquadronStartupEvent> SquadronStartupEvent;

        internal void InvokeSquadronStartupEvent(SquadronStartupEvent arg)
        {
            SquadronStartupEvent?.Invoke(this, arg);
        }
    }
}