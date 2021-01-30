using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{


    public partial class SaaSignalsFoundEvent : EventBase
    {
        internal SaaSignalsFoundEvent() { }

        [JsonProperty("BodyName")]
        public string BodyName { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; private set; }

        [JsonProperty("Signals")]
        public IReadOnlyList<Signal> Signals { get; private set; }
    }

    public class Signal
    {
        internal Signal() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("Type_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string TypeLocalised { get; private set; }
    }

    public partial class SaaSignalsFoundEvent
    {
        public static SaaSignalsFoundEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SaaSignalsFoundEvent>(json);
        }
    }


}

namespace EliteAPI.Event.Handler
{

    public partial class EventHandler
    {
        public event EventHandler<SaaSignalsFoundEvent> SaaSignalsFoundEvent;
        internal void InvokeSaaSignalsFoundEvent(SaaSignalsFoundEvent arg)
        {
            SaaSignalsFoundEvent?.Invoke(this, arg);
        }
    }
}