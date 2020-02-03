using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class PassengersInfo : EventBase
    {
        internal PassengersInfo() { }

        /// <summary>
        /// A list of passenger records.
        /// </summary>
        [JsonProperty("Manifest")]
        public List<Manifest> Manifest { get; internal set; }

        internal static PassengersInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePassengersEvent(JsonConvert.DeserializeObject<PassengersInfo>(json, JsonSettings.Settings));
        }
    }
}