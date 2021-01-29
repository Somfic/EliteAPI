using System.Collections.Generic;

using EliteAPI.Status.Abstractions;

namespace EliteAPI.Status.NavRoute.Abstractions
{
    /// <summary>
    /// Holds information about the current navigation route
    /// </summary>
    public interface INavRoute : IStatus
    {
        /// <summary>
        /// All stops on the route
        /// </summary>
        StatusProperty<IReadOnlyList<RouteStop>> Stops { get; }
    }
}