using EliteAPI.Web.Models;
using EliteAPI.Web.Spansh.RoutePlanner;
using EliteAPI.Web.Spansh.Search;
using EliteAPI.Web.Spansh.Utilities;
using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh;

public class SpanshApi : WebApi
{
    public SpanshApi(IServiceProvider services) : base(services)
    {
        Routes = AddCategory<RoutePlannerApi>();
        Search = AddCategory<SearchApi>();
        Utilities = AddCategory<UtilitiesApi>();
    }

    protected  override string BaseUrl => "https://www.spansh.co.uk/api";

    public RoutePlannerApi Routes { get; }
    
    public SearchApi Search { get; }

    internal UtilitiesApi Utilities { get; }
}