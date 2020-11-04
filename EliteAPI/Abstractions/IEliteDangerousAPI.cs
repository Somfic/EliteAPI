using EliteAPI.Status.Models.Abstractions;
using System;
using System.Threading.Tasks;
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
        IShipStatus Status { get; }

        /// <summary>
        /// Whether the api is currently running
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Whether the api has catched up on past event in this session
        /// </summary>
        bool HasCatchedUp { get; }

        /// <summary>
        /// Initializes the api
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Starts the api
        /// </summary>
        Task StartAsync();

        /// <summary>
        /// Stops the api
        /// </summary>
        Task StopAsync();
    }
}