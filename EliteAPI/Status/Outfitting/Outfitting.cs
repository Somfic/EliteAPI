using System;
using System.Collections.Generic;
using System.Text;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Outfitting.Abstractions;

namespace EliteAPI.Status.Outfitting
{
    /// <inheritdoc />
    public class Outfitting : IOutfitting
    {
        /// <inheritdoc />
        public StatusProperty<string> MarketId { get; } = new();

        /// <inheritdoc />
        public StatusProperty<string> StationName { get; } = new();

        /// <inheritdoc />
        public StatusProperty<string> StarSystem { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Horizons { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<OutfittingItem>> Deals { get; } = new();

        /// <inheritdoc />
        public event EventHandler OnChange;

        /// <inheritdoc />
        void IStatus.TriggerOnChange()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
