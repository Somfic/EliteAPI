using System;

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
        event EventHandler<IRawStatus> OnChange;

        /// <summary>
        /// Generates this status's Json
        /// </summary>
        string ToJson();
        
        internal void TriggerOnChange(IRawStatus rawStatus);
    }
}