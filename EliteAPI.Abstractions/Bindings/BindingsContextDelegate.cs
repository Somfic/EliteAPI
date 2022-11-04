using EliteAPI.Abstractions.Bindings.Models;

namespace EliteAPI.Abstractions.Bindings;

/// <summary>
/// Handles <see cref="Binding"/>.
/// </summary>
public delegate void BindingsContextDelegate(IReadOnlyCollection<Binding> bindings, BindingsContext context);

/// <summary>
/// Handles <see cref="Binding"/> asynchronously.
/// </summary>
public delegate Task AsyncBindingsContextDelegate(IReadOnlyCollection<Binding> bindings, BindingsContext context);

/// <summary>
/// Handles <see cref="Binding"/>.
/// </summary>
public delegate void BindingsDelegate(IReadOnlyCollection<Binding> bindings);

/// <summary>
/// Handles <see cref="Binding"/> asynchronously.
/// </summary>
public delegate Task AsyncBindingsDelegate(IReadOnlyCollection<Binding> bindings);