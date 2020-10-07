using EliteAPI.Abstractions;

using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace Example1
{
    // Core class of our application
    public class Core
    {
        private readonly ILogger<Core> _log;
        private readonly IEliteDangerousAPI _api;

        public Core(ILogger<Core> log, IEliteDangerousAPI api)
        {
            // Get our dependencies through dependency injection
            _log = log;
            _api = api;
        }

        public async Task Run()
        {
            // Log to the logging system whenever we obtain a bounty
            _api.Events.BountyEvent += (sender, e) =>
            {
                string target = e.Target;
                long amount = e.TotalReward;

                _log.LogInformation("New bounty obtained: CR{amount} for killing {target}", amount, target);
            };

            // Start EliteAPI
            await _api.StartAsync();
        }
    }
}
