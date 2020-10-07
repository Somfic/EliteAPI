using EliteAPI.Status.Models;
using EliteAPI.Status.Processor.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EliteAPI.Status.Models.Abstractions;

namespace EliteAPI.Status.Processor
{
    /// <inheritdoc />
    public class StatusProcessor : IStatusProcessor
    {
        private readonly ILogger<StatusProcessor> _log;
        private readonly IShipStatus _status;
        private readonly IDictionary<string, string> _cache;

        public StatusProcessor(ILogger<StatusProcessor> log, IShipStatus status)
        {
            _log = log;
            _status = status;
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
                await InvokeStatusMethods(content);
                StatusUpdated?.Invoke(this, content);
            }
        }

        private async Task InvokeStatusMethods(string json)
        {
            try
            {
                RawShipStatus raw = JsonConvert.DeserializeObject<RawShipStatus>(json);

                foreach (string propertyName in _status.GetType().GetProperties().Select(x => x.Name))
                {
                    await InvokeStatusUpdateMethod(raw, _status, propertyName);
                }
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not update status");
            }
        }

        private Task InvokeStatusUpdateMethod(RawShipStatus raw, IShipStatus status, string propertyName)
        {
            try
            {
                object rawValue = raw.GetType().GetProperty(propertyName).GetValue(raw);
                object statusUpdateProperty = _status.GetType().GetProperty(propertyName).GetValue(_status);
                MethodInfo updateMethod = statusUpdateProperty.GetType().GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);
                MethodInfo needsUpdateMethod = statusUpdateProperty.GetType().GetMethod("NeedsUpdate", BindingFlags.NonPublic | BindingFlags.Instance);

                var needsUpdate = needsUpdateMethod.Invoke(statusUpdateProperty, new[] {rawValue});
                if ((bool) needsUpdate)
                {
                    _log.LogTrace("Invoking OnChange event for {name} status", propertyName);
                    updateMethod.Invoke(statusUpdateProperty, new[] { this, rawValue });
                }
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not update status property {name}", propertyName);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task ProcessCargoFile(FileInfo cargoFile)
        {
            if (!cargoFile.Exists) { return Task.CompletedTask; }

            string content = ReadAllText(cargoFile);
            if (!IsInCache(cargoFile, content))
            {
                AddToCache(cargoFile, content);
                CargoUpdated?.Invoke(this, content);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task ProcessMarketFile(FileInfo marketFile)
        {
            if (marketFile == null || !marketFile.Exists) { return Task.CompletedTask; }

            string content = ReadAllText(marketFile);
            if (!IsInCache(marketFile, content))
            {
                AddToCache(marketFile, content);
                MarketUpdated?.Invoke(this, content);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task ProcessShipyardFile(FileInfo shipyardFile)
        {
            if (shipyardFile == null || !shipyardFile.Exists) { return Task.CompletedTask; }

            string content = ReadAllText(shipyardFile);
            if (!IsInCache(shipyardFile, content))
            {
                AddToCache(shipyardFile, content);
                ShipyardUpdated?.Invoke(this, content);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task ProcessOutfittingFile(FileInfo outfittingFile)
        {
            if (outfittingFile == null || !outfittingFile.Exists) { return Task.CompletedTask; }

            string content = ReadAllText(outfittingFile);
            if (!IsInCache(outfittingFile, content))
            {
                AddToCache(outfittingFile, content);
                OutfittingUpdated?.Invoke(this, content);
            }

            return Task.CompletedTask;
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
