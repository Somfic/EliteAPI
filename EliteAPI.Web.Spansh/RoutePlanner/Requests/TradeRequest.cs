using EliteAPI.Web.Attributes;
using EliteAPI.Web.Models;

namespace EliteAPI.Web.Spansh.RoutePlanner.Requests;

public class TradeRequest : IWebApiRequest
{
    public TradeRequest(string startingSystem, string startingStation, int range, int capacity)
    {
        StartingSystem = startingSystem;
        StartingStation = startingStation;
        JumpRange = range;
        CargoCapacity = capacity;
    }

    [QueryParameter("system")]
    public string StartingSystem { get; init; }
    
    [QueryParameter("station")]
    public string StartingStation { get; init; }
    
    [QueryParameter("starting_capital")]
    public int StartingCapital { get; init; } = 100_000_000;

    [QueryParameter("max_hop_distance")] 
    public int JumpRange { get; init; }

    [QueryParameter("max_cargo")] 
    public int CargoCapacity { get; init; }
    
    [QueryParameter("max_hops")]
    public int AmountOfStops { get; init; } = 5;
    
    [QueryParameter("max_system_distance")]
    public int MaxDistanceToArrival { get; init; } = 10_000;
    
    [QueryParameter("max_price_age")]
    public int MaxPriceAge { get; init; } = 60 * 60 * 24 * 7; // 7 days
    
    [QueryParameter("requires_large_pad")]
    public bool RequiresLargePad { get; init; } = false;
    
    [QueryParameter("allow_planetary")]
    public bool AllowPlanetary { get; init; } = false;
    
    [QueryParameter("allow_prohibited")]
    public bool AllowProhibited { get; init; } = false;
    
    [QueryParameter("permit")]
    public bool AllowPermitSystems { get; init; } = false;
    
    [QueryParameter("unique")]
    public bool AvoidLoops { get; init; } = false;
    
    public string Endpoint => "trade/route";
    public HttpMethod Method => HttpMethod.Post;
}