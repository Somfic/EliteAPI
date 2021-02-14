using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class FssSignalDiscoveredEvent : EventBase<FssSignalDiscoveredEvent>
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

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FssSignalDiscoveredEvent> FssSignalDiscoveredEvent;

    }
}