using System;

namespace EliteAPI.Event.Attributes
{
    /// <summary>
    /// Class for modular events in EliteAPI
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class EliteDangerousEventAttribute : Attribute
    {
        /// <summary>
        /// Class for modular events in EliteAPI
        /// </summary>
        /// <param name="runOnCatchup"> Whether to run this method while catching up </param>
        public EliteDangerousEventAttribute(bool runOnCatchup = false)
        {
            RunOnCatchup = runOnCatchup;
        }

        /// <summary>
        /// Whether to run this method while catching up
        /// </summary>
        public bool RunOnCatchup { get; }
    }
}