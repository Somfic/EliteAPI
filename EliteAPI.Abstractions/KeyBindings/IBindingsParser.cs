using EliteAPI.KeyBindings;

namespace EliteAPI.Abstractions.KeyBindings;

/// <summary>Helper for converting between XML and bindings.</summary>
public interface IBindingsParser
{
    Bindings ToBindings(string xml);
}