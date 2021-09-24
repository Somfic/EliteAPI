using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI.Exceptions;
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
                //_log.LogTrace(new StatusFileNotFoundException("Could not find the Status.json file", ex), "Skipping Status.json");
                return null;
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
                //_log.LogTrace(new MarketFileNotFoundException("Could not find the Market.json file", ex), "Skipping Market.json");
                return null;
            }
        }

        /// <inheritdoc />
        public async Task<FileInfo> FindModulesFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return await FindFile(journalDirectory, "ModulesInfo.json");
            }
            catch (Exception ex)
            {
                //_log.LogTrace(new ModulesInfoFileNotFoundException("Could not find the ModulesInfo.json file", ex), "Skipping ModulesInfo.json");
                return null;
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
                //_log.LogTrace(new CargoFileNotFoundException("Could not find the Cargo.json file", ex), "Skipping Cargo.json");
                return null;
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
                //_log.LogTrace(new ShipyardFileNotFoundException("Could not find the Shipyard.json file", ex), "Skipping Shipyard.json");
                return null;
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
                //_log.LogTrace(new OutfittingFileNotFoundException("Could not find the Outfitting.json file", ex), "Skipping Outfitting.json");
                return null;
            }
        }

        /// <inheritdoc />
        public async Task<FileInfo> FindNavRouteFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return await FindFile(journalDirectory, "NavRoute.json");
            }
            catch (Exception ex)
            {
                //_log.LogTrace(new NavRouteFileNotFoundException("Could not find the NavRoute.json file", ex), "Skipping NavRoute.json");
                return null;
            }
        }

        /// <inheritdoc />
        public async Task<FileInfo> FindBackpackFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return await FindFile(journalDirectory, "Backpack.json");
            }
            catch (Exception ex)
            {
                //_log.LogTrace(new BackpackFileNotFoundException("Could not find the Backpack.json file", ex), "Skipping Backpack.json");
                return null;
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