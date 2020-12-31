using System;
using System.Collections.Generic;
using System.Text;

namespace EliteAPI.Status.Abstractions
{
    /// <summary>
    /// Holds status information about the game
    /// </summary>
    public interface IStatus
    {
        /// <summary>
        /// Triggered when any of the properties have been updated
        /// </summary>
        event EventHandler OnChange;

        internal void TriggerOnChange();
    }
}
