using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class PowerplayJoinEvent : EventBase
    {
        internal PowerplayJoinEvent() { }

        [JsonProperty("Power")]
        public string Power { get; private set; }
    }

    public partial class PowerplayJoinEvent
    {
        public static PowerplayJoinEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayJoinEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayJoinEvent> PowerplayJoinEvent;

        internal void InvokePowerplayJoinEvent(PowerplayJoinEvent arg)
        {
            PowerplayJoinEvent?.Invoke(this, arg);
        }
    }
}