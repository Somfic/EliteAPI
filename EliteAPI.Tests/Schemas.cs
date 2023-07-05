using System.Collections;
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
[Ignore("Tests still in progress")]
public class Schemas
{
    private static IEvents _events;
    private static string[] _legacyEvents = { "BackpackMaterials", "BuyMicroResources", "ShipTargetted" };
    private static string[] _legacyExamples =
    {
        "\"timestamp\":\"2020-04-27T08:02:52Z\", \"event\":\"Route\"",
        "\"timestamp\":\"2020-04-27T08:02:52Z\", \"event\":\"Route\""
    };
    
    [OneTimeSetUp]
    public void Setup()
    {
        var eventParser = new EventParser(Mock.Of<IServiceProvider>());
        eventParser.Use<LocalisedConverter>();;
        _events = new Events.Events(Mock.Of<ILogger<Events.Events>>(), eventParser);
        _events.Register();
    }
    
    [Test(Description = "Properties")]
    [TestCaseSource(nameof(GetSchemas))]
    public void Properties((string name, string schema) schemaInfo)
    {
        var (name, schema) = schemaInfo;
        name += "Event";
        
        var eventType = _events.EventTypes.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
        
        Assert.That(eventType, Is.Not.Null, $"Event {name} not found");
        if (eventType == null)
            return;
        
        var properties = eventType.GetProperties();
        var expectedProperties = JObject.Parse(schema)["properties"]!.ToObject<Dictionary<string, JToken>>();

        foreach (var expectedProperty in expectedProperties!)
        {
            if(expectedProperty.Key.EndsWith("_Localised"))
                continue;
            
            var property = properties.FirstOrDefault(x =>
                string.Equals(x.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName, expectedProperty.Key,
                    StringComparison.CurrentCultureIgnoreCase));

            var expectedType = expectedProperty.Value["type"]!.ToObject<string>();
            
            Assert.That(property, Is.Not.Null, $"Property {name}.{expectedProperty.Key} was not found (type {expectedType})");
            if (property == null)
                continue;

            // Make all IDs strings
            if(expectedProperty.Key.EndsWith("ID") || expectedProperty.Key.EndsWith("Address"))
                expectedType = "string";
            
            var type = ConvertToJTokenType(property.PropertyType);

            Assert.That(string.Equals(type.ToString(), expectedType, StringComparison.CurrentCultureIgnoreCase), Is.True,
                $"Property {name}.{expectedProperty.Key} is not the expected type '{expectedType}' (is {type})");
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
    
    private static IEnumerable<(string name, string schema)> GetSchemas()
    {
        Process.Start("git", "clone https://github.com/jixxed/ed-journal-schemas.git schemas-repo").WaitForExit();
        
        var files = Directory.GetFiles("schemas-repo", "*.json", SearchOption.AllDirectories);
        var schemas = new List<(string, string)>();
        
        foreach (var file in files)
        {
            var name = Path.GetFileNameWithoutExtension(file);
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
        else if (type == typeof(int) || type == typeof(long) || type == typeof(short) || type == typeof(byte))
        {
            return "integer";
        }
        else if (type == typeof(float) || type == typeof(double) || type == typeof(decimal))
        {
            return "number";
        }
        else if (type == typeof(bool))
        {
            return "boolean";
        }
        else if (type == typeof(DateTime))
        {
            return "string";
        }
        else if (type.GetInterfaces().Any(x => x == typeof(IEnumerable)))
        {
            return "array";
        }
        else if (type.IsValueType)
        {
            return "object";
        }
        else
        {
            return "unknown";
        }
    }
}