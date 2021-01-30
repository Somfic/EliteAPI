using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

using EliteAPI.Options.Bindings.Models;
using EliteAPI.Options.Processor.Abstractions;
using EliteAPI.Services.FileReader.Abstractions;

using Microsoft.Extensions.Logging;

namespace EliteAPI.Options.Processor
{
    /// <inheritdoc />
    public class OptionsProcessor : IOptionsProcessor
    {
        private readonly IDictionary<string, string> _cache;
        private readonly ILogger<OptionsProcessor> _log;
        private readonly IBindings _bindings;
        private readonly IFileReader _fileReader;

        public OptionsProcessor(ILogger<OptionsProcessor> log, IBindings bindings, IFileReader fileReader)
        {
            _log = log;
            _bindings = bindings;
            _fileReader = fileReader;

            _cache = new ConcurrentDictionary<string, string>();
        }

        /// <inheritdoc />
        public event EventHandler<string> BindingsUpdated;

        /// <inheritdoc />
        public async Task ProcessBindingsFile(FileInfo bindingsFile)
        {
            if (bindingsFile == null || !bindingsFile.Exists) { return; }

            var content = _fileReader.ReadAllText(bindingsFile);
            if (!IsInCache(bindingsFile, content))
            {
                AddToCache(bindingsFile, content);

                XmlSerializer serializer = new XmlSerializer(typeof(KeyBindings));

                using (StringReader reader = new StringReader(content))
                {
                    _bindings.Active = (KeyBindings) serializer.Deserialize(reader);
                    _bindings.TriggerOnChange();
                }

                BindingsUpdated?.Invoke(this, content);
            }

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
    }
}