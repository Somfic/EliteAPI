using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class FssSignalDiscoveredEvent : EventBase
    {
        internal FssSignalDiscoveredEvent() { }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("SignalName")]
        public string SignalName { get; private set; }
        
        [JsonProperty("SignalName_Localised")]
        public string SignalNameLocalised { get; private set; }
        
        [JsonProperty("IsStation")]
        public bool IsStation { get; private set; }
    }

    public partial class FssSignalDiscoveredEvent
    {
        public static FssSignalDiscoveredEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FssSignalDiscoveredEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FssSignalDiscoveredEvent> FssSignalDiscoveredEvent;

        internal void InvokeFssSignalDiscoveredEvent(FssSignalDiscoveredEvent arg)
        {
            FssSignalDiscoveredEvent?.Invoke(this, arg);
        }
    }
}