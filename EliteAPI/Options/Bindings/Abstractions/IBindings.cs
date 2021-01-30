using System.Collections.Generic;

using EliteAPI.Options.Abstractions;

namespace EliteAPI.Options.Bindings.Models
{
    /// <summary>
    /// Holds information about the keybindings
    /// </summary>
    public interface IBindings : IOption
    {
        /// <summary>
        /// The active keybindings
        /// </summary>
        public KeyBindings Active { get; internal set; }
    }
}