using FluentAssertions;

namespace EliteAPI.Tests;

public class Flattening
{
    [Test]
    public void OneField()
    {
        var json = "{ \"test\": 1 }";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("test", 1, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MultipleFields()
    {
        var json = "{ \"test1\": 1, \"test2\": \"value\", \"test3\": true }";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("test1", 1, JsonType.Number),
            new JsonPath("test2", "value", JsonType.String),
            new JsonPath("test3", true, JsonType.Boolean)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void SimpleArray()
    {
        var json = "{ \"items\": [1, 2, 3] }";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("items[0]", 1, JsonType.Number),
            new JsonPath("items[1]", 2, JsonType.Number),
            new JsonPath("items[2]", 3, JsonType.Number),
            new JsonPath("items.Length", 3, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void ArrayWithObject()
    {
        var json = "{ \"items\": [ { \"nested\": 1 }, { \"nested\": \"2\" }, { \"nested\": false } ] }";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("items[0].nested", 1, JsonType.Number),
            new JsonPath("items[1].nested", "2", JsonType.String),
            new JsonPath("items[2].nested", false, JsonType.Boolean),
            new JsonPath("items.Length", 3, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    private List<JsonPath> FlattenJson(string json)
    {
        // TODO: call flattening function
        return [];
    } 
}