using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class DiedEvent : EventBase
    {
        internal DiedEvent()
        {
        }

        [JsonProperty("KillerName")] public string KillerName { get; private set; }
        [JsonProperty("KillerShip")] public string KillerShip { get; private set; }
    }

    public partial class DiedEvent
    {
        public static DiedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DiedEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DiedEvent> DiedEvent;

        internal void InvokeDiedEvent(DiedEvent arg)
        {
            DiedEvent?.Invoke(this, arg);
        }
    }
}