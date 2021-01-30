using System;
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

        [Theory(DisplayName = "Events have no public setters")]
        [MemberData(nameof(GetData))]
        public void PrivateSetters(Type type)
        {
            var invalidProperties = type.GetProperties().Where(x => x.SetMethod != null && x.SetMethod.IsPublic);
            invalidProperties.Should().BeEmpty();
        }

        [Theory(DisplayName = "Events contain FromJson method")]
        [MemberData(nameof(GetData))]
        public void HasFromJsonMethod(Type type)
        {
            type.GetMethods().Select(x => x.Name).Should().Contain("FromJson");
        }

        [Theory(DisplayName = "EventHandler contains event methods")]
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