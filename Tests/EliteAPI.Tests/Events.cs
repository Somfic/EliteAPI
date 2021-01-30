using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using EliteAPI.Abstractions;
using EliteAPI.Event.Provider;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Options.Bindings;

using FluentAssertions;

using Microsoft.Extensions.Logging;

using Moq;

using Newtonsoft.Json;

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

                issues = issues.Where(x => !x.Contains("With configuration:"));
                issues = issues.Where(x => !x.StartsWith("-"));
                issues = issues.Where(x =>
                    !Regex.IsMatch(x,
                        "Expected actual to be a dictionary with [0-9]{1,} item\\(s\\), but has additional key\\(s\\)"));
                issues = issues.Select(x => Regex.Replace(x,
                    "(Expected actual to be a dictionary with [0-9]{1,} item\\(s\\), but it misses key\\(s\\) .*) and has additional key\\(s\\) .*",
                    "$1"));
                issues = issues.Where(x => !string.IsNullOrWhiteSpace(x));

                var processedIssues = issues.ToList();

                if (processedIssues.Any())
                {
                    _output.WriteLine("Elite: Dangerous event JSON:\n{1}\n\nEliteAPI event JSON:\n{0}",
                        JsonConvert.SerializeObject(actual, Formatting.Indented),
                        JsonConvert.SerializeObject(expected, Formatting.Indented));
                    throw new XunitException(string.Join(Environment.NewLine, processedIssues));
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetData), "ApproachBody")]
        public async Task ApproachBody(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "ApproachSettlement")]
        public async Task ApproachSettlement(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "AsteroidCracked")]
        public async Task AsteroidCracked(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "BuyAmmo")]
        public async Task BuyAmmo(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "BuyDrones")]
        public async Task BuyDrones(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Cargo")]
        public async Task Cargo(string json)
        {
            await TestEvent(json);

            EliteDangerousApi api = new EliteDangerousApi(null);
        }

        [Theory]
        [MemberData(nameof(GetData), "CargoTransfer")]
        public async Task CargoTransfer(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "CarrierJump")]
        public async Task CarrierJump(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "CarrierJumpRequest")]
        public async Task CarrierJumpRequest(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "CarrierStats")]
        public async Task CarrierStats(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "CodexEntry")]
        public async Task CodexEntry(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Commander")]
        public async Task Commander(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "CommitCrime")]
        public async Task CommitCrime(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "CrewAssign")]
        public async Task CrewAssign(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "CrimeVictim")]
        public async Task CrimeVictim(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Died")]
        public async Task Died(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Docked")]
        public async Task Docked(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "DockFighter")]
        public async Task DockFighter(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "DockingDenied")]
        public async Task DockingDenied(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "DockingGranted")]
        public async Task DockingGranted(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "DockingRequested")]
        public async Task DockingRequested(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "DockingTimeout")]
        public async Task DockingTimeout(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "DockSRV")]
        public async Task DockSRV(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "EjectCargo")]
        public async Task EjectCargo(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "EngineerProgress")]
        public async Task EngineerProgress(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "FighterDestroyed")]
        public async Task FighterDestroyed(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "FighterRebuilt")]
        public async Task FighterRebuilt(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Fileheader")]
        public async Task Fileheader(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Friends")]
        public async Task Friends(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "FSDJump")]
        public async Task FSDJump(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "FSDTarget")]
        public async Task FSDTarget(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "FSSAllBodiesFound")]
        public async Task FSSAllBodiesFound(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "FSSSignalDiscovered")]
        public async Task FSSSignalDiscovered(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "FuelScoop")]
        public async Task FuelScoop(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "HeatDamage")]
        public async Task HeatDamage(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "HeatWarning")]
        public async Task HeatWarning(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "HullDamage")]
        public async Task HullDamage(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Interdicted")]
        public async Task Interdicted(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "LaunchDrone")]
        public async Task LaunchDrone(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "LaunchFighter")]
        public async Task LaunchFighter(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "LaunchSRV")]
        public async Task LaunchSRV(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "LeaveBody")]
        public async Task LeaveBody(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Liftoff")]
        public async Task Liftoff(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "LoadGame")]
        public async Task LoadGame(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Loadout")]
        public async Task Loadout(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Location")]
        public async Task Location(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Market")]
        public async Task Market(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "MarketBuy")]
        public async Task MarketBuy(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Materials")]
        public async Task Materials(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "MiningRefined")]
        public async Task MiningRefined(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Missions")]
        public async Task Missions(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "ModuleInfo")]
        public async Task ModuleInfo(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Music")]
        public async Task Music(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "NavRoute")]
        public async Task NavRoute(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "NpcCrewPaidWage")]
        public async Task NpcCrewPaidWage(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Outfitting")]
        public async Task Outfitting(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "PayFines")]
        public async Task PayFines(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Powerplay")]
        public async Task Powerplay(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Progress")]
        public async Task Progress(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "ProspectedAsteroid")]
        public async Task ProspectedAsteroid(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Rank")]
        public async Task Rank(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "ReceiveText")]
        public async Task ReceiveText(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "RefuelAll")]
        public async Task RefuelAll(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Reputation")]
        public async Task Reputation(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "ReservoirReplenished")]
        public async Task ReservoirReplenished(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Resurrect")]
        public async Task Resurrect(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "SAAScanComplete")]
        public async Task SAAScanComplete(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "SAASignalsFound")]
        public async Task SAASignalsFound(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Scan")]
        public async Task Scan(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Scanned")]
        public async Task Scanned(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "SendText")]
        public async Task SendText(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "ShieldState")]
        public async Task ShieldState(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "ShipTargeted")]
        public async Task ShipTargeted(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Shipyard")]
        public async Task Shipyard(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "ShipyardSwap")]
        public async Task ShipyardSwap(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Shutdown")]
        public async Task Shutdown(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "SquadronStartup")]
        public async Task SquadronStartup(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "StartJump")]
        public async Task StartJump(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Statistics")]
        public async Task Statistics(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "StoredModules")]
        public async Task StoredModules(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "StoredShips")]
        public async Task StoredShips(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "SupercruiseEntry")]
        public async Task SupercruiseEntry(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "SupercruiseExit")]
        public async Task SupercruiseExit(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Touchdown")]
        public async Task Touchdown(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "UnderAttack")]
        public async Task UnderAttack(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "Undocked")]
        public async Task Undocked(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "VehicleSwitch")]
        public async Task VehicleSwitch(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "WingAdd")]
        public async Task WingAdd(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "WingJoin")]
        public async Task WingJoin(string json)
        {
            await TestEvent(json);
        }

        [Theory]
        [MemberData(nameof(GetData), "WingLeave")]
        public async Task WingLeave(string json)
        {
            await TestEvent(json);
        }
    }
}