using Newtonsoft.Json;

using System.Collections.Generic;

namespace EliteAPI.Status.NavRoute
{
    /// <summary>
    /// Container class for a waypoint on the route
    /// </summary>
    public class RouteStop
    {
        internal RouteStop()
        {
        }

        /// <summary>
        /// The name of the star system
        /// </summary>
        [JsonProperty("StarSystem")]
        public string System { get; private set; }

        /// <summary>
        /// The address of the star system
        /// </summary>
        [JsonProperty("SystemAddress")]
        public string Address { get; private set; }

        /// <summary>
        /// The position of the star system
        /// </summary>
        [JsonProperty("StarPos")]
        public IReadOnlyList<double> Position { get; private set; }

        /// <summary>
        /// The class of the star system's main star
        /// </summary>
        [JsonProperty("StarClass")]
        public string Class { get; private set; }
    }
}