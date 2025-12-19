using System.Linq;

namespace EliteAPI.Bindings;

public readonly struct Binding
{
    public string Device { get; init; }

    public string Key { get; init; }

    public string KeyCode => $"{string.Join("", Modifiers?.Select(m => m.KeyCode) ?? Enumerable.Empty<string>())}{BindingsUtils.GetKeyCode(Key)}";

    public Binding[]? Modifiers { get; init; }

    public Binding(string device, string key, Binding[]? modifiers = null)
    {
        Device = device;
        Key = key;
        Modifiers = modifiers;
    }
}
