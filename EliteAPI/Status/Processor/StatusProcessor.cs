using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using EliteAPI.Status.Processor.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.Status.Processor
{
    /// <inheritdoc />
    public class StatusProcessor : IStatusProcessor
    {
        private readonly ILogger<StatusProcessor> _log;
        private readonly IDictionary<string, string> _cache;

        public StatusProcessor(ILogger<StatusProcessor> log)
        {
            _log = log;
            _cache = new Dictionary<string, string>();
        }

        /// <inheritdoc />
        public event EventHandler<string> StatusUpdated;

        /// <inheritdoc />
        public event EventHandler<string> CargoUpdated;

        /// <inheritdoc />
        public event EventHandler<string> MarketUpdated;

        /// <inheritdoc />
        public event EventHandler<string> ShipyardUpdated;

        /// <inheritdoc />
        public event EventHandler<string> OutfittingUpdated;

        /// <inheritdoc />
        public async Task ProcessStatusFile(FileInfo statusFile)
        {
            if (!statusFile.Exists) { return; }

            string content = ReadAllText(statusFile);
            if (!IsInCache(statusFile, content))
            {
                AddToCache(statusFile, content);
                StatusUpdated?.Invoke(this, content);
            }
        }

        /// <inheritdoc />
        public async Task ProcessCargoFile(FileInfo cargoFile)
        {
            if(!cargoFile.Exists) { return; }

            string content = ReadAllText(cargoFile);
            if (!IsInCache(cargoFile, content))
            {
                AddToCache(cargoFile, content);
                CargoUpdated?.Invoke(this, content);
            }
        }

        /// <inheritdoc />
        public async Task ProcessMarketFile(FileInfo marketFile)
        {
            if (marketFile == null || !marketFile.Exists) { return; }

            string content = ReadAllText(marketFile);
            if (!IsInCache(marketFile, content))
            {
                AddToCache(marketFile, content);
                MarketUpdated?.Invoke(this, content);
            }
        }

        /// <inheritdoc />
        public async Task ProcessShipyardFile(FileInfo shipyardFile)
        {
            if(shipyardFile == null || !shipyardFile.Exists) { return; }

            string content = ReadAllText(shipyardFile);
            if (!IsInCache(shipyardFile, content))
            {
                AddToCache(shipyardFile, content);
                ShipyardUpdated?.Invoke(this, content);
            }
        }

        /// <inheritdoc />
        public async Task ProcessOutfittingFile(FileInfo outfittingFile)
        {
            if(outfittingFile == null || !outfittingFile.Exists) { return; }

            string content = ReadAllText(outfittingFile);
            if (!IsInCache(outfittingFile, content))
            {
                AddToCache(outfittingFile, content);
                OutfittingUpdated?.Invoke(this, content);
            }
        }

        private void AddToCache(FileInfo file, string content)
        {
            if (!_cache.ContainsKey(file.Name))
            {
                _cache.Add(file.Name, content);
            }
            else
            {
                _cache[file.Name] = content;
            }
        }

        private bool IsInCache(FileInfo file, string content)
        {
            return _cache.ContainsKey(file.Name) && _cache[file.Name] == content;
        }

        private IEnumerable<string> ReadAllLines(FileInfo file)
        {
            using FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000, FileOptions.RandomAccess);
            using StreamReader stream = new StreamReader(fs, Encoding.UTF8);

            string line;
            while ((line = stream.ReadLine()) != null)
            {
                yield return line;
            }
        }

        private string ReadAllText(FileInfo file) => string.Join(Environment.NewLine, ReadAllLines(file));
    }
}
