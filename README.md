<div text-align="center">
<img src="https://github.com/EliteAPI/EliteAPI/blob/master/Icons/logo_gradient_shine.jpg?raw=true" align="right"
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
EliteAPI is distributed through the NuGet package manager; the recommended way to install this library. Alternatively, the library could also be compiled to retrieve the .dll file.

### .NET Platform
EliteAPI targets .NET Standard 2.0. Creating applications using the latest version of .NET Core is the most recommended. If needed, .NET Framework 4.6.1 or higher is also supported.

### Installation using NuGet
EliteAPI is listed as `EliteAPI` on NuGet. A reference to the library can be made in a number of different ways through NuGet, here are the most common ones. 
|Platform|Syntax|
|---|---|
|Package manager|`Install-Package EliteAPI`|
|.NET CLI|`dotnet add package EliteAPI`|
|Package reference|`<PackageReference Include="EliteAPI"/>`|
|Paket CLI|`paket add EliteAPI`|


## Getting started

### Dependency Injection
EliteAPI is bundeled with Depedency Injection. It is recommended that you use a [host](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.1) when working with the API. EliteAPI contains an extension method `AddEliteAPI()` that adds all the required services to your `IServiceCollection`. 

Below is an example of how to create a host in a .NET Core environment, and how to set up the API.

```cs
using EliteAPI;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
```
```cs
private static async Task Main(string[] args) {

     // Create a host that uses EliteAPI
     IHost host = Host.CreateDefaultBuilder()
          .ConfigureServices((context, service) =>
          {
               service.AddEliteAPI();
               service.AddTransient<MyAppService>(); // Example
          })
          .Build();

     // Get the EliteDangerousAPI api object
     var api = ActivatorUtilities.CreateInstance<EliteDangerousAPI>(host.Services);
     
     // Start the api
     await api.StartAsync();
     
     // Run forever
     await Task.Delay(-1);
}
```

### Hooking into an event
EliteAPI constantly scans the Journal log files for new in-game events. Whenever a new event is detected it is invoked in the api. There are multiple ways to hook into an event.

#### Through events
EliteAPI has an individual event for every event logged in the Journal files. These events can be found in the `IEliteDangerousAPI.Events` property. The event is automatically invoked whenever the specified action is peformed in-game.

```cs
api.Events.BountyEvent += (sender, e) =>
{
     // Triggered whenever we collect a bounty
     Console.WriteLine("Collected {0} from {1}", e.TotalReward, e.Target);

     var gear = api.Status.Gear;
};
```

#### Through attributes
In-game events can be assigned to specific methods using the `EliteDangerousEvent` attribute. The method must be public, in a public class that derives from `EliteDangerousEventModule` and must also be added through the EliteAPI configuration. This registeres this class as a service to your `IServiceCollection`.

```cs
service.AddEliteAPI(config => {
     config.AddEventModule<CombatModule>();
});
```

Which in-game event triggers the method is based on the method's first parameter type. 

```cs
public class CombatModule : EliteDangerousEventModule {

     public CombatModule(IServiceProvider services) : base(services) {  }

     [EliteDangerousEvent]
     public async Task NewBounty(BountyEvent e) {
          // Triggered whenever we collect a bounty
          Console.WriteLine("Collected {0} from {1}", e.TotalReward, e.Target);

          var gear = EliteAPI.Status.Gear;
     }
}
```

## Configuration
EliteAPI can be configured using configuration files.

```ini
[EliteAPI]
Journalpath = "W:\\"
```


## License
EliteAPI is distributed under the MIT license.
