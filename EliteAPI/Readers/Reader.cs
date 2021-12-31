using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EliteAPI.Abstractions.Readers;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Readers;

public class Reader : IReader
{
    private readonly ILogger<Reader>? _log;

    private IList<FileSelector> _files = new List<FileSelector>();
    private Dictionary<string, string[]> _lastValues = new();

    public Reader(ILogger<Reader> log)
    {
        _log = log;
    }

    public void Register(FileSelector selector)
    {
        _files.Add(selector);
    }
    
    public async IAsyncEnumerable<string?> FindNew()
    {
        foreach (var fileSelector in _files)
        {
            var file = fileSelector.Directory.GetFiles(fileSelector.FilePattern).OrderByDescending(x => x.LastWriteTime).FirstOrDefault();
            if (file == null)
            {
                _log?.LogWarning("No files found matching {Pattern} in {Directory}", fileSelector.FilePattern, fileSelector.Directory.FullName);
                _files.Remove(fileSelector);
                continue;
            }
            
            if(!_lastValues.ContainsKey(file.FullName))
                _lastValues.Add(file.FullName, Array.Empty<string>());

            StreamReader stream = null;

            try
            {
                stream = new StreamReader(file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            }
            catch (Exception ex)
            {
                _log?.LogWarning(ex, "Could not open file {File}", file.FullName);
                continue;
            }

            if (fileSelector.ContainsMultipleEntries)
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
                    yield return value;
                }
                
                // Update last values
                _lastValues[file.FullName] = newValues.ToArray();
            } 
            else
            {
                stream.BaseStream.Position = 0;
                var newValue = await stream.ReadToEndAsync() ?? string.Empty;
                var lastValue = string.Join(Environment.NewLine, _lastValues[file.FullName]!);

                if (newValue != lastValue)
                {
                    _log?.LogTrace("{File}: {Json}", file.Name, newValue);
                    yield return newValue;
                }
            }
        }
    }
}