using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class EjectCargoEvent : EventBase
    {
        internal EjectCargoEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Abandoned")]
        public bool Abandoned { get; private set; }
    }

    public partial class EjectCargoEvent
    {
        public static EjectCargoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EjectCargoEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EjectCargoEvent> EjectCargoEvent;

        internal void InvokeEjectCargoEvent(EjectCargoEvent arg)
        {
            EjectCargoEvent?.Invoke(this, arg);
        }
    }
}