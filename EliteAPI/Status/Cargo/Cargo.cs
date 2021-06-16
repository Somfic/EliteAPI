using System;
using System.Collections.Generic;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Cargo.Abstractions;

namespace EliteAPI.Status.Cargo
{
    /// <inheritdoc />
    public class Cargo : StatusBase, ICargo
    {
        /// <inheritdoc />
        public StatusProperty<string> Vessel { get; } = new();

        /// <inheritdoc />
        public StatusProperty<int> Count { get; } = new();

        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<CargoItem>> Inventory { get; } = new();
    }
}