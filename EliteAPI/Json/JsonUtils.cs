using System.Text.Json;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Json;

public static class JsonUtils
{
    public static List<JsonPath> FlattenJson(string json)
    {
        // TODO: call flattening function
        // arrays need Length 
        // key + localisation
        // controls mapping
        List<JsonPath> paths = [];
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
    private static JsonPath ToJsonPath(this JValue value)
    {
        var path = NormalizePath(value.Path);
        var @type = value.Type;

        if (path.ToLower().EndsWith("Address") || path.EndsWith("Id") || path.EndsWith("ID"))
            @type = JTokenType.String;

        return @type switch
        {
            JTokenType.Integer => new JsonPath
            {
                Path = path,
                Value = Convert.ToInt64(value.Value),
                Type = JsonType.Number
            },
            JTokenType.Float => new JsonPath
            {
                Path = path,
                Value = Convert.ToDecimal(value.Value),
                Type = JsonType.Decimal
            },
            JTokenType.Uri or JTokenType.Guid or JTokenType.String => new JsonPath
            {
                Path = path,
                Value = Convert.ToString(value.Value) ?? string.Empty,
                Type = JsonType.String
            },
            JTokenType.Boolean => new JsonPath
            {
                Path = path,
                Value = Convert.ToBoolean(value.Value),
                Type = JsonType.Boolean
            },
            JTokenType.Date => new JsonPath
            {
                Path = path,
                Value = Convert.ToDateTime(value.Value),
                Type = JsonType.DateTime
            },
            _ => new JsonPath
            {
                Path = "",
                Value = "",
                Type = JsonType.String
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
