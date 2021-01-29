using System;
using System.Collections.Generic;

using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Modules.Abstractions;

namespace EliteAPI.Status.Modules
{
    public class Modules : IModules
    {
        /// <inheritdoc />
        public StatusProperty<IReadOnlyList<Module>> Installed { get; } = new();

        /// <inheritdoc />
        public event EventHandler OnChange;

        /// <inheritdoc />
        void IStatus.TriggerOnChange()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }
}