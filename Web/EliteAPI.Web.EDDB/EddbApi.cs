using EliteAPI.Web.EDDB.System;

namespace EliteAPI.Web.EDDB;

[Obsolete("EDDB has shut down their API. This API will be removed in a future version of EliteAPI.", true)]
public class EddbApi : WebApi
{
    public EddbApi(IServiceProvider services) : base(services)
    {
        Systems = AddCategory<SystemApi>();
    }

    public override string BaseUrl => "https://eddb.io/";
    
    public SystemApi Systems { get; }
}