using System.Text.Json;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace EliteAPI;

public static class JExtensions
{
    public static IEnumerable<JValue> GetLeafValues(this JToken jToken)
    {
        if (jToken is JValue jvalue)
        {
            yield return jvalue;
        }
        else if (jToken is JArray jArray)
        {
            foreach (var result in GetLeafValuesFromJArray(jArray))
            {
                yield return result;
            }

            // yield return GetLeafValues(JToken.Parse($"{{ {jArray.Path.Replace(".", "")}: {{ 'Length': {jArray.Count} }} }}")).First();
            yield return GetLeafValuesFromJProperty(new JProperty($"{jArray.Path}.Length", jArray.Count)).First();

        }
        else if (jToken is JProperty jProperty)
        {
            foreach (var result in GetLeafValuesFromJProperty(jProperty))
            {
                yield return result;
            }
        }
        else if (jToken is JObject jObject)
        {
            foreach (var result in GetLeafValuesFromJObject(jObject))
            {
                yield return result;
            }
        }
    }


    //  JSONToken -> JsonPath
    public static JsonPath ToCustomJsonPath(this JValue jValue)
    {
        return jValue.Type switch
        {
            JTokenType.Integer => new JsonPath
            {
                Path = NormalizePath(jValue.Path),
                Value = Convert.ToInt32(jValue.Value),
                Type = JsonType.Number
            },
            JTokenType.Float => new JsonPath
            {
                Path = NormalizePath(jValue.Path),
                Value = Convert.ToDecimal(jValue.Value),
                Type = JsonType.Decimal
            },
            JTokenType.Uri or JTokenType.Guid or JTokenType.String => new JsonPath
            {
                Path = NormalizePath(jValue.Path),
                Value = Convert.ToString(jValue.Value),
                Type = JsonType.String
            },
            JTokenType.Boolean => new JsonPath
            {
                Path = NormalizePath(jValue.Path),
                Value = Convert.ToBoolean(jValue.Value),
                Type = JsonType.Boolean
            },
            JTokenType.Date => new JsonPath
            {
                Path = NormalizePath(jValue.Path),
                Value = Convert.ToDateTime(jValue.Value),
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

    static string NormalizePath(string rawPath)
    {
        if (rawPath.StartsWith("['") && rawPath.EndsWith("']"))
            return rawPath.Substring(2, rawPath.Length - 4);
        return rawPath;
    }

    static IEnumerable<JValue> GetLeafValuesFromJArray(JArray jArray)
    {
        for (var i = 0; i < jArray.Count; i++)
        {
            foreach (var result in GetLeafValues(jArray[i]))
            {
                yield return result;
            }
        }
    }

    static IEnumerable<JValue> GetLeafValuesFromJProperty(JProperty jProperty)
    {
        foreach (var result in GetLeafValues(jProperty.Value))
        {
            yield return result;
        }
    }

    static IEnumerable<JValue> GetLeafValuesFromJObject(JObject jObject)
    {
        foreach (var jToken in jObject.Children())
        {
            foreach (var result in GetLeafValues(jToken))
            {
                yield return result;
            }
        }
    }

    #endregion
}
