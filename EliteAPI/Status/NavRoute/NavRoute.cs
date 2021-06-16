using System;
using System.Collections.Generic;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.NavRoute.Abstractions;

namespace EliteAPI.Status.NavRoute
{
    public class NavRoute : StatusBase, INavRoute
    {

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<RouteStop>> Stops { get; } = new(new List<RouteStop>());
    }
}