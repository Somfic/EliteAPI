using EliteAPI.Web.EDSM.Commander;
using EliteAPI.Web.EDSM.Status;

namespace EliteAPI.Web.EDSM;

public class EdsmApi : WebApi
{
    public EdsmApi(IServiceProvider services) : base(services)
    {
        Status = AddCategory<StatusApi>();
        Commander = AddCategory<CommanderApi>();
    }

    public override string BaseUrl => "https://www.edsm.net/";

    public StatusApi Status { get; }

    public CommanderApi Commander { get; }
}