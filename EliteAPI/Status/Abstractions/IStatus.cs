using System;
using EliteAPI.Abstractions;

namespace EliteAPI.Status.Abstractions
{
    /// <summary>
    /// Holds status information about the game
    /// </summary>
    public interface IStatus : IJsonObject
    {
        /// <summary>
        /// Triggered when any of the properties have been updated
        /// </summary>
        event EventHandler<IRawStatus> OnChange;

        /// <summary>
        /// Generates this status's Json
        /// </summary>
        new string ToJson();
        
        internal void TriggerOnChange(IRawStatus rawStatus);
    }
}