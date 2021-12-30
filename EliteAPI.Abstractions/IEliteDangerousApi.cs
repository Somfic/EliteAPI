using EliteAPI.Abstractions.Events;

namespace EliteAPI.Abstractions;

/// <summary>The base class for EliteAPI.</summary>
public interface IEliteDangerousApi
{
    /// <summary>Holds the state of all the API's events.</summary>
    IEvents Events { get; }

    /// <summary>Initialises the API.</summary>
    Task InitialiseAsync();

    /// <summary>Starts the API.</summary>
    Task StartAsync();

    /// <summary>Stops the API.</summary>
    Task StopAsync();
}