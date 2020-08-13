using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class PassengersEvent : EventBase
    {
        internal PassengersEvent() { }

        /// <summary>
        /// A list of passenger records.
        /// </summary>
        [JsonProperty("Manifest")]
        public List<PassengersManifest> Manifest { get; internal set; }

        
    }
}