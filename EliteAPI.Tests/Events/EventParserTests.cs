using System;
using EliteAPI.Abstractions.Events;
using EliteAPI.Events;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace EliteAPI.Tests.Events
{
    public class EventParserTests
    {
        private readonly EventParser _eventParser;
        
        public EventParserTests()
        {
            _eventParser = new EventParser(Mock.Of<IServiceProvider>());
        }

        [Fact]
        public void ToJson()
        {
            var testEvent = new TestEvent()
            {
                Event = "Tests",
                Test = "Hello World!"
            };

            var result = _eventParser.ToJson(testEvent);
            
            result.Should().NotBeNullOrEmpty();
            result.Should().Contain("\"Event\":\"Tests\"");
            result.Should().Contain("\"Tests\":\"Hello World!\"");

            var parsed = JsonConvert.DeserializeObject<TestEvent>(result);
            
            parsed.Should().NotBeNull();
            parsed!.Event.Should().Be("Tests");
            parsed.Test.Should().Be("Hello World!");
        }

        private class TestEvent : IEvent
        {
            public DateTime Timestamp => DateTime.Now;

            public string Event { get; init; }
            public string Test { get; init; }
        }
    }
}