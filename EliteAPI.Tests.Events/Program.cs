
using EliteAPI.Event.Provider.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            if(string.IsNullOrWhiteSpace(path)) { path = "../../../Journal"; }

            if (!Directory.Exists(path))
            {
                _log.LogError(new DirectoryNotFoundException(path), "Directory does not exist");
                Environment.Exit(-1);
                return;
            }

            DirectoryInfo directory = new DirectoryInfo(path);

            DirectoryInfo[] versions = directory.GetDirectories();

            IList<Result> results = new List<Result>();

            foreach (DirectoryInfo versionDirectory in versions)
            {
                string version = versionDirectory.Name;
                FileInfo[] files = versionDirectory.GetFiles();

                _log.LogInformation($"Processing v{version}");

                IList<Task> tasks = new List<Task>();
                int finished = 0;
                int total = files.Length;

                foreach (FileInfo fileInfo in files)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        _log.LogDebug($"Processing {fileInfo.Name}");

                        string eventName = fileInfo.Name;
                        IList<string> allEvents = (await File.ReadAllLinesAsync(fileInfo.FullName)).ToList();
                        IList<string> testEvents = allEvents.ToList().OrderBy(x => Guid.NewGuid()).Take(Math.Min(allEvents.Count, 50)).ToList();

                        total += testEvents.Count();
                        bool hasHadError = false;

                        for (int i = 1; i < testEvents.Count() + 1; i++)
                        {
                            string json = testEvents[i - 1];

                            try
                            {
                                await _eventProvider.ProcessJsonEvent(json);
                            }
                            catch (Exception ex)
                            {
                                if (hasHadError) continue;

                                hasHadError = true;

                                if (ex is TargetInvocationException)
                                {
                                    ex = ex.InnerException;
                                    if(ex == null) { continue; }

                                    StringBuilder message = new StringBuilder();
                                    message.AppendLine(ex.Message);

                                    Exception innerException = ex.InnerException;
                                    while (innerException != null)
                                    {
                                        message.AppendLine();
                                        message.AppendLine(innerException.Message);
                                        innerException = innerException.InnerException;
                                    }

                                    results.Add(new Result()
                                    {
                                        Title = $"{eventName} (v{ version})",
                                        Message = message.ToString(),
                                        Path = Path.Combine(fileInfo.Directory.Name, fileInfo.Name),
                                        Line = allEvents.IndexOf(json) + 1,
                                        Level = "warning"
                                    });
                                }
                            }

                            finished++;
                        }
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }

            await File.WriteAllTextAsync("annotations.json", JsonConvert.SerializeObject(results));

            await Task.Delay(1000);

            var file = new FileInfo("annotations.json");

            _log.LogCritical(file.FullName);
        }
    }
}
