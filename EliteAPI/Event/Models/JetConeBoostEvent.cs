
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class JetConeBoostEvent : EventBase
    {
        internal JetConeBoostEvent() { }

        [JsonProperty("BoostValue")]
        public double BoostValue { get; private set; }
    }

    public partial class JetConeBoostEvent
    {
        public static JetConeBoostEvent FromJson(string json) => JsonConvert.DeserializeObject<JetConeBoostEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<JetConeBoostEvent> JetConeBoostEvent;
        internal void InvokeJetConeBoostEvent(JetConeBoostEvent arg) => JetConeBoostEvent?.Invoke(this, arg);
    }
}
