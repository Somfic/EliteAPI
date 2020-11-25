
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class JetConeDamageEvent : EventBase
    {
        internal JetConeDamageEvent() { }

        [JsonProperty("Module")]
        public string Module { get; private set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; private set; }
    }

    public partial class JetConeDamageEvent
    {
        public static JetConeDamageEvent FromJson(string json) => JsonConvert.DeserializeObject<JetConeDamageEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<JetConeDamageEvent> JetConeDamageEvent;
        internal void InvokeJetConeDamageEvent(JetConeDamageEvent arg) => JetConeDamageEvent?.Invoke(this, arg);
    }
}
