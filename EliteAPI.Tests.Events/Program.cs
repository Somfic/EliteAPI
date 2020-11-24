
using EliteAPI.Event.Provider.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
                    logger.SetMinimumLevel(LogLevel.Debug);
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
        private readonly IEventProvider _eventProvider;

        public Core(IServiceProvider services)
        {
            _log = services.GetRequiredService<ILogger<Core>>();
            _eventProvider = services.GetRequiredService<IEventProvider>();
        }


        internal async Task Run(string path)
        {
            if (!Directory.Exists(path))
            {
                _log.LogError(new DirectoryNotFoundException(path), "Directory does not exist");
                Environment.Exit(-1);
                return;
            }

            DirectoryInfo directory = new DirectoryInfo(path);

            DirectoryInfo[] versions = directory.GetDirectories();

            //         event              version json
            Dictionary<string, Dictionary<string, string[]>> allEvents = new Dictionary<string, Dictionary<string, string[]>>();

            foreach (DirectoryInfo versionDirectory in versions)
            {
                string version = versionDirectory.Name;
                FileInfo[] files = versionDirectory.GetFiles();

                foreach (FileInfo fileInfo in files)
                {
                    string eventName = fileInfo.Name;
                    string[] jsonEvents = await File.ReadAllLinesAsync(fileInfo.FullName);

                    if (allEvents.ContainsKey(eventName))
                    {
                        allEvents[eventName].Add(version, jsonEvents);
                    }
                    else
                    {
                        Dictionary<string, string[]> x = new Dictionary<string, string[]>
                        {
                            { version, jsonEvents }
                        };
                        allEvents.Add(eventName, x);
                    }
                }
            }

            _log.LogInformation("Found {amount} unique json events", allEvents.Count);


            List<ErrorEntry> errors = new List<ErrorEntry>();
            int totalErrors = 0;

            foreach (KeyValuePair<string, Dictionary<string, string[]>> testCase in allEvents)
            {
                string eventName = testCase.Key;

                _log.LogInformation("Testing {event}", eventName);

                foreach (KeyValuePair<string, string[]> jsonPair in testCase.Value)
                {
                    string version = jsonPair.Key;
                    foreach (string json in jsonPair.Value)
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
                                if (!ex.Data.Contains("Json")) { ex.Data.Add("Json", json); }

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
