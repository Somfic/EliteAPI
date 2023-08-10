using EliteAPI.Web.Models;
using EliteAPI.Web.Spansh.RoutePlanner;
using EliteAPI.Web.Spansh.Utilities;
using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh;

public class SpanshApi : WebApi
{
    public SpanshApi(IServiceProvider services) : base(services)
    {
        Routes = AddCategory<RoutePlannerApi>();
        Utilities = AddCategory<UtilitiesApi>();
    }

    protected  override string BaseUrl => "https://www.spansh.co.uk/api";

    public RoutePlannerApi Routes { get; }

    internal UtilitiesApi Utilities { get; }
}