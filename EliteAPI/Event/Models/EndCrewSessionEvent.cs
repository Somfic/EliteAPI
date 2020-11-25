
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class EndCrewSessionEvent : EventBase
    {
        internal EndCrewSessionEvent() { }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; private set; }
    }

    public partial class EndCrewSessionEvent
    {
        public static EndCrewSessionEvent FromJson(string json) => JsonConvert.DeserializeObject<EndCrewSessionEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<EndCrewSessionEvent> EndCrewSessionEvent;
        internal void InvokeEndCrewSessionEvent(EndCrewSessionEvent arg) => EndCrewSessionEvent?.Invoke(this, arg);
    }
}
