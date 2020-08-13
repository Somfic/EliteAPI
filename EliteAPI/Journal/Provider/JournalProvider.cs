using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
        public async Task<FileInfo> FindJournalFile(DirectoryInfo journalDirectory)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<FileInfo>> FindSupportFiles(DirectoryInfo journalDirectory)
        {
            throw new System.NotImplementedException();
        }
    }
}