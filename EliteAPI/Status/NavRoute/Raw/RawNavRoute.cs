using Newtonsoft.Json;

using System.Collections.Generic;

namespace EliteAPI.Status.NavRoute.Raw
{
    internal class RawNavRoute
    {
        [JsonProperty("Route")]
        public IReadOnlyList<RouteStop> Stops { get; set; }
    }
}
