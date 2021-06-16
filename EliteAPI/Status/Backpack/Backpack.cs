using System;
using System.Collections.Generic;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Backpack.Abstractions;

namespace EliteAPI.Status.Backpack
{
    /// <inheritdoc />
    public class Backpack : StatusBase, IBackpack
    {
        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<BackpackItem>> Items { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<BackpackItem>> Components { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<BackpackItem>> Consumables { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<BackpackItem>> Data { get; } = new();
    }
}