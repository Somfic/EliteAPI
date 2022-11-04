using EliteAPI;
using EliteAPI.Abstractions.Bindings.Models;
using EliteAPI.Bindings;
using EliteAPI.Events;
using EliteAPI.Events.Status.Ship.Events;

// Create an instance of the API
var api = EliteDangerousApi.Create();

// Subscribe to the lights event
api.Events.On<LightsStatusEvent>(lights => 
    Console.WriteLine($"Lights are {(lights.Value ? "on" : "off")}"));

api.Bindings.OnBindings(_ =>
{
    Console.WriteLine(api.Bindings[KeyBinding.ShipSpotLightToggle].Primary?.Key);
});

// Start the API
await api.StartAsync();
Console.WriteLine("EliteAPI started");

// Run until the game stops
api.Events.WaitFor<ShutdownEvent>();
Console.WriteLine("Game closed, shutting down");
await api.StopAsync();