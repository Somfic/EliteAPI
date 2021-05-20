using System.Collections.Generic;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Backpack;

namespace EliteAPI.Status.Cargo.Abstractions
{
    /// <summary>
    /// Holds information about the ship's cargo
    /// </summary>
    public interface IBackpack : IStatus
    {
        /// <summary>
        /// The items in the backpack
        /// </summary>
        public StatusProperty<IReadOnlyList<BackpackItem>> Items { get; }
        
        /// <summary>
        /// The components in the backpack
        /// </summary>
        public StatusProperty<IReadOnlyList<BackpackItem>> Components { get; }

        /// <summary>
        /// The consumables in the backpack
        /// </summary>
        public StatusProperty<IReadOnlyList<BackpackItem>> Consumables { get; }

        /// <summary>
        /// The data in the backpack
        /// </summary>
        public StatusProperty<IReadOnlyList<BackpackItem>> Data { get; }
    }
}