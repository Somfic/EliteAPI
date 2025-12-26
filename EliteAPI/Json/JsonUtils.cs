using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using EliteAPI.Events;
using EliteAPI.Json.SerializationSettings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EventValueType = EliteAPI.Events.EventValueType;

namespace EliteAPI.Json;

public static class JsonUtils
{
    public static JsonSerializerSettings SerializerSettings = new() { ContractResolver = new EventContractResolver(), Converters = [new LocalisedConverter()] };

    public static string GetEventName(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            return string.Empty;

        var obj = JObject.Parse(json);

        {
            if (obj.TryGetValue("event", out var eventName))
                return eventName.ToString();
        }

        {
            if (obj.TryGetValue("Event", out var eventName))
                return eventName.ToString();
        }

        return string.Empty;
    }

    public static List<EventPath> FlattenJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            return [];

        // TODO: call flattening function
        // arrays need Length 
        // key + localisation
        // controls mapping
        List<EventPath> paths = [];
        var token = JToken.Parse(json);

        foreach (var value in token.GetLeafValues().Where(v => !string.IsNullOrWhiteSpace(v.Path)))
            paths.Add(value.ToJsonPath());

        return paths;
    }

    private static IEnumerable<JValue> GetLeafValues(this JToken token)
    {
        if (token is JValue value && value.Type != JTokenType.Null)
        {
            yield return value;
        }
        else if (token is JArray array)
        {
            foreach (var result in GetLeafValues(array))
                yield return result;

            yield return GetLeafValues(new JProperty($"{array.Path}.Length", array.Count)).First();
        }
        else if (token is JProperty property)
        {
            foreach (var result in GetLeafValues(property))
                yield return result;
        }
        else if (token is JObject @object)
        {
            foreach (var result in GetLeafValues(@object))
                yield return result;
        }
    }

    //  JSONToken -> JsonPath
    private static EventPath ToJsonPath(this JValue value)
    {
        var path = NormalizePath(value.Path);
        var @type = value.Type;

        if (path.ToLower().EndsWith("Address") || path.EndsWith("Id") || path.EndsWith("ID") || path.EndsWith("System"))
            @type = JTokenType.String;

        // convert numbers > 32bit or BigInteger to decimal
        if (@type == JTokenType.Integer)
        {
            if (value.Value is BigInteger)
            {
                @type = JTokenType.Float;
            }
            else
            {
                try
                {
                    var longValue = Convert.ToInt64(value.Value);
                    if (longValue > int.MaxValue || longValue < int.MinValue)
                        @type = JTokenType.Float;
                }
                catch
                {
                    @type = JTokenType.Float;
                }
            }
        }

        return @type switch
        {
            JTokenType.Integer => new EventPath
            {
                Path = path,
                Value = Convert.ToInt32(value.Value),
                Type = EventValueType.Number
            },
            JTokenType.Float => new EventPath
            {
                Path = path,
                Value = value.Value is BigInteger bigInt ? (decimal)bigInt : Convert.ToDecimal(value.Value),
                Type = EventValueType.Decimal
            },
            JTokenType.Uri or JTokenType.Guid or JTokenType.String => new EventPath
            {
                Path = path,
                Value = Convert.ToString(value.Value) ?? string.Empty,
                Type = EventValueType.String
            },
            JTokenType.Boolean => new EventPath
            {
                Path = path,
                Value = Convert.ToBoolean(value.Value),
                Type = EventValueType.Boolean
            },
            JTokenType.Date => new EventPath
            {
                Path = path,
                Value = Convert.ToDateTime(value.Value),
                Type = EventValueType.DateTime
            },
            _ => new EventPath
            {
                Path = "",
                Value = "",
                Type = EventValueType.String
            },
        };
    }

    #region Helpers

    private static string NormalizePath(string path)
    {
        return path.Replace("'][", ".").Replace("['", "").Replace("']", "");
    }

    private static IEnumerable<JValue> GetLeafValues(JArray array)
    {
        for (var i = 0; i < array.Count; i++)
        {
            foreach (var result in GetLeafValues(array[i]))
                yield return result;
        }
    }

    private static IEnumerable<JValue> GetLeafValues(JProperty property)
    {
        foreach (var result in GetLeafValues(property.Value))
            yield return result;
    }

    private static IEnumerable<JValue> GetLeafValues(JObject @object)
    {
        foreach (var jToken in @object.Children())
        {
            foreach (var result in GetLeafValues(jToken))
                yield return result;
        }
    }

    #endregion
}
