using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class FssAllBodiesFoundEvent : EventBase
    {
        internal FssAllBodiesFoundEvent()
        {
        }

        [JsonProperty("SystemName")] public string SystemName { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class FssAllBodiesFoundEvent
    {
        public static FssAllBodiesFoundEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FssAllBodiesFoundEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FssAllBodiesFoundEvent> FssAllBodiesFoundEvent;

        internal void InvokeFssAllBodiesFoundEvent(FssAllBodiesFoundEvent arg)
        {
            FssAllBodiesFoundEvent?.Invoke(this, arg);
        }
    }
}