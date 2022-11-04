using EliteAPI.Abstractions.Bindings.Models;

namespace EliteAPI.Abstractions.Bindings;

/// <summary>Helper for converting between XML and bindings.</summary>
public interface IBindingsParser
{
    IReadOnlyCollection<Binding> Parse(string xml);
}