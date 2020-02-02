using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MaterialsInfo : EventBase
    {
        [JsonProperty("Raw")]
        public List<Raw> Raw { get; internal set; }

        [JsonProperty("Manufactured")]
        public List<Encoded> Manufactured { get; internal set; }

        [JsonProperty("Encoded")]
        public List<Encoded> Encoded { get; internal set; }

        internal static MaterialsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMaterialsEvent(JsonConvert.DeserializeObject<MaterialsInfo>(json, JsonSettings.Settings));
        }
    }
}