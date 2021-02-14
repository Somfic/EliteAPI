using System.Threading.Tasks;

using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Provider.Abstractions
{
    /// <summary>
    /// Converts JSON events to <see cref="IEvent{T}" /> events
    /// </summary>
    public interface IEventProvider
    {
        /// <summary>
        /// Processes a json event to <see cref="IEvent{T}" />
        /// </summary>
        /// <param name="json"> The json event from the journal </param>
        Task<IEvent> ProcessJsonEvent(string json);

        /// <summary>
        /// Caches all the event classes
        /// </summary>
        Task RegisterEventClasses();
    }
}