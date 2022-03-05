<div text-align="center">
<img src="https://github.com/EliteAPI/Icons/blob/main/logo_gradient_shine.jpg?raw=true" align="right"
     title="EliteAPI by Somfic" width="280" height="280">
<h1 align="center">EliteAPI</h1>

<p align="center"><i>An Elite: Dangerous API library for .NET</i></p>

<p align="center">
     <a href="https://www.discord.gg/jwpFUPZ">
          <img alt="Discord" src="https://img.shields.io/discord/498422961297031168?color=%23f2a529&label=DISCORD&style=for-the-badge">
     </a>
     <a href="https://app.codacy.com/gh/EliteAPI/EliteAPI?utm_source=github.com&utm_medium=referral&utm_content=EliteAPI/EliteAPI&utm_campaign=Badge_Grade_Dashboard">
          <img alt="Codacy grade" src="https://img.shields.io/codacy/grade/cd6364ab2d6a46a18627e6c8454f5672?color=%23f2a529&label=CODE%20QUALITY&style=for-the-badge">
     </a>
     <a href="https://github.com/EliteAPI/EliteAPI/releases">
        <img alt="GitHub release" src="https://img.shields.io/github/v/release/EliteAPI/EliteAPI?color=%23f2a529&label=VERSION&style=for-the-badge">
     </a>
     <a href="https://github.com/EliteAPI/EliteAPI/blob/master/LICENSE">
         <img alt="GitHub" src="https://img.shields.io/github/license/EliteAPI/EliteAPI?color=%23f2a529&label=LICENSE&style=for-the-badge">
     </a>
</p>
<p>When playing Elite: Dangerous, many in-game events are outputted to the Journal log files. EliteAPI makes use of these files to provide live information about in-game events in a .NET environment. 
</div>

## Installation

EliteAPI is distributed through the NuGet package manager; the recommended way to install the library. Alternatively,
the source can be compiled to retrieve the `EliteAPI.dll` file.

EliteAPI targets `.NET 6.0`.

### Installation using NuGet

EliteAPI is listed as `EliteAPI` on NuGet. Installing it can be done as follows:

```
dotnet add package EliteAPI
```

### Building from source

The library can be built from source using the `dotnet CLI`.

```console
$ git clone https://github.com/EliteAPI/EliteAPI.git EliteAPI
$ cd EliteAPI
$ dotnet build -c Release
```

The compiled `EliteAPI.dll` file can be found in in the `bin\Release` folder.

## Creating an API instance

EliteAPI is designed to be used as a *Service* with dependency injection. Acquiring an instance of the API can be done
in a few ways.

### Host

The API can be added to your
application's [host](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host). A host is used to
encapsulate the application's resources, such
as [logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging), [configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration),
and [dependency injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection). The API can
be added using the `AddEliteApi()` method.

```cs
var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddEliteApi();
        services.AddTransient<MyAppService>(); // Example service
    })
    .Build();

var api = host.Services.GetService<IEliteDangerousApi>();
```

### ServiceCollection

You can choose not the use the host and create a `ServiceCollection` directly, and add the API to it. Note that you lose
the ability to configure resources such as [logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging), [configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration),
and [dependency injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection). The library
contains an extension method `AddEliteApi()` that can be used to directly add all required API services to
the `IServiceCollection`.

```cs
var serviceCollection = new ServiceCollection();
serviceCollection.AddEliteApi();

var services = serviceCollection.BuildServiceProvider();

var api = services.GetService<IEliteDangerousApi>();
```

### Factory method

Alternatively, the `Create()` factory method can be used to create an instance of the `EliteDangerousApi` class.

## Getting started

EliteAPI constantly scans the Journal log files for new in-game events. Whenever a new event is detected it is invoked
in the API.

Subscribing to an event is done through the `On<T>()`, `OnJson<T>()`, `OnAny()`, and `OnAnyJson()` methods in
the `IEliteDangerousApi.Events` property.

| Method        | Description                                           | Parameter                  |
|---------------|-------------------------------------------------------|----------------------------|
| `On<T>()`     | Subscribes to an event of type `T where T : IEvent`   | The event of type `T`      |
| `OnAny()`     | Subscribes to all events                              | The event of type `IEvent` |
| `OnJson<T>()` | Subscribes to an event of type `T where T : IEvent`   | The `JSON` of the event    |
| `OnAnyJson()` | Subscribes to all events                              | The `JSON` of the event    |


The `EventContext` object contains information about the event such as whether the event was raised during session catchup and the source of the event. 
The `EventContext` parameter is **optional** and does not need to be implemented.

The delegates passed to the `On<T>()` and `OnJson<T>()` methods are invoked whenever an event of type `T` is detected in-game.
The delegates are invoked with the event and the optional `EventContext` object.

```cs
api.Events.On<DockingRequestedEvent>((e, context) => 
    Console.WriteLine($"Requested docking at {e.StationName}"));
```

Delegates passed to the `OnAny()` and `OnAnyJson()` methods are invoked whenever *any* event is detected in-game. 
These delegates are also invoked with the event and the optional `EventContext` object.
```cs
api.Events.OnAny(e => 
    Console.WriteLine($"Received event {e.Event}"));
```

The delegates can also be implemented through methods, if you prefer.
```cs
api.Events.On<GearStatusEvent>(OnGearChange);
```
```cs
void OnGearChange(GearStatusEvent gear, EventContext context)
{
    if (gear.Value)
        Console.WriteLine("Landing gear deployed");
    else
        Console.WriteLine("Landing gear retracted");
}
```

These delegates also allow for asynchronous implementations.
```cs
api.Events.On<FssSignalDiscoveredEvent>(async e =>
    await SomeAsyncMethod(e));
```

## License

EliteAPI is distributed under the MIT license.
