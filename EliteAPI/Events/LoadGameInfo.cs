using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class LoadGameInfo : EventBase
    {
        internal static LoadGameInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLoadGameEvent(JsonConvert.DeserializeObject<LoadGameInfo>(json, JsonSettings.Settings));

        [JsonProperty("FID")]
        public string Fid { get; internal set; }
        [JsonProperty("Commander")]
        public string Commander { get; internal set; }
        [JsonProperty("Horizons")]
        public bool Horizons { get; internal set; }
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }
        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; internal set; }
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }
        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }
        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; internal set; }
        [JsonProperty("FuelCapacity")]
        public double FuelCapacity { get; internal set; }
        [JsonProperty("GameMode")]
        public string GameMode { get; internal set; }
        [JsonProperty("Group")]
        public string Group { get; internal set; }
        [JsonProperty("Credits")]
        public long Credits { get; internal set; }
        [JsonProperty("Loan")]
        public long Loan { get; internal set; }
    }
}
