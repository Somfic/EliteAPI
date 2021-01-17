using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Provider;
using EliteAPI.Event.Provider.Abstractions;
using FluentAssertions.Json;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace EliteAPI.Tests
{
    public class Events
    {
        [Theory]
        [MemberData(nameof(Entries))]
        public async Task Event(string json)
        {
            IEventProvider provider = new EventProvider(Mock.Of<ILogger<EventProvider>>());

            EventBase parsed = await provider.ProcessJsonEvent(json);

            var expected = JToken.Parse(json);
            var actual = JToken.Parse(JsonConvert.SerializeObject(parsed));

            actual.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> Entries => new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Test cases")).GetFiles().ToList().SelectMany(x =>
            File.ReadAllLines(x.FullName).ToList().Select(line => new object[] { line }));
    }
}