using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using EliteAPI.Abstractions;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Spansh.NeutronPlotter.Abstractions;
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
        private readonly INeutronPlotter _plotter;
        private readonly ILogger<Core> _log;

        public Core(ILogger<Core> log, IEliteDangerousApi api, INeutronPlotter plotter)
        {
            // Get our dependencies through dependency injection
            _log = log;
            _api = api;
            _plotter = plotter;
        }

        public async Task Run()
        {
            var plot = (await _plotter.Plot("Fusaneg", "Fusang", 100)).Result;
            _log.LogInformation(JsonConvert.SerializeObject(plot.SystemJumps, Formatting.Indented));
        }
    }
}