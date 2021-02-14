using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ShipTargetedEvent : EventBase<ShipTargetedEvent>
    {
        internal ShipTargetedEvent() { }

        [JsonProperty("TargetLocked")]
        public bool TargetLocked { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; private set; }

        [JsonProperty("ScanStage")]
        public long ScanStage { get; private set; }

        [JsonProperty("PilotName")]
        public string PilotName { get; private set; }

        [JsonProperty("PilotName_Localised")]
        public string PilotNameLocalised { get; private set; }

        [JsonProperty("PilotRank")]
        public string PilotRank { get; private set; }

        [JsonProperty("SquadronID")]
        public string SquadronId { get; private set; }

        [JsonProperty("ShieldHealth")]
        public double ShieldHealth { get; private set; }

        [JsonProperty("HullHealth")]
        public double HullHealth { get; private set; }

        [JsonProperty("LegalStatus")]
        public string LegalStatus { get; private set; }

        [JsonProperty("Faction")]
        public string Faction { get; private set; }

        [JsonProperty("Subsystem")]
        public string Subsystem { get; private set; }

        [JsonProperty("Subsystem_Localised")]
        public string SubsystemLocalised { get; private set; }

        [JsonProperty("SubsystemHealth")]
        public double SubsystemHealth { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ShipTargetedEvent> ShipTargetedEvent;

        internal void InvokeShipTargetedEvent(ShipTargetedEvent arg)
        {
            ShipTargetedEvent?.Invoke(this, arg);
        }
    }
}