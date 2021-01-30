using System;

using EliteAPI.Options.Abstractions;
using EliteAPI.Options.Bindings.Models;

namespace EliteAPI.Options.Bindings
{
    /// <inheritdoc />
    public class Bindings : IBindings
    {
        private KeyBindings _active;
        
        internal Bindings() { }
        
        /// <inheritdoc />

        
        /// <inheritdoc />
        public event EventHandler OnChange;
        
        /// <inheritdoc />
        void IOption.TriggerOnChange() { OnChange?.Invoke(this, EventArgs.Empty); }

        /// <inheritdoc />
        KeyBindings IBindings.Active
        {
            get => _active;
            set => _active = value;
        }
    }
}