
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class StartJumpEvent : EventBase
    {
        internal StartJumpEvent() { }

        [JsonProperty("JumpType")]
        public string JumpType { get; private set; }
    }

    public partial class StartJumpEvent
    {
        public static StartJumpEvent FromJson(string json) => JsonConvert.DeserializeObject<StartJumpEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<StartJumpEvent> StartJumpEvent;
        internal void InvokeStartJumpEvent(StartJumpEvent arg) => StartJumpEvent?.Invoke(this, arg);
    }
}
