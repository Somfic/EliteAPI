using System;
using System.Collections.Generic;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Backpack;
using EliteAPI.Status.Backpack.Raw;
using EliteAPI.Status.Cargo.Abstractions;

namespace EliteAPI.Status.Cargo
{
    /// <inheritdoc />
    public class Shipyard : IShipyard
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

        /// <inheritdoc />
        public event EventHandler OnChange;

        /// <inheritdoc />
        void IStatus.TriggerOnChange()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}