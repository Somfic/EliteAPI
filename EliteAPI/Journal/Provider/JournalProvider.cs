using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using EliteAPI.Configuration.Abstractions;
using EliteAPI.Exceptions;
using EliteAPI.Journal.Provider.Abstractions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Journal.Provider
{
    /// <inheritdoc />
    public class JournalProvider : IJournalProvider
    {
        private readonly IEliteDangerousApiConfiguration _codeConfig;
        private readonly IConfiguration _config;
        private readonly ILogger<JournalProvider> _log;

        public JournalProvider(IServiceProvider services)
        {
            _config = services.GetRequiredService<IConfiguration>();
            _log = services.GetRequiredService<ILogger<JournalProvider>>();
            _codeConfig = services.GetRequiredService<IEliteDangerousApiConfiguration>();
        }

        /// <inheritdoc />
        public async Task<FileInfo> FindJournalFile(DirectoryInfo journalDirectory)
        {
            try
            {
                var files = await FindJournalFiles(journalDirectory);

                return files
                    .OrderByDescending(file => file.LastWriteTime)
                    .First();
            }
            catch (Exception ex)
            {
                Exception exception = new JournalFileNotFoundException("Could not find journal file", ex);
                exception.Data.Add("Path", journalDirectory.FullName);
                _log.LogTrace(exception, "Could not get active journal file from journal directory");
                return await Task.FromException<FileInfo>(exception);
            }
        }

        /// <inheritdoc />
        public async Task<FileInfo[]> FindJournalFiles(DirectoryInfo journalDirectory)
        {
            try
            {
                var fileFilter = !string.IsNullOrWhiteSpace(_config.GetSection("EliteAPI")["Journal"]) ? _config.GetSection("EliteAPI")["Journal"] : _codeConfig.JournalFile;

                return journalDirectory
                    .GetFiles(fileFilter)
                    .OrderByDescending(file => file.LastWriteTime)
                    .ToArray();
            }
            catch (Exception ex)
            {
                Exception exception = new JournalFileNotFoundException("Could not find journal files", ex);
                exception.Data.Add("Path", journalDirectory.FullName);
                _log.LogTrace(exception, "Could not get journal files from journal directory");
                return await Task.FromException<FileInfo[]>(exception);
            }
        }
    }
}