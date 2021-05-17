using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using EliteAPI.Abstractions;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Status.NavRoute;

using Microsoft.Extensions.Logging;

using Moq;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ProtoBuf;
using ProtoBuf.Meta;

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
            _api.Ship.Available.OnChange += (sender, e) =>
            {
                _log.LogCritical("Available changed to {Value}!", e);
            };
            
            await _api.StartAsync();
        }
    }
}