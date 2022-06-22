using EliteAPI;
using EliteAPI.Abstractions.Status;
using EliteAPI.Events;
using EliteAPI.Events.Status.Ship;
using EliteAPI.Events.Status.Ship.Events;

// Create an instance of the API
var api = EliteDangerousApi.Create();

// Subscribe to the lights event
api.Events.On<LightsStatusEvent>(lights => 
    Console.WriteLine($"Lights are {(lights.Value ? "on" : "off")}"));

// Start the API
await api.StartAsync();

// Run until the game stops
api.Events.WaitFor<ShutdownEvent>();
await api.StopAsync();