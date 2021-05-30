using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI.Configuration.Abstractions;
using EliteAPI.Exceptions;
using EliteAPI.Journal.Provider;
using EliteAPI.Options.Provider.Abstractions;
using EliteAPI.Services.FileReader.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Options.Provider
{
    /// <inheritdoc />
    public class OptionsProvider : IOptionsProvider
    {
        private readonly IFileReader _fileReader;
        private IConfiguration _config;
        private ILogger<JournalProvider> _log;
        private IEliteDangerousApiConfiguration _codeConfig;

        public OptionsProvider(IServiceProvider services)
        {
            _fileReader = services.GetRequiredService<IFileReader>();
            _config = services.GetRequiredService<IConfiguration>();
            _log = services.GetRequiredService<ILogger<JournalProvider>>();
            _codeConfig = services.GetRequiredService<IEliteDangerousApiConfiguration>();
        }

        /// <inheritdoc />
        public Task<FileInfo> FindActiveBindingsFile(DirectoryInfo optionsDirectory)
        {
            var bindingsDirectories = optionsDirectory.GetDirectories("Bindings");

            if (bindingsDirectories.Length == 0)
            {
                throw new BindingsDirectoryNotFoundException("The bindings directory could not be found");
            }

            var bindingsDirectory = bindingsDirectories.First();

            var fileFilter = !string.IsNullOrWhiteSpace(_config.GetSection("EliteAPI")["Bindings"]) ? _config.GetSection("EliteAPI")["Bindings"] : _codeConfig.BindingsFile;
            
            var file = bindingsDirectory
                .GetFiles(fileFilter)
                .OrderByDescending(x => x.LastWriteTime)
                .FirstOrDefault();

            if (file == null)
            {
                throw new BindingsNotFoundException("Could not find a bindings file");
            }
            
            return Task.FromResult(file);
        }
    }
}
