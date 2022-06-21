using EliteAPI;
using EliteAPI.Events.Status.Ship.Events;

// Create an instance of the API
var api = EliteDangerousApi.Create();

// Subscribe to the event
api.Events.On<LightsStatusEvent>(lights => 
    Console.WriteLine($"Lights {(lights.Value ? "on" : "off")}"));

// Start the API
Console.WriteLine("Hello commander o7");
await api.StartAsync();

Console.WriteLine("Waiting for gear");
var gearEvent = api.Events.Until<GearStatusEvent>();
Console.WriteLine("Gears are " + (gearEvent.Value ? "down" : "up"));

// Run indefinitely
await Task.Delay(-1);