using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class ProgressEvent : EventBase
    {
        internal ProgressEvent() { }

        [JsonProperty("Combat")]
        public long Combat { get; private set; }

        [JsonProperty("Trade")]
        public long Trade { get; private set; }

        [JsonProperty("Explore")]
        public long Explore { get; private set; }

        [JsonProperty("Empire")]
        public long Empire { get; private set; }

        [JsonProperty("Federation")]
        public long Federation { get; private set; }

        [JsonProperty("CQC")]
        public long Cqc { get; private set; }
    }

    public partial class ProgressEvent
    {
        public static ProgressEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ProgressEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ProgressEvent> ProgressEvent;

        internal void InvokeProgressEvent(ProgressEvent arg)
        {
            ProgressEvent?.Invoke(this, arg);
        }
    }
}