using EliteAPI.Web.Spansh;
using EliteAPI.Web.Spansh.RoutePlanner.Requests;
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
        
    })
    .Build()
    .Services
    .GetRequiredService<SpanshApi>();

Console.WriteLine("Getting route ... ");
var response = await spansh.Routes.Trade(new TradeRequest("Shinrarta Dezhra", "Jameson Memorial", 50, 720));

response.On(
    ok: route =>
    {
        foreach (var stop in route)
        {
            Console.WriteLine(stop.System.Name + " - " + stop.System.Station);
            foreach (var commodity in stop.Commodities)
            {
                Console.WriteLine($"   - {commodity.Name} {commodity.Amount}x (+{commodity.TotalProfit:N0}cr)");
            }

            Console.WriteLine();
        }
    },
    error: e => Console.WriteLine(e.Message));