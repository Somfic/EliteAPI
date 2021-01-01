using System;
using System.Collections.Generic;
using System.Text;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Modules.Abstractions;
using EliteAPI.Status.Modules.Raw;

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
