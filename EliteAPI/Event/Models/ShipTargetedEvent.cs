using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class ShipTargetedEvent : EventBase
    {
        internal ShipTargetedEvent()
        {
        }

        [JsonProperty("TargetLocked")] public bool TargetLocked { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ScanStage")] public long ScanStage { get; private set; }

        [JsonProperty("PilotName")] public string PilotName { get; private set; }

        [JsonProperty("PilotName_Localised")] public string PilotNameLocalised { get; private set; }

        [JsonProperty("PilotRank")] public string PilotRank { get; private set; }

        [JsonProperty("ShieldHealth")] public double ShieldHealth { get; private set; }

        [JsonProperty("HullHealth")] public double HullHealth { get; private set; }
    }

    public partial class ShipTargetedEvent
    {
        public static ShipTargetedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipTargetedEvent>(json);
        }
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