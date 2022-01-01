using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Events.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using ProtoBuf;

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
    public ReadOnlyCollection<KeyValuePair<string, string>> ToPaths<T>(T @event) where T : IEvent
    {
        // Parse the event into a dictionary of paths and values using JToken.
        var root = JObject.Parse(ToJson(@event));

        return root.Properties().SelectMany(GetPaths).Where(x => x.Value != null)
            .Select(x => new KeyValuePair<string, string>(x.Key, JsonConvert.SerializeObject(x.Value))).ToList()
            .AsReadOnly()!;
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

    /// <inheritdoc />
    public byte[] ToProto<T>(T data)
    {
        try
        {
            using var stream = new MemoryStream();
            Serializer.Serialize(stream, data);
            return stream.ToArray();
        }
        catch (Exception ex)
        {
            ex.Data.Add("Data", data);
            _log?.LogWarning(ex, "Could not serialise data using protobuf");
            throw;
        }
    }

    /// <inheritdoc />
    public T FromProto<T>(byte[] data)
    {
        try
        {
            return Serializer.Deserialize<T>(new MemoryStream(data));
        }
        catch (Exception ex)
        {
            ex.Data.Add("Data", data);
            _log?.LogWarning(ex, "Could not deserialize data using protobuf");
            throw;
        }
    }


    private IList<KeyValuePair<string, object?>> GetPaths(JObject jObject)
    {
        try
        {
            return jObject.Properties().SelectMany(GetPaths).ToList();
        }
        catch (Exception ex)
        {
            _log?.LogWarning(ex, "Could not parse paths for JSON object {Json}", jObject.Path);
            return Array.Empty<KeyValuePair<string, object?>>();
        }
    }

    private IList<KeyValuePair<string, object?>> GetPaths(JArray jArray)
    {
        try
        {
            return jArray.Values<JObject>().SelectMany(x => x?.Properties().SelectMany(GetPaths)).ToList();
        }
        catch (Exception ex)
        {
            _log?.LogWarning(ex, "Could not parse paths for JSON array {Json}", jArray.Path);
            return Array.Empty<KeyValuePair<string, object?>>();
        }
    }


    private IList<KeyValuePair<string, object?>> GetPaths(JProperty property)
    {
        try
        {
            switch (property.Value.Type)
            {
                case JTokenType.Object:
                    return property.Value.Children<JProperty>().SelectMany(GetPaths).ToList();

                case JTokenType.Array:
                    return property.Value.Values<JObject>().SelectMany(GetPaths).ToList();

                case JTokenType.Boolean:
                    return new[] {new KeyValuePair<string, object?>(property.Path, property.Value.Value<bool>())};

                case JTokenType.String:
                    return new[] {new KeyValuePair<string, object?>(property.Path, property.Value.Value<string>())};

                case JTokenType.Date:
                    return new[] {new KeyValuePair<string, object?>(property.Path, property.Value.Value<DateTime>())};

                case JTokenType.Integer:
                    return new[] {new KeyValuePair<string, object?>(property.Path, property.Value.Value<int>())};

                case JTokenType.Float:
                    return new[] {new KeyValuePair<string, object?>(property.Path, property.Value.Value<float>())};

                default:
                    _log?.LogDebug("Unsupported type {Type} for JSON path {Json}", property.Value.Type.ToString(),
                        property.Path);
                    return Array.Empty<KeyValuePair<string, object?>>();
            }
        }
        catch (Exception ex)
        {
            _log?.LogWarning(ex, "Could not parse JSON {Path}", property.Value.Path);
            return Array.Empty<KeyValuePair<string, object?>>();
        }
    }
}