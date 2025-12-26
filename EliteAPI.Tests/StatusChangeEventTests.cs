using EliteAPI;
using FluentAssertions;

namespace EliteAPI.Tests;

public class StatusChangeEventTests
{
    [Test]
    public void FiresStatusEvent_WhenStatusJsonProcessed()
    {
        var api = new EliteDangerousApi(null, null);
        var statusEventFired = false;

        api.OnJson("Status", e => statusEventFired = true);

        var statusJson = """{"event":"Status","Flags":16777216,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson);

        statusEventFired.Should().BeTrue();
    }

    [Test]
    public void FiresChangeEvent_WhenFieldChanges()
    {
        var api = new EliteDangerousApi(null, null);
        var gearChangeEventFired = false;

        api.OnJson("Status.Gear", e => gearChangeEventFired = true);

        // First status: Gear is off (bit 2 = 0)
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson1);

        gearChangeEventFired.Should().BeFalse("first update should not fire change event");

        // Second status: Gear is on (bit 2 = 1, so Flags = 4)
        var statusJson2 = """{"event":"Status","Flags":4,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson2);

        gearChangeEventFired.Should().BeTrue("gear changed from false to true");
    }

    [Test]
    public void DoesNotFireChangeEvent_WhenFieldStaysSame()
    {
        var api = new EliteDangerousApi(null, null);
        var gearChangeEventFired = false;

        api.OnJson("Status.Gear", e => gearChangeEventFired = true);

        // First status: Gear is off
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson1);

        // Second status: Gear still off
        var statusJson2 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson2);

        gearChangeEventFired.Should().BeFalse("gear did not change");
    }

    [Test]
    public void FiresMultipleChangeEvents_WhenMultipleFieldsChange()
    {
        var api = new EliteDangerousApi(null, null);
        var gearChangeEventFired = false;
        var hardpointsChangeEventFired = false;

        api.OnJson("Status.Gear", e => gearChangeEventFired = true);
        api.OnJson("Status.Hardpoints", e => hardpointsChangeEventFired = true);

        // First status: Both off
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson1);

        // Second status: Both on (Gear bit 2 = 4, Hardpoints bit 6 = 64, total = 68)
        var statusJson2 = """{"event":"Status","Flags":68,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson2);

        gearChangeEventFired.Should().BeTrue();
        hardpointsChangeEventFired.Should().BeTrue();
    }

    [Test]
    public void FiresChangeEvent_ForNumericFieldChanges()
    {
        var api = new EliteDangerousApi(null, null);
        var guiFocusChangeEventFired = false;

        api.OnJson("Status.GuiFocus", e => guiFocusChangeEventFired = true);

        // First status: GuiFocus = 0
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson1);

        // Second status: GuiFocus = 3
        var statusJson2 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":3}""";
        api.Invoke(statusJson2);

        guiFocusChangeEventFired.Should().BeTrue();
    }

    [Test]
    public void FiresChangeEvent_ForNestedFieldChanges()
    {
        var api = new EliteDangerousApi(null, null);
        var fuelChangeEventFired = false;

        api.OnJson("Status.Fuel", e => fuelChangeEventFired = true);

        // First status: FuelMain = 32.0
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0,"Fuel":{"FuelMain":32.0,"FuelReservoir":0.5}}""";
        api.Invoke(statusJson1);

        // Second status: FuelMain = 31.5
        var statusJson2 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0,"Fuel":{"FuelMain":31.5,"FuelReservoir":0.5}}""";
        api.Invoke(statusJson2);

        fuelChangeEventFired.Should().BeTrue();
    }

    [Test]
    public void FiresChangeEvent_ForPipsChanges()
    {
        var api = new EliteDangerousApi(null, null);
        var pipsChangeEventFired = false;

        api.OnJson("Status.Pips", e => pipsChangeEventFired = true);

        // First status: Pips = [4,4,4]
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson1);

        // Second status: Pips = [2,8,2]
        var statusJson2 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[2,8,2],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson2);

        pipsChangeEventFired.Should().BeTrue();
    }

    [Test]
    public void FiresEventsInCorrectOrder_StatusThenChanges()
    {
        var api = new EliteDangerousApi(null, null);
        var eventOrder = new List<string>();

        api.OnAllJson(e =>
        {
            eventOrder.Add(e.eventName);
        });

        // First status
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson1);

        eventOrder.Clear();

        // Second status: Gear changes
        var statusJson2 = """{"event":"Status","Flags":4,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson2);

        // Should fire Status event first, then Status.Gear
        eventOrder.Should().HaveCount(2);
        eventOrder[0].Should().Be("Status");
        eventOrder[1].Should().Be("Status.Gear");
    }

    [Test]
    public void OnlyFiresChangeEvent_ForRootField_NotSubfields()
    {
        var api = new EliteDangerousApi(null, null);
        var eventsFired = new List<string>();

        api.OnAllJson(e =>
        {
            if (e.eventName.StartsWith("Status."))
                eventsFired.Add(e.eventName);
        });

        // First status
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0,"Fuel":{"FuelMain":32.0,"FuelReservoir":0.5}}""";
        api.Invoke(statusJson1);

        eventsFired.Clear();

        // Second status: Both FuelMain and FuelReservoir change
        var statusJson2 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0,"Fuel":{"FuelMain":31.5,"FuelReservoir":0.4}}""";
        api.Invoke(statusJson2);

        // Should only fire Status.Fuel once (not Status.Fuel.FuelMain and Status.Fuel.FuelReservoir)
        eventsFired.Should().ContainSingle();
        eventsFired.Should().Contain("Status.Fuel");
    }

    [Test]
    public void DoesNotFireChangeEvents_ForNonStatusEvents()
    {
        var api = new EliteDangerousApi(null, null);
        var changeEventsFired = 0;

        api.OnAllJson(e =>
        {
            if (e.eventName.StartsWith("Status."))
                changeEventsFired++;
        });

        // Process a non-Status event
        var dockedJson = """{"event":"Docked","StationName":"Jameson Memorial","timestamp":"2025-11-29T15:00:00Z"}""";
        api.Invoke(dockedJson);

        changeEventsFired.Should().Be(0, "non-Status events should not trigger change events");
    }

    [Test]
    public void AllowsMultipleHandlers_ForSameChangeEvent()
    {
        var api = new EliteDangerousApi(null, null);
        var handler1Fired = false;
        var handler2Fired = false;

        api.OnJson("Status.Gear", e => handler1Fired = true);
        api.OnJson("Status.Gear", e => handler2Fired = true);

        // First status
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson1);

        // Second status: Gear changes
        var statusJson2 = """{"event":"Status","Flags":4,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0}""";
        api.Invoke(statusJson2);

        handler1Fired.Should().BeTrue();
        handler2Fired.Should().BeTrue();
    }

    [Test]
    public void FiresChangeEvent_ForBalance_WhenItChanges()
    {
        var api = new EliteDangerousApi(null, null);
        var balanceChangeEventFired = false;

        api.OnJson("Status.Balance", e => balanceChangeEventFired = true);

        // First status: Balance = 1000000
        var statusJson1 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0,"Balance":1000000}""";
        api.Invoke(statusJson1);

        // Second status: Balance = 1000500
        var statusJson2 = """{"event":"Status","Flags":0,"Flags2":0,"Pips":[4,4,4],"FireGroup":0,"GuiFocus":0,"Balance":1000500}""";
        api.Invoke(statusJson2);

        balanceChangeEventFired.Should().BeTrue();
    }

    [Test]
    public void DoesNotThrow_WhenJsonIsEmpty()
    {
        var api = new EliteDangerousApi(null, null);
        var anyEventFired = false;

        api.OnAllJson(e => anyEventFired = true);

        var emptyJson = "";
        var invokeAction = () => api.Invoke(emptyJson);

        invokeAction.Should().NotThrow("empty JSON should be handled gracefully");
        anyEventFired.Should().BeFalse("no events should fire for empty JSON");
    }

    [Test]
    public void DoesNotThrow_WhenJsonIsWhitespace()
    {
        var api = new EliteDangerousApi(null, null);
        var anyEventFired = false;

        api.OnAllJson(e => anyEventFired = true);

        var whitespaceJson = "   ";
        var invokeAction = () => api.Invoke(whitespaceJson);

        invokeAction.Should().NotThrow("whitespace JSON should be handled gracefully");
        anyEventFired.Should().BeFalse("no events should fire for whitespace JSON");
    }
}
