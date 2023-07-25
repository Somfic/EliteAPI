using EliteAPI;
using EliteAPI.Abstractions.Bindings.Models;
using EliteAPI.Bindings;
using EliteAPI.Events;
using EliteAPI.Events.Status.FCMaterials;
using EliteAPI.Events.Status.Ship.Events;
using FcMaterialsEvent = EliteAPI.Events.Status.FCMaterials.FcMaterialsEvent;

// Create an instance of the API
var api = EliteDangerousApi.Create();

// Subscribe to the lights event
api.Events.On<LightsStatusEvent>(lights => 
    Console.WriteLine($"Lights are {(lights.Value ? "on" : "off")}"));

api.Bindings.OnBindings(_ =>
{
    Console.WriteLine(api.Bindings[KeyBinding.ShipSpotLightToggle].Primary?.Key);
});

api.Events.On<BalanceStatusEvent>(e => Console.WriteLine(e.Value));

api.Events.On<FcMaterialsEvent>(e =>
{
    Console.WriteLine("FC Materials:");
});

// Start the API
if (!await api.StartAsync())
{
    Console.WriteLine("Failed to start EliteAPI");
    return;
}

Console.WriteLine("EliteAPI started");

// Run until the game stops
api.Events.WaitFor<ShutdownEvent>();
Console.WriteLine("Game closed, shutting down");
await api.StopAsync();
