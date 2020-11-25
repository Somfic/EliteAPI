
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class NpcCrewPaidWageEvent : EventBase
    {
        internal NpcCrewPaidWageEvent() { }

        [JsonProperty("NpcCrewName")]
        public string NpcCrewName { get; private set; }

        [JsonProperty("NpcCrewId")]
        public long NpcCrewId { get; private set; }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }
    }

    public partial class NpcCrewPaidWageEvent
    {
        public static NpcCrewPaidWageEvent FromJson(string json) => JsonConvert.DeserializeObject<NpcCrewPaidWageEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<NpcCrewPaidWageEvent> NpcCrewPaidWageEvent;
        internal void InvokeNpcCrewPaidWageEvent(NpcCrewPaidWageEvent arg) => NpcCrewPaidWageEvent?.Invoke(this, arg);
    }
}
