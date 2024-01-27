using EliteAPI.Web.Spansh;
using EliteAPI.Web.Spansh.RoutePlanner.Requests;
using EliteAPI.Web.Spansh.Search.Requests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var spansh = new HostBuilder()
    .ConfigureServices(s =>
    {
        s.AddWebApi<SpanshApi>();
    })
    .ConfigureLogging(s =>
    {
        s.AddSimpleConsole();
        s.AddFilter("Microsoft", LogLevel.Warning);
        s.AddFilter("System", LogLevel.Warning);
        s.SetMinimumLevel(LogLevel.Trace);

    })
    .Build()
    .Services
    .GetRequiredService<SpanshApi>();

Console.WriteLine("Searching ... ");
var response = await spansh.Search.Bodies(new BodiesRequest
{
    Filters = new BodiesRequest.FilterOptions
    {
        Atmosphere = new AtmosphereFilter(AtmosphereFilter.Atmosphere.SuitableForWaterBasedLife),
        Distance = new MinMaxFilter(1000)
    },
    ReferenceSystem = "Fusang"
});

response.On(
    ok: r =>
    {
        Console.WriteLine(string.Join(", ", r.Bodies.Select(x => x.SystemName)));
    },
    error: e => Console.WriteLine(e.Message));
    