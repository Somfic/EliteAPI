using System;
using System.Collections.Generic;
using System.Linq;
using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Events.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Events;

/// <inheritdoc />
public class EventParser : IEventParser
{
    private readonly IServiceProvider _services;

    public EventParser(IServiceProvider services)
    {
        _services = services;
        _log = services.GetService<ILogger<EventParser>>();
    }

    /// <inheritdoc />
    public IReadOnlyCollection<JsonConverter> Converters => _converters.AsReadOnly();

    private readonly List<JsonConverter> _converters = new();
    private readonly ILogger<EventParser>? _log;

    /// <inheritdoc />
    public void Use<TConverter>() where TConverter : JsonConverter
    {
        _log?.LogDebug("Using converter {Converter}", typeof(TConverter).FullName);

        var converter = ActivatorUtilities.CreateInstance<TConverter>(_services);
        _converters.Add(converter);
    }

    /// <inheritdoc />
    public string ToJson<T>(T @event) where T : IEvent
    {
        return JsonConvert.SerializeObject(@event,
            new JsonSerializerSettings {ContractResolver = new EventContractResolver()});
    }

    /// <inheritdoc />
    public IEnumerable<EventPath> ToPaths<T>(T @event) where T : IEvent
    {
        var eventName = @event.Event;
        
        if(string.IsNullOrWhiteSpace(eventName))
            eventName = @event.GetType().Name.Replace("Event", string.Empty);
        
        // Parse the event into a dictionary of paths and values using JToken.
        var root = JObject.Parse(ToJson(@event));

        return root.Properties().SelectMany(GetPaths).Select(x => new EventPath($"{eventName}.{x.Path}", x.Value)).ToList().AsReadOnly();
    }
    
    /// <inheritdoc />
    public IEnumerable<EventPath> ToPaths(string json)
    {
        if (string.IsNullOrEmpty(json))
            return Array.Empty<EventPath>();
        
        var root = JObject.Parse(json);
        var eventKey = root["event"];

        if (eventKey == null)
        {
            var ex = new JsonException("The JSON does not contain an event key.");
            ex.Data.Add("JSON", json);

            _log?.LogWarning(ex, "Could not parse JSON");
            throw ex;
        }
        
        var parsed = JsonConvert.DeserializeObject(json, new JsonSerializerSettings {ContractResolver = new EventContractResolver(), Converters = _converters});
        var parsedJson = JsonConvert.SerializeObject(parsed);
        root = JObject.Parse(parsedJson);

        var eventName = eventKey.Value<string>();
        return root.Properties().SelectMany(GetPaths).Select(x => new EventPath($"{eventName}.{x.Path}", x.Value)).ToList().AsReadOnly();
    }

    /// <inheritdoc />
    public T? FromJson<T>(string json) where T : IEvent
    {
        return JsonConvert.DeserializeObject<T>(json,
            new JsonSerializerSettings {ContractResolver = new EventContractResolver(), Converters = _converters});
    }

    /// <inheritdoc />
    public IEvent? FromJson(Type type, string json)
    {
        return JsonConvert.DeserializeObject(json, type,
            new JsonSerializerSettings
                {ContractResolver = new EventContractResolver(), Converters = _converters}) as IEvent;
    }

    private IEnumerable<EventPath> GetPaths(JObject? jObject)
    {
        try
        {
            if(jObject == null)
                return Array.Empty<EventPath>();
            
            return jObject.Properties().SelectMany(GetPaths).ToList();
        }
        catch (Exception ex)
        {
            _log?.LogWarning(ex, "Could not parse paths for JSON object {Json}", jObject.Path);
            return Array.Empty<EventPath>();
        }
    }

    private IEnumerable<EventPath> GetPaths(JProperty property) => GetPaths(property.Value);

    private IEnumerable<EventPath> GetPaths(JToken token)
    {
        try
        {
            switch (token.Type)
            {
                case JTokenType.Null:
                    return new[] {new EventPath(token.Path, string.Empty)};

                case JTokenType.Object:
                    return token.Children<JProperty>().SelectMany(GetPaths);

                case JTokenType.Array:
                    if (!token.Values().Any())
                        return Array.Empty<EventPath>();

                    var arrayType = token.Values().First().Type;

                    switch (arrayType)
                    {
                        case JTokenType.Property:
                            return token.Values<JObject>().SelectMany(GetPaths);

                        case JTokenType.Integer:
                        case JTokenType.Boolean:
                        case JTokenType.Float:  
                        case JTokenType.String:
                            return token.Values<JToken>().SelectMany(GetPaths);

                        default:
                            throw new JsonException("Unsupported array type: " + arrayType);
                    }

                case JTokenType.Boolean:
                    return new[] {new EventPath(token.Path, JsonConvert.SerializeObject(token.Value<bool>()))};

                case JTokenType.String:
                    return new[] {new EventPath(token.Path, JsonConvert.SerializeObject(token.Value<string>()))};

                case JTokenType.Date:
                    return new[] {new EventPath(token.Path, JsonConvert.SerializeObject(token.Value<DateTime>()))};

                case JTokenType.Integer:
                    return new[] {new EventPath(token.Path, JsonConvert.SerializeObject(token.Value<long>()))};

                case JTokenType.Float:
                    return new[] {new EventPath(token.Path, JsonConvert.SerializeObject(token.Value<float>()))};

                default:
                    _log?.LogDebug("Unsupported type {Type} for JSON path {Json}", token.Type.ToString(),
                        token.Path);
                    return new[] {new EventPath(token.Path, "\"__UNKNOWN__\"")};
            }
        }
        catch (Exception ex)
        {
            ex.Data.Add("Path", token.Path);
            ex.Data.Add("Type", token.Type.ToString());
            ex.Data.Add("Value", token.ToString());

            _log?.LogWarning(ex, "Could not parse part of JSON {Path}", token.Path);
            return new[] {new EventPath(token.Path, "\"__UNKNOWN__\"")};
        }
    }
}