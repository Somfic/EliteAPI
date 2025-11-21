using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Tests;

public class Flattening
{
    [Test]
    public void OneField()
    {
        var json = """{ "test": 1 }""";
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
        var json = """{ "test1": 1, "test2": "value", "test3": true }""";
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
        var json = """{ "items": [1, 2, 3] }""";
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
        var json = """{ "items": [ { "nested": 1 }, { "nested": "2" }, { "nested": false } ] }""";
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

    [Test]
    public void DecimalField()
    {
        var json = """{ "price": 19.99 }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("price", 19.99m, JsonType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MultipleDecimalFields()
    {
        var json = """{ "price": 19.99, "tax": 1.50, "total": 21.49 }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("price", 19.99m, JsonType.Decimal),
            new JsonPath("tax", 1.50m, JsonType.Decimal),
            new JsonPath("total", 21.49m, JsonType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void DateTimeField()
    {
        var json = """{ "timestamp": "2025-11-21T10:30:00Z" }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("timestamp", DateTime.Parse("2025-11-21T10:30:00Z"), JsonType.DateTime)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MultipleDateTimeFields()
    {
        var json = """{ "createdAt": "2025-11-21T10:30:00Z", "updatedAt": "2025-11-21T15:45:00Z" }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("createdAt", DateTime.Parse("2025-11-21T10:30:00Z"), JsonType.DateTime),
            new JsonPath("updatedAt", DateTime.Parse("2025-11-21T15:45:00Z"), JsonType.DateTime)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MixedTypesWithDecimalAndDateTime()
    {
        var json = """{ "id": 1, "name": "Product", "price": 29.99, "created": "2025-11-21T10:00:00Z", "active": true }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("id", 1, JsonType.Number),
            new JsonPath("name", "Product", JsonType.String),
            new JsonPath("price", 29.99m, JsonType.Decimal),
            new JsonPath("created", DateTime.Parse("2025-11-21T10:00:00Z"), JsonType.DateTime),
            new JsonPath("active", true, JsonType.Boolean)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void SimpleNestedObject()
    {
        var json = """{ "user": { "name": "John", "age": 30 } }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("user.name", "John", JsonType.String),
            new JsonPath("user.age", 30, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void DeeplyNestedObject()
    {
        var json = """{ "level1": { "level2": { "level3": { "value": "deep" } } } }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("level1.level2.level3.value", "deep", JsonType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NestedObjectWithMixedTypes()
    {
        var json = """{ "product": { "id": 1, "name": "Widget", "price": 19.99, "created": "2025-11-21T10:00:00Z", "inStock": true } }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("product.id", 1, JsonType.Number),
            new JsonPath("product.name", "Widget", JsonType.String),
            new JsonPath("product.price", 19.99m, JsonType.Decimal),
            new JsonPath("product.created", DateTime.Parse("2025-11-21T10:00:00Z"), JsonType.DateTime),
            new JsonPath("product.inStock", true, JsonType.Boolean)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MultipleNestedObjects()
    {
        var json = """{ "user": { "name": "John", "age": 30 }, "address": { "city": "NYC", "zip": 10001 } }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("user.name", "John", JsonType.String),
            new JsonPath("user.age", 30, JsonType.Number),
            new JsonPath("address.city", "NYC", JsonType.String),
            new JsonPath("address.zip", 10001, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NestedObjectWithDecimalAndDateTime()
    {
        var json = """{ "transaction": { "amount": 99.99, "fee": 2.50, "timestamp": "2025-11-21T14:30:00Z" } }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("transaction.amount", 99.99m, JsonType.Decimal),
            new JsonPath("transaction.fee", 2.50m, JsonType.Decimal),
            new JsonPath("transaction.timestamp", DateTime.Parse("2025-11-21T14:30:00Z"), JsonType.DateTime)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NestedObjectWithArrays()
    {
        var json = """{ "user": { "name": "John", "scores": [95, 87, 92] } }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("user.name", "John", JsonType.String),
            new JsonPath("user.scores[0]", 95, JsonType.Number),
            new JsonPath("user.scores[1]", 87, JsonType.Number),
            new JsonPath("user.scores[2]", 92, JsonType.Number),
            new JsonPath("user.scores.Length", 3, JsonType.Number)
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
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("order.id", 123, JsonType.Number),
            new JsonPath("order.customer.name", "Jane Doe", JsonType.String),
            new JsonPath("order.customer.email", "jane@example.com", JsonType.String),
            new JsonPath("order.items[0].name", "Item1", JsonType.String),
            new JsonPath("order.items[0].price", 10.50m, JsonType.Decimal),
            new JsonPath("order.items[1].name", "Item2", JsonType.String),
            new JsonPath("order.items[1].price", 25.99m, JsonType.Decimal),
            new JsonPath("order.items.Length", 2, JsonType.Number),
            new JsonPath("order.total", 36.49m, JsonType.Decimal),
            new JsonPath("order.orderDate", DateTime.Parse("2025-11-21T09:00:00Z"), JsonType.DateTime)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void EmptyObject()
    {
        var json = """{ "empty": {} }""";
        var paths = FlattenJson(json);

        var expected = Array.Empty<JsonPath>();

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void EmptyArray()
    {
        var json = """{ "items": [] }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("items.Length", 0, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NullValues()
    {
        var json = """{ "name": null, "age": 30 }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("age", 30, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NegativeNumbers()
    {
        var json = """{ "temperature": -15, "balance": -100 }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("temperature", -15, JsonType.Number),
            new JsonPath("balance", -100, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NegativeDecimals()
    {
        var json = """{ "balance": -99.99, "adjustment": -5.50 }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("balance", -99.99m, JsonType.Decimal),
            new JsonPath("adjustment", -5.50m, JsonType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ZeroValues()
    {
        var json = """{ "count": 0, "price": 0.0, "active": false }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("count", 0, JsonType.Number),
            new JsonPath("price", 0.0m, JsonType.Decimal),
            new JsonPath("active", false, JsonType.Boolean)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void EmptyString()
    {
        var json = """{ "name": "", "description": "text" }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("name", "", JsonType.String),
            new JsonPath("description", "text", JsonType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ArrayOfDecimals()
    {
        var json = """{ "prices": [19.99, 29.99, 39.99] }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("prices[0]", 19.99m, JsonType.Decimal),
            new JsonPath("prices[1]", 29.99m, JsonType.Decimal),
            new JsonPath("prices[2]", 39.99m, JsonType.Decimal),
            new JsonPath("prices.Length", 3, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ArrayOfDateTimes()
    {
        var json = """{ "timestamps": ["2025-11-21T10:00:00Z", "2025-11-21T11:00:00Z", "2025-11-21T12:00:00Z"] }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("timestamps[0]", DateTime.Parse("2025-11-21T10:00:00Z"), JsonType.DateTime),
            new JsonPath("timestamps[1]", DateTime.Parse("2025-11-21T11:00:00Z"), JsonType.DateTime),
            new JsonPath("timestamps[2]", DateTime.Parse("2025-11-21T12:00:00Z"), JsonType.DateTime),
            new JsonPath("timestamps.Length", 3, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MixedTypeArray()
    {
        var json = """{ "mixed": [1, "text", true, 2.5] }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("mixed[0]", 1, JsonType.Number),
            new JsonPath("mixed[1]", "text", JsonType.String),
            new JsonPath("mixed[2]", true, JsonType.Boolean),
            new JsonPath("mixed[3]", 2.5m, JsonType.Decimal),
            new JsonPath("mixed.Length", 4, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void VeryLargeDecimal()
    {
        var json = """{ "bigNumber": 999999999.99 }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("bigNumber", 999999999.99m, JsonType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void VerySmallDecimal()
    {
        var json = """{ "smallNumber": 0.0001 }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("smallNumber", 0.0001m, JsonType.Decimal)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void StringWithSpecialCharacters()
    {
        var json = """{ "text": "Hello \"World\"\nNew Line\tTab" }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("text", "Hello \"World\"\nNew Line\tTab", JsonType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void StringWithUnicode()
    {
        var json = """{ "greeting": "Hello 🌍 World", "emoji": "😀" }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("greeting", "Hello 🌍 World", JsonType.String),
            new JsonPath("emoji", "😀", JsonType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void VeryLongString()
    {
        var longText = new string('a', 10000);
        var json = $$"""{ "longText": "{{longText}}" }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("longText", longText, JsonType.String)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NullInNestedObject()
    {
        var json = """{ "user": { "name": "John", "email": null, "age": 30 } }""";
        var paths = FlattenJson(json);

        var expected = new[]
        {
            new JsonPath("user.name", "John", JsonType.String),
            new JsonPath("user.age", 30, JsonType.Number)
        };

        paths.Should().BeEquivalentTo(expected);
    }

    private static List<JsonPath> FlattenJson(string json)
    {
        // TODO: call flattening function
        // arrays need Length 
        // key + localisation
        // controls mapping

        List<JsonPath> temp = [];
        var jToken = JToken.Parse(json);
        foreach (var jValue in jToken.GetLeafValues())
        {
            var jpath = jValue.ToCustomJsonPath();
            // Skips values that are null
            if (!(string.IsNullOrWhiteSpace(jpath.Path) || string.IsNullOrWhiteSpace(jpath.Path))) temp.Add(jpath);
        }

        return temp;
    }
}
