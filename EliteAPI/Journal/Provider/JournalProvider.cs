using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI.Journal.Provider.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Journal.Provider
{
    /// <inheritdoc />
    public class JournalProvider : IJournalProvider
    {
        private readonly IConfiguration _config;
        private readonly ILogger<JournalProvider> _log;

        public JournalProvider(IServiceProvider services)
        {
            _config = services.GetRequiredService<IConfiguration>();
            _log = services.GetRequiredService<ILogger<JournalProvider>>();
        }

        /// <inheritdoc />
        public Task<FileInfo> FindJournalFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return Task.FromResult(journalDirectory
                    .GetFiles("Journal.*.log")
                    .OrderByDescending(file => file.LastWriteTime)
                    .First());
            }
            catch (Exception ex)
            {
                Exception exception = new FileNotFoundException("Could not find journal file", ex);
                _log.LogTrace(exception, "Could not get active journal file from journal directory");
                throw exception;
            }
        }
    }
}