
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ApproachBodyEvent : EventBase
    {
        internal ApproachBodyEvent() { }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("Body")]
        public string Body { get; private set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; private set; }
    }

    public partial class ApproachBodyEvent
    {
        public static ApproachBodyEvent FromJson(string json) => JsonConvert.DeserializeObject<ApproachBodyEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ApproachBodyEvent> ApproachBodyEvent;
        internal void InvokeApproachBodyEvent(ApproachBodyEvent arg) => ApproachBodyEvent?.Invoke(this, arg);
    }
}
