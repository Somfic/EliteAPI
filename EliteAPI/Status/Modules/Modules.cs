using System;
using System.Collections.Generic;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Modules.Abstractions;

namespace EliteAPI.Status.Modules
{
    public class Modules : StatusBase, IModules
    {
        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<Module>> Installed { get; } = new();
    }
}