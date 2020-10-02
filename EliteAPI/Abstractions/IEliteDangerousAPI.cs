using System;
using System.Threading.Tasks;
using EliteAPI.Status.Models;
using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI.Abstractions
{
    /// <summary>
    /// EliteAPI
    /// </summary>
    public interface IEliteDangerousAPI
    {
        /// <summary>
        /// EliteAPI's version
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Container for all events
        /// </summary>
        EventHandler Events { get; }

        /// <summary>
        /// Container for the ship's current status
        /// </summary>
        ShipStatus Status { get; }

        /// <summary>
        /// Whether the api is currently running
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Initializes the api
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Starts the api
        /// </summary>
        Task StartAsync();
    }
}