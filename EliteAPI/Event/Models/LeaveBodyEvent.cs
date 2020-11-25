
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class LeaveBodyEvent : EventBase
    {
        internal LeaveBodyEvent() { }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("Body")]
        public string Body { get; private set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; private set; }
    }

    public partial class LeaveBodyEvent
    {
        public static LeaveBodyEvent FromJson(string json) => JsonConvert.DeserializeObject<LeaveBodyEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<LeaveBodyEvent> LeaveBodyEvent;
        internal void InvokeLeaveBodyEvent(LeaveBodyEvent arg) => LeaveBodyEvent?.Invoke(this, arg);
    }
}
