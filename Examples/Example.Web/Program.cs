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

var response = await spansh.Routes.Neutron(new NeutronRequest("Sol", "Colonia"));

response.On(
    ok: r => Console.WriteLine(r.TotalJumps),
    error: e => Console.WriteLine(e.Message));