using EliteAPI.Abstractions.Configuration;
using EliteAPI.Abstractions.Events;

namespace EliteAPI.Abstractions;

/// <summary>The base class for EliteAPI.</summary>
public interface IEliteDangerousApi
{
    /// <summary>
    /// The configuration for the API.
    /// </summary>
    IEliteDangerousApiConfiguration Config { get; }
    
    /// <summary>
    /// Parser used for converting the raw data into usable objects.
    /// </summary>
    IEventParser Parser { get; }
    
    /// <summary>Holds the state of all the API's events.</summary>
    IEvents Events { get; }

    /// <summary>Initialises the API.</summary>
    Task InitialiseAsync();

    /// <summary>Starts the API.</summary>
    Task StartAsync();

    /// <summary>Stops the API.</summary>
    Task StopAsync();
}