using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Provider;
using EliteAPI.Event.Provider.Abstractions;
using FluentAssertions;
using FluentAssertions.Json;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EliteAPI.Tests
{
    public class Events
    {
        private readonly ITestOutputHelper _output;

        public Events(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [ClassData(typeof(EventTestData))]
        public async Task Event(string eventName, string json)
        {
            IEventProvider provider = new EventProvider(Mock.Of<ILogger<EventProvider>>());

            var parsed = await provider.ProcessJsonEvent(json);

            var expected = JToken.Parse(json);
            var actual = JToken.Parse(JsonConvert.SerializeObject(parsed));

            try
            {
                actual.Should().BeEquivalentTo(expected);
            } 
            catch(Exception ex) 
            {
                if (!ex.Message.Contains("has extra property"))
                {
                    throw;
                }
            }

            _output.WriteLine(JsonConvert.SerializeObject(parsed, Formatting.Indented));
        }


        public class EventTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator() => _data.ToList().GetEnumerator();

            private readonly IEnumerable<object[]> _data = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Test cases")).GetFiles().ToList().SelectMany(x => File.ReadAllLines(x.FullName).ToList().Select(line => new object[] { Regex.Match(line, "\"event\":\"(.*?)\"").Groups[1].Value, line }));
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}