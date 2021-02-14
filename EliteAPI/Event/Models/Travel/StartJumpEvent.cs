using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class StartJumpEvent : EventBase<StartJumpEvent>
    {
        internal StartJumpEvent() { }

        [JsonProperty("JumpType")]
        public string JumpType { get; private set; }
        
        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }
        
        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }
        
        [JsonProperty("StarClass")]
        public string StarClass { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<StartJumpEvent> StartJumpEvent;

    }
}