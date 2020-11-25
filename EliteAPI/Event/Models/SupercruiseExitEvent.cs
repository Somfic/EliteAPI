
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class SupercruiseExitEvent : EventBase
    {
        internal SupercruiseExitEvent() { }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("Body")]
        public string Body { get; private set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; private set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; private set; }
    }

    public partial class SupercruiseExitEvent
    {
        public static SupercruiseExitEvent FromJson(string json) => JsonConvert.DeserializeObject<SupercruiseExitEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<SupercruiseExitEvent> SupercruiseExitEvent;
        internal void InvokeSupercruiseExitEvent(SupercruiseExitEvent arg) => SupercruiseExitEvent?.Invoke(this, arg);
    }
}
