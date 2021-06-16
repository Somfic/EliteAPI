using System;
using System.Collections.Generic;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Market.Abstractions;

namespace EliteAPI.Status.Market
{
    /// <inheritdoc />
    public class Market : StatusBase, IMarket
    {
        /// <inheritdoc />
        public StatusProperty<string> MarketId { get; } = new();

        /// <inheritdoc />
        public StatusProperty<string> StationName { get; } = new();

        /// <inheritdoc />
        public StatusProperty<string> StationType { get; } = new();

        /// <inheritdoc />
        public StatusProperty<string> StarSystem { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<Commodity>> Commodities { get; } = new();
    }
}