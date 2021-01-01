using System;
using System.Threading.Tasks;
using EliteAPI.Status.Cargo.Abstractions;
using EliteAPI.Status.Models.Abstractions;
using EliteAPI.Status.NavRoute.Abstractions;
using EliteAPI.Status.Ship.Abstractions;
using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI.Abstractions
{
    [Obsolete("Use IEliteDangerousApi instead", true)]
    public interface IEliteDangerousAPI
    {

    }

    /// <summary>
    ///     EliteAPI
    /// </summary>
    public interface IEliteDangerousApi
    {
        /// <summary>
        ///     EliteAPI's version
        /// </summary>
        string Version { get; }

        /// <summary>
        ///     Container for all events
        /// </summary>
        EventHandler Events { get; }

        /// <summary>
        /// Container for the ship's current status
        /// </summary>
        [Obsolete("Use the Ship property instead", false)]
        IShipStatus Status { get; }

        /// <summary>
        /// Container for the ship's current status
        /// </summary>
        IShip Ship { get; }

        /// <summary>
        /// Container for the ship's current navigation route
        /// </summary>
        INavRoute NavRoute { get; }

        /// <summary>
        /// Container for the ship's current cargo
        /// </summary>
        ICargo Cargo { get; }

        /// <summary>
        ///     Whether the api is currently running
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        ///     Whether the api has catched up on past event in this session
        /// </summary>
        bool HasCatchedUp { get; }

        /// <summary>
        ///     Initializes the api
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        ///     Starts the api
        /// </summary>
        Task StartAsync();

        /// <summary>
        ///     Stops the api
        /// </summary>
        Task StopAsync();
    }
}