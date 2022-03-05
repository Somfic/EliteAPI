using EliteAPI.Web.Spansh.RoutePlanner;
using EliteAPI.Web.Spansh.Utilities;

namespace EliteAPI.Web.Spansh;

public class SpanshApi : WebApi
{
    public SpanshApi(IServiceProvider services) : base(services)
    {
        Routes = AddCategory<RoutePlannerApi>();
        Utilities = AddCategory<UtilitiesApi>();
    }

    public override string BaseUrl => "https://www.spansh.co.uk/api";

    public RoutePlannerApi Routes { get; }

    public UtilitiesApi Utilities { get; }
}