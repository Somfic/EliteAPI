using EliteAPI.Web.EDDB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

var host = Host.CreateDefaultBuilder()
    //.ConfigureLogging(log => log.ClearProviders())
    .ConfigureServices(services => services.AddWebApi<EddbApi>())
    .Build();
    
var eddb = host.Services.GetRequiredService<EddbApi>();
var systems = await eddb.Systems.Query("Fusang");

Console.WriteLine(systems.RawContent);
Console.WriteLine(JsonConvert.SerializeObject(systems.Content.First().Stations.First(), Formatting.Indented));