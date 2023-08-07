using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using EliteAPI.Abstractions.Events;
using EliteAPI.Events;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Tests;

[TestFixture]
public class Schemas
{
    private static IEvents _events;

    [OneTimeSetUp]
    public void Setup()
    {
        var eventParser = new EventParser(Mock.Of<IServiceProvider>());
        eventParser.Use<LocalisedConverter>();
        
        _events = new Events.Events(Mock.Of<ILogger<Events.Events>>(), eventParser);
        _events.Register();
    }

    [Test(Description = "Properties")]
    [TestCaseSource(nameof(GetProperties))]
    [Ignore("Tests are being worked on")]
    public void Properties((string name, string type) schemaInfo)
    {
        var eventName = schemaInfo.name.Split('.')[0] + "Event";
        var name = string.Join(".", schemaInfo.name.Split('.').Skip(1));
        var type = schemaInfo.type;
        
        var eventType = _events.EventTypes.FirstOrDefault(x => x.Name == eventName);
        Assert.That(eventType, Is.Not.Null, $"Event type {eventName} not found");

        if (type == "object")
        {
            // Skip
            Assert.Pass();
        }
        else if (type == "array")
        {
            // Skip
            Assert.Pass();
        }
        else
        {
            // Skip nested properties
            if(name.Any(x => x == '.'))
                Assert.Pass();
            
            var properties = eventType!
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetCustomAttributes<JsonPropertyAttribute>().Any());

            var jsonProperty =
                properties.FirstOrDefault(x => string.Equals(x.GetCustomAttribute<JsonPropertyAttribute>()!.PropertyName, name, StringComparison.InvariantCultureIgnoreCase));
            Assert.That(jsonProperty, Is.Not.Null, $"Property {name} not found on event {eventName}");

            var jsonPropertyType = jsonProperty!.PropertyType;
            var jsonPropertyTypeName = ConvertToJTokenType(jsonPropertyType);

            Assert.That(jsonPropertyTypeName, Is.EqualTo(type),
                $"Property {name} on event {eventName} is of type {jsonPropertyTypeName} but should be of type {type}");
        }
    }

    [Test(Description = "Events")]
    [TestCaseSource(nameof(GetSchemas))]
    public void Event((string name, string schema) schemaInfo)
    {
        var (name, schema) = schemaInfo;

        name += "Event";

        Assert.That(_events.EventTypes.Select(x => x.Name.ToLower()), Does.Contain(name.ToLower()));
    }


    static IImmutableList<(string name, string type)> GetProperties()
    {
        var result = new List<(string, string)>();

        foreach (var (name, schema) in GetSchemas())
        {
            Console.WriteLine($"Processing {name}");

            var schemaObject = JObject.Parse(schema);
            var properties = schemaObject["properties"]?.Children<JProperty>();

            if (properties == null)
                continue;

            result.AddRange(ExtractProperties(properties, name));
        }

        return result.ToImmutableList();
    }

    static IEnumerable<(string name, string type)> ExtractProperties(IEnumerable<JProperty> properties,
        string namePrefix = "")
    {
        foreach (var property in properties)
        {
            var type = property.Value["type"]?.Value<string>();
            var name = property.Value["title"]?.Value<string>();

            if (type == null || name == null)
                continue;
            
            if(name.EndsWith("_Localised"))
                continue;
            
            if(name.EndsWith("ID") || name.EndsWith("Address") || name.EndsWith("Market"))
                type = "string";

            var propertyName = (namePrefix + "." + name).TrimStart('.').TrimEnd('.').Replace("..", ".");
            yield return (propertyName, type);
            
            switch (type)
            {
                case "array":
                {
                    var items = property.Value.Value<JObject>("items")?.Value<JObject>("properties")
                        ?.Children<JProperty>();

                    if (items == null)
                        continue;

                    var arrayProperties = ExtractProperties(items, namePrefix + "." + name);

                    foreach (var arrayProperty in arrayProperties)
                        yield return arrayProperty;
                    break;
                }
                case "object":
                {
                    var items = property.Value["properties"]?.Children<JProperty>();

                    if (items == null)
                        continue;

                    var objectProperties = ExtractProperties(items, namePrefix + "." + name);

                    foreach (var objectProperty in objectProperties)
                        yield return objectProperty;
                    break;
                }
            }
        }
    }

    static IEnumerable<(string name, string schema)> GetSchemas()
    {
        Process.Start("git", "clone https://github.com/Somfic/journal-schemas.git schemas-repo").WaitForExit();

        var files = Directory.GetFiles("schemas-repo", "*.json", SearchOption.AllDirectories);
        var schemas = new List<(string, string)>();

        foreach (var file in files)
        {
            var name = Path.GetFileNameWithoutExtension(file);

            if (name is "_Event" or "ShipLockerBackpack" or "ShipLockerMaterials")
                continue;

            var schema = File.ReadAllText(file);

            schemas.Add((name, schema));
        }

        return schemas;
    }

    private static string ConvertToJTokenType(Type type)
    {
        if (type == typeof(string) || type == typeof(Localised))
        {
            return "string";
        }

        if (type == typeof(int) || type == typeof(long) || type == typeof(short) || type == typeof(byte))
        {
            return "integer";
        }

        if (type == typeof(float) || type == typeof(double) || type == typeof(decimal))
        {
            return "number";
        }

        if (type == typeof(bool))
        {
            return "boolean";
        }

        if (type == typeof(DateTime))
        {
            return "string";
        }

        if (type.GetInterfaces().Any(x => x == typeof(IEnumerable)))
        {
            return "array";
        }

        if (type.IsValueType)
        {
            return "object";
        }

        return "unknown";
    }
}