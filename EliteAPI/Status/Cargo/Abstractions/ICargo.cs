using System.Collections.Generic;

using EliteAPI.Status.Abstractions;

namespace EliteAPI.Status.Cargo.Abstractions
{
    /// <summary>
    /// Holds information about the ship's cargo
    /// </summary>
    public interface ICargo : IStatus
    {
        // todo: turn into enum
        /// <summary>
        /// The name type of vessel that holds the cargo
        /// </summary>
        public StatusProperty<string> Vessel { get; }

        /// <summary>
        /// The amount of tonnes that are in cargo
        /// </summary>
        public StatusProperty<int> Count { get; }

        /// <summary>
        /// All the cargo's inventory
        /// </summary>
        public StatusProperty<IReadOnlyList<CargoItem>> Inventory { get; }
    }
}