using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace EliteAPI.Abstractions.Events;

/// <summary>Helper for converting between JSON and events.</summary>
public interface IEventParser
{
    /// <summary>
    /// Collection of <see cref="JsonConverter"/>s to use when converting to and from JSON.
    /// </summary>
    IReadOnlyCollection<JsonConverter> Converters { get; }

    /// <summary>Generates the JSON from the provided event.</summary>
    /// <param name="event">The event</param>
    string ToJson<T>(T @event) where T : IEvent;

    /// <summary>
    /// Generates protobuf encoded data for an object.
    /// </summary>
    /// <param name="data"></param>
    /// <typeparam name="T">The type of the object</typeparam>
    byte[] ToProto<T>(T data);
    
    /// <summary>
    /// Generates an object from protobuf encoded data.
    /// </summary>
    /// <param name="data"></param>
    /// <typeparam name="T">The type of the object</typeparam>
    T FromProto<T>(byte[] data);

    /// <summary>Generates a collection of paths.</summary>
    /// <param name="event">The event</param>
    IReadOnlyCollection<EventPath> ToPaths<T>(T @event) where T : IEvent;

    /// <summary>Generates the event from the provided JSON string.</summary>
    /// <param name="json">The JSON string</param>
    T? FromJson<T>(string json) where T : IEvent;
    
    /// <summary>Generates the event from the provided JSON string.</summary>
    /// <param name="type">The event type</param>
    /// <param name="json">The JSON string</param>
    IEvent? FromJson(Type type, string json);
    
    /// <summary>
    /// Registers a converter to be used when parsing events.
    /// </summary>
    /// <typeparam name="TConverter">The converter type</typeparam>
    void Use<TConverter>() where TConverter : JsonConverter;
}