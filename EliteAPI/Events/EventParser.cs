using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EliteAPI.Abstractions;
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
        var json = ToJson(@event);

        return ToPaths(json);
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
        var paths = root.Properties().SelectMany(GetPaths).Select(x => new EventPath($"{eventName}.{x.Path}", x.Value));
        
        // Add a .length path for arrays.
        var arrayPaths = root.Properties().Where(x => x.Value.Type == JTokenType.Array).Select(x => new EventPath($"{eventName}.{x.Path}.Length", x.Value.Count().ToString()));
        
        return paths.Concat(arrayPaths);
    }

    /// <inheritdoc />
    public T? FromJson<T>(string json) where T : IEvent
    {
        RegisterLocalisedValues(json);
        
        return JsonConvert.DeserializeObject<T>(json,
            new JsonSerializerSettings { Converters = _converters});
    }

    /// <inheritdoc />
    public IEvent? FromJson(Type type, string json)
    {
        RegisterLocalisedValues(json);
        
        return JsonConvert.DeserializeObject(json, type,
            new JsonSerializerSettings
                { Converters = _converters}) as IEvent;
    }

    private void RegisterLocalisedValues(string json)
    {
        var matches = Regex.Matches(json, "\"([^\"]*?)\":\"([^\"]*?)\",[^\"]?\"([^\"]*?)_Localised\":\"([^\"]*)\"");

        foreach (Match match in matches)
        {
            var symbolKey = match.Groups[1].Value;
            var symbolValue = match.Groups[2].Value;
            var localisedKey = match.Groups[3].Value;
            var localisedValue = match.Groups[4].Value;
            
            if (symbolKey != localisedKey)
                continue;
            
            Localisation.SetLocalisedString(symbolValue, localisedValue);
        }
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

    private IEnumerable<EventPath> GetPaths(JProperty property) => GetPaths(property.Name, property.Value);

    private IEnumerable<EventPath> GetPaths(string name, JToken token)
    {
        try
        {
            // If the name ends with "id" or "address" and the token is not an object or array, then overwrite it to a string.
            if((name.EndsWith("id", StringComparison.InvariantCultureIgnoreCase) || name.EndsWith("address", StringComparison.InvariantCultureIgnoreCase)) && token.Type is not JTokenType.Object or JTokenType.Array)
                return new[] {new EventPath(token.Path, JsonConvert.SerializeObject(token.Value<string>()))};
            
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
                            return token.Values<JObject>().SelectMany(x => GetPaths((token as JProperty)?.Name ?? "", x));

                        case JTokenType.Integer:
                        case JTokenType.Boolean:
                        case JTokenType.Float:  
                        case JTokenType.String:
                            return token.Values<JToken>().SelectMany(x => GetPaths("", x));

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