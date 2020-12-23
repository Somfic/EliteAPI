using System.Threading.Tasks;
using EliteAPI.Abstractions;

namespace Example
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