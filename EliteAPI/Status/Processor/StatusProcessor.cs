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
using EliteAPI.Status.Market.Abstractions;
using EliteAPI.Status.Market.Raw;
using EliteAPI.Status.Models.Abstractions;
using EliteAPI.Status.Modules.Abstractions;
using EliteAPI.Status.Modules.Raw;
using EliteAPI.Status.NavRoute.Abstractions;
using EliteAPI.Status.NavRoute.Raw;
using EliteAPI.Status.Outfitting.Abstractions;
using EliteAPI.Status.Outfitting.Raw;
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
        private readonly IShipStatus _status;
        private readonly INavRoute _navRoute;
        private readonly ICargo _cargo;
        private readonly IMarket _market;
        private readonly IModules _modules;
        private readonly IOutfitting _outfitting;

        public StatusProcessor(ILogger<StatusProcessor> log, IShip ship, INavRoute navRoute, ICargo cargo, IMarket market, IShipStatus status, IModules modules, IOutfitting outfitting)
        {
            _log = log;
            _ship = ship;
            _navRoute = navRoute;
            _cargo = cargo;
            _market = market;
            _status = status;
            _modules = modules;
            _outfitting = outfitting;
            _cache = new Dictionary<string, string>();
        }

        /// <inheritdoc />
        public event EventHandler<string> StatusUpdated;

        /// <inheritdoc />
        public event EventHandler<string> ModulesUpdated;

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
                await InvokeMethods<RawShip>(content, _status);
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
        public async Task ProcessModulesFile(FileInfo modulesFile)
        {
            if (!modulesFile.Exists) return;

            var content = ReadAllText(modulesFile);
            if (!IsInCache(modulesFile, content))
            {
                AddToCache(modulesFile, content);
                await InvokeMethods<RawModules>(content, _modules);
                ModulesUpdated?.Invoke(this, content);
            }
        }

        /// <inheritdoc />
        public async Task ProcessMarketFile(FileInfo marketFile)
        {
            if (marketFile == null || !marketFile.Exists) return;

            var content = ReadAllText(marketFile);
            if (!IsInCache(marketFile, content))
            {
                AddToCache(marketFile, content);
                await InvokeMethods<RawMarket>(content, _market);
                MarketUpdated?.Invoke(this, content);
            }
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
        public async Task ProcessOutfittingFile(FileInfo outfittingFile)
        {
            if (outfittingFile == null || !outfittingFile.Exists) return;

            var content = ReadAllText(outfittingFile);
            if (!IsInCache(outfittingFile, content))
            {
                AddToCache(outfittingFile, content);
                await InvokeMethods<RawOutfitting>(content, _outfitting);
                OutfittingUpdated?.Invoke(this, content);
            }
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

                string value = rawValue.ToString();
                if(Type.GetTypeCode(rawValue.GetType()) == TypeCode.Object)
                {
                    value = JsonConvert.SerializeObject(rawValue);
                }

                var statusUpdateProperty = clean.GetType().GetProperty(propertyName).GetValue(clean);
                var updateMethod = statusUpdateProperty.GetType()
                    .GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);
                var needsUpdateMethod = statusUpdateProperty.GetType()
                    .GetMethod("NeedsUpdate", BindingFlags.NonPublic | BindingFlags.Instance);

                var needsUpdate = needsUpdateMethod.Invoke(statusUpdateProperty, new[] {rawValue});
                if ((bool) needsUpdate)
                {
                    _log.LogTrace("Invoking OnChange event for {name} ({value})", name, value);
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