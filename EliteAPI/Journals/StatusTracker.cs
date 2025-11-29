using System.Collections.Generic;
using System.Linq;
using EliteAPI.Events;

namespace EliteAPI.Journals;

public class StatusTracker
{
    private readonly object _lock = new();
    private Dictionary<string, dynamic> _previousState = new();

    /// <summary>
    /// Gets the names of fields that changed between the previous state and the new paths.
    /// Only includes fields from the Status event (excludes the EliteAPI. prefix and .Status. portion).
    /// Returns an empty list on the first update (when there is no previous state).
    /// </summary>
    public List<string> GetChangedFieldNames(List<EventPath> newPaths)
    {
        lock (_lock)
        {
            var changedFields = new List<string>();

            // If this is the first update (no previous state), don't report any changes
            if (_previousState.Count == 0)
                return changedFields;

            foreach (var path in newPaths)
            {
                // Extract the field name from paths like "EliteAPI.Gear" or "EliteAPI.Fuel.FuelMain"
                // Note: WithPath() converts ".." to "." so paths have single dot after EliteAPI
                var fullPath = path.Path;

                // Check if this value changed
                var hasChanged = false;

                if (_previousState.TryGetValue(fullPath, out var previousValue))
                {
                    // Compare values - need to handle different types
                    hasChanged = !ValuesEqual(previousValue, path.Value);
                }
                else
                {
                    // New field that didn't exist before (but we already have state, so this is a true new field)
                    hasChanged = true;
                }

                if (hasChanged)
                {
                    // Remove "EliteAPI." prefix to get field path like "Gear" or "Fuel.FuelMain"
                    var fieldPath = fullPath.StartsWith("EliteAPI.")
                        ? fullPath.Substring("EliteAPI.".Length)
                        : fullPath;

                    // Extract the root field name (e.g., "Fuel" from "Fuel.FuelMain")
                    var rootFieldName = fieldPath.Split('.')[0];

                    // Skip internal/synthetic fields that users don't care about
                    if (rootFieldName == "Flags" || rootFieldName == "Flags2" || rootFieldName == "Available")
                        continue;

                    if (!changedFields.Contains(rootFieldName))
                        changedFields.Add(rootFieldName);
                }
            }

            return changedFields;
        }
    }

    /// <summary>
    /// Updates the tracker with the new state.
    /// </summary>
    public void UpdateState(List<EventPath> paths)
    {
        lock (_lock)
        {
            _previousState.Clear();
            foreach (var path in paths)
            {
                _previousState[path.Path] = path.Value;
            }
        }
    }

    private static bool ValuesEqual(dynamic a, dynamic b)
    {
        // Handle null cases
        if (a == null && b == null) return true;
        if (a == null || b == null) return false;

        // For value types and strings, use Equals
        if (a.GetType().IsValueType || a is string)
        {
            return a.Equals(b);
        }

        // For reference types, try to compare
        return a == b;
    }
}
