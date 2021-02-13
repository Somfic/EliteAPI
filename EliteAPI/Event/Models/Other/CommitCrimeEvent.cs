using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class CommitCrimeEvent : EventBase
    {
        internal CommitCrimeEvent() { }

        [JsonProperty("CrimeType")]
        public string CrimeType { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("Fine")]
        public long Fine { get; private set; }

        [JsonProperty("Victim")]
        public string Victim { get; private set; }

        [JsonProperty("Victim_Localised")]
        public string VictimLocalised { get; private set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; private set; }
    }

    public partial class CommitCrimeEvent
    {
        public static CommitCrimeEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommitCrimeEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CommitCrimeEvent> CommitCrimeEvent;

        internal void InvokeCommitCrimeEvent(CommitCrimeEvent arg)
        {
            CommitCrimeEvent?.Invoke(this, arg);
        }
    }
}