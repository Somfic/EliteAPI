using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using EliteAPI.Event.Models.Abstractions;

using FluentAssertions;

using Xunit;

namespace EliteAPI.Tests
{
    public class EventStandards
    {
        public static IEnumerable<object[]> GetData() => typeof(EventBase).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(EventBase)) && x.IsClass && !x.IsAbstract).Select(x => new object[] {x});

        [Theory(DisplayName = "No public constructors")]
        [MemberData(nameof(GetData))]
        public void PrivateConstructors(Type type)
        {
            var invalidConstructors = type.GetConstructors().Where(x => x.IsPublic);

            invalidConstructors.Should().BeEmpty();
        }

        [Theory(DisplayName = "Identifiers are strings")]
        [MemberData(nameof(GetData))]
        public void StringIdentifiers(Type type)
        {
            var invalidProperties = type.GetProperties()
                .Where(x => x.PropertyType != typeof(string)
                            && ((x.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase) && !x.Name.EndsWith("paid", StringComparison.OrdinalIgnoreCase))
                                || x.Name.EndsWith("address", StringComparison.OrdinalIgnoreCase)));

            invalidProperties.Should().BeEmpty();
        }

        [Theory(DisplayName = "Slots are strings")]
        [MemberData(nameof(GetData))]
        public void SlotsAreStrings(Type type)
        {
            var invalidProperties = type.GetProperties()
                .Where(x => x.PropertyType != typeof(string)
                            && x.Name.EndsWith("slot", StringComparison.OrdinalIgnoreCase)
                            && !x.Name.EndsWith("paid", StringComparison.OrdinalIgnoreCase));

            invalidProperties.Should().BeEmpty();
        }

        [Theory(DisplayName = "Prices are longs")]
        [MemberData(nameof(GetData))]
        public void PricesAreLongs(Type type)
        {
            var invalidProperties = type.GetProperties()
                .Where(x => x.PropertyType != typeof(long)
                            && (x.Name.EndsWith("price", StringComparison.OrdinalIgnoreCase)
                                || x.Name.EndsWith("cost", StringComparison.OrdinalIgnoreCase)
                                || x.Name.EndsWith("reward", StringComparison.OrdinalIgnoreCase)));

            invalidProperties.Should().BeEmpty();
        }

        [Theory(DisplayName = "Event properties use double")]
        [MemberData(nameof(GetData))]
        public void OnlyDoubles(Type type)
        {
            var invalidProperties = type.GetProperties()
                .Where(x => x.PropertyType == typeof(decimal) || x.PropertyType == typeof(float));

            invalidProperties.Should().BeEmpty();
        }


        [Theory(DisplayName = "Enum usage")]
        [MemberData(nameof(GetData))]
        public void FlagsAreEnums(Type type)
        {
            return; // todo: do enums

            // this test works
            var invalidProperties = type.GetProperties()
                .Where(x => !x.PropertyType.IsEnum && (x.Name.EndsWith("type", StringComparison.OrdinalIgnoreCase) || x.Name.EndsWith("state", StringComparison.OrdinalIgnoreCase)));

            invalidProperties.Should().BeEmpty();
        }

        [Theory(DisplayName = "Use IReadOnlyList for enumerables")]
        [MemberData(nameof(GetData))]
        public void ReadOnlyListForEnumerables(Type type)
        {
            var properties = type.GetProperties();
            var complexProperties = properties.Where(x => !x.PropertyType.IsPrimitive && x.PropertyType != typeof(string));
            var collectionProperties = complexProperties.Where(x => x.PropertyType.GetInterface(nameof(IEnumerable)) != null);

            var invalidProperties = collectionProperties.Where(x => !x.PropertyType.GetInterfaces().Any(n => n.IsGenericType && n.GetGenericTypeDefinition() == typeof(IReadOnlyCollection<>)));

            invalidProperties.Should().BeEmpty();
        }

        [Theory(DisplayName = "No public setters")]
        [MemberData(nameof(GetData))]
        public void PrivateSetters(Type type)
        {
            var invalidProperties = type.GetProperties().Where(x => x.SetMethod != null && x.SetMethod.IsPublic);

            invalidProperties.Should().BeEmpty();
        }

        [Theory(DisplayName = "Contains FromJson method")]
        [MemberData(nameof(GetData))]
        public void HasFromJsonMethod(Type type)
        {
            type.GetMethods().Select(x => x.Name).Should().Contain("FromJson");
        }

        [Theory(DisplayName = "Contains event methods")]
        [MemberData(nameof(GetData))]
        public void HasInvokeMethod(Type type)
        {
            typeof(Event.Handler.EventHandler).GetMethods(BindingFlags.Instance
                                                          | BindingFlags.NonPublic
                                                          | BindingFlags.Public
                                                          | BindingFlags.Static)
                .Where(x => !x.Name.StartsWith("add_")
                            && !x.Name.StartsWith("remove_")
                            && x.GetParameters().Length > 0
                            && x.GetParameters().First().ParameterType.IsSubclassOf(typeof(EventBase)))
                .Select(x => x.Name)
                .Should()
                .Contain($"Invoke{type.Name}");
        }

        [Theory(DisplayName = "EventHandler contains event")]
        [MemberData(nameof(GetData))]
        public void HasEvent(Type type)
        {
            typeof(Event.Handler.EventHandler).GetEvents().Select(x => x.Name).Should().Contain(type.Name);
        }
    }
}