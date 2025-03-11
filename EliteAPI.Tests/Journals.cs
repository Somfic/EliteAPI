using EliteAPI.Abstractions.Events;
using EliteAPI.Events;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;

[TestFixture]
public class JournalFileTests
{
    private IEvents _events;

    [OneTimeSetUp]
    public void Setup()
    {
        var eventParser = new EventParser(Mock.Of<IServiceProvider>());
        eventParser.Use<LocalisedConverter>();
        _events = new Events(Mock.Of<ILogger<Events>>(), eventParser);
        _events.Register();
    }
    
    static IEnumerable<string> GetJournalFiles() =>
        Directory.EnumerateFiles("./Journals");
    
    [TestCaseSource(nameof(GetJournalFiles))]
    public void TestJournalFile(string filePath)
    {
        foreach (var line in File.ReadLines(filePath))
        {
            // skip lines based on your _legacyExamples criteria if needed
            // if (_legacyExamples.Any(line.Contains))
            //     continue;

            try
            {
                JObject.Parse(line);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Json", line);
                Assert.Ignore($"Invalid JSON: {ex.Message}");
                continue;
            }

            var invokedEvent = _events.Invoke(line, new EventContext());
            Assert.That(invokedEvent, Is.Not.Null, $"Event is not registered: {line}");

            var eventType = invokedEvent.GetType();
            var eventName = eventType.Name;
            if (eventName.EndsWith("Event"))
                eventName = eventName.Substring(0, eventName.Length - 5);

            Assert.That(string.Equals(eventName, invokedEvent.Event, StringComparison.CurrentCultureIgnoreCase),
                $"Event is not of type {eventName} but {invokedEvent.Event}");
        };
    }
}