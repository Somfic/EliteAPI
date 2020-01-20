using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class EngineerProgressInfo : EventBase
    {
        [JsonProperty("Engineers")]
        public List<Engineer> Engineers { get; internal set; }

        internal static EngineerProgressInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeEngineerProgressEvent(JsonConvert.DeserializeObject<EngineerProgressInfo>(json, JsonSettings.Settings));
        }
    }
}