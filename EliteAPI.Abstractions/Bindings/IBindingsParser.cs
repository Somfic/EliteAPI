using EliteAPI.Bindings;

namespace EliteAPI.Abstractions.Bindings;

/// <summary>Helper for converting between XML and bindings.</summary>
public interface IBindingsParser
{
    IReadOnlyCollection<Binding> Parse(string xml);
}