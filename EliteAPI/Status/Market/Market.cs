using System;
using System.Collections.Generic;
using System.Text;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Market.Abstractions;

namespace EliteAPI.Status.Market
{
    /// <inheritdoc />
    public class Market : IMarket
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

        /// <inheritdoc />
        public event EventHandler OnChange;

        /// <inheritdoc />
        void IStatus.TriggerOnChange()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
