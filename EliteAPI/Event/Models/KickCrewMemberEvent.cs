
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class KickCrewMemberEvent : EventBase
    {
        internal KickCrewMemberEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; private set; }
    }

    public partial class KickCrewMemberEvent
    {
        public static KickCrewMemberEvent FromJson(string json) => JsonConvert.DeserializeObject<KickCrewMemberEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<KickCrewMemberEvent> KickCrewMemberEvent;
        internal void InvokeKickCrewMemberEvent(KickCrewMemberEvent arg) => KickCrewMemberEvent?.Invoke(this, arg);
    }
}
