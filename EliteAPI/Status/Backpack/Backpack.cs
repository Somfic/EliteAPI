using System;
using System.Collections.Generic;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Backpack;
using EliteAPI.Status.Cargo.Abstractions;

namespace EliteAPI.Status.Cargo
{
    /// <inheritdoc />
    public class Backpack : IBackpack
    {
        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<BackpackItem>> Items { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<BackpackItem>> Components { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<BackpackItem>> Consumables { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<BackpackItem>> Data { get; } = new();

        /// <inheritdoc />
        public event EventHandler OnChange;

        /// <inheritdoc />
        void IStatus.TriggerOnChange()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}