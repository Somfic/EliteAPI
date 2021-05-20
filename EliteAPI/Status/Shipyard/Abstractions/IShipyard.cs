using System.Collections.Generic;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Backpack;
using EliteAPI.Status.Backpack.Raw;

namespace EliteAPI.Status.Cargo.Abstractions
{
    /// <summary>
    /// Holds information about the active shipyard
    /// </summary>
    public interface IShipyard : IStatus
    {
        /// <summary>
        /// The market id for the station this shipyard is at
        /// </summary>
        public StatusProperty<string> MarketId { get; }

        /// <summary>
        /// The name of the station this shipyard is at
        /// </summary>
        public StatusProperty<string> StationName { get; }
        
        /// <summary>
        /// The name of the starsystem this shipyard is at
        /// </summary>
        public StatusProperty<string> StarSystem { get; }
        
        /// <summary>
        /// Whether the commander has the Horizons expansion
        /// </summary>
        public StatusProperty<bool> HasHorizons { get; }
        
        /// <summary>
        /// Whether the commander has access to the Cobra Mk IV
        /// </summary>
        public StatusProperty<bool> AllowsCobraMk4 { get; }
        
        /// <summary>
        /// The deals in this shipyard
        /// </summary>
        public StatusProperty<IReadOnlyList<ShipyardDeal>> Deals { get; }
    }
}