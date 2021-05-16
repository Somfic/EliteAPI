using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class LoadGameEvent : EventBase<LoadGameEvent>
    {
        internal LoadGameEvent() { }

        [JsonProperty("FID")]
        public string Fid { get; private set; }

        [JsonProperty("Commander")]
        public string Commander { get; private set; }

        [JsonProperty("Horizons")]
        public bool HasHorizons { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; private set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; private set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; private set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; private set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; private set; }

        [JsonProperty("FuelCapacity")]
        public double FuelCapacity { get; private set; }

        [JsonProperty("StartLanded")]
        public bool IsLanded { get; private set; }

        [JsonProperty("GameMode")]
        public string GameMode { get; private set; }

        [JsonProperty("Credits")]
        public long Credits { get; private set; }

        [JsonProperty("Loan")]
        public long Loan { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<LoadGameEvent> LoadGameEvent;

        internal void InvokeLoadGameEvent(LoadGameEvent arg)
        {
            LoadGameEvent?.Invoke(this, arg);
        }
    }
}