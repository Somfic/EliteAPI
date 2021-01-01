using System;
using System.Collections.Generic;
using System.Text;
using EliteAPI.Status.Abstractions;

namespace EliteAPI.Status.Outfitting.Abstractions
{
    /// <summary>
    /// Holds information about the currently available outfitting deals at the station market
    /// </summary>
    public interface IOutfitting : IStatus
    {
        /// <summary>
        /// The id of this market
        /// </summary>
        StatusProperty<string> MarketId { get; }

        /// <summary>
        /// The name of the station of this market
        /// </summary>
        StatusProperty<string> StationName { get; }

        /// <summary>
        /// The name of the starsystem
        /// </summary>
        StatusProperty<string> StarSystem { get; }

        /// <summary>
        /// Whether the Horizon DLC is active
        /// </summary>
        StatusProperty<bool> Horizons { get; }

        /// <summary>
        /// The outfitting items being dealt at this station
        /// </summary>
        StatusProperty<IReadOnlyList<OutfittingItem>> Deals { get; }
    }
}
