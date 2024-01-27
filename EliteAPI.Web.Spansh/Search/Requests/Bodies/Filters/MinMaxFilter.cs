using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh.Search.Requests;

public class MinMaxFilter
{
    public MinMaxFilter()
    {
        
    }
    
    public MinMaxFilter(double max)
    {
        Max = max;
    }
    
    public MinMaxFilter(double min, double max)
    {
        Min = min;
        Max = max;
    }
    
    [JsonProperty("min")]
    public double Min { get; init; } = 0;

    [JsonProperty("max")]
    public double Max { get; init; } = 1000000;
}