using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class MaterialsInfo : EventBase
    {
        internal static MaterialsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialsEvent(JsonConvert.DeserializeObject<MaterialsInfo>(json, JsonSettings.Settings));

        [JsonProperty("Raw")]
        public List<Raw> Raw { get; internal set; }
        [JsonProperty("Manufactured")]
        public List<Encoded> Manufactured { get; internal set; }
        [JsonProperty("Encoded")]
        public List<Encoded> Encoded { get; internal set; }
    }
}
