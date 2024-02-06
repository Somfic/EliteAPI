using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using EliteAPI.Abstractions.Bindings;
using EliteAPI.Abstractions.Bindings.Models;
using EliteAPI.Abstractions.Events;
using EliteAPI.Bindings;
using EliteAPI.Events;
using Microsoft.Extensions.Logging;
using Moq;

namespace EliteAPI.Tests;

[TestFixture]
public class Convetions
{
    [Test(Description = "Event types")]
    [TestCaseSource(nameof(GetTypes))]
    public void Events(Type type)
    {
        // Namespace should be EliteAPI.Events
        Assert.That(type.Namespace!.StartsWith("EliteAPI.Events"),
            $"Type {type.Name} should be in namespace EliteAPI.Events");

        // Name should not have underscores
        Assert.That(!type.Name.Contains("_"),
            $"Type {type.Name} should not contain underscores");

        // Name should be PascalCase
        Assert.That(char.IsUpper(type.Name[0]),
            $"Type {type.Name} should start with a capital letter");

        // Should be a struct
        Assert.That(type.IsValueType,
            $"Type {type.Name} should be a struct");

        // Should implement IEvent
        Assert.That(type.GetInterfaces().Contains(typeof(IEvent)),
            $"Type {type.Name} should implement IEvent");
    }

    [Test(Description = "Property namespace")]
    [TestCaseSource(nameof(GetProperties))]
    public void PropertyNamespace(PropertyInfo property)
    {
        var name = property.DeclaringType!.Name + "." + property.Name;

        // Namespace should be EliteAPI.Events
        Assert.That(property.DeclaringType!.Namespace!.StartsWith("EliteAPI.Events"),
            $"Property {name} should be in namespace EliteAPI.Events");
    }

    [Test(Description = "Property underscores")]
    [TestCaseSource(nameof(GetProperties))]
    public void PropertyUnderscores(PropertyInfo property)
    {
        var name = property.DeclaringType!.Name + "." + property.Name;

// Name should not have underscores
        Assert.That(!property.Name.Contains("_"),
            $"Property {name} should not contain underscores");
    }

    [Test(Description = "Property casing")]
    [TestCaseSource(nameof(GetProperties))]
    public void PropertyCasing(PropertyInfo property)
    {
        var name = property.DeclaringType!.Name + "." + property.Name;

        // Name should be PascalCase
        Assert.That(char.IsUpper(property.Name[0]),

            $"Property {name} should start with a capital letter");
    }


    [Test(Description = "Property name length")]
    [TestCaseSource(nameof(GetProperties))]
    public void PropertyNameLength(PropertyInfo property)
    {
        var name = property.DeclaringType!.Name + "." + property.Name;

        // Name should not be too long
        Assert.That(property.Name.Length <= 32,
            $"Property {name} should not be longer than 32 characters");
    }

    [Test(Description = "Property type")]
    [TestCaseSource(nameof(GetProperties))]
    public void PropertyType(PropertyInfo property)
    {
        var name = property.DeclaringType!.Name + "." + property.Name;

        if (property.PropertyType == typeof(float) || property.PropertyType == typeof(decimal))
        {
            // Property should be of type double
            Assert.That(property.PropertyType == typeof(double),
                $"Property {name} should be of type double");
        }

        if (property.PropertyType == typeof(bool) &&
            !property.DeclaringType.Namespace.StartsWith("EliteAPI.Events.Status"))
        {
            // Property should be named IsX or HasX or WasX
            var prefixes = new[] { "Is", "Has", "Was", "Allows", "Can", "Should" };
            Assert.That(prefixes.Any(x => property.Name.StartsWith(x)),
                $"Property {name} should start with {string.Join(" or ", prefixes)}");
        }
    }

    [Test(Description = "Property id or address")]
    [TestCaseSource(nameof(GetProperties))]
    public void PropertyIdOrAddressNaming(PropertyInfo property)
    {
        var name = property.DeclaringType!.Name + "." + property.Name;

        // Properties ending with ID and Address should be of type string and spelled as 'Id' and 'Address'
        if (property.Name.EndsWith("ID", StringComparison.OrdinalIgnoreCase) ||
            property.Name.EndsWith("Address", StringComparison.OrdinalIgnoreCase))
        {
            if(property.Name.EndsWith("paid", StringComparison.InvariantCultureIgnoreCase))
                return;
            
            Assert.That(property.PropertyType == typeof(string),
                $"Property {name} should be of type string");

            if (property.Name.EndsWith("ID", StringComparison.OrdinalIgnoreCase))
            {
                Assert.That(property.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase),
                    $"Property {name} should end with 'Id'");
            }
            else if (property.Name.EndsWith("Address", StringComparison.OrdinalIgnoreCase))
            {
                Assert.That(property.Name.EndsWith("Address", StringComparison.OrdinalIgnoreCase),
                    $"Property {name} should end with 'Address'");
            }
        }
    }

static IImmutableList<PropertyInfo> GetProperties()
    {
        var eventParser = new EventParser(Mock.Of<IServiceProvider>());
        eventParser.Use<LocalisedConverter>();
        var events = new Events.Events(Mock.Of<ILogger<Events.Events>>(), eventParser);
        events.Register();
        
        var properties = new List<PropertyInfo>();

        if(events == null)
            throw new Exception("Events not initialized");
        
        foreach (var eventType in events.EventTypes)
        {
            properties.AddRange(eventType.GetProperties());
        }

        return properties.ToImmutableList();
    }

    static IImmutableList<Type> GetTypes()
    {
        var eventParser = new EventParser(Mock.Of<IServiceProvider>());
        eventParser.Use<LocalisedConverter>();
        
        var events = new Events.Events(Mock.Of<ILogger<Events.Events>>(), eventParser);
        events.Register();

        if (events == null)
            throw new Exception("Events not initialized");

        return events.EventTypes.ToImmutableList();
    }
}