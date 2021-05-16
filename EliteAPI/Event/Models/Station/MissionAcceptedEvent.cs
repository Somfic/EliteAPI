using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MissionAcceptedEvent : EventBase<MissionAcceptedEvent>
    {
        internal MissionAcceptedEvent() { }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("LocalisedName")]
        public string LocalisedName { get; private set; }

        [JsonProperty("TargetType")]
        public string TargetType { get; private set; }

        [JsonProperty("TargetType_Localised")]
        public string TargetTypeLocalised { get; private set; }

        [JsonProperty("TargetFaction")]
        public string TargetFaction { get; private set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; private set; }

        [JsonProperty("DestinationStation")]
        public string DestinationStation { get; private set; }

        [JsonProperty("Target")]
        public string Target { get; private set; }

        [JsonProperty("Expiry")]
        public DateTime Expiry { get; private set; }

        [JsonProperty("Wing")]
        public bool IsWing { get; private set; }

        [JsonProperty("Influence")]
        public string Influence { get; private set; }

        [JsonProperty("Reputation")]
        public string Reputation { get; private set; }

        [JsonProperty("Reward")]
        public long Reward { get; private set; }

        [JsonProperty("MissionID")]
        public string MissionId { get; private set; }
        
        [JsonProperty("KillCount")] 
        public int KillCount { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MissionAcceptedEvent> MissionAcceptedEvent;

        internal void InvokeMissionAcceptedEvent(MissionAcceptedEvent arg)
        {
            MissionAcceptedEvent?.Invoke(this, arg);
        }
    }
}
