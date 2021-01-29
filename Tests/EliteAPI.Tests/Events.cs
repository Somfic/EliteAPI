using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Provider;
using EliteAPI.Event.Provider.Abstractions;
using FluentAssertions;
using FluentAssertions.Equivalency;
using FluentAssertions.Json;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace EliteAPI.Tests
{
    public class Events
    {
        private static ITestOutputHelper _output;

        public Events(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object[]> GetData(string eventName)
        {
            var directory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Test cases"));
            var file = directory.GetFiles().First(x => x.Name == $"{eventName}.json");

            return File.ReadAllLines(file.FullName).Select(line => new object[] {line});
        }

        private static async Task TestEvent(string json)
        {
            IEventProvider provider = new EventProvider(Mock.Of<ILogger<EventProvider>>());

            var parsedEvent = await provider.ProcessJsonEvent(json);

            var expectedJson = json;
            var actualJson = JsonConvert.SerializeObject(parsedEvent);

            var expected = JsonConvert.DeserializeObject(expectedJson); 
            var actual = JsonConvert.DeserializeObject(actualJson);

            try
            {
                actual.Should().BeEquivalentTo(expected);
            }
            catch (XunitException ex)
            {
                IEnumerable<string> issues = ex.UserMessage.Split(Environment.NewLine);
                
                issues = issues.Where(x => !string.IsNullOrWhiteSpace(x));
                issues = issues.Where(x => !x.Contains("With configuration:"));
                issues = issues.Where(x => !x.StartsWith("-"));
                issues = issues.Where(x => !x.Contains("but has additional key(s)")).ToList();

                var processedIssues = issues.ToList();
                
                if (processedIssues.Any())
                {
                    _output.WriteLine("Elite: Dangerous event JSON:\n{1}\n\nEliteAPI event JSON:\n{0}", JsonConvert.SerializeObject(actual, Formatting.Indented), JsonConvert.SerializeObject(expected, Formatting.Indented));
                    throw new XunitException(string.Join(Environment.NewLine, processedIssues));
                }
            }
           
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "ApproachBody")]
        public async Task ApproachBody(string json) => await TestEvent(json);

        [Theory]        
        [MemberData(nameof(GetData), parameters: "ApproachSettlement")]
        public async Task ApproachSettlement(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "AsteroidCracked")]
        public async Task AsteroidCracked(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "BuyAmmo")]
        public async Task BuyAmmo(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "BuyDrones")]
        public async Task BuyDrones(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Cargo")]
        public async Task Cargo(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "CargoTransfer")]
        public async Task CargoTransfer(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "CarrierJump")]
        public async Task CarrierJump(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "CarrierJumpRequest")]
        public async Task CarrierJumpRequest(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "CarrierStats")]
        public async Task CarrierStats(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "CodexEntry")]
        public async Task CodexEntry(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Commander")]
        public async Task Commander(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "CommitCrime")]
        public async Task CommitCrime(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "CrewAssign")]
        public async Task CrewAssign(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "CrimeVictim")]
        public async Task CrimeVictim(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Died")]
        public async Task Died(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Docked")]
        public async Task Docked(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "DockFighter")]
        public async Task DockFighter(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "DockingDenied")]
        public async Task DockingDenied(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "DockingGranted")]
        public async Task DockingGranted(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "DockingRequested")]
        public async Task DockingRequested(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "DockingTimeout")]
        public async Task DockingTimeout(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "DockSRV")]
        public async Task DockSRV(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "EjectCargo")]
        public async Task EjectCargo(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "EngineerProgress")]
        public async Task EngineerProgress(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "FighterDestroyed")]
        public async Task FighterDestroyed(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "FighterRebuilt")]
        public async Task FighterRebuilt(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Fileheader")]
        public async Task Fileheader(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Friends")]
        public async Task Friends(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "FSDJump")]
        public async Task FSDJump(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "FSDTarget")]
        public async Task FSDTarget(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "FSSAllBodiesFound")]
        public async Task FSSAllBodiesFound(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "FSSSignalDiscovered")]
        public async Task FSSSignalDiscovered(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "FuelScoop")]
        public async Task FuelScoop(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "HeatDamage")]
        public async Task HeatDamage(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "HeatWarning")]
        public async Task HeatWarning(string json) => await TestEvent(json);
        
        [Theory]
        [MemberData(nameof(GetData), parameters: "HullDamage")]
        public async Task HullDamage(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Interdicted")]
        public async Task Interdicted(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "LaunchDrone")]
        public async Task LaunchDrone(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "LaunchFighter")]
        public async Task LaunchFighter(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "LaunchSRV")]
        public async Task LaunchSRV(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "LeaveBody")]
        public async Task LeaveBody(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Liftoff")]
        public async Task Liftoff(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "LoadGame")]
        public async Task LoadGame(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Loadout")]
        public async Task Loadout(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Location")]
        public async Task Location(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Market")]
        public async Task Market(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "MarketBuy")]
        public async Task MarketBuy(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Materials")]
        public async Task Materials(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "MiningRefined")]
        public async Task MiningRefined(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Missions")]
        public async Task Missions(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "ModuleInfo")]
        public async Task ModuleInfo(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Music")]
        public async Task Music(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "NavRoute")]
        public async Task NavRoute(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "NpcCrewPaidWage")]
        public async Task NpcCrewPaidWage(string json) => await TestEvent(json);
        
        [Theory]
        [MemberData(nameof(GetData), parameters: "Outfitting")]
        public async Task Outfitting(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "PayFines")]
        public async Task PayFines(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Powerplay")]
        public async Task Powerplay(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Progress")]
        public async Task Progress(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "ProspectedAsteroid")]
        public async Task ProspectedAsteroid(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Rank")]
        public async Task Rank(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "ReceiveText")]
        public async Task ReceiveText(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "RefuelAll")]
        public async Task RefuelAll(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Reputation")]
        public async Task Reputation(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "ReservoirReplenished")]
        public async Task ReservoirReplenished(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Resurrect")]
        public async Task Resurrect(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "SAAScanComplete")]
        public async Task SAAScanComplete(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "SAASignalsFound")]
        public async Task SAASignalsFound(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Scan")]
        public async Task Scan(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Scanned")]
        public async Task Scanned(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "SendText")]
        public async Task SendText(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "ShieldState")]
        public async Task ShieldState(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "ShipTargeted")]
        public async Task ShipTargeted(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Shipyard")]
        public async Task Shipyard(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "ShipyardSwap")]
        public async Task ShipyardSwap(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Shutdown")]
        public async Task Shutdown(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "SquadronStartup")]
        public async Task SquadronStartup(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "StartJump")]
        public async Task StartJump(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Statistics")]
        public async Task Statistics(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "StoredModules")]
        public async Task StoredModules(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "StoredShips")]
        public async Task StoredShips(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "SupercruiseEntry")]
        public async Task SupercruiseEntry(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "SupercruiseExit")]
        public async Task SupercruiseExit(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Touchdown")]
        public async Task Touchdown(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "UnderAttack")]
        public async Task UnderAttack(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "Undocked")]
        public async Task Undocked(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "VehicleSwitch")]
        public async Task VehicleSwitch(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "WingAdd")]
        public async Task WingAdd(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "WingJoin")]
        public async Task WingJoin(string json) => await TestEvent(json);

        [Theory]
        [MemberData(nameof(GetData), parameters: "WingLeave")]
        public async Task WingLeave(string json) => await TestEvent(json);
    }
}