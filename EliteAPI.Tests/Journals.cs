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
using Newtonsoft.Json.Linq;

namespace EliteAPI.Tests;

[TestFixture]
public class Journals
{
    private IEvents _events;
    private static string[] _legacyExamples = [];

    [OneTimeSetUp]
    public void Setup()
    {
        var eventParser = new EventParser(Mock.Of<IServiceProvider>());
        eventParser.Use<LocalisedConverter>();
        _events = new Events.Events(Mock.Of<ILogger<Events.Events>>(), eventParser);
        _events.Register();
    }
    
    [Test(Description = "Journals")]
    [TestCaseSource(nameof(GetJournalLines))]
    public void Events(string json)
    {
        if (_legacyExamples.Any(json.Contains)) return;

        // Check if the JSON is valid
        try
        {
            JObject.Parse(json);
        } catch (Exception ex)
        {
            ex.Data.Add("Json", json);
            // Skip if the JSON is invalid
            Assert.Ignore($"Invalid JSON: {ex.Message}");
            return;
        }

        var invokedEvent = _events.Invoke(json, new EventContext());
        
        Assert.That(invokedEvent, Is.Not.Null, $"Event is not registered: {json}");
        
        // Check if the event is the correct type
        var eventType = invokedEvent.GetType();
        var eventName = eventType.Name;
        if (eventName.EndsWith("Event"))
            eventName = eventName.Substring(0, eventName.Length - 5);
        
        Assert.That(string.Equals(eventName, invokedEvent.Event, StringComparison.CurrentCultureIgnoreCase), $"Event is not of type {eventName} but {invokedEvent.Event}");
    }
    
    static IEnumerable<string> GetJournalLines()
    {
        foreach (var file in Directory.EnumerateFiles("./Journals"))
        {
            foreach (var line in File.ReadLines(file))
            {
                yield return line;
            }
        }
    }
}