using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class MissionAcceptedEvent : EventBase
    {
        internal MissionAcceptedEvent()
        {
        }

        [JsonProperty("Faction")] public string Faction { get; private set; }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("LocalisedName")] public string LocalisedName { get; private set; }

        [JsonProperty("TargetType")] public string TargetType { get; private set; }

        [JsonProperty("TargetType_Localised")] public string TargetTypeLocalised { get; private set; }

        [JsonProperty("TargetFaction")] public string TargetFaction { get; private set; }

        [JsonProperty("DestinationSystem")] public string DestinationSystem { get; private set; }

        [JsonProperty("DestinationStation")] public string DestinationStation { get; private set; }

        [JsonProperty("Target")] public string Target { get; private set; }

        [JsonProperty("Expiry")] public DateTimeOffset Expiry { get; private set; }

        [JsonProperty("Wing")] public bool Wing { get; private set; }

        [JsonProperty("Influence")] public string Influence { get; private set; }

        [JsonProperty("Reputation")] public string Reputation { get; private set; }

        [JsonProperty("Reward")] public long Reward { get; private set; }

        [JsonProperty("MissionID")] public long MissionId { get; private set; }
    }

    public partial class MissionAcceptedEvent
    {
        public static MissionAcceptedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionAcceptedEvent>(json);
        }
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