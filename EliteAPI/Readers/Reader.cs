using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EliteAPI.Abstractions.Readers;
using EliteAPI.Abstractions.Readers.Selectors;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Readers;

public class Reader : IReader
{
    private readonly ILogger<Reader>? _log;

    private readonly List<IFileSelector> _files = new();
    private readonly Dictionary<IFileSelector, Exception?> _fileErrors = new();
    private readonly Dictionary<string, string[]> _lastValues = new();

    public Reader(ILogger<Reader> log)
    {
        _log = log;
    }

    /// <inheritdoc />
    public IReadOnlyCollection<IFileSelector> Selectors => _files.AsReadOnly();

    /// <inheritdoc />
    public void Register(IFileSelector selector)
    {
        _log?.LogDebug("Registering file selector {File} for {Category}", selector.GetType().FullName, selector.Category.ToString());
        _files.Add(selector); 
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<Line> FindNew()
    {
        foreach (var fileSelector in _files.Where(x => x.IsApplicable))
        {
            FileInfo file;

            try
            {
                file = fileSelector.GetFile();
            }
            catch (Exception ex)
            {
                TryLogWarning(fileSelector, ex);
                continue;
            }

            if (!_lastValues.ContainsKey(file.FullName))
                _lastValues.Add(file.FullName, Array.Empty<string>());

            StreamReader? stream;

            try
            {
                stream = new StreamReader(file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            }
            catch (Exception ex)
            {
                TryLogWarning(fileSelector, ex);
                continue;
            }

            if (fileSelector.IsMultiLine)
            {
                var newValues = new List<string>();

                stream.BaseStream.Position = 0;
                while (!stream.EndOfStream)
                {
                    newValues.Add(await stream.ReadLineAsync());
                }

                // Yield all new values
                foreach (var value in newValues.Except(_lastValues[file.FullName]))
                {
                    _log?.LogTrace("{File}: {Json}", file.Name, value);
                    yield return new Line(file, fileSelector, value);
                }

                // Update last values
                _lastValues[file.FullName] = newValues.ToArray();
            }
            else
            {
                stream.BaseStream.Position = 0;
                var newValue = await stream.ReadToEndAsync();
                var lastValue = _lastValues[file.FullName].Length == 0 ? string.Empty : _lastValues[file.FullName][0];

                if (newValue != lastValue)
                {
                    _log?.LogTrace("{File}: {Json}", file.Name, newValue);

                    // Yield the new value
                    yield return new Line(file, fileSelector, newValue);

                    // Update last value
                    if(_lastValues[file.FullName].Length == 0)
                        _lastValues[file.FullName] = new[] { newValue };
                    else
                        _lastValues[file.FullName][0] = newValue;
                }
            }
        }
    }

    private void TryLogWarning(IFileSelector selector, Exception ex)
    {
        if (!_fileErrors.ContainsKey(selector))
            _fileErrors.Add(selector, null);
        
        if (_fileErrors[selector] == null || _fileErrors[selector]!.Message != ex.Message || _fileErrors[selector]!.InnerException?.Message != ex.InnerException?.Message)
        {
            switch (selector.Category)
            {
                case FileCategory.Events:
                    _log?.LogWarning(ex, "Could not query the Journal File for events");
                    break;
                case FileCategory.Status:
                    _log?.LogDebug(ex, "Could not query a status file");
                    break;
                case FileCategory.Bindings:
                    _log?.LogWarning(ex, "Could not query the Bindings file for keybindings");
                    break;
            }

            _fileErrors[selector] = ex;
        }
    }
}