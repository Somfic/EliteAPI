using System.Threading.Tasks;

using EliteAPI.Abstractions;

using Microsoft.Extensions.Logging;

namespace EliteAPI.ManualTest
{
    // Core class of our application
    public class Core
    {
        private readonly IEliteDangerousApi _api;
        private readonly ILogger<Core> _log;

        public Core(ILogger<Core> log, IEliteDangerousApi api)
        {
            // Get our dependencies through dependency injection
            _log = log;
            _api = api;
        }

        public async Task Run()
        {
            await _api.InitializeAsync();
            
            _api.Bindings.OnChange += (sender, e) =>
            {
                _log.LogInformation("Bindings changed to {Name}", _api.Bindings.Active.PresetName);
            };

            await _api.StartAsync();
        }
    }
}