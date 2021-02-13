using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class EngineerProgressEvent : EventBase
    {
        internal EngineerProgressEvent() { }

        [JsonProperty("Engineers")]
        public IReadOnlyList<Engineer> Engineers { get; private set; }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class Engineer
    {
        internal Engineer() { }

        [JsonProperty("Engineer")]
        public string EngineerEngineer { get; private set; }

        [JsonProperty("EngineerID")]
        public long EngineerId { get; private set; }

        [JsonProperty("Progress")]
        public string Progress { get; private set; }

        [JsonProperty("RankProgress", NullValueHandling = NullValueHandling.Ignore)]
        public long? RankProgress { get; private set; }

        [JsonProperty("Rank", NullValueHandling = NullValueHandling.Ignore)]
        public long? Rank { get; private set; }

        ///feiohjriohqoiqrqioqioqewoodbwqdqidijpfqvopojfewnfnqoqp2opo2po22o2o2o
    }

    public partial class EngineerProgressEvent
    {
        public static EngineerProgressEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EngineerProgressEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EngineerProgressEvent> EngineerProgressEvent;

        internal void InvokeEngineerProgressEvent(EngineerProgressEvent arg)
        {
            EngineerProgressEvent?.Invoke(this, arg);
        }
    }
}