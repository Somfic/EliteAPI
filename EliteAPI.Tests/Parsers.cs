using EliteAPI.Abstractions.Events;
using EliteAPI.Events;
using Moq;
using Newtonsoft.Json;

namespace EliteAPI.Tests;

[TestFixture]
public class Parsers
{
    private static IEventParser _parser;

    [OneTimeSetUp]
    public void Setup()
    {
        _parser = new EventParser(Mock.Of<IServiceProvider>());
    }

    [Test]
    public void AddLengthToArraysInPaths()
    {
        var json = JsonConvert.SerializeObject(new TestEvent());
        var paths = _parser.ToPaths(json).ToArray();
        
        Assert.Multiple(() =>
        {
            Assert.That(paths.Count(x => x.Path == "Test.TestInt"), Is.EqualTo(1));
            Assert.That(paths.Count(x => x.Path == "Test.TestString"), Is.EqualTo(1));
            Assert.That(paths.Count(x => x.Path == "Test.TestArray.Length"), Is.EqualTo(1));
            Assert.That(paths.Count(x => x.Path.EndsWith(".Length")), Is.EqualTo(1));
            Assert.That(paths.Count(x => x.Path == "Test.TestArray[0].TestInt"), Is.EqualTo(1));
            Assert.That(paths.Count(x => x.Path == "Test.TestArray[0].TestString"), Is.EqualTo(1));
            Assert.That(paths.Count(x => x.Path == "Test.TestArray[1].TestInt"), Is.EqualTo(1));
            Assert.That(paths.Count(x => x.Path == "Test.TestArray[1].TestString"), Is.EqualTo(1));
            Assert.That(paths.Count(x => x.Path == "Test.TestObject.TestInt"), Is.EqualTo(1));
            Assert.That(paths.Count(x => x.Path == "Test.TestObject.TestString"), Is.EqualTo(1));
            
            Assert.That(paths.First(x => x.Path == "Test.TestInt").Value, Is.EqualTo("0"));
            Assert.That(paths.First(x => x.Path == "Test.TestString").Value, Is.EqualTo("\"0\""));
            Assert.That(paths.First(x => x.Path == "Test.TestArray.Length").Value, Is.EqualTo("2"));
            Assert.That(paths.First(x => x.Path == "Test.TestArray[0].TestInt").Value, Is.EqualTo("1"));
            Assert.That(paths.First(x => x.Path == "Test.TestArray[0].TestString").Value, Is.EqualTo("\"1\""));
            Assert.That(paths.First(x => x.Path == "Test.TestArray[1].TestInt").Value, Is.EqualTo("2"));
            Assert.That(paths.First(x => x.Path == "Test.TestArray[1].TestString").Value, Is.EqualTo("\"2\""));
            Assert.That(paths.First(x => x.Path == "Test.TestObject.TestInt").Value, Is.EqualTo("3"));
            Assert.That(paths.First(x => x.Path == "Test.TestObject.TestString").Value, Is.EqualTo("\"3\""));
        });
    }

    private struct TestEvent
    {
        [JsonProperty("event")]
        public string Event => "Test";
        
        [JsonProperty("timestamp")]
        public DateTime Timestamp => DateTime.UtcNow;
        
        public int TestInt => 0;
         
        public string TestString => "0";
            
        public TestData[] TestArray => new[]
        {
            new TestData
            {
                TestInt = 1,
                TestString = "1"
            },
            new TestData
            {
                TestInt = 2,
                TestString = "2"
            }
        };
        
        public TestData TestObject => new TestData
        {
            TestInt = 3,
            TestString = "3"
        };
        
        public struct TestData
        {
            public int TestInt { get; init; }
            
            public string TestString { get; init; }
        }
    }
}