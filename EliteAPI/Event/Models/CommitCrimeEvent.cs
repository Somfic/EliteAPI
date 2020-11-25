
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CommitCrimeEvent : EventBase
    {
        internal CommitCrimeEvent() { }

        [JsonProperty("CrimeType")]
        public string CrimeType { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("Fine")]
        public long Fine { get; private set; }
    }

    public partial class CommitCrimeEvent
    {
        public static CommitCrimeEvent FromJson(string json) => JsonConvert.DeserializeObject<CommitCrimeEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CommitCrimeEvent> CommitCrimeEvent;
        internal void InvokeCommitCrimeEvent(CommitCrimeEvent arg) => CommitCrimeEvent?.Invoke(this, arg);
    }
}
