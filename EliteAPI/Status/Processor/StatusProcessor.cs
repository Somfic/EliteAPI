using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Cargo.Abstractions;
using EliteAPI.Status.Cargo.Raw;
using EliteAPI.Status.NavRoute.Abstractions;
using EliteAPI.Status.NavRoute.Raw;
using EliteAPI.Status.Processor.Abstractions;
using EliteAPI.Status.Ship.Abstractions;
using EliteAPI.Status.Ship.Raw;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.Status.Processor
{
    /// <inheritdoc />
    public class StatusProcessor : IStatusProcessor
    {
        private readonly IDictionary<string, string> _cache;
        private readonly ILogger<StatusProcessor> _log;

        private readonly IShip _ship;
        private readonly INavRoute _navRoute;
        private readonly ICargo _cargo;

        public StatusProcessor(ILogger<StatusProcessor> log, IShip ship, INavRoute navRoute, ICargo cargo)
        {
            _log = log;
            _ship = ship;
            _navRoute = navRoute;
            _cargo = cargo;
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
        public event EventHandler<string> NavRouteUpdated;

        /// <inheritdoc />
        public async Task ProcessStatusFile(FileInfo statusFile)
        {
            if (!statusFile.Exists) return;

            var content = ReadAllText(statusFile);

            if (string.IsNullOrWhiteSpace(content))
            {
                _log.LogTrace("Skipping status processing due to empty Status.json file");
                return;
            }

            if (!IsInCache(statusFile, content))
            {
                AddToCache(statusFile, content);
                await InvokeMethods<RawShip>(content, _ship);
                StatusUpdated?.Invoke(this, content);
            }
        }

        /// <inheritdoc />
        public async Task ProcessCargoFile(FileInfo cargoFile)
        {
            if (!cargoFile.Exists) return;

            var content = ReadAllText(cargoFile);
            if (!IsInCache(cargoFile, content))
            {
                AddToCache(cargoFile, content);
                await InvokeMethods<RawCargo>(content, _cargo);
                CargoUpdated?.Invoke(this, content);
            }
        }

        /// <inheritdoc />
        public Task ProcessMarketFile(FileInfo marketFile)
        {
            if (marketFile == null || !marketFile.Exists) return Task.CompletedTask;

            var content = ReadAllText(marketFile);
            if (!IsInCache(marketFile, content))
            {
                AddToCache(marketFile, content);
                //await InvokeMarketMethods(content);
                MarketUpdated?.Invoke(this, content);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task ProcessShipyardFile(FileInfo shipyardFile)
        {
            if (shipyardFile == null || !shipyardFile.Exists) return Task.CompletedTask;

            var content = ReadAllText(shipyardFile);
            if (!IsInCache(shipyardFile, content))
            {
                AddToCache(shipyardFile, content);
                //await InvokeShipyardMethods(content);
                ShipyardUpdated?.Invoke(this, content);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task ProcessOutfittingFile(FileInfo outfittingFile)
        {
            if (outfittingFile == null || !outfittingFile.Exists) return Task.CompletedTask;

            var content = ReadAllText(outfittingFile);
            if (!IsInCache(outfittingFile, content))
            {
                AddToCache(outfittingFile, content);
                //await InvokeOutfittingMethods(content);
                OutfittingUpdated?.Invoke(this, content);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task ProcessNavRouteFile(FileInfo navRouteFile)
        {
            if (navRouteFile == null || !navRouteFile.Exists) return;

            var content = ReadAllText(navRouteFile);
            if (!IsInCache(navRouteFile, content))
            {
                AddToCache(navRouteFile, content);
                await InvokeMethods<RawNavRoute>(content, _navRoute);
                NavRouteUpdated?.Invoke(this, content);
            }
        }

        private async Task InvokeMethods<T>(string json, IStatus status)
        {
            string name = status.GetType().Name;

            try
            {
                var raw = JsonConvert.DeserializeObject<T>(json);

                foreach (var propertyName in status.GetType().GetProperties().Select(x => x.Name))
                    await InvokeUpdateMethod(raw, status, propertyName);

                status.TriggerOnChange();
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not update {name} status", name);
            }
        }

        private Task InvokeUpdateMethod(object raw, object clean, string propertyName)
        {
            string name = propertyName;

            try
            {
                name = $"{clean.GetType().Name}.{name}";

                var rawValue = raw.GetType().GetProperty(propertyName).GetValue(raw);
                var statusUpdateProperty = clean.GetType().GetProperty(propertyName).GetValue(clean);
                var updateMethod = statusUpdateProperty.GetType()
                    .GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);
                var needsUpdateMethod = statusUpdateProperty.GetType()
                    .GetMethod("NeedsUpdate", BindingFlags.NonPublic | BindingFlags.Instance);

                var needsUpdate = needsUpdateMethod.Invoke(statusUpdateProperty, new[] {rawValue});
                if ((bool) needsUpdate)
                {
                    _log.LogTrace("Invoking OnChange event for {name}", name, propertyName);
                    updateMethod.Invoke(statusUpdateProperty, new[] {this, rawValue});
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("PropertyName", propertyName);
                _log.LogWarning(ex, "Could not invoke OnChange for {name}", name, propertyName);
            }

            return Task.CompletedTask;
        }

        private void AddToCache(FileSystemInfo file, string content)
        {
            if (!_cache.ContainsKey(file.Name))
                _cache.Add(file.Name, content);
            else
                _cache[file.Name] = content;
        }

        private bool IsInCache(FileSystemInfo file, string content)
        {
            return _cache.ContainsKey(file.Name) && _cache[file.Name] == content;
        }

        private static IEnumerable<string> ReadAllLines(FileInfo file)
        {
            using var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000,
                FileOptions.RandomAccess);
            using var stream = new StreamReader(fs, Encoding.UTF8);

            string line;
            while ((line = stream.ReadLine()) != null) yield return line;
        }

        private static string ReadAllText(FileInfo file)
        {
            return string.Join(Environment.NewLine, ReadAllLines(file));
        }
    }
}