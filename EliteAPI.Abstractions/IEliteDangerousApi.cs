using EliteAPI.Abstractions.Bindings;
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
    /// Parser used for converting raw JSON into Events.
    /// </summary>
    IEventParser EventParser { get; }

    /// <summary>Holds the state of all the API's events.</summary>
    IEvents Events { get; }
    
    /// <summary>
    /// Parser used for converting raw XML into Bindings.
    /// </summary>
    IBindingsParser BindingsParser { get; }
    
    /// <summary>User defined in-game bindings.</summary>
    IBindings Bindings { get; } 

    /// <summary>Initialises the API.</summary>
    Task InitialiseAsync();

    /// <summary>Starts the API.</summary>
    Task<bool> StartAsync();

    /// <summary>Stops the API.</summary>
    Task StopAsync();

    event EventHandler<Exception> OnError;
}