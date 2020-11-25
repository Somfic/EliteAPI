using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI.Status.Provider.Abstractions;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Status.Provider
{
    /// <inheritdoc />
    public class StatusProvider : IStatusProvider
    {
        private readonly ILogger<StatusProvider> _log;

        public StatusProvider(ILogger<StatusProvider> log)
        {
            _log = log;
        }

        /// <inheritdoc />
        public async Task<FileInfo> FindStatusFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return await FindFile(journalDirectory, "Status.json");
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not get Status.json file");
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<FileInfo> FindMarketFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return await FindFile(journalDirectory, "Market.json");
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not get Market.json file");
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<FileInfo> FindCargoFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return await FindFile(journalDirectory, "Cargo.json");
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not get Cargo.json file");
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<FileInfo> FindShipyardFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return await FindFile(journalDirectory, "Shipyard.json");
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not get Shipyard.json file");
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<FileInfo> FindOutfittingFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return await FindFile(journalDirectory, "Outfitting.json");
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not get Outfitting.json file");
                throw;
            }
        }

        private Task<FileInfo> FindFile(DirectoryInfo directory, string name)
        {
            if (!directory.Exists)
            {
                Exception directoryException = new DirectoryNotFoundException("The journal directory does not exist");
                directoryException.Data.Add("Directory", directory.FullName);
                directoryException.Data.Add("File", name);
                throw directoryException;
            }

            var files = directory.GetFiles(name);

            if (files.Length > 0) return Task.FromResult(files.First());

            if (name == "Status.json")
            {
                var path = Path.Combine(directory.FullName, name);
                var fileException = new FileNotFoundException("The file does not exist", path);
                fileException.Data.Add("Directory", directory.FullName);
                fileException.Data.Add("File", name);
                throw fileException;
            }

            return Task.FromResult<FileInfo>(null);
        }
    }
}