using System;
using System.Collections.Generic;
using System.Text;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Modules.Raw;

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
