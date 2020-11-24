using EliteAPI.Event.Models.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Somfic.Logging.Console;
using Somfic.Logging.Console.Themes;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EliteAPI.Event.Processor.Abstractions;
using EliteAPI.Event.Provider.Abstractions;
using Newtonsoft.Json;
using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI.Tests.Events
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // Build the host for dependency injection
            IHost host = Host.CreateDefaultBuilder()
                .ConfigureLogging((context, logger) =>
                {
                    logger.ClearProviders();
                    logger.SetMinimumLevel(LogLevel.Debug);
                    logger.AddPrettyConsole(ConsoleThemes.Code);
                })
                .ConfigureServices((context, service) =>
                {
                    // Add EliteAPI's services to the depdency injection system
                    service.AddEliteAPI();
                })
                .Build();

            // Create an instance of our Core class
            Core core = ActivatorUtilities.CreateInstance<Core>(host.Services);

            // Execute the Run method inside our Core class
            await core.Run(string.Join(' ', args));
        }
    }

    public class Core
    {
        private readonly ILogger<Core> _log;
        private IEventProvider _eventProvider;

        public Core(IServiceProvider services)
        {
            _log = services.GetRequiredService<ILogger<Core>>();
            _eventProvider = services.GetRequiredService<IEventProvider>();
        }


        internal async Task Run(string path)
        {
            if (!Directory.Exists(path))
            {
                _log.LogError(new DirectoryNotFoundException(path),"Directory does not exist");
                Environment.Exit(-1);
                return;
            }

            DirectoryInfo directory = new DirectoryInfo(path);

            var versions = directory.GetDirectories();

            //         event              version json
            Dictionary<string, Dictionary<string, string[]>> allEvents = new Dictionary<string, Dictionary<string, string[]>>();

            foreach (var versionDirectory in versions)
            {
                string version = versionDirectory.Name;
                var files = versionDirectory.GetFiles();

                foreach (var fileInfo in files)
                {
                    string eventName = fileInfo.Name;
                    string[] jsonEvents = await File.ReadAllLinesAsync(fileInfo.FullName);

                    if (allEvents.ContainsKey(eventName))
                    {
                        allEvents[eventName].Add(version, jsonEvents);
                    }
                    else
                    {
                        var x = new Dictionary<string, string[]>();
                        x.Add(version, jsonEvents);
                        allEvents.Add(eventName, x);
                    }
                }   
            }

            _log.LogInformation("Found {amount} unique json events", allEvents.Count);


            var errors = new List<ErrorEntry>();
            int totalErrors = 0;

            foreach (var testCase in allEvents)
            {
                string eventName = testCase.Key;

                _log.LogInformation("Testing {event}", eventName);

                foreach (var jsonPair in testCase.Value)
                {
                    string version = jsonPair.Key;
                    foreach (var json in jsonPair.Value)
                    {
                        try
                        {
                            await _eventProvider.ProcessJsonEvent(json);
                        }
                        catch (Exception ex)
                        {
                            totalErrors++;
                            if (!errors.Any(x => x.Exception.Message == ex.Message && x.Version == version && x.EventName == eventName))
                            {
                                if(!ex.Data.Contains("Json")) { ex.Data.Add("Json", json); }

                                errors.Add(new ErrorEntry(version, ex, eventName));
                            }
                        }
                    }
                }
            }

            if (errors.Any())
            {
                errors.ForEach(x =>
                {
                    _log.LogWarning(x.Exception, "{event} ({version})", x.EventName, x.Version);
                });

                _log.LogError("{amount} errors found", errors.Count);
                Environment.Exit(-1);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public class ErrorEntry
        {
            public ErrorEntry(string version, Exception exception, string eventName)
            {
                Version = version;
                Exception = exception;
                EventName = eventName;
            }

            public string Version { get; }
            public string EventName { get; }
            public Exception Exception { get; }
        }
    }
}
