namespace EliteAPI.Web.Attributes;

/// <summary>A parameter in the body of a request.</summary>
[AttributeUsage(AttributeTargets.Property)]
public class BodyParameterAttribute : Attribute
{
    public BodyParameterAttribute(string key)
    {
        Key = key;
    }

    /// <summary>The key of the parameter in the body.</summary>
    public string Key { get; }
}

/// <summary>A secret value extracted through previous authentication.</summary>
[AttributeUsage(AttributeTargets.Property)]
public class SecretAttribute : Attribute
{
    public SecretAttribute(string key)
    {
        Key = key;
    }

    /// <summary>The key of the secret.</summary>
    public string Key { get; }
}