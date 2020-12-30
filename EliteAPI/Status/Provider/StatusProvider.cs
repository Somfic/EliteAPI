using EliteAPI.Exceptions;
using EliteAPI.Status.Provider.Abstractions;

using Microsoft.Extensions.Logging;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
                throw new StatusFileNotFoundException("Could not getting the Status.json file", ex);
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
                var dirException = new JournalDirectoryNotFoundException("The journal directory does not exist");
                dirException.Data.Add("Path", directory.FullName);
                return Task.FromException<FileInfo>(dirException);
            }

            var files = directory.GetFiles(name);

            if (files.Length > 0) return Task.FromResult(files.First());

            var path = Path.Combine(directory.FullName, name);
            var fileException = new SupportFileNotFoundException($"The {name} could not be found");
            fileException.Data.Add("Path", path);
            return Task.FromException<FileInfo>(fileException);
        }
    }
}