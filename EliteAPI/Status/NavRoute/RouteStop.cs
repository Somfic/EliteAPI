using System.Collections.Generic;

using Newtonsoft.Json;

namespace EliteAPI.Status.NavRoute
{
    /// <summary>
    /// Container class for a waypoint on the route
    /// </summary>
    public class RouteStop
    {
        internal RouteStop() { }

        /// <summary>
        /// The name of the star system
        /// </summary>
        [JsonProperty("StarSystem")]
        public string System { get; init; }

        /// <summary>
        /// The address of the star system
        /// </summary>
        [JsonProperty("SystemAddress")]
        public string Address { get; init; }

        /// <summary>
        /// The position of the star system
        /// </summary>
        [JsonProperty("StarPos")]
        public IReadOnlyList<double> Position { get; init; }

        /// <summary>
        /// The class of the star system's main star
        /// </summary>
        [JsonProperty("StarClass")]
        public string Class { get; init; }
    }
}