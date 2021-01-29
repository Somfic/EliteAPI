using System.Collections.Generic;

using Newtonsoft.Json;

namespace EliteAPI.Status.NavRoute.Raw
{
    internal class RawNavRoute
    {
        [JsonProperty("Route")]
        public IReadOnlyList<RouteStop> Stops { get; set; }
    }
}