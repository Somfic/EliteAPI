using System.Collections.Generic;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Backpack.Raw;
using EliteAPI.Status.Cargo.Abstractions;
using EliteAPI.Status.Shipyard.Abstractions;

namespace EliteAPI.Status.Shipyard
{
    /// <inheritdoc />
    public class Shipyard : StatusBase, IShipyard
    {
        /// <inheritdoc />
        public StatusProperty<string> MarketId { get; } = new();

        /// <inheritdoc />
        public StatusProperty<string> StationName { get; } = new();

        /// <inheritdoc />
        public StatusProperty<string> StarSystem { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> HasHorizons { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> AllowsCobraMk4 { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<ShipyardDeal>> Deals { get; } = new();
    }
}