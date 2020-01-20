using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PassengersInfo : EventBase
    {
        [JsonProperty("Manifest")]
        public List<Manifest> Manifest { get; internal set; }

        internal static PassengersInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePassengersEvent(JsonConvert.DeserializeObject<PassengersInfo>(json, JsonSettings.Settings));
        }
    }
}