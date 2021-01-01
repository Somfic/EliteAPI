using System;
using EliteAPI.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EliteAPI.Event.Module
{
    /// <summary>
    /// Wrapper for event modules
    /// </summary>
    public abstract class EliteDangerousEventModule
    {
        /// <summary>
        /// The Elite Dangerous API
        /// </summary>
        protected readonly IEliteDangerousApi EliteAPI;

        /// <summary>
        /// Wrapper for event modules
        /// </summary>
        /// <param name="api">The EliteDangerousAPI</param>
        protected EliteDangerousEventModule(IEliteDangerousApi api)
        {
            EliteAPI = api;
        }
    }
}