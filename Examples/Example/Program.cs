using EliteAPI;
using EliteAPI.Abstractions.Bindings.Models;
using EliteAPI.Events;
using EliteAPI.Events.Status.Ship.Events;

// Create an instance of the Api
var api = EliteDangerousApi.Create();

// Subscribe to the DockingRequested event
api.Events.On<DockingRequestedEvent>((e, context) =>
{
    // Return if the event was raised while catching up with the journal
    if (context.IsRaisedDuringCatchup)
        return;
    
    Console.WriteLine($"Requested docking at {e.StationName}");
});

// Subscribe to all events
api.Events.On<MarketEvent>(e =>
{
    Console.WriteLine(e.Commodities.Count);
});

// Handle gear changes in the OnGearChange method
api.Events.On<GearStatusEvent>(OnGearChange);

// Start the API
await api.StartAsync();

// Get the binding for the ship's lights
var lightsBinding = api.Bindings[KeyBinding.ShipSpotLightToggle].Primary?.Key ?? "not set";
Console.WriteLine($"Lights binding: {lightsBinding}");

// Wait for the in-game Shutdown event (this method is blocking and will halt the main thread)
await Task.Delay(-1);

await api.StopAsync();

// This method will be called when the gear changes
void OnGearChange(GearStatusEvent gear)
{
    Console.WriteLine($"Gear is {(gear.Value ? "down" : "up")}");
}