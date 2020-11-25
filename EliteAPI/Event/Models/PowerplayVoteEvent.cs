
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class PowerplayVoteEvent : EventBase
    {
        internal PowerplayVoteEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }

        [JsonProperty("Votes")]
        public long Votes { get; private set; }

        [JsonProperty("")]
        public long Empty { get; private set; }
    }

    public partial class PowerplayVoteEvent
    {
        public static PowerplayVoteEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayVoteEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<PowerplayVoteEvent> PowerplayVoteEvent;
        internal void InvokePowerplayVoteEvent(PowerplayVoteEvent arg) => PowerplayVoteEvent?.Invoke(this, arg);
    }
}
