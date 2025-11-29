using EliteAPI.Events;
using EliteAPI.Journals;
using FluentAssertions;
using ValueType = EliteAPI.Events.ValueType;

namespace EliteAPI.Tests;

public class StatusTrackerTests
{
    [Test]
    public void DetectsFieldChange_WhenBooleanValueChanges()
    {
        var tracker = new StatusTracker();

        // First update: Gear is false
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.Gear", false, ValueType.Boolean),
            new("EliteAPI.Hardpoints", false, ValueType.Boolean)
        };
        tracker.UpdateState(initialPaths);

        // Second update: Gear changes to true
        var updatedPaths = new List<EventPath>
        {
            new("EliteAPI.Gear", true, ValueType.Boolean),
            new("EliteAPI.Hardpoints", false, ValueType.Boolean)
        };

        var changedFields = tracker.GetChangedFieldNames(updatedPaths);

        changedFields.Should().ContainSingle();
        changedFields.Should().Contain("Gear");
    }

    [Test]
    public void DetectsFieldChange_WhenNumericValueChanges()
    {
        var tracker = new StatusTracker();

        // First update: GuiFocus is 0
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.GuiFocus", 0, ValueType.Number),
            new("EliteAPI.FireGroup", 1, ValueType.Number)
        };
        tracker.UpdateState(initialPaths);

        // Second update: GuiFocus changes to 3
        var updatedPaths = new List<EventPath>
        {
            new("EliteAPI.GuiFocus", 3, ValueType.Number),
            new("EliteAPI.FireGroup", 1, ValueType.Number)
        };

        var changedFields = tracker.GetChangedFieldNames(updatedPaths);

        changedFields.Should().ContainSingle();
        changedFields.Should().Contain("GuiFocus");
    }

    [Test]
    public void DetectsFieldChange_WhenDecimalValueChanges()
    {
        var tracker = new StatusTracker();

        // First update: FuelMain is 32.0
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.Fuel.FuelMain", 32.0m, ValueType.Decimal),
            new("EliteAPI.Fuel.FuelReservoir", 0.5m, ValueType.Decimal)
        };
        tracker.UpdateState(initialPaths);

        // Second update: FuelMain changes to 31.5
        var updatedPaths = new List<EventPath>
        {
            new("EliteAPI.Fuel.FuelMain", 31.5m, ValueType.Decimal),
            new("EliteAPI.Fuel.FuelReservoir", 0.5m, ValueType.Decimal)
        };

        var changedFields = tracker.GetChangedFieldNames(updatedPaths);

        // Should detect "Fuel" as the root field that changed
        changedFields.Should().ContainSingle();
        changedFields.Should().Contain("Fuel");
    }

    [Test]
    public void DetectsMultipleFieldChanges()
    {
        var tracker = new StatusTracker();

        // First update
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.Gear", false, ValueType.Boolean),
            new("EliteAPI.Hardpoints", false, ValueType.Boolean),
            new("EliteAPI.GuiFocus", 0, ValueType.Number)
        };
        tracker.UpdateState(initialPaths);

        // Second update: Multiple fields change
        var updatedPaths = new List<EventPath>
        {
            new("EliteAPI.Gear", true, ValueType.Boolean),
            new("EliteAPI.Hardpoints", true, ValueType.Boolean),
            new("EliteAPI.GuiFocus", 0, ValueType.Number)
        };

        var changedFields = tracker.GetChangedFieldNames(updatedPaths);

        changedFields.Should().HaveCount(2);
        changedFields.Should().Contain("Gear");
        changedFields.Should().Contain("Hardpoints");
    }

    [Test]
    public void ReturnsEmptyList_WhenNoFieldsChange()
    {
        var tracker = new StatusTracker();

        // First update
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.Gear", false, ValueType.Boolean),
            new("EliteAPI.GuiFocus", 0, ValueType.Number)
        };
        tracker.UpdateState(initialPaths);

        // Second update: Same values
        var updatedPaths = new List<EventPath>
        {
            new("EliteAPI.Gear", false, ValueType.Boolean),
            new("EliteAPI.GuiFocus", 0, ValueType.Number)
        };

        var changedFields = tracker.GetChangedFieldNames(updatedPaths);

        changedFields.Should().BeEmpty();
    }

    [Test]
    public void ReturnsEmptyList_OnFirstUpdate()
    {
        var tracker = new StatusTracker();

        // First update (no previous state)
        var paths = new List<EventPath>
        {
            new("EliteAPI.Gear", false, ValueType.Boolean),
            new("EliteAPI.Hardpoints", false, ValueType.Boolean),
            new("EliteAPI.GuiFocus", 0, ValueType.Number)
        };

        var changedFields = tracker.GetChangedFieldNames(paths);

        // First update should not report any changes (no previous state to compare against)
        changedFields.Should().BeEmpty();
    }

    [Test]
    public void ExtractsRootFieldName_FromNestedPath()
    {
        var tracker = new StatusTracker();

        // First update
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.Fuel.FuelMain", 32.0m, ValueType.Decimal),
            new("EliteAPI.Fuel.FuelReservoir", 0.5m, ValueType.Decimal),
            new("EliteAPI.Destination.System", 123456789L, ValueType.Number)
        };
        tracker.UpdateState(initialPaths);

        // Second update: Change nested field
        var updatedPaths = new List<EventPath>
        {
            new("EliteAPI.Fuel.FuelMain", 31.0m, ValueType.Decimal),
            new("EliteAPI.Fuel.FuelReservoir", 0.4m, ValueType.Decimal),
            new("EliteAPI.Destination.System", 987654321L, ValueType.Number)
        };

        var changedFields = tracker.GetChangedFieldNames(updatedPaths);

        // Should detect root fields: "Fuel" and "Destination"
        changedFields.Should().HaveCount(2);
        changedFields.Should().Contain("Fuel");
        changedFields.Should().Contain("Destination");
    }

    [Test]
    public void OnlyReportsRootFieldOnce_WhenMultipleSubfieldsChange()
    {
        var tracker = new StatusTracker();

        // First update
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.Fuel.FuelMain", 32.0m, ValueType.Decimal),
            new("EliteAPI.Fuel.FuelReservoir", 0.5m, ValueType.Decimal)
        };
        tracker.UpdateState(initialPaths);

        // Second update: Both Fuel subfields change
        var updatedPaths = new List<EventPath>
        {
            new("EliteAPI.Fuel.FuelMain", 31.0m, ValueType.Decimal),
            new("EliteAPI.Fuel.FuelReservoir", 0.4m, ValueType.Decimal)
        };

        var changedFields = tracker.GetChangedFieldNames(updatedPaths);

        // Should only report "Fuel" once, even though two subfields changed
        changedFields.Should().ContainSingle();
        changedFields.Should().Contain("Fuel");
    }

    [Test]
    public void HandlesStringValueChanges()
    {
        var tracker = new StatusTracker();

        // First update
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.LegalState", "Clean", ValueType.String)
        };
        tracker.UpdateState(initialPaths);

        // Second update: LegalState changes
        var updatedPaths = new List<EventPath>
        {
            new("EliteAPI.LegalState", "Wanted", ValueType.String)
        };

        var changedFields = tracker.GetChangedFieldNames(updatedPaths);

        changedFields.Should().ContainSingle();
        changedFields.Should().Contain("LegalState");
    }

    [Test]
    public void HandlesPipsArrayChanges()
    {
        var tracker = new StatusTracker();

        // First update
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.Pips.Systems", 2, ValueType.Number),
            new("EliteAPI.Pips.Engines", 8, ValueType.Number),
            new("EliteAPI.Pips.Weapons", 2, ValueType.Number)
        };
        tracker.UpdateState(initialPaths);

        // Second update: Pips change
        var updatedPaths = new List<EventPath>
        {
            new("EliteAPI.Pips.Systems", 4, ValueType.Number),
            new("EliteAPI.Pips.Engines", 4, ValueType.Number),
            new("EliteAPI.Pips.Weapons", 4, ValueType.Number)
        };

        var changedFields = tracker.GetChangedFieldNames(updatedPaths);

        // Should detect "Pips" as changed (only once, even though all 3 subfields changed)
        changedFields.Should().ContainSingle();
        changedFields.Should().Contain("Pips");
    }

    [Test]
    public void IsThreadSafe_WhenAccessedConcurrently()
    {
        var tracker = new StatusTracker();

        // Initialize
        var initialPaths = new List<EventPath>
        {
            new("EliteAPI.Gear", false, ValueType.Boolean)
        };
        tracker.UpdateState(initialPaths);

        // Simulate concurrent access
        var tasks = new List<Task>();
        for (int i = 0; i < 100; i++)
        {
            var value = i % 2 == 0;
            tasks.Add(Task.Run(() =>
            {
                var paths = new List<EventPath>
                {
                    new("EliteAPI.Gear", value, ValueType.Boolean)
                };
                tracker.GetChangedFieldNames(paths);
                tracker.UpdateState(paths);
            }));
        }

        // Should not throw
        var act = () => Task.WaitAll(tasks.ToArray());
        act.Should().NotThrow();
    }
}
