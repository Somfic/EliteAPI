using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using EliteAPI.Abstractions;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Provider;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Options.Bindings;

using FluentAssertions;

using Microsoft.Extensions.Logging;

using Moq;

using Newtonsoft.Json;

using ProtoBuf;
using ProtoBuf.Meta;

using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace EliteAPI.Tests
{
    public class TestDataEntry
    {
        public Type type { get; init; }

        public IList<string> jsons { get; init; }

        public TestDataEntry(Type type)
        {
            this.type = type;
            this.jsons = new List<string>();
        }

        public override string ToString() => type.ToString();
    }
    
    public class Events
    {
        private static ITestOutputHelper _output;
        private static RpcEncoder _rpcEncoder;

        public Events(ITestOutputHelper output)
        {
            _output = output;
            _rpcEncoder = new RpcEncoder(Mock.Of<ILogger<RpcEncoder>>());

        }

        public static IEnumerable<object[]> GetEventsWithJson()
        {
            var types = typeof(EventBase<>).Assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(IEvent)) && x.IsClass && !x.IsAbstract && !x.IsInterface && !x.Namespace.StartsWith("EliteAPI.Status")).ToList();

            var directory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Test cases"));

            IList<object[]> values = new List<object[]>();

            foreach (var type in types)
            {
                var file = new FileInfo(Path.Combine(directory.FullName, type.Name.Replace("Event", ".json")));
                if (!File.Exists(file.FullName))
                {
                    values.Add(new object[] {new TestDataEntry(type)});
                    continue;
                }

                var jsons = File.ReadAllLines(file.FullName);
                var dataEntry = new TestDataEntry(type);

                foreach (var json in jsons) { dataEntry.jsons.Add(json); }

                values.Add(new object[] {dataEntry});
            }

            return values;
        }

        [Theory(DisplayName = "gRPC compatibility", Skip = "Not implemented yet")]
        [MemberData(nameof(GetEventsWithJson))]
        public async Task GrpcCompatibility(TestDataEntry entry)
        {
            if (entry.jsons.Count == 0)
            {
                _output.WriteLine("File not found, skipping");
                return; //todo: throw warnig
            }

            foreach (var json in entry.jsons)
            {
                IEventProvider provider = new EventProvider(Mock.Of<ILogger<EventProvider>>());

                var startWith = await provider.ProcessJsonEvent(json);

                var serializerStream = _rpcEncoder.Encode(startWith);
                string serialized = Convert.ToBase64String(serializerStream.ToArray());

                byte[] deserialized = Convert.FromBase64String(serialized);
                MemoryStream deserializerStream = new MemoryStream(deserialized);
                var endWith = Serializer.Deserialize(entry.type, deserializerStream);
                
                endWith.Should().BeEquivalentTo(startWith);
            }
        }

        [Theory(DisplayName = "Has correct properties")]
        [MemberData(nameof(GetEventsWithJson))]
        public async Task HasCorrectProperties(TestDataEntry entry)
        {
            if (entry.jsons.Count == 0)
            {
                _output.WriteLine("File not found, skipping");
                return; //todo: throw warning 
            }

            foreach (var json in entry.jsons)
            {
                IEventProvider provider = new EventProvider(Mock.Of<ILogger<EventProvider>>());

                var parsedEvent = await provider.ProcessJsonEvent(json);

                var expectedJson = json;
                var actualJson = JsonConvert.SerializeObject(parsedEvent);

                var expected = JsonConvert.DeserializeObject(expectedJson);
                var actual = JsonConvert.DeserializeObject(actualJson);

                try { actual.Should().BeEquivalentTo(expected); }
                catch (XunitException ex)
                {
                    IEnumerable<string> issues = ex.UserMessage.Split(Environment.NewLine);

                    issues = issues.Where(x => !x.Contains("With configuration:"));
                    issues = issues.Where(x => !x.StartsWith("-"));
                    issues = issues.Where(x =>
                        !Regex.IsMatch(x,
                            "Expected actual to be a dictionary with [0-9]{1,} item\\(s\\), but has additional key\\(s\\)"));
                    issues = issues.Select(x => Regex.Replace(x,
                        "(Expected actual to be a dictionary with [0-9]{1,} item\\(s\\), but it misses key\\(s\\) .*) and has additional key\\(s\\) .*",
                        "$1"));
                    issues = issues.Where(x => !string.IsNullOrWhiteSpace(x));

                    var processedIssues = issues.ToList();

                    if (processedIssues.Any())
                    {
                        _output.WriteLine("Elite: Dangerous event JSON:\n{1}\n\nEliteAPI event JSON:\n{0}",
                            JsonConvert.SerializeObject(actual, Formatting.Indented),
                            JsonConvert.SerializeObject(expected, Formatting.Indented));
                        throw new XunitException(string.Join(Environment.NewLine, processedIssues));
                    }
                }
            }
        }
    }
}