using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
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
        public static PowerplayEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayEvent> PowerplayEvent;

        internal void InvokePowerplayEvent(PowerplayEvent arg)
        {
            PowerplayEvent?.Invoke(this, arg);
        }
    }
}