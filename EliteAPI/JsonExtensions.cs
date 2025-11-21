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

			yield return GetLeafValues(JToken.Parse($"{{ 'items': {{ 'Length': {jArray.Count} }} }}")).First();

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
		switch (jValue.Type)
		{
			case JTokenType.Integer:
			case JTokenType.Float:
				return new JsonPath
				{
					Path = jValue.Path,
					Value = Convert.ToInt32(jValue.Value),
					Type = JsonType.Number
				};
			case JTokenType.Uri:
			case JTokenType.Guid:
			case JTokenType.String:
				return new JsonPath
				{
					Path = jValue.Path,
					Value = Convert.ToString(jValue.Value),
					Type = JsonType.String
				};
			case JTokenType.Boolean:
				return new JsonPath
				{
					Path = jValue.Path,
					Value = Convert.ToBoolean(jValue.Value),
					Type = JsonType.Boolean
				};
			default:
				return new JsonPath
				{
					Path = "",
					Value = "",
					Type = JsonType.String
				};
		}
	}

	#region Helpers

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
