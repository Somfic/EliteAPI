using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EliteAPI.Event.Processor;
using EliteAPI.Event.Provider;
using EliteAPI.Journal.Directory;
using EliteAPI.Journal.Provider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteAPI
{
    public interface IEliteDangerousAPI
    {
        Task StartAsync();
    }

    public class EliteDangerousAPI : IEliteDangerousAPI
    {
        private readonly IEventProvider _eventProvider;
        private readonly IEventProcessor _eventProcessor;
        private readonly IJournalProvider _journalProvider;
        private readonly IJournalDirectoryProvider _journalDirectoryProvider;
        //private readonly IJournalProcesser _journalProcessor;

        private readonly ILogger<EliteDangerousAPI> _log;
        private readonly IConfiguration _config;

        public EliteDangerousAPI(IServiceProvider services)
        {
            try
            {
                _log = services.GetRequiredService<ILogger<EliteDangerousAPI>>();
                _config = services.GetRequiredService<IConfiguration>();

                _eventProvider = services.GetRequiredService<IEventProvider>();
                _eventProcessor = services.GetRequiredService<IEventProcessor>();

                _journalProvider = services.GetRequiredService<IJournalProvider>();
                _journalDirectoryProvider = services.GetRequiredService<IJournalDirectoryProvider>();
            }
            catch (Exception ex)
            {
                InitializationException = ex;
            }
        }
        private Exception InitializationException { get; }

        public async Task StartAsync()
        {
            if (InitializationException != null)
            {
                _log?.LogCritical(InitializationException, "EliteAPI could not be initialized");

                throw InitializationException;
            }

            _log.LogInformation("Starting EliteAPI v{version}", "3.0");

            CheckComputerOperatingSystem();

            try
            {
                DirectoryInfo journalDirectory = await _journalDirectoryProvider.FindJournalDirectory();
                if (journalDirectory == null)
                {
                    _log.LogWarning("Continuing without event and context support");
                }
                else
                {
                    _log.LogInformation("Journal directory set to {journalDirectory}", journalDirectory.FullName);
                    FileInfo journalFile = await _journalProvider.FindJournalFile(journalDirectory);

                    await _eventProcessor.RegisterHandlers();
                }
            }
            catch (Exception ex)
            {
                _log.LogCritical(ex, "EliteAPI could not be started");
                throw;
            }
        }

        private void CheckComputerOperatingSystem()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _log.LogWarning("You are not running on a Windows machine, some features may not work properly");
            }
        }
    }
}
