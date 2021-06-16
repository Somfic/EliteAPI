using System.Collections.Generic;

using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Status.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Status.NavRoute.Raw
{
    public class RawNavRoute : EventBase<RawNavRoute>, IRawStatus
    {
        [JsonProperty("Route")]
        public IReadOnlyList<RouteStop> Stops { get; set; }
    }
}