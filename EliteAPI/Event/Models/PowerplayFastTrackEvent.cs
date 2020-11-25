
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PowerplayFastTrackEvent : EventBase
    {
        internal PowerplayFastTrackEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

    public partial class PowerplayFastTrackEvent
    {
        public static PowerplayFastTrackEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayFastTrackEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PowerplayFastTrackEvent> PowerplayFastTrackEvent;
        internal void InvokePowerplayFastTrackEvent(PowerplayFastTrackEvent arg) => PowerplayFastTrackEvent?.Invoke(this, arg);
    }
}
