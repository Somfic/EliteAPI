using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Events;
using EliteAPI.Events;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Tests.JournalManual;

[TestFixture]
public class JournalManual
{
    private static IEvents _events;

    [OneTimeSetUp]
    public void Setup()
    {
        var eventParser = new EventParser(Mock.Of<IServiceProvider>());
        eventParser.Use<LocalisedConverter>();;
        _events = new Events.Events(Mock.Of<ILogger<Events.Events>>(), eventParser);
        _events.Register();
    }

    [Test(Description = "Events")]
    [TestCaseSource(nameof(GetEvents))]
    public void Event(string @event)
    {
        @event += "Event";
        
        Assert.That(_events.EventTypes.Select(x => x.Name), Does.Contain(@event));
    }

    [Test(Description = "Json Examples")]
    [TestCaseSource(nameof(GetJsonExamples))]
    public void Json(string json)
    {
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

        _events.Invoke(json, new EventContext());
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

        return text.ToString();
    }
    
    private static IEnumerable<string> GetEvents()
    {
        var text = GetText();

        return Regex.Matches(text.ToString(), @"^(\d{1,2})\.(\d{1,2}) ([^ ]*)", RegexOptions.Multiline)
            .Where(x =>
                !x.Value.StartsWith("1.") &&
                !x.Value.StartsWith("2.") &&
                !x.Value.StartsWith("3.") &&
                !x.Value.StartsWith("15."))
            .Select(x => x.Groups[3].Value);
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
}