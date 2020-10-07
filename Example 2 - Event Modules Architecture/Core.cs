using EliteAPI.Abstractions;

using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace Example2
{
    // Core class of our application
    public class Core
    {
        private readonly IEliteDangerousAPI _api;

        public Core(IEliteDangerousAPI api)
        {
            // Get our dependencies through dependency injection
            _api = api;
        }

        public async Task Run()
        {
            // Start EliteAPI
            await _api.StartAsync();
        }
    }
}
