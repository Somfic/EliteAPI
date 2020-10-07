using System;

namespace EliteAPI.Event.Models.Abstractions
{
    /// <summary>
    /// An in-game event
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// The timestamp of the event
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The name of the event
        /// </summary>
        string Event { get;  }
    }
}