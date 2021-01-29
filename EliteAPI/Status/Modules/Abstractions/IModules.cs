using System.Collections.Generic;

using EliteAPI.Status.Abstractions;

namespace EliteAPI.Status.Modules.Abstractions
{
    /// <summary>
    /// Holds information about the ship's currently installed modules
    /// </summary>
    public interface IModules : IStatus
    {
        /// <summary>
        /// A list of installed modules
        /// </summary>
        StatusProperty<IReadOnlyList<Module>> Installed { get; }
    }
}