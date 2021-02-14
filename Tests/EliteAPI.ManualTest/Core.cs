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
            try
            {
                var n = StatisticsEvent.FromJson((await File.ReadAllLinesAsync(@"C:\Users\somfi\Documents\GitHub\EliteAPI\EliteAPI\Tests\EliteAPI.Tests\Test cases\Statistics.json"))[0]);

                RpcEncoder encoder = new RpcEncoder(Mock.Of<ILogger<RpcEncoder>>());

                string encoded = Convert.ToBase64String(encoder.Encode(n).ToArray());
                string decoded = encoder.Decode<StatisticsEvent>(encoded).ToJson();
                
               _log.LogCritical(Serializer.GetProto<StatisticsEvent>(ProtoSyntax.Proto3));
            }
            catch (Exception ex)
            {
                _log.LogCritical(ex, "Could not run program");
            }
        }
    }
}