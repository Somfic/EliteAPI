using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using EliteAPI.Abstractions.Events;
using EliteAPI.Events;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Tests;

[TestFixture]
public class JournalManual
{
    private static IEvents _events;
    private static string[] _legacyEvents = { "BackpackMaterials", "BuyMicroResources", "ShipTargetted", "CarrierNameChanged" };
    private static string[] _legacyExamples =
    {
        "\"timestamp\":\"2020-04-27T08:02:52Z\", \"event\":\"Route\"",
        "\"timestamp\":\"2020-04-27T08:02:52Z\", \"event\":\"Route\"",
        "\"timestamp\":\"2020-10-07T14:01:08Z\", \"event\":\"BuyMicroResource\"",
    };
    
    [OneTimeSetUp]
    public void Setup()
    {
        var eventParser = new EventParser(Mock.Of<IServiceProvider>());
        eventParser.Use<LocalisedConverter>();
        _events = new Events.Events(Mock.Of<ILogger<Events.Events>>(), eventParser);
        _events.Register();
    }

    [Test(Description = "Events")]
    [TestCaseSource(nameof(GetChapters))]
    public void Event((int chapter, int subchapter, string name) chapterInfo)
    {
        if (_legacyEvents.Contains(chapterInfo.name))
        {
            Assert.Ignore($"Legacy event: {chapterInfo.name}");
            return;
        }
        
        chapterInfo.name += "Event";

        Assert.That(_events.EventTypes.Select(x => x.Name.ToLower()), Does.Contain(chapterInfo.name.ToLower()));
    }

    [Test(Description = "Json Examples")]
    [TestCaseSource(nameof(GetJsonExamples))]
    public void Json(string json)
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
        
        Assert.That(invokedEvent, Is.Not.Null, $"Event is null");
        
        // Check if the event is the correct type
        var eventType = invokedEvent.GetType();
        var eventName = eventType.Name;
        if (eventName.EndsWith("Event"))
            eventName = eventName.Substring(0, eventName.Length - 5);
        
        Assert.That(string.Equals(eventName, invokedEvent.Event, StringComparison.CurrentCultureIgnoreCase), $"Event is not of type {eventName} but {invokedEvent.Event}");
    }

    [Test(Description = "Properties")]
    [TestCaseSource(nameof(GetProperties))]
    [Ignore("This test is not finished")]
    public void Properties((string eventName, Property property) propertyInfo)
    {
        var (eventName, expectedProperty) = propertyInfo;
        
        var eventType = _events.EventTypes.FirstOrDefault(x => string.Equals(x.Name, eventName, StringComparison.CurrentCultureIgnoreCase));

        if (eventType == null)
            Assert.Ignore($"Event {eventName} does not exist");
        
        var properties = eventType.GetProperties();
        
        // Get the property by the JsonProperty attribute
        var property = properties.FirstOrDefault(x => string.Equals(x.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName, expectedProperty.Name, StringComparison.CurrentCultureIgnoreCase));

        Assert.That(property, Is.Not.Null, $"Type '{eventType.Name}' does not contain expected property '{expectedProperty.Name}'");

        if (property == null)
            return;
        
        // Check the child properties
        foreach (var expectedChild in expectedProperty.Children)
        {
            var childProperty = property.PropertyType.GetProperties().FirstOrDefault(x => string.Equals(x.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName, expectedChild.Name, StringComparison.CurrentCultureIgnoreCase));
            Assert.That(childProperty, Is.Not.Null, $"Type '{property.PropertyType.Name}' does not contain expected child property '{expectedChild.Name}'");
            
            // Check the child's children
            foreach (var expectedGrandChild in expectedChild.Children)
            {
                var childChildProperty = childProperty.PropertyType.GetProperties().FirstOrDefault(x => string.Equals(x.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName, expectedGrandChild.Name, StringComparison.CurrentCultureIgnoreCase));
                Assert.That(childChildProperty, Is.Not.Null, $"Type '{childProperty.PropertyType.Name}' does not contain expected child property '{expectedGrandChild.Name}'");
            }
        }
    }

    private static string GetText()
    {
        if (!File.Exists("Journal_Manual_v37.pdf"))
        {
            // Download Journal Manual PDF
            var httpClient = new HttpClient();
            var pdf = httpClient
                .GetByteArrayAsync("https://hosting.zaonce.net/community/journal/v37/Journal_Manual_v37.pdf")
                .GetAwaiter().GetResult();
            File.WriteAllBytes("Journal_Manual_v37.pdf", pdf);
        }

        // Extract text from PDF
        var pdfReader = new PdfReader("Journal_Manual_v37.pdf");
        var pdfDocument = new PdfDocument(pdfReader);

        var text = new StringBuilder();
        
        for (var i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
        {
            var page = pdfDocument.GetPage(i);
            var strategy = new SimpleTextExtractionStrategy();
            var currentText = PdfTextExtractor.GetTextFromPage(page, strategy);
            text.Append(currentText);
        }
        
        File.WriteAllText("Journal_Manual_v37.txt", text.ToString());

        return text.ToString();
    }
    
    private static IEnumerable<(int chapter, int subchapter, string name)> GetChapters()
    {
        var text = GetText();

        return Regex.Matches(text.ToString(), @"^(\d{1,2})\.(\d{1,2}) ([^ ]*)", RegexOptions.Multiline)
            .Where(x =>
                !x.Value.StartsWith("1.") &&
                !x.Value.StartsWith("2.") &&
                !x.Value.StartsWith("3.") &&
                !x.Value.StartsWith("15."))
            .Select(x => (int.Parse(x.Groups[1].Value), int.Parse(x.Groups[2].Value), x.Groups[3].Value));
    }
    
    private static IEnumerable<string> GetJsonExamples()
    {
        var text = GetText();
        
        return Regex
            .Matches(text.ToString(), @"\{(?=\s*""timestamp""\s*:)(?:[^{}]|(?<Open>\{)|(?<-Open>\}))*(?(Open)(?!))\}")
            .Select(x => x.Value.ReplaceLineEndings()
                .Replace("“", "\"")
                .Replace("”", "\"")
                .Replace("‘", "'")
                .Replace("’", "'")
                .Replace("\n", "")
                .Replace("\r", ""));
    }

    private static IEnumerable<(string eventName, Property property)> GetProperties()
    {
        var chapters = GetChapterText();
        var properties = new List<(string eventName, Property property)>();

        foreach (var chapter in chapters)
        {
            var eventName = Regex.Match(chapter, @"^(\d{1,2})\.(\d{1,2}) ([^ ]*)").Groups[3].Value;
            
            if(string.IsNullOrEmpty(eventName))
                continue;

            eventName += "Event";

            var chapterProperties = GetPropertiesFromChapter(chapter).ToArray();
            properties.AddRange(chapterProperties.Select(x => (eventName, x)));
        }

        return properties;
    }

    private static IEnumerable<string> GetChapterText()
    {
        var text = GetText();
        var headings = GetChapters().ToArray();
        var lines = text.Split('\n').ToList();

        var currentIndex = 0;

        foreach (var heading in headings)
        {
            var chapterText = new StringBuilder();

            // Append all the text until the line is the next heading
            var nextIndex = lines.FindIndex(x =>
                x.StartsWith($"{heading.chapter}.{heading.subchapter} {heading.name}"));
            if (nextIndex == -1) nextIndex = lines.Count - 1;

            var chapterLines = lines.GetRange(Math.Max(0, currentIndex), Math.Max(nextIndex - currentIndex, 0));
            chapterText.Append(string.Join("\n", chapterLines));
            chapterText.Append('\n');

            currentIndex = nextIndex;

            yield return chapterText.ToString();
        }
    }

    private static IEnumerable<Property> GetPropertiesFromChapter(string text)
    {
        var parameters = new List<Property>();
        var lines = text.Split('\n');

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();

            if (trimmedLine.StartsWith("•"))
            {
                var rootParameter = Property.FromLine(trimmedLine, null);
                if (rootParameter.HasValue)
                    parameters.Add(rootParameter.Value);
            }
            else if (trimmedLine.StartsWith("o") && parameters.Count > 0)
            {
                var childParameter = Property.FromLine(trimmedLine, parameters[^1].Name);
                if (childParameter.HasValue)
                    parameters[^1].Children.Add(childParameter.Value);
            }
            else if (trimmedLine.StartsWith("▪") && parameters.Count > 0 && parameters[^1].Children.Count > 0)
            {
                var grandchildParameter = Property.FromLine(trimmedLine, parameters[^1].Children[^1].Name);
                if (grandchildParameter.HasValue)
                    parameters[^1].Children[^1].Children.Add(grandchildParameter.Value);  
            }
        }

        return parameters;
    }

    public readonly struct Property
    {
        public string Name { get; init; }
        public string? Parent { get; init; }
        public IList<Property> Children { get; init; }

        public Property(string name, string? parent)
        {
            Name = name;
            Parent = parent;
            Children = new List<Property>();
        }
        
        public static Property? FromLine(string line, string? parent)
        {
            var parameterName = Regex.Match(line, @"^.{1} ([a-zA-Z]+)").Groups[1].Value.Trim();

            if (string.IsNullOrEmpty(parameterName))
                return null;
            
            return new Property(parameterName, parent);
        }
    }
}