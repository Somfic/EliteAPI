using EliteAPI.Events;
using EliteAPI.Json;
using FluentAssertions;
using EventValueType = EliteAPI.Events.EventValueType;

namespace EliteAPI.Tests;

public class Flattening
{
    [Test]
    public void OneField()
    {
        var json = """{ "test": 1 }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("test", 1, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MultipleFields()
    {
        var json = """{ "test1": 1, "test2": "value", "test3": true }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("test1", 1, EventValueType.Number),
            new EventPath("test2", "value", EventValueType.String),
            new EventPath("test3", true, EventValueType.Boolean)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void SimpleArray()
    {
        var json = """{ "items": [1, 2, 3] }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("items[0]", 1, EventValueType.Number),
            new EventPath("items[1]", 2, EventValueType.Number),
            new EventPath("items[2]", 3, EventValueType.Number),
            new EventPath("items.Length", 3, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ArrayWithObject()
    {
        var json = """{ "items": [ { "nested": 1 }, { "nested": "2" }, { "nested": false } ] }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("items[0].nested", 1, EventValueType.Number),
            new EventPath("items[1].nested", "2", EventValueType.String),
            new EventPath("items[2].nested", false, EventValueType.Boolean),
            new EventPath("items.Length", 3, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void DecimalField()
    {
        var json = """{ "price": 19.99 }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("price", 19.99m, EventValueType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MultipleDecimalFields()
    {
        var json = """{ "price": 19.99, "tax": 1.50, "total": 21.49 }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("price", 19.99m, EventValueType.Decimal),
            new EventPath("tax", 1.50m, EventValueType.Decimal),
            new EventPath("total", 21.49m, EventValueType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void DateTimeField()
    {
        var json = """{ "timestamp": "2025-11-21T10:30:00Z" }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("timestamp", new DateTime(2025, 11, 21, 10, 30, 0, DateTimeKind.Utc), EventValueType.DateTime)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MultipleDateTimeFields()
    {
        var json = """{ "createdAt": "2025-11-21T10:30:00Z", "updatedAt": "2025-11-21T15:45:00Z" }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("createdAt", new DateTime(2025, 11, 21, 10, 30, 0, DateTimeKind.Utc), EventValueType.DateTime),
            new EventPath("updatedAt", new DateTime(2025, 11, 21, 15, 45, 0, DateTimeKind.Utc), EventValueType.DateTime)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MixedTypesWithDecimalAndDateTime()
    {
        var json = """{ "id": 1, "name": "Product", "price": 29.99, "created": "2025-11-21T10:00:00Z", "active": true }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("id", 1, EventValueType.Number),
            new EventPath("name", "Product", EventValueType.String),
            new EventPath("price", 29.99m, EventValueType.Decimal),
            new EventPath("created", new DateTime(2025, 11, 21, 10, 0, 0, DateTimeKind.Utc), EventValueType.DateTime),
            new EventPath("active", true, EventValueType.Boolean)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void SimpleNestedObject()
    {
        var json = """{ "user": { "name": "John", "age": 30 } }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("user.name", "John", EventValueType.String),
            new EventPath("user.age", 30, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void DeeplyNestedObject()
    {
        var json = """{ "level1": { "level2": { "level3": { "value": "deep" } } } }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("level1.level2.level3.value", "deep", EventValueType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NestedObjectWithMixedTypes()
    {
        var json = """{ "product": { "id": 1, "name": "Widget", "price": 19.99, "created": "2025-11-21T10:00:00Z", "inStock": true } }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("product.id", 1, EventValueType.Number),
            new EventPath("product.name", "Widget", EventValueType.String),
            new EventPath("product.price", 19.99m, EventValueType.Decimal),
            new EventPath("product.created", new DateTime(2025, 11, 21, 10, 0, 0, DateTimeKind.Utc), EventValueType.DateTime),
            new EventPath("product.inStock", true, EventValueType.Boolean)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MultipleNestedObjects()
    {
        var json = """{ "user": { "name": "John", "age": 30 }, "address": { "city": "NYC", "zip": 10001 } }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("user.name", "John", EventValueType.String),
            new EventPath("user.age", 30, EventValueType.Number),
            new EventPath("address.city", "NYC", EventValueType.String),
            new EventPath("address.zip", 10001, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NestedObjectWithDecimalAndDateTime()
    {
        var json = """{ "transaction": { "amount": 99.99, "fee": 2.50, "timestamp": "2025-11-21T14:30:00Z" } }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("transaction.amount", 99.99m, EventValueType.Decimal),
            new EventPath("transaction.fee", 2.50m, EventValueType.Decimal),
            new EventPath("transaction.timestamp", new DateTime(2025, 11, 21, 14, 30, 0, DateTimeKind.Utc), EventValueType.DateTime)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NestedObjectWithArrays()
    {
        var json = """{ "user": { "name": "John", "scores": [95, 87, 92] } }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("user.name", "John", EventValueType.String),
            new EventPath("user.scores[0]", 95, EventValueType.Number),
            new EventPath("user.scores[1]", 87, EventValueType.Number),
            new EventPath("user.scores[2]", 92, EventValueType.Number),
            new EventPath("user.scores.Length", 3, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ComplexNestedStructure()
    {
        var json = """
        {
            "order": {
                "id": 123,
                "customer": {
                    "name": "Jane Doe",
                    "email": "jane@example.com"
                },
                "items": [
                    { "name": "Item1", "price": 10.50 },
                    { "name": "Item2", "price": 25.99 }
                ],
                "total": 36.49,
                "orderDate": "2025-11-21T09:00:00Z"
            }
        }
        """;
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("order.id", 123, EventValueType.Number),
            new EventPath("order.customer.name", "Jane Doe", EventValueType.String),
            new EventPath("order.customer.email", "jane@example.com", EventValueType.String),
            new EventPath("order.items[0].name", "Item1", EventValueType.String),
            new EventPath("order.items[0].price", 10.50m, EventValueType.Decimal),
            new EventPath("order.items[1].name", "Item2", EventValueType.String),
            new EventPath("order.items[1].price", 25.99m, EventValueType.Decimal),
            new EventPath("order.items.Length", 2, EventValueType.Number),
            new EventPath("order.total", 36.49m, EventValueType.Decimal),
            new EventPath("order.orderDate", new DateTime(2025, 11, 21, 9, 0, 0, DateTimeKind.Utc), EventValueType.DateTime)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void EmptyObject()
    {
        var json = """{ "empty": {} }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = Array.Empty<EventPath>();

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void EmptyArray()
    {
        var json = """{ "items": [] }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("items.Length", 0, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NullValues()
    {
        var json = """{ "name": null, "age": 30 }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("age", 30, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NegativeNumbers()
    {
        var json = """{ "temperature": -15, "balance": -100 }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("temperature", -15, EventValueType.Number),
            new EventPath("balance", -100, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NegativeDecimals()
    {
        var json = """{ "balance": -99.99, "adjustment": -5.50 }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("balance", -99.99m, EventValueType.Decimal),
            new EventPath("adjustment", -5.50m, EventValueType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ZeroValues()
    {
        var json = """{ "count": 0, "price": 0.0, "active": false }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("count", 0, EventValueType.Number),
            new EventPath("price", 0.0m, EventValueType.Decimal),
            new EventPath("active", false, EventValueType.Boolean)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void EmptyString()
    {
        var json = """{ "name": "", "description": "text" }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("name", "", EventValueType.String),
            new EventPath("description", "text", EventValueType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ArrayOfDecimals()
    {
        var json = """{ "prices": [19.99, 29.99, 39.99] }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("prices[0]", 19.99m, EventValueType.Decimal),
            new EventPath("prices[1]", 29.99m, EventValueType.Decimal),
            new EventPath("prices[2]", 39.99m, EventValueType.Decimal),
            new EventPath("prices.Length", 3, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ArrayOfDateTimes()
    {
        var json = """{ "timestamps": ["2025-11-21T10:00:00Z", "2025-11-21T11:00:00Z", "2025-11-21T12:00:00Z"] }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("timestamps[0]", new DateTime(2025, 11, 21, 10, 0, 0, DateTimeKind.Utc), EventValueType.DateTime),
            new EventPath("timestamps[1]", new DateTime(2025, 11, 21, 11, 0, 0, DateTimeKind.Utc), EventValueType.DateTime),
            new EventPath("timestamps[2]", new DateTime(2025, 11, 21, 12, 0, 0, DateTimeKind.Utc), EventValueType.DateTime),
            new EventPath("timestamps.Length", 3, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MixedTypeArray()
    {
        var json = """{ "mixed": [1, "text", true, 2.5] }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("mixed[0]", 1, EventValueType.Number),
            new EventPath("mixed[1]", "text", EventValueType.String),
            new EventPath("mixed[2]", true, EventValueType.Boolean),
            new EventPath("mixed[3]", 2.5m, EventValueType.Decimal),
            new EventPath("mixed.Length", 4, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void VeryLargeDecimal()
    {
        var json = """{ "bigNumber": 999999999.99 }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("bigNumber", 999999999.99m, EventValueType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void VerySmallDecimal()
    {
        var json = """{ "smallNumber": 0.0001 }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("smallNumber", 0.0001m, EventValueType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void StringWithSpecialCharacters()
    {
        var json = """{ "text": "Hello \"World\"\nNew Line\tTab" }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("text", "Hello \"World\"\nNew Line\tTab", EventValueType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void StringWithUnicode()
    {
        var json = """{ "greeting": "Hello 🌍 World", "emoji": "😀" }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("greeting", "Hello 🌍 World", EventValueType.String),
            new EventPath("emoji", "😀", EventValueType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void VeryLongString()
    {
        var longText = new string('a', 10000);
        var json = $$"""{ "longText": "{{longText}}" }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("longText", longText, EventValueType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NullInNestedObject()
    {
        var json = """{ "user": { "name": "John", "email": null, "age": 30 } }""";
        var paths = JsonUtils.FlattenJson(json);

        var expected = new[]
        {
            new EventPath("user.name", "John", EventValueType.String),
            new EventPath("user.age", 30, EventValueType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetEventName_WithEmptyString_ReturnsEmptyString()
    {
        var json = "";
        var eventName = JsonUtils.GetEventName(json);

        eventName.Should().BeEmpty();
    }

    [Test]
    public void GetEventName_WithWhitespace_ReturnsEmptyString()
    {
        var json = "   ";
        var eventName = JsonUtils.GetEventName(json);

        eventName.Should().BeEmpty();
    }

    [Test]
    public void GetEventName_WithValidEvent_ReturnsEventName()
    {
        var json = """{ "event": "TestEvent", "timestamp": "2025-01-01T00:00:00Z" }""";
        var eventName = JsonUtils.GetEventName(json);

        eventName.Should().Be("TestEvent");
    }

    [Test]
    public void GetEventName_WithNoEventField_ReturnsEmptyString()
    {
        var json = """{ "timestamp": "2025-01-01T00:00:00Z" }""";
        var eventName = JsonUtils.GetEventName(json);

        eventName.Should().BeEmpty();
    }
}
