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

			yield return GetLeafValues(JToken.Parse($"{{length :{jArray.Count}}}")).First();

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

	// PRIVATE HELPERS 

	//  JSONToken -> JsonPath

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

}
