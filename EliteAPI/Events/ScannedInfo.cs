using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ScannedInfo : EventBase
    {
        internal static ScannedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeScannedEvent(JsonConvert.DeserializeObject<ScannedInfo>(json, JsonSettings.Settings));

        [JsonProperty("ScanType")]
        public string ScanType { get; internal set; }
    }
}
