using System;
using System.Collections.Generic;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Cargo.Abstractions;

namespace EliteAPI.Status.Cargo
{
    /// <inheritdoc />
    public class Cargo : ICargo
    {
        /// <inheritdoc />
        public StatusProperty<string> Vessel { get; } = new();

        /// <inheritdoc />
        public StatusProperty<int> Count { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<CargoItem>> Inventory { get; } = new();

        /// <inheritdoc />
        public event EventHandler OnChange;

        /// <inheritdoc />
        void IStatus.TriggerOnChange()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}