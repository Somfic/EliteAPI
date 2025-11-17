using FluentAssertions;

namespace EliteAPI.Tests;

public class Flattening
{
    [Test]
    public void OneField()
    {
        var json = "{ \"test\": 1 }";
        var paths = FlattenJson(json);

        paths.Should().NotBeEmpty();
        paths.Should().HaveCount(1);

        paths[0].Path.Should().Be("test");
        paths[0].Value.Should().Be(1);
        paths[0].Type.Should().Be(JsonType.Number);
    }

    [Test]
    public void MultipleFields()
    {
        var json = "{ \"test1\": 1, \"test2\": \"value\", \"test3\": true }";
        var paths = FlattenJson(json);

        paths.Should().NotBeEmpty();
        paths.Should().HaveCount(3);

        paths[0].Path.Should().Be("test1");
        paths[0].Value.Should().Be(1);
        paths[0].Type.Should().Be(JsonType.Number);

        paths[1].Path.Should().Be("test2");
        paths[1].Value.Should().Be("value");
        paths[1].Type.Should().Be(JsonType.String);

        paths[2].Path.Should().Be("test3");
        paths[2].Value.Should().Be(true);
        paths[2].Type.Should().Be(JsonType.Boolean);
    }
    
    private List<JsonPath> FlattenJson(string json)
    {
        // TODO: call flattening function
        return [];
    } 
}