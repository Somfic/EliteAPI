using EliteAPI.Web.Attributes;

namespace EliteAPI.Web.EDSM;

public abstract class AuthenticatedRequest
{
    [Secret("key")]
    [QueryParameter("apiKey")]
    public string? ApiKey { get; }
}