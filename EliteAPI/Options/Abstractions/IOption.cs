using System;
using EliteAPI.Options.Bindings.Models;

namespace EliteAPI.Options.Abstractions
{
    /// <summary>
    /// Holds information about the game options
    /// </summary>
    public interface IOption
    {
        /// <summary>
        /// Triggered when any of the properties of this option have been updated
        /// </summary>
        event EventHandler<KeyBindings> OnChange;

        internal void TriggerOnChange();

        /// <summary>
        /// This option's JSON
        /// </summary>
        string ToJson();
    }
}