
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PowerplayEvent : EventBase
    {
        internal PowerplayEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Rank")]
        public long Rank { get; private set; }

        [JsonProperty("Merits")]
        public long Merits { get; private set; }

        [JsonProperty("Votes")]
        public long Votes { get; private set; }

        [JsonProperty("TimePledged")]
        public long TimePledged { get; private set; }
    }

    public partial class PowerplayEvent
    {
        public static PowerplayEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PowerplayEvent> PowerplayEvent;
        internal void InvokePowerplayEvent(PowerplayEvent arg) => PowerplayEvent?.Invoke(this, arg);
    }
}
