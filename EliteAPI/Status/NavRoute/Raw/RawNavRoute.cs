using System.Collections.Generic;

using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Status.NavRoute.Raw
{
    public class RawNavRoute : EventBase<RawNavRoute>
    {
        [JsonProperty("Route")]
        public IReadOnlyList<RouteStop> Stops { get; set; }
    }
}