using System.Collections.Generic;

using EliteAPI.Status.Abstractions;

namespace EliteAPI.Status.Market.Abstractions
{
    /// <summary>
    /// Holds information about the current market
    /// </summary>
    public interface IMarket : IStatus
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
        /// The type of station this market is
        /// </summary>
        StatusProperty<string> StationType { get; }

        /// <summary>
        /// The name of the starsystem
        /// </summary>
        StatusProperty<string> StarSystem { get; }

        /// <summary>
        /// All the commodities that are traded at this market
        /// </summary>
        StatusProperty<IReadOnlyList<Commodity>> Commodities { get; }
    }
}