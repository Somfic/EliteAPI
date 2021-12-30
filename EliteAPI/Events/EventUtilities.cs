using System.Linq;
using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Events.Converters;
using Newtonsoft.Json;

namespace EliteAPI.Events;

/// <inheritdoc />
public class EventUtilities : IEventUtilities
{
    private readonly IEvents _events;

    public EventUtilities(IEvents events)
    {
        _events = events;
    }

    /// <inheritdoc />
    public string ToJson<T>(T @event) where T : IEvent
    {
        return JsonConvert.SerializeObject(@event,
            new JsonSerializerSettings
                {ContractResolver = new EventContractResolver(), Converters = _events.Converters.ToArray()});
    }

    /// <inheritdoc />
    public T? FromJson<T>(string json) where T : IEvent
    {
        return JsonConvert.DeserializeObject<T>(json,
            new JsonSerializerSettings {Converters = _events.Converters.ToArray()});
    }
}