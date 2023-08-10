namespace EliteAPI.Web.Attributes;

/// <summary>A parameter in the query of a request.</summary>
[AttributeUsage(AttributeTargets.Property)]
public class QueryParameterAttribute : Attribute
{
    public QueryParameterAttribute(string key)
    {
        Key = key;
    }

    /// <summary>The key of the parameter in the query.</summary>
    public string Key { get; }
}