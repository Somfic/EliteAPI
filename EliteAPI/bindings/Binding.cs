namespace EliteAPI.Bindings;

public readonly struct Binding : IBinding
{
	public string Device { get; init; }

	public string Key { get; init; }

	public IBinding[]? Modifiers { get; init; }

	public Binding(string device, string key, IBinding[]? modifiers = null)
	{
		Device = device;
		Key = key;
		Modifiers = modifiers;

	}
}
