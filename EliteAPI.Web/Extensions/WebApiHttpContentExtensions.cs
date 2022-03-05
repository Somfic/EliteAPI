using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ReSharper disable once CheckNamespace
namespace System.Net.Http;

public static class WebApiHttpContentExtensions
{
    public static async Task<(T parsed, string json)> ReadAsJsonAsync<T>(this HttpContent content)
    {
        var json = await content.ReadAsStringAsync();

        var jObject = JToken.Parse(json);
        if (jObject.Type == JTokenType.Array) json = "{ root: " + json + " }"; // todo: fix this lol

        var body = JsonConvert.DeserializeObject<T>(json);

        if (body == null)
            throw new JsonException("Could not parse the request's response into the given JSON schema.")
                {Data = {["Json"] = json, ["Schema"] = typeof(T).Name}};

        return (body, json);
    }
}