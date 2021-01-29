using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class LoadGameEvent : EventBase
    {
        internal LoadGameEvent() { }

        [JsonProperty("FID")]
        public string Fid { get; private set; }

        [JsonProperty("Commander")]
        public string Commander { get; private set; }

        [JsonProperty("Horizons")]
        public bool Horizons { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; private set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; private set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; private set; }

        [JsonProperty("FuelCapacity")]
        public double FuelCapacity { get; private set; }

        [JsonProperty("GameMode")]
        public string GameMode { get; private set; }

        [JsonProperty("Credits")]
        public long Credits { get; private set; }

        [JsonProperty("Loan")]
        public long Loan { get; private set; }
    }

    public partial class LoadGameEvent
    {
        public static LoadGameEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LoadGameEvent>(json);
        }
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