using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class TouchdownEvent : EventBase<TouchdownEvent>
    {
        internal TouchdownEvent() { }

        [JsonProperty("PlayerControlled")]
        public bool IsPlayerControlled { get; private set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; private set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; private set; }
        
        [JsonProperty("StarSystem")] 
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("Body")] 
        public string Body { get; private set; }

        [JsonProperty("BodyID")]
        public string BodyId { get; private set; }

        [JsonProperty("OnPlanet")] 
        public bool IsOnPlanet { get; private set; }

        [JsonProperty("OnStation")] 
        public bool IsOnStation { get; private set; }

        [JsonProperty("NearestDestination")]
        public string NearestDestination { get; private set; }

        [JsonProperty("NearestDestination_Localised")]
        public string NearestDestinationLocalised { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<TouchdownEvent> TouchdownEvent;

        internal void InvokeTouchdownEvent(TouchdownEvent arg)
        {
            TouchdownEvent?.Invoke(this, arg);
        }
    }
}